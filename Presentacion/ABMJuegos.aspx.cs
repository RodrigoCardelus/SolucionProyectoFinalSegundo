using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Configuration;
using System.Data;
using System.Xml;

public partial class ABMJuegos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();

                RefWCF.Juegos unj = (RefWCF.Juegos)Session["Juego"];   
               
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
        btnBuscar.Enabled = true;

        txtCodigo.Enabled = true;

    }

    private void ActivoBotonesA()
    {

        btnAgregar.Enabled = true;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = false;


        txtCodigo.Enabled = true;

    }
    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodigo.Enabled = true;
        txtCodigo.Text = "";
        txtDificultad.Text = " ";
        lblError.Text = "";
    }

    
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        RefWCF.Juegos unJ = null;

        RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];

        try
        {

            unJ = new RefWCF.Juegos()
            {
                Codigo = 0,
                UnUsuario = unUsu,
                Dificultad = txtDificultad.Text.Trim(),
                ListadoPreguntas = null
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new RefWCF.ServicioClient().AgregarJuegos(unJ, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";

            txtCodigo.Text = "";
            txtDificultad.Text = "";

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
            RefWCF.Juegos unJ = (RefWCF.Juegos)Session["Juego"];

            new RefWCF.ServicioClient().EliminarJuegos(unJ,(RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Baja con Exito";

            txtCodigo.Text = "";
            txtDificultad.Text = "";

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
            RefWCF.Juegos unJ = (RefWCF.Juegos)Session["Juego"];
            unJ.Dificultad = txtDificultad.Text.Trim();

            //ejecuto operacion de actualizar en bd
            new RefWCF.ServicioClient().ModificarJuegos(unJ, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtCodigo.Text = "";
            txtDificultad.Text = "";


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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int Codigo = Convert.ToInt32(txtCodigo.Text.Trim());

       
        RefWCF.Usuario pLogueo = null;

        //busco Juegos
        RefWCF.Juegos unJ = new RefWCF.ServicioClient().BuscarJuegos(Convert.ToInt32(txtCodigo.Text.Trim()), pLogueo);

        try
        {
            if (unJ == null)
            {
                this.ActivoBotonesA();
                lblError.Text = " No se ha encontrado Juego " + Codigo;
            }
            else
            {
              
                this.ActivoBotonesBM();
                txtDificultad.Text = unJ.Dificultad;
                Session["Juego"] = unJ;
                List<RefWCF.Preguntas> ListadoPreguntas = new List<RefWCF.Preguntas>();

                lblError.Text = "El Juego con el usuario de logueo es : " + unJ.UnUsuario.UsuarioLog + " . ";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

   
       
}