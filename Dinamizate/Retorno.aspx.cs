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
    public partial class Retorno : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\Usuario;Initial Catalog=Dinamizate;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["funcionario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT * FROM dinamizate.reserva", sqlCon);
                    sqlCmd.SelectCommand.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    sqlCmd.Fill(dt);
                    List<String> Reservas = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlDataAdapter sqlCmd2 = new SqlDataAdapter("verPrestamos", sqlCon);
                        sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlCmd2.SelectCommand.Parameters.AddWithValue("@IdReserva", dt.Rows[i]["idReserva"]);
                        sqlCmd2.SelectCommand.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        sqlCmd2.Fill(dt2);
                        if (dt2.Rows.Count == 1)
                        {
                            sqlCmd2 = new SqlDataAdapter("verRetornos", sqlCon);
                            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlCmd2.SelectCommand.Parameters.AddWithValue("@IdReserva", dt.Rows[i]["idReserva"]);
                            sqlCmd2.SelectCommand.ExecuteNonQuery();
                            DataTable dt3 = new DataTable();
                            sqlCmd2.Fill(dt3);
                            if (dt3.Rows.Count == 0)
                            {
                                Reservas.Add(((String)dt.Rows[i]["idReserva"].ToString()) + "-" + ((String)dt.Rows[i]["Usuario_Cedula"].ToString()));
                            }
                        }

                    }
                    sqlCon.Close();
                    R.DataSource = Reservas;
                    R.DataBind();
                }
            }
        }

        protected void Retornar_Click(object sender, EventArgs e)
        {
            DateTime fechaR = DateTime.Parse(FechaRetorno.Text.Trim() + " " + HoraRetorno.Text.Trim() + ":" + MinutoRetorno.Text.Trim() + ":00");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd3 = new SqlCommand("CrearRetorno", sqlCon);
            sqlCmd3.CommandType = CommandType.StoredProcedure;
            sqlCmd3.Parameters.AddWithValue("@IdPrestamo", (R.SelectedValue.Split('-'))[0].Trim());
            sqlCmd3.Parameters.AddWithValue("@CedulaF", Session["funcionario"]);
            sqlCmd3.Parameters.AddWithValue("@FechaRetorno", fechaR);
            sqlCmd3.Parameters.AddWithValue("@EstadoBici", Estado.Text.Trim());
            sqlCmd3.Parameters.AddWithValue("@Observaciones", Observaciones.Text.Trim());
            sqlCmd3.ExecuteNonQuery();
            sqlCon.Close();
            aplicarMulta();
            
            System.Web.HttpContext.Current.Response.Write("<script>alert('Retorno realizado con éxito');</script>");
            Response.Redirect("MainMenu.aspx");
        }

        protected void aplicarMulta() {
            DateTime fechaR = DateTime.Parse(FechaRetorno.Text.Trim() + " " + HoraRetorno.Text.Trim() + ":" + MinutoRetorno.Text.Trim() + ":00");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT * FROM dinamizate.prestamo WHERE Reserva_idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sqlCmd.Fill(dt);
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("SELECT * FROM dinamizate.reserva WHERE idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd2.SelectCommand.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            sqlCmd2.Fill(dt2);
            SqlDataAdapter sqlCmd3 = new SqlDataAdapter("SELECT * FROM dinamizate.retorno WHERE Prestamo_Reserva_idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd3.SelectCommand.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            sqlCmd3.Fill(dt3);

            SqlCommand sqlCmd5 = new SqlCommand("CrearPunto", sqlCon);
            sqlCmd5.CommandType = CommandType.StoredProcedure;
            sqlCmd5.Parameters.AddWithValue("@CedulaU", dt2.Rows[0]["Usuario_Cedula"]);
            sqlCmd5.Parameters.AddWithValue("@CedulaF", Session["funcionario"]);
            sqlCmd5.Parameters.AddWithValue("@Fecha", fechaR);
            sqlCmd5.Parameters.AddWithValue("@Razon", "Uso");
            sqlCmd5.ExecuteNonQuery();

            DateTime fechaE = (DateTime)dt.Rows[0]["FechaEntrega"];
            if (fechaR.Subtract(fechaE).TotalMinutes >= 15) {
                SqlCommand sqlCmd4 = new SqlCommand("CrearMulta", sqlCon);
                sqlCmd4.CommandType = CommandType.StoredProcedure;
                sqlCmd4.Parameters.AddWithValue("@IdRetorno", dt3.Rows[0]["idRetorno"]);
                sqlCmd4.Parameters.AddWithValue("@CedulaF", Session["funcionario"]);
                sqlCmd4.Parameters.AddWithValue("@Causa", "Entrega tardía");
                sqlCmd4.Parameters.AddWithValue("@Valor", "1500");
                sqlCmd4.Parameters.AddWithValue("@CedulaU", dt2.Rows[0]["Usuario_Cedula"]);
                sqlCmd4.ExecuteNonQuery();
                SqlCommand sqlCmd6 = new SqlCommand("Delete FROM dbo.Puntos WHERE Usuario_Cedula = " + dt2.Rows[0]["Usuario_Cedula"], sqlCon);
                sqlCmd6.ExecuteNonQuery();
            }
        }

        protected void RMulta_Click(object sender, EventArgs e)
        {
            DateTime fechaR = DateTime.Parse(FechaRetorno.Text.Trim() + " " + HoraRetorno.Text.Trim() + ":" + MinutoRetorno.Text.Trim() + ":00");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CrearRetorno", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@IdPrestamo", (R.SelectedValue.Split('-'))[0].Trim());
            sqlCmd.Parameters.AddWithValue("@CedulaF", Session["funcionario"]);
            sqlCmd.Parameters.AddWithValue("@FechaRetorno", fechaR);
            sqlCmd.Parameters.AddWithValue("@EstadoBici", Estado.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Observaciones", Observaciones.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            aplicarMulta();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("SELECT * FROM dinamizate.reserva WHERE idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd2.SelectCommand.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            sqlCmd2.Fill(dt2);
            SqlDataAdapter sqlCmd3 = new SqlDataAdapter("SELECT * FROM dinamizate.retorno WHERE Prestamo_Reserva_idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd3.SelectCommand.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            sqlCmd3.Fill(dt3);
            Session["retorno"] = dt3.Rows[0]["idRetorno"];
            Session["usuario"] = dt2.Rows[0]["Usuario_Cedula"];
            SqlCommand sqlCmd4 = new SqlCommand("Delete FROM dbo.Puntos WHERE Usuario_Cedula = "+ dt2.Rows[0]["Usuario_Cedula"], sqlCon);
            sqlCmd4.ExecuteNonQuery();
            Response.Redirect("agregarMulta.aspx");
        }

        protected void RPuntos_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT * FROM dinamizate.reserva WHERE idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sqlCmd.Fill(dt);
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("SELECT * FROM dbo.Puntos WHERE Usuario_Cedula = " + dt.Rows[0]["Usuario_Cedula"], sqlCon);
            sqlCmd2.SelectCommand.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            sqlCmd2.Fill(dt2);
            if (dt2.Rows.Count >= 20)
            {
                DateTime fechaR = DateTime.Parse(FechaRetorno.Text.Trim() + " " + HoraRetorno.Text.Trim() + ":" + MinutoRetorno.Text.Trim() + ":00");
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd3 = new SqlCommand("CrearRetorno", sqlCon);
                sqlCmd3.CommandType = CommandType.StoredProcedure;
                sqlCmd3.Parameters.AddWithValue("@IdPrestamo", (R.SelectedValue.Split('-'))[0].Trim());
                sqlCmd3.Parameters.AddWithValue("@CedulaF", Session["funcionario"]);
                sqlCmd3.Parameters.AddWithValue("@FechaRetorno", fechaR);
                sqlCmd3.Parameters.AddWithValue("@EstadoBici", Estado.Text.Trim());
                sqlCmd3.Parameters.AddWithValue("@Observaciones", Observaciones.Text.Trim());
                sqlCmd3.ExecuteNonQuery();
                sqlCon.Close();
                aplicarMulta();
                SqlCommand sqlCmd4 = new SqlCommand("Delete FROM dbo.Puntos WHERE Usuario_Cedula = " + dt.Rows[0]["Usuario_Cedula"], sqlCon);
                sqlCmd4.ExecuteNonQuery();
                System.Web.HttpContext.Current.Response.Write("<script>alert('Retorno con puntos realizado con éxito');</script>");
                Response.Redirect("MainMenu.aspx");
            }
            else {
                System.Web.HttpContext.Current.Response.Write("<script>alert('El usuario no tiene suficientes puntos');</script>");
            }
        }
    }
}