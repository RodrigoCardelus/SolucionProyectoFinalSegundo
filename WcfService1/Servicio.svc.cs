using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;
using Logica;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        #region Usuario
        Usuario IServicio.LogueoUsuario(string UsuarioLog, string Contraseña)
        {
            return (LogicaUsuario.GetInstancia().LogueoUsuario(UsuarioLog, Contraseña));
        }

        void IServicio.AgregarUsuario(Usuario pUsu, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaUsuario().AgregarUsuario(pUsu, pLogueo);
        }

        void IServicio.EliminarUsuario(Usuario pUsu, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaUsuario().EliminarUsuario(pUsu, pLogueo);
        }

        void IServicio.ModificarUsuario(Usuario pUsu, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaUsuario().ModificarUsuario(pUsu, pLogueo);
        }

        Usuario IServicio.BuscarUsuario(string UsuarioLogueo, Usuario pLogueo)
        {
            return (LogicaUsuario.GetInstancia().BuscarUsuario(UsuarioLogueo, pLogueo));
        }

        #endregion

        #region Categorias
        void IServicio.AgregarCategorias(Categorias unaC, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaCategorias().AgregarCategorias(unaC, pLogueo);
        }

        void IServicio.EliminarCategorias(Categorias unaC, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaCategorias().EliminarCategorias(unaC, pLogueo);
        }

        void IServicio.ModificarCategorias(Categorias unaC, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaCategorias().ModificarCategorias(unaC, pLogueo);
        }

        Categorias IServicio.BuscarCategoriasActivo(string CodigoC, Usuario pLogueo)
        {
            return (LogicaCategorias.GetInstancia().BuscarCategoriasActivo(CodigoC, pLogueo));
        }
        #endregion


        #region Preguntas
        void IServicio.AgregarPreguntas(Preguntas unaP, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaPreguntas().AgregarPreguntas(unaP, pLogueo);
        }

        Preguntas IServicio.BuscarPreguntas(string CodigoP, Usuario pLogueo)
        {
            return (LogicaPreguntas.GetInstancia().BuscarPreguntas(CodigoP, pLogueo));
        }


        List<Preguntas> IServicio.ListaPreguntasNuncaUsadas(Usuario pLogueo)
        {
            return (Logica.FabricaLogica.getLogicaPreguntas().ListaPreguntasNuncaUsadas(pLogueo));
        }

        void IServicio.AgregarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, Usuario pLogueo)
        {
            LogicaPreguntas.GetInstancia().AgregarPreguntasdeUnJuego(unaP, unJ, pLogueo);
        }

        void IServicio.EliminarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, Usuario pLogueo)
        {
            LogicaPreguntas.GetInstancia().EliminarPreguntasdeUnJuego(unaP, unJ, pLogueo);
        }

        #endregion


        #region Juegos
        void IServicio.AgregarJuegos(Juegos unJ, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaJuegos().AgregarJuegos(unJ, pLogueo);
        }

        Juegos IServicio.BuscarJuegos(int Codigo, Usuario pLogueo)
        {
            return (LogicaJuegos.GetInstancia().BuscarJuegos(Codigo, pLogueo));
        }


        void IServicio.EliminarJuegos(Juegos unJ, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaJuegos().EliminarJuegos(unJ, pLogueo);
        }


        void IServicio.ModificarJuegos(Juegos unJ, Usuario pLogueo)
        {
            Logica.FabricaLogica.getLogicaJuegos().ModificarJuegos(unJ, pLogueo);
        }

        List<Juegos> IServicio.ListadoJuegosConPreguntas()
        {
            return (Logica.FabricaLogica.getLogicaJuegos().ListaJuegosConPreguntas());
        }

        List<Juegos> IServicio.ListaJuegosNuncaUsados(Usuario pLogueo)
        {
            return (Logica.FabricaLogica.getLogicaJuegos().ListaJuegosVacios(pLogueo));
        }

        List<Juegos> IServicio.ListaJuegosVacios(Usuario pLogueo)
        {
            return (Logica.FabricaLogica.getLogicaJuegos().ListaJuegosVacios(pLogueo));
        }

        #endregion

        #region Jugar
        void IServicio.JugarJuegos(Jugar J)
        {
            Logica.FabricaLogica.getLogicaJugar().JugarJuegos(J);
        }

        List<Jugar> IServicio.ListadoJugadas()
        {
            return (Logica.FabricaLogica.getLogicaJugar().ListadoJugadas());
        }

        #endregion

    }
}
