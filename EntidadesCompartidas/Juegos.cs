using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Juegos
    {
        #region Atributos
        int codigo;
        Usuario unUsuario;
        string dificultad;
        DateTime fechaC;
        List<Preguntas> listadoPreguntas;

        #endregion


        #region Propiedades
        [DataMember]
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        [DataMember]
        public Usuario UnUsuario
        {
            get { return unUsuario; }
            set
            {
                if (value == null)
                {

                    throw new Exception("No existe el Usuario");
                }
                unUsuario = value;
            }
        }

        [DataMember]
        public string Dificultad
        {
            get { return dificultad; }
            set
            {
                if (value != "FACIL" && value != "MEDIO" && value != "DIFICIL")
                {

                    throw new Exception("Ingrese uno de los 3 tipos correspondientes: FACIL, MEDIO O DIFICIL");

                }
                dificultad = value;
            }
        }

        [DataMember]
        public DateTime FechaC
        {
            get { return fechaC; }
            set { fechaC = value; }
        }

        [DataMember]
        public List<Preguntas> ListadoPreguntas
        {
            get { return listadoPreguntas; }
            set { listadoPreguntas = value;}

        }

        //puede no tener preguntas pero la lista no puede ser nula
        #endregion

        #region Propiedades
        public Juegos(int pCodigo, Usuario pUnUsuario, string pDificultad, DateTime pFechaC, List<Preguntas> pListadoPreguntas)
        {
            Codigo = pCodigo;
            UnUsuario = pUnUsuario;
            Dificultad = pDificultad;
            FechaC = pFechaC;
            ListadoPreguntas = pListadoPreguntas;
        }
        #endregion

        public Juegos() { }
       
        //falta hacer data contract y data member y el Constructor por Defecto
    }
}
