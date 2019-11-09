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
    public partial class Prestamo : System.Web.UI.Page
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
                        if (dt2.Rows.Count == 0)
                        {
                            Reservas.Add(((String)dt.Rows[i]["idReserva"].ToString()) + "-" + ((String)dt.Rows[i]["Usuario_Cedula"].ToString()));
                        }

                    }
                    sqlCon.Close();
                    R.DataSource = Reservas;
                    R.DataBind();
                }
            }
        }


        protected void Actualizar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT * FROM dinamizate.reserva WHERE idReserva = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sqlCmd.Fill(dt);
            FechaPrestamo.Text = ((DateTime)dt.Rows[0]["Fecha"]).Day.ToString() + "/"+ ((DateTime)dt.Rows[0]["Fecha"]).Month.ToString() + "/" + ((DateTime)dt.Rows[0]["Fecha"]).Year.ToString();
            HoraPrestamo.SelectedValue = ((DateTime)dt.Rows[0]["Fecha"]).Hour.ToString();
            MinutoPrestamo.SelectedValue = ((DateTime)dt.Rows[0]["Fecha"]).Minute.ToString();
            FechaPrestamo.DataBind();
            HoraPrestamo.DataBind();
            MinutoPrestamo.DataBind();
        }

        protected void Prestar_Click(object sender, EventArgs e)
        {
            DateTime fechaP = DateTime.Parse(FechaPrestamo.Text.Trim() + " " + HoraPrestamo.Text.Trim() + ":" + MinutoPrestamo.Text.Trim() + ":00");
            DateTime fechaE = DateTime.Parse(FechaEstimada.Text.Trim() + " " + HoraEstimada.Text.Trim() + ":" + MinutoEstimado.Text.Trim() + ":00");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd3 = new SqlCommand("CrearPrestamo", sqlCon);
            sqlCmd3.CommandType = CommandType.StoredProcedure;
            sqlCmd3.Parameters.AddWithValue("@IdReserva", (R.SelectedValue.Split('-'))[0].Trim());
            sqlCmd3.Parameters.AddWithValue("@FechaPrestamo", fechaP);
            sqlCmd3.Parameters.AddWithValue("@FechaEntrega", fechaE);
            sqlCmd3.Parameters.AddWithValue("@Observaciones", Observaciones.Text.Trim());
            sqlCmd3.Parameters.AddWithValue("@CedulaF", int.Parse((String)Session["funcionario"]));
            sqlCmd3.ExecuteNonQuery();
            sqlCon.Close();
            System.Web.HttpContext.Current.Response.Write("<script>alert('Prestamo realizado con éxito');</script>");
            Response.Redirect("MainMenu.aspx");
        }
    }
}