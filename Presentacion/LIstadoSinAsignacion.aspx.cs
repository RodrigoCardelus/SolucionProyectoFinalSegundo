using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class ListadoSinAsignacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
                RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];
                List<RefWCF.Juegos> _lista = new List<RefWCF.Juegos>();
                List<RefWCF.Preguntas> _listaP = new List<RefWCF.Preguntas>();
                Session["Juegos"] = _lista;
                Session["Preguntas"] = _listaP;
                this.CargaInicial();
                this.CargaPreguntasNuncaUsadas();
                this.CargaJuegosVacios();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void CargaInicial()
    {
        RefWCF.Usuario pLogueo = null;
        GvJuegosNuncaUsados.DataSource = new RefWCF.ServicioClient().ListaJuegosNuncaUsados(pLogueo).ToList();
        GvJuegosNuncaUsados.DataBind();

    }

    protected void CargaPreguntasNuncaUsadas()
    {

        RefWCF.Usuario pLogueo = null;
        GvPreguntasNuncaUsadas.DataSource = new RefWCF.ServicioClient().ListaPreguntasNuncaUsadas(pLogueo).ToList();
        GvPreguntasNuncaUsadas.DataBind();

    }

    protected void CargaJuegosVacios()
    {
        RefWCF.Usuario pLogueo = null;
        GvListadoJuegosVacios.DataSource = new RefWCF.ServicioClient().ListaJuegosVacios(pLogueo).ToList();
        GvListadoJuegosVacios.DataBind();
    }
}