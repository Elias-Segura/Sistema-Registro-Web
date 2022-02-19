using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class DepartamentoTipo
    {
        #region ATRIBUTOS
        private int departamentoTipo_id;
        private string departamentoTipo_nombre;
        private string departamento_estado;

        #endregion

        #region CONSTRUCTOR
        public DepartamentoTipo()
        {

        }

        public DepartamentoTipo(string departamentoTipo_nombre, string departamento_estado)
        {
            this.departamentoTipo_nombre = departamentoTipo_nombre;
            this.departamento_estado = departamento_estado;
        }

        public DepartamentoTipo(int departamentoTipo_id, string departamentoTipo_nombre, string departamento_estado)
        {
            this.departamentoTipo_id = departamentoTipo_id;
            this.departamentoTipo_nombre = departamentoTipo_nombre;
            this.departamento_estado = departamento_estado;
        }
        #endregion

        #region GET's and SET's
        public int DepartamentoTipo_id { get => departamentoTipo_id; set => departamentoTipo_id = value; }
        public string DepartamentoTipo_nombre { get => departamentoTipo_nombre; set => departamentoTipo_nombre = value; }
        public string Departamento_estado { get => departamento_estado; set => departamento_estado = value; }
        #endregion

    }
}
