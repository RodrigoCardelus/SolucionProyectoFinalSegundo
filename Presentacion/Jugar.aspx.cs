using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Jugar : System.Web.UI.Page
{ 
    int PosPregunta;
    int resultado;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                RefWCF.Usuario unUsu = (RefWCF.Usuario)Session["Usuario"];
                List<RefWCF.Juegos> _lista = new List<RefWCF.Juegos>();
                Session["Juegos"] = _lista;
                Session["PosPregunta"] = 0;
                rdbListRespuestas.Items.Clear();
                Session["Resultado"] = 0;

            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    
    
    protected void btnJugar_Click(object sender, EventArgs e)
    {
        try
        {
           
            resultado = 0;
            PosPregunta = 0;
            RefWCF.Juegos unJ = (RefWCF.Juegos)Session["Juegos"];
            List<RefWCF.Preguntas> ListadoPreguntas = unJ.ListadoPreguntas.ToList();
            RefWCF.Preguntas unaP = ListadoPreguntas[PosPregunta];
            lblPregunta.Text = unaP.Texto + "? ";
            List<RefWCF.Respuestas> ListadoRespuestas = unaP.ListadoRespuestas.ToList();
            RefWCF.Respuestas unaR = ListadoRespuestas[PosPregunta];

            foreach(RefWCF.Respuestas r in ListadoRespuestas )
            {
                rdbListRespuestas.Items.Add(new ListItem(r.TextoR, r.Resultado.ToString()));

            }
           
            lblError.Text = "El Juego ah Comenzado";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
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
                
                lblError.Text = " No se ha encontrado Juego " + Codigo;
            }
            else
            {
                Session["Juegos"] = unJ;
                txtUsuarioLogueo.Text = unJ.UnUsuario.UsuarioLog;
                txtDificultad.Text = unJ.Dificultad;
                List<RefWCF.Preguntas> ListadoPreguntas = new List<RefWCF.Preguntas>();
                ListadoPreguntas = unJ.ListadoPreguntas.ToList();
                lblError.Text = "El Juego con el usuario de logueo es : " + unJ.UnUsuario.UsuarioLog + " . ";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {

        RefWCF.Juegos unJ;
        RefWCF.Jugar J;
        string nombre;
        int puntaje;

        unJ = (RefWCF.Juegos) Session["Juegos"];
        List<RefWCF.Preguntas> ListadoPreguntas = new List<RefWCF.Preguntas>();
        ListadoPreguntas = unJ.ListadoPreguntas.ToList();

        try
        {

            PosPregunta = (int) Session["PosPregunta"] + 1 ;
            Session["PosPregunta"] = PosPregunta;

            if (PosPregunta < ListadoPreguntas.Count())
            {
              
                RefWCF.Preguntas unaP = ListadoPreguntas[PosPregunta];
                lblPregunta.Text = unaP.Texto + "? ";
                List<RefWCF.Respuestas> ListadoRespuestas = unaP.ListadoRespuestas.ToList();
                RefWCF.Respuestas unaR = ListadoRespuestas[PosPregunta];

                rdbListRespuestas.Items.Clear();

                foreach (RefWCF.Respuestas r in ListadoRespuestas)
                {
                    rdbListRespuestas.Items.Add(new ListItem(r.TextoR, r.Resultado.ToString()));

                }
                 resultado = (int) Session["Resultado"];
                for (int i = 0; i < ListadoRespuestas.Count; i++)
                {
                    if (rdbListRespuestas.Items[i].Selected == ListadoRespuestas[i].Resultado)
                    {
                        resultado = resultado + unaP.Puntaje;

                    }
                }
              Session["Resultado"] = resultado;
              
            }
            if (PosPregunta ==  ListadoPreguntas.Count())
            {
                resultado = (int)Session["Resultado"];
                lblError.Text = "Se ah terminado el Juego " + " Con su Puntaje : " + resultado.ToString();
                J = new RefWCF.Jugar()
                {
                    UnJuego = unJ,
                    Nombre = txtUsuarioLogueo.Text.Trim(),
                    Puntaje = resultado
                };
         
                new RefWCF.ServicioClient().JugarJuegos(J);   
            }
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void rdbListRespuestas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}