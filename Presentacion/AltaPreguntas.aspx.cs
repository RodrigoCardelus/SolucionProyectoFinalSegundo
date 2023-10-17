using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AltaPreguntas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
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

        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;
        txtCodigoP.Enabled = false;

    }

    private void ActivoBotonesA()
    {
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;
        txtCodigoP.Enabled = true;

    }
    private void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;
        txtCodigoP.Enabled = true;
        txtCodigoP.Text = "";
        txtCodigoC.Text = "";
        txtPuntaje.Text = " ";
        txtTexto.Text = "";
        List<RefWCF.Respuestas> _lista = new List<RefWCF.Respuestas>();
        Session["Respuestas"] = _lista;
        lblError.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string CodigoP = txtCodigoP.Text.Trim();

        RefWCF.Usuario pLogueo = null;
        
        RefWCF.Preguntas unaP = new RefWCF.ServicioClient().BuscarPreguntas(txtCodigoP.Text, pLogueo);
        try
        {
            if (unaP == null)
            {
                this.ActivoBotonesA();
                lblError.Text = " No se ha encontrado la Pregunta " + CodigoP;
            }
            else
            {
                this.ActivoBotonesBM();
                txtCodigoP.Text = unaP.CodigoP;
                txtCodigoC.Text = unaP.UnaCategoria.CodigoC;
                txtPuntaje.Text = Convert.ToString(unaP.Puntaje);
                txtTexto.Text = unaP.Texto;
                GvRespuestas.DataSource = unaP.ListadoRespuestas.ToList();
                GvRespuestas.DataBind();

                lblError.Text = "El Juego con el con su Codigo Pregunta es : " + unaP.CodigoP + " . ";
            }
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

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            RefWCF.Preguntas unaP = null;
            RefWCF.Usuario pLogueo = null;

            string CodigoP = txtCodigoP.Text.Trim();
            string CodigoC = txtCodigoC.Text.Trim();
            RefWCF.Categorias unaC = new RefWCF.ServicioClient().BuscarCategoriasActivo(txtCodigoC.Text, pLogueo);
            string Texto = txtTexto.Text.Trim();
            int Puntaje = Convert.ToInt32(txtPuntaje.Text.Trim());
            List<RefWCF.Respuestas> ListadoRespuestas = (List<RefWCF.Respuestas>)Session["Respuestas"];


            //agrego la Pregunta
            new RefWCF.ServicioClient().AgregarPreguntas(unaP, pLogueo);

         
            lblError.Text = "Alta con exito";


        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}