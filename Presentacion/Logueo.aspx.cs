using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Xml;


public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();
                RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];

            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
    private void LimpioFormulario()
    {

        txtUsuarioLogueo.Text = " ";
        txtContraseña.Text = "";
        lblError.Text = "";

    }

    protected void btnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico usuario
            RefWCF.Usuario unUsu = new RefWCF.ServicioClient().LogueoUsuario(txtUsuarioLogueo.Text.Trim(), txtContraseña.Text.Trim());
            if (unUsu != null)
            {
                //si llego aca es pq es valido
                Session["Usuario"] = unUsu;
                lblError.Text = "Logueo Correcto";
                Response.Redirect("~/Principal.aspx");
            }
            else
                lblError.Text = "Datos Incorrectos";

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

}
