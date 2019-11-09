using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dinamizate
{
    public partial class Reserva : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\Usuario;Initial Catalog=Dinamizate;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * From dinamizate.bicicleta WHERE Disponible = 1", sqlCon);
                    DataTable dt = new DataTable();
                    List<String> bicis = new List<string>();

                    sqlDA.Fill(dt);
                    sqlCon.Close();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bicis.Add(((String)dt.Rows[i]["idBicicleta"].ToString()) + "-" + ((String)dt.Rows[i]["Marca"]));
                    }
                    Bicicleta.DataSource = bicis;
                    Bicicleta.DataBind();
                }
            }
        }

        protected void Reservar_Click(object sender, EventArgs e)
        {
            DateTime fechaReserva = DateTime.Parse(Fecha.Text.Trim() + " " + Hora.Text.Trim() + ":" + Minuto.Text.Trim() + ":00");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("VerMultas", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.AddWithValue("@Cedula", int.Parse((String)Session["usuario"]));
            sqlCmd.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sqlCmd.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('No se pudo realizar la reserva debido a que hay multas activas');</script>");
            }
            else {
                if (fechaReserva.Subtract(DateTime.Now).TotalHours <= 2)
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('No se pudo realizar la reserva debido a que debe haber un intervalo de 2 horas entre reserva y prestamo');</script>");
                }
                else {
                    sqlCmd = new SqlDataAdapter("verReservas", sqlCon);
                    sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlCmd.SelectCommand.Parameters.AddWithValue("@Cedula", int.Parse((String)Session["usuario"]));
                    sqlCmd.SelectCommand.ExecuteNonQuery();
                    dt = new DataTable();
                    sqlCmd.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("verRetornos", sqlCon);
                            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlCmd2.SelectCommand.Parameters.AddWithValue("@IdReserva", dt.Rows[i]["idReserva"]);
                            sqlCmd2.SelectCommand.ExecuteNonQuery();
                            DataTable dt2 = new DataTable();
                            sqlCmd2.Fill(dt2);
                            if (dt2.Rows.Count == 0)
                            {
                                System.Web.HttpContext.Current.Response.Write("<script>alert('No se pudo realizar la reserva debido a que hay un prestamo activo');</script>");
                            }
                            else
                            {
                                if (sqlCon.State == ConnectionState.Closed)
                                    sqlCon.Open();
                                SqlCommand sqlCmd3 = new SqlCommand("CrearReserva", sqlCon);
                                sqlCmd3.CommandType = CommandType.StoredProcedure;
                                sqlCmd3.Parameters.AddWithValue("@Fecha", fechaReserva);
                                sqlCmd3.Parameters.AddWithValue("@IdBicicleta", int.Parse(Bicicleta.Text.Split('-')[0].Trim()));
                                sqlCmd3.Parameters.AddWithValue("@CedulaU", int.Parse((String)Session["usuario"]));
                                sqlCmd3.ExecuteNonQuery();
                                SqlCommand sqlCmd4 = new SqlCommand("UPDATE dinamizate.bicicleta SET Disponible = 0 WHERE idBicicleta =" + int.Parse(Bicicleta.Text.Split('-')[0].Trim()), sqlCon);
                                sqlCon.Close();
                                System.Web.HttpContext.Current.Response.Write("<script>alert('Reserva realizada con éxito');</script>");
                                Session["usuario"] = null;
                                Response.Redirect("Default.aspx");
                            }
                        }
                    }
                    else
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        SqlCommand sqlCmd3 = new SqlCommand("CrearReserva", sqlCon);
                        sqlCmd3.CommandType = CommandType.StoredProcedure;
                        sqlCmd3.Parameters.AddWithValue("@Fecha", fechaReserva);
                        sqlCmd3.Parameters.AddWithValue("@IdBicicleta", int.Parse(Bicicleta.Text.Split('-')[0].Trim()));
                        sqlCmd3.Parameters.AddWithValue("@CedulaU", int.Parse((String)Session["usuario"]));
                        sqlCmd3.ExecuteNonQuery();
                        SqlCommand sqlCmd4 = new SqlCommand("UPDATE dinamizate.bicicleta SET Disponible = 0 WHERE idBicicleta =" + int.Parse(Bicicleta.Text.Split('-')[0].Trim()), sqlCon);
                        sqlCon.Close();
                        System.Web.HttpContext.Current.Response.Write("<script>alert('Reserva realizada con éxito');</script>");
                        Session["usuario"] = null;
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }

        protected void Salir_Click1(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}