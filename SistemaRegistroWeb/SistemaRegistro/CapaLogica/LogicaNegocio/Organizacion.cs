using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Organizacion
    {
        #region ATRIBUTOS
        private int organizacion_id;
        private string organizacion_nombre;
        private string organizacion_tipo;
        private string organizacion_descripcion;
        private string organizacion_estado;
        #endregion


        #region CONSTRUCTOR
        public Organizacion()
        {

        }

        public Organizacion(string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            this.organizacion_nombre = organizacion_nombre;
            this.organizacion_tipo = organizacion_tipo;
            this.organizacion_descripcion = organizacion_descripcion;
            this.organizacion_estado = organizacion_estado;
        }

        public Organizacion(int organizacion_id, string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            this.organizacion_id = organizacion_id;
            this.organizacion_nombre = organizacion_nombre;
            this.organizacion_tipo = organizacion_tipo;
            this.organizacion_descripcion = organizacion_descripcion;
            this.organizacion_estado = organizacion_estado;
        }
        #endregion

        #region GET's and SET's
        public int Organizacion_id { get => organizacion_id; set => organizacion_id = value; }
        public string Organizacion_nombre { get => organizacion_nombre; set => organizacion_nombre = value; }
        public string Organizacion_tipo { get => organizacion_tipo; set => organizacion_tipo = value; }
        public string Organizacion_descripcion { get => organizacion_descripcion; set => organizacion_descripcion = value; }
        public string Organizacion_estado { get => organizacion_estado; set => organizacion_estado = value; }
        #endregion
    }
}
