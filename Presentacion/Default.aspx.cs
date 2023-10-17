using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                List<RefWCF.Jugar> _lista = new List<RefWCF.Jugar>();
                Session["Jugar"] = _lista;
                List<RefWCF.Juegos> _listaJ = new List<RefWCF.Juegos>();
                Session["Juegos"] = _listaJ;
                this.CargaInicial();
                this.CargaJuegos();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void CargaInicial()
    {

        GvJugadas.DataSource = new RefWCF.ServicioClient().ListadoJugadas().ToList();
        GvJugadas.DataBind();

    }

    protected void CargaJuegos()
    {

        GvJuegos.DataSource = new RefWCF.ServicioClient().ListadoJuegosConPreguntas().ToList();
        GvJuegos.DataBind();

    }


    protected void btnFiltrarNombre_Click(object sender, EventArgs e)
    {
        try
        {
            List<RefWCF.Jugar> _lista = new List<RefWCF.Jugar>();
            Session["Jugar"] = _lista;
            string UsuarioLog = txtUsuarioLogueo.Text.Trim();

            RefWCF.Usuario pLogueo = (RefWCF.Usuario)Session["Usuario"];

            RefWCF.Usuario unU = new RefWCF.ServicioClient().BuscarUsuario(txtUsuarioLogueo.Text.Trim(), pLogueo);
            if (unU == null)
                throw new Exception("No existe Usuario - no se filtra");


            List<Object> _resultado =
               (from J in _lista
                where J.Nombre == unU.UsuarioLog
                select J

               ).ToList<object>();



            GvJugadas.DataSource = _resultado;
            GvJugadas.DataBind();
            Session["Resultado"] = _resultado;


        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;

        }
    }

    protected void btnFiltrarDificultad_Click(object sender, EventArgs e)
    {
        try
        {
            List<RefWCF.Juegos> _listaJ = new List<RefWCF.Juegos>();
            Session["Juegos"] = _listaJ;
            string Dificultad = txtDificultad.Text.Trim();

            List<Object> _resultado =
               ((from unJ in (new RefWCF.ServicioClient().ListadoJuegosConPreguntas())
                 where unJ.Dificultad == Dificultad
                 select unJ

              ).ToList<object>());


            GvJuegos.DataSource = _resultado;
            GvJuegos.DataBind();
            Session["Resultado"] = _resultado;

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;

        }
    }

    protected void btnFiltroDificultadPuntaje_Click(object sender, EventArgs e)
    {
        try
        {
            List<RefWCF.Jugar> _lista = new List<RefWCF.Jugar>();
            Session["Jugar"] = _lista;
            int Puntaje = Convert.ToInt32(txtPuntaje.Text.Trim());


            List<Object> _resultado =
              ((from J in (new RefWCF.ServicioClient().ListadoJugadas())
                where J.Puntaje == Puntaje
                orderby J.Puntaje
                select J
               ).ToList<object>());


            GvJugadas.DataSource = _resultado;
            GvJugadas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
 }