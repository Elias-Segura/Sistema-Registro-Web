using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Tramite
    {
        #region ATRIBUTOS
        private int tramite_id;
        private string tramite_nombre;
        private string tramite_descripcion;
        private string tramite_estado;

        #endregion



        #region CONSTRUCTOR
        public Tramite()
        {

        }

        public Tramite(string tramite_nombre, string tramite_descripcion, string tramite_estado)
        {
            this.tramite_nombre = tramite_nombre;
            this.tramite_descripcion = tramite_descripcion;
            this.tramite_estado = tramite_estado;
        }
        public Tramite(int tramite_id, string tramite_nombre, string tramite_descripcion, string tramite_estado)
        {
            this.tramite_id = tramite_id;
            this.tramite_nombre = tramite_nombre;
            this.tramite_descripcion = tramite_descripcion;
            this.tramite_estado = tramite_estado;
        }
        #endregion

        #region GET's and SET's
        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public string Tramite_nombre { get => tramite_nombre; set => tramite_nombre = value; }
        public string Tramite_descripcion { get => tramite_descripcion; set => tramite_descripcion = value; }
        public string Tramite_estado { get => tramite_estado; set => tramite_estado = value; }
        #endregion
    }
}
