using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMCategorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();

                RefWCF.Categorias unaC = (RefWCF.Categorias)Session["Categorias"];

                RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }


    }
    private void ActivoBotonesA()
    {
     
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtCodigoC.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigoC.Enabled = true;
    }

    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        btnBuscar.Enabled = true;


        txtCodigoC.Enabled = true;

    }
    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodigoC.Enabled = true;
        txtCodigoC.Text = "";
        txtNombre.Text = "";
        lblError.Text = "";

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string CodigoC = txtCodigoC.Text.Trim();


        RefWCF.Usuario pLogueo = null;
        //busco
        RefWCF.Categorias unaC = new RefWCF.ServicioClient().BuscarCategoriasActivo(CodigoC, pLogueo);

        try
        {
            if (unaC == null)
            {
                this.ActivoBotonesA();
                lblError.Text = " No se ha encontrado el usuario Logueo " + CodigoC;
            }
            else
            {
                this.ActivoBotonesBM();
                txtCodigoC.Text = unaC.CodigoC;
                txtNombre.Text = unaC.Nombre;
                Session["Categoria"] = unaC;
                lblError.Text = "El Codigo de la Categorias es: " + unaC.CodigoC + " . ";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        RefWCF.Categorias unaC = null;

        try
        {
            unaC = new RefWCF.Categorias()
            {
                CodigoC = txtCodigoC.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
             
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new RefWCF.ServicioClient().AgregarCategorias(unaC, (RefWCF.Usuario)Session["Usuario"]);
           

            //Si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";

            txtNombre.Text = "";
            txtCodigoC.Text = "";
            txtNombre.Text = "";

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

            RefWCF.Categorias unaC = (RefWCF.Categorias)Session["Categoria"];
            new RefWCF.ServicioClient().EliminarCategorias(unaC, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Baja con Exito";

        
            txtCodigoC.Text = "";
            txtNombre.Text = "";
        

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

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {

            RefWCF.Categorias unaC = (RefWCF.Categorias)Session["Categoria"];
            unaC.Nombre = txtNombre.Text.Trim();


            //ejecuto operacion de actualizar en bd
            new RefWCF.ServicioClient().ModificarCategorias(unaC, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtCodigoC.Text = "";
            txtNombre.Text = "";
        

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
}