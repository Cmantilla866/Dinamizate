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
    public partial class _Default : Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\Usuario;Initial Catalog=Dinamizate;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("Login", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.AddWithValue("@Cedula", CedulaI.Text.Trim());
            sqlCmd.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sqlCmd.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                string pass = (string)dt.Rows[0]["Contraseña"];
                if (pass.Equals(ContraseñaI.Text.Trim()))
                {
                    Session["usuario"] = CedulaI.Text.Trim();
                    Response.Redirect("Reserva.aspx");
                }
            }
            else {
                sqlCmd = new SqlDataAdapter("LoginF", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@Cedula", CedulaI.Text.Trim());
                sqlCmd.SelectCommand.ExecuteNonQuery();
                dt = new DataTable();
                sqlCmd.Fill(dt);
                if (dt.Rows.Count == 1) {
                    string pass = (string)dt.Rows[0]["Contraseña"];
                    if (pass.Equals(ContraseñaI.Text.Trim()))
                    {
                        Session["funcionario"] = CedulaI.Text.Trim();
                        Response.Redirect("MainMenu.aspx");
                    }
                }
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Registro", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@CedulaU", int.Parse(CedulaR.Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@NombreU", Nombre.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@CiudadU", Ciudad.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@DireccionU", Direccion.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@CelularU", int.Parse(Celular.Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@FijoU", int.Parse(Fijo.Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@ContraseñaU", ContraseñaR.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@CedulaF", int.Parse(CedulaF.Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@NombreF", NombreF.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@TelefonoF", int.Parse(NumeroF.Text.Trim()));
            sqlCmd.Parameters.AddWithValue("@ParentescoF", Parentesco.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }
    }

}