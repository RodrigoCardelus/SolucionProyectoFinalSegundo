using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {
        #region Operaciones

        #region Usuario
        [OperationContract]
        Usuario LogueoUsuario(string UsuarioLog, string Contraseña);

        [OperationContract]
        void AgregarUsuario(EntidadesCompartidas.Usuario pUsu, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void EliminarUsuario(EntidadesCompartidas.Usuario pUsu, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void ModificarUsuario(EntidadesCompartidas.Usuario pUsu, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        Usuario BuscarUsuario(string UsuarioLogueo, EntidadesCompartidas.Usuario pLogueo);

        #endregion

        #region Categorias

        [OperationContract]
        void AgregarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void EliminarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void ModificarCategorias(Categorias unaC, EntidadesCompartidas.Usuario pLogueo);


        [OperationContract]
        Categorias BuscarCategoriasActivo(string CodigoC, EntidadesCompartidas.Usuario pLogueo);



        #endregion

        #region Juegos

        [OperationContract]
        void AgregarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void EliminarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void ModificarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        Juegos BuscarJuegos(int Codigo, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        List<Juegos> ListaJuegosNuncaUsados(EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        List<Juegos> ListaJuegosVacios(EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        List<Juegos> ListadoJuegosConPreguntas();

        #endregion

        #region Preguntas

        [OperationContract]
        void AgregarPreguntas(Preguntas unaP, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        Preguntas BuscarPreguntas(string CodigoP, EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        List<Preguntas> ListaPreguntasNuncaUsadas(EntidadesCompartidas.Usuario pLogueo);

        [OperationContract]
        void AgregarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, Usuario pLogueo);

        [OperationContract]
        void EliminarPreguntasdeUnJuego(Preguntas unaP, Juegos unJ, EntidadesCompartidas.Usuario pLogueo);


        #endregion

        #region Jugar
        [OperationContract]
        void JugarJuegos(Jugar J);

        [OperationContract]

        List<Jugar> ListadoJugadas();

        #endregion


        #endregion
    }
}