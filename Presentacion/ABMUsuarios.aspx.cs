using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Configuration;
using System.Data;
using System.Xml;

public partial class ABMUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();

                RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];

                RefWCF.Usuario unUsuActual = (RefWCF.Usuario)Session["UsuarioActual"];
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        btnBuscar.Enabled = false;
      

        txtUsuarioLogueo.Enabled = false;

    }

    private void ActivoBotonesA()
    {
        btnAgregar.Enabled = true;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = false;
        txtUsuarioLogueo.Enabled = true;

    }
    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;
        txtUsuarioLogueo.Enabled = true;
        txtUsuarioLogueo.Text = "";
        txtContraseña.Text = "";
        txtNombreCompleto.Text = " ";
        lblError.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string UsuarioLog = txtUsuarioLogueo.Text.Trim();

        RefWCF.Usuario pLogueo = null;
        
        RefWCF.Usuario unUsu = new RefWCF.ServicioClient().BuscarUsuario(txtUsuarioLogueo.Text.Trim(), pLogueo);
        Session["UsuarioActual"] = unUsu;

        try
        {
            if (unUsu == null)
            {
                this.ActivoBotonesA();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                lblError.Text = " No se ha encontrado el usuario Logueo " + UsuarioLog;
            }
            else
            {
                this.ActivoBotonesBM();
                txtUsuarioLogueo.Text = unUsu.UsuarioLog;
                txtContraseña.Text = unUsu.Contraseña;
                txtNombreCompleto.Text = unUsu.NombreC;
                lblError.Text = "El Nombre del Usuario con el usuario buscado es : " + unUsu.UsuarioLog + " . ";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }


    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        RefWCF.Usuario unUsu = null;

        try
        {
            unUsu = new RefWCF.Usuario()
            {
                UsuarioLog = txtUsuarioLogueo.Text.Trim(),
                Contraseña = txtContraseña.Text.Trim(),
                NombreC = txtNombreCompleto.Text.Trim()
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new RefWCF.ServicioClient().AgregarUsuario(unUsu, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";

            txtUsuarioLogueo.Text = "";
            txtContraseña.Text = "";
            txtNombreCompleto.Text = "";

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {

            //obtengo objeto, y lo modifico. 
            RefWCF.Usuario unUsuActual = (RefWCF.Usuario)Session["UsuarioActual"];
            unUsuActual.Contraseña = txtContraseña.Text.Trim();
            unUsuActual.NombreC = txtNombreCompleto.Text.Trim();

            //ejecuto operacion de actualizar en bd
            new RefWCF.ServicioClient().ModificarUsuario(unUsuActual, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtUsuarioLogueo.Text = "";
            txtContraseña.Text = "";
            txtNombreCompleto.Text = "";
        

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            

            RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];

            new RefWCF.ServicioClient().EliminarUsuario(unUsu, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Baja con Exito";

            txtUsuarioLogueo.Text = "";
            txtContraseña.Text = "";
            txtUsuarioLogueo.Text = "";

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}