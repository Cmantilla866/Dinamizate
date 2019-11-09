using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dinamizate
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["funcionario"]==null) {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Prestamo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prestamo.aspx");
        }

        protected void Retorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Retorno.aspx");
        }

        protected void Pagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pagarMulta.aspx");
        }

        protected void Salir_Click(object sender, EventArgs e)
        {
            Session["funcionario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}