using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Jugar
    {
        #region Atributos
        DateTime fechaHora;
        Juegos unJuego;
        string nombre;
        int puntaje;

        #endregion

        #region Propiedades
        [DataMember]
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }

        }

        [DataMember]
        public Juegos UnJuego
        {
            get { return unJuego; }
            set
            {
                if (value == null)
                {
                    throw new Exception("No hay un Juego");
                }
              unJuego = value;
            }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim().Length == 0 || value.Trim().Length > 20)
                {

                    throw new Exception("El Nombre no puede estar vacio o mayor a 20 caracteres");
                }
              nombre = value;
            }
        }

        [DataMember]
        public int Puntaje
        {
            get { return puntaje; }
            set {
                   if(value < 0)
                   {
                     throw new Exception("El Puntaje no puede ser negativo");
                   }
               puntaje = value;
            }
        }

        //no puede tener puntaje negativo

        #endregion

        #region Constructor
        public Jugar(DateTime pFechaHora, Juegos pUnJuego, string pNombre, int pPuntaje)
        {
            FechaHora = pFechaHora;
            UnJuego = pUnJuego;
            Nombre = pNombre;
            Puntaje = pPuntaje;

        }

        public Jugar() { }
        #endregion

        //falta hacer data contract y data member y el Constructor por Defecto
    }
}
