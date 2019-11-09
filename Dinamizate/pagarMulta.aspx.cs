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
    public partial class pagarMulta : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\Usuario;Initial Catalog=Dinamizate;Integrated Security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["funcionario"]==null) {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            if (R.SelectedValue!= null) {
                SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT * FROM dinamizate.multa WHERE idMulta = " + (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
                sqlCmd.SelectCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();
                sqlCmd.Fill(dt);
                Causa.Text = (String)dt.Rows[0]["Causa"];
                Valor.Text = (String)dt.Rows[0]["Valor"];
            }
            
        }

        protected void Pagar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd3 = new SqlCommand("DELETE FROM dinamizate.multa WHERE idMulta = "+ (R.SelectedValue.Split('-'))[0].Trim(), sqlCon);
            sqlCmd3.ExecuteNonQuery();
            sqlCon.Close();
            System.Web.HttpContext.Current.Response.Write("<script>alert('Multa pagada');</script>");
            Response.Redirect("MainMenu.aspx");
        }

        protected void CedulaU_TextChanged(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("VerMultas", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.AddWithValue("@Cedula", int.Parse(CedulaU.Text.Trim()));
            sqlCmd.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sqlCmd.Fill(dt);
            List<String> Multas = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Multas.Add(((String)dt.Rows[i]["idMulta"].ToString()) + "-" + ((String)dt.Rows[i]["Causa"].ToString()) + "-" + ((String)dt.Rows[i]["Valor"].ToString()));
            }
            R.DataSource = Multas;
            R.DataBind();
        }
    }
}