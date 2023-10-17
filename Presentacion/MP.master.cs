using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class MP : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    if (!(Session["Usuario"] is RefWCF.Usuario))
                        Response.Redirect("~Default.aspx");

                    RefWCF.Usuario unUsuario = (RefWCF.Usuario)Session["Usuario"];
                    lblUsuarioLogueado.Text = unUsuario.UsuarioLog;

                }

            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void Menu_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}
