using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Preguntas
    {
        #region Atributos
        string codigoP;
        Categorias unaCategoria;
        string texto;
        int puntaje;
        List<Respuestas> listadoRespuestas;
        #endregion


        #region Propiedades
        [DataMember]
        public string CodigoP
        {
            get { return codigoP; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[0-9A-Za-z][0-9A-Za-z][0-9A-Za-z][0-9A-Za-z][0-9A-Za-z]"))
                    codigoP = value;
                else
                    throw new Exception("Formato de CodigoP no valido");

            }
        }
        //cambiar el Regex como en la bd

        [DataMember]
        public Categorias UnaCategoria
        {
            get { return unaCategoria; }
            set
            {
                if(value == null)
                {
                    throw new Exception("No existe la Categoria");
                    
                }
                unaCategoria = value;
            }
        }

        [DataMember]
        public string Texto
        {
            get { return texto; }
            set
            {
                
                 if (value.Trim().Length == 0 || value.Trim().Length > 50)
                 {
                    throw new Exception("El texto no puede estar vacio o ser mayor a 50 caracteres");

                 }

                texto = value;
            }
        }

        [DataMember]
        public int Puntaje
        {
            get { return puntaje; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new Exception("El Puntaje de la Pregunta debe ser de 1 a 10");

                }
              puntaje = value;
            }
        }

        [DataMember]
        public List<Respuestas> ListadoRespuestas
        {
            get { return listadoRespuestas; }
            set {
                    if (value == null)
                    {
                    throw new Exception("El Listado de Respuestas no puede ser nulo");

                     }
                listadoRespuestas = value;
               }
        }
        //tiene que ser una coleccion, no tiene que ser nulo y minimo tiene que tener dos respuestas
        #endregion

        #region Constructor
        public Preguntas(string pCodigoP, Categorias pUnaCategoria, string pTexto, int pPuntaje, List<Respuestas> pListadoRespuestas)
        {
            CodigoP = pCodigoP;
            UnaCategoria = pUnaCategoria;
            Texto = pTexto;
            Puntaje = pPuntaje;
            ListadoRespuestas = pListadoRespuestas;
        }

        public Preguntas() { }

        //falta hacer data contract y data member y el Constructor por Defecto
        #endregion
    }
}
