using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class ManejoPreguntasdeUnJuego : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                RefWCF.Usuario unUsuario = (RefWCF.Usuario)Session["Usuario"];

                this.LimpioFormulario();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    private void ActivoBotonesBM()
    {

        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtCodigo.Enabled = false;

    }

    private void ActivoBotonesA()
    {
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtCodigo.Enabled = true;

    }
    private void LimpioFormulario()
    {
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = true;
        txtCodigo.Enabled = true;
        txtCodigo.Text = "";
        txtUsuarioLogueo.Text = "";
        txtDificultad.Text = "";
        txtCodigoP.Text = "";
        GVPreguntas = null;
        lblError.Text = "";
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
 
        int Codigo = Convert.ToInt32(txtCodigo.Text.Trim());

        RefWCF.Usuario pLogueo = null;

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

                Session["Juegos"] = unJ;
                this.ActivoBotonesBM();
                txtUsuarioLogueo.Text = unJ.UnUsuario.UsuarioLog;
                txtDificultad.Text = unJ.Dificultad;
                List<RefWCF.Preguntas> ListadoPreguntas = new List<RefWCF.Preguntas>();
                GVPreguntas.DataSource = unJ.ListadoPreguntas.ToList();
                GVPreguntas.DataBind();
                Session["ListadoPreguntas"] = unJ.ListadoPreguntas.ToList();
                lblError.Text = "El Juego con el usuario de logueo es : " + unJ.UnUsuario.UsuarioLog + " . ";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        RefWCF.Preguntas unaP;
        RefWCF.Juegos unJ;

        try
        {
           
           

            string CodigoP = txtCodigoP.Text.Trim();
            unaP= new RefWCF.ServicioClient().BuscarPreguntas(CodigoP, (RefWCF.Usuario)Session["Usuario"]);
            unJ = (RefWCF.Juegos)Session["Juegos"];

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            
            //agrego las Preguntas de un Juego
            new RefWCF.ServicioClient().AgregarPreguntasdeUnJuego(unaP, unJ, (RefWCF.Usuario)Session["Usuario"]);

            lblError.Text = "Alta con Exito";

            //dejo pronto Pregunta
            txtCodigo.Text = "";
            txtUsuarioLogueo.Text = "";
            txtDificultad.Text = "";

            List<RefWCF.Preguntas> ListadoPreguntas = new List<RefWCF.Preguntas>();

            ListadoPreguntas = (List<RefWCF.Preguntas>)Session["ListadoPreguntas"];
            unJ = new RefWCF.ServicioClient().BuscarJuegos(unJ.Codigo, (RefWCF.Usuario)Session["Usuario"]);

            GVPreguntas.DataSource = unJ.ListadoPreguntas.ToList();
            GVPreguntas.DataBind();

            btnAgregar.Enabled = false;

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







    protected void GVPreguntas_SelectedIndexChanged1(object sender, EventArgs e)
    {

        RefWCF.Juegos unJ;
        RefWCF.Preguntas unaP;

        unJ = (RefWCF.Juegos)Session["Juegos"];

        List<RefWCF.Preguntas> ListadoPreguntas = new List<RefWCF.Preguntas>();

        ListadoPreguntas = (List<RefWCF.Preguntas>)Session["ListadoPreguntas"];

        unaP = ListadoPreguntas[GVPreguntas.SelectedIndex];


        new RefWCF.ServicioClient().EliminarPreguntasdeUnJuego(unaP, unJ, (RefWCF.Usuario)Session["Usuario"]);

        unJ = new RefWCF.ServicioClient().BuscarJuegos(unJ.Codigo, (RefWCF.Usuario)Session["Usuario"]);

        GVPreguntas.DataSource = unJ.ListadoPreguntas.ToList();
        GVPreguntas.DataBind();

    }
}