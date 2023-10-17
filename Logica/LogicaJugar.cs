using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaJugar: ILogicaJugar
    {
         // Singleton
        //1)atributo privado de clase que me permite almacenar mis objetos
        //en este caso sera un solo objeto (singleton puro)
        //inicializo en null, porque asi optimizo: hasta que alguien necesite un objeto mio,
        //no lo creo - optimizo memoria 
        private static LogicaJugar _instancia = null;


    //2)Constructor privado, no permite que nadie pueda crear objetos de la clase, solo yo
    //como no necesito nada... genero constructor vacio

    private LogicaJugar() { }


    //3)mecanismo para obtener un objeto de la Clase
    public static LogicaJugar GetInstancia()
    {

        if (_instancia == null) // no hay objeto.....
            _instancia = new LogicaJugar(); // creo uno, yo puedo por ser la clase

        return _instancia;

    }
        //fin Singleton

    public void JugarJuegos(Jugar J)
     {
          FabricaPersistencia.getPersistenciaJugar().JugarJuegos(J);
     }

     public List<Jugar> ListadoJugadas()
     {
          return (FabricaPersistencia.getPersistenciaJugar().ListadoJugadas());
      }
  }
}