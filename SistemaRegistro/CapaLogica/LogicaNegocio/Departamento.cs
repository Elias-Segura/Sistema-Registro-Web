using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Departamento
    {
        #region ATRIBUTOS

        protected int departamento_id;
        protected int organizacion_id;
        protected int departementoTipoID;
        protected string departamento_nombre;
        protected string departamento_descripcion;
        protected string departamento_estado;

 


        #endregion

        #region CONSTRUCTOR

        public Departamento(int departamento_id, int organizacion_id, int departementoTipoID, string departamento_nombre, string departamento_descripcion, string departamento_estado)
        {
            this.Departamento_id = departamento_id;
            this.Organizacion_id = organizacion_id;
            this.DepartementoTipoID = departementoTipoID;
            this.Departamento_nombre = departamento_nombre;
            this.Departamento_descripcion = departamento_descripcion;
            this.Departamento_estado = departamento_estado;
       
        
        }

        public Departamento(int organizacion_id, int departementoTipoID, string departamento_nombre, string departamento_descripcion, string departamento_estado)
        {
            this.organizacion_id = organizacion_id;
            this.departementoTipoID = departementoTipoID;
            this.departamento_nombre = departamento_nombre;
            this.departamento_descripcion = departamento_descripcion;
            this.departamento_estado = departamento_estado;
        }



        #endregion

        #region GET's and SET's

        public int Organizacion_id { get => organizacion_id; set => organizacion_id = value; }
        public int DepartementoTipoID { get => departementoTipoID; set => departementoTipoID = value; }
        public string Departamento_nombre { get => departamento_nombre; set => departamento_nombre = value; }
        public string Departamento_descripcion { get => departamento_descripcion; set => departamento_descripcion = value; }
        public string Departamento_estado { get => departamento_estado; set => departamento_estado = value; }
        public int Departamento_id { get => departamento_id; set => departamento_id = value; }


        #endregion

    }
}
