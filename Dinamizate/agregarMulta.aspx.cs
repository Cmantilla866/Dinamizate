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
    public partial class agregarMulta : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\Usuario;Initial Catalog=Dinamizate;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["funcionario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            }

        protected void Multar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CrearMulta", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@IdRetorno", Session["retorno"]);
            sqlCmd.Parameters.AddWithValue("@CedulaF", Session["funcionario"]);
            sqlCmd.Parameters.AddWithValue("@Causa", Causa.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Valor", Valor.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@CedulaU", Session["usuario"]);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            System.Web.HttpContext.Current.Response.Write("<script>alert('Multa creada');</script>");
            Response.Redirect("MainMenu.aspx");
        }
    }
}