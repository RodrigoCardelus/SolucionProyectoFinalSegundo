using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaJuegos:ILogicaJuegos
    {
        // Singleton
        //1)atributo privado de clase que me permite almacenar mis objetos
        //en este caso sera un solo objeto (singleton puro)
        //inicializo en null, porque asi optimizo: hasta que alguien necesite un objeto mio,
        //no lo creo - optimizo memoria 
        private static LogicaJuegos _instancia = null;


        //2)Constructor privado, no permite que nadie pueda crear objetos de la clase, solo yo
       //como no necesito nada... genero constructor vacio

       private LogicaJuegos() { }


      //3)mecanismo para obtener un objeto de la Clase
      public static LogicaJuegos GetInstancia()
      {

         if (_instancia == null) // no hay objeto.....
             _instancia = new LogicaJuegos(); // creo uno, yo puedo por ser la clase

         return _instancia;

     }
        //fin Singleton

     public void AgregarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
     {
        FabricaPersistencia.getPersistenciaJuegos().AgregarJuegos(unJ, pLogueo);
     }

     public Juegos BuscarJuegos(int Codigo, EntidadesCompartidas.Usuario pLogueo)
     {
         return (FabricaPersistencia.getPersistenciaJuegos().BuscarJuegos(Codigo, pLogueo));
     }

     public void EliminarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
     {
         FabricaPersistencia.getPersistenciaJuegos().EliminarJuegos(unJ, pLogueo);
     }

     public void ModificarJuegos(Juegos unJ, EntidadesCompartidas.Usuario pLogueo)
     {
         FabricaPersistencia.getPersistenciaJuegos().ModificarJuegos(unJ, pLogueo);
     }

     public List<Juegos> ListaJuegosNuncaUsados(EntidadesCompartidas.Usuario pLogueo)
     {
          return (FabricaPersistencia.getPersistenciaJuegos().ListaJuegosNuncaUsados(pLogueo));
     }

     public List<Juegos> ListaJuegosVacios(EntidadesCompartidas.Usuario pLogueo)
     {
         return (FabricaPersistencia.getPersistenciaJuegos().ListaJuegosVacios(pLogueo));
     }

     public List<Juegos> ListaJuegosConPreguntas()
     {
        return (FabricaPersistencia.getPersistenciaJuegos().ListadoJuegosConPreguntas());
     }

  }
}