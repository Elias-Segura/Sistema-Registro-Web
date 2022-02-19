using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Codigo
    {

        #region ATRIBUTOS
        protected int codigo_id;
        protected int organizacion_id;
        protected string codigo_formato;
        protected string codigo_estado;

        #endregion

        #region CONSTRUCTORES
        public Codigo(int codigo_id, int organizacion_id, string codigo_formato, string codigo_estado)
        {
            this.Codigo_id = codigo_id;
            this.Organizacion_id = organizacion_id;
            this.Codigo_formato = codigo_formato;
            this.Codigo_estado = codigo_estado;
        }

        public Codigo(int organizacion_id, string codigo_formato, string codigo_estado)
        {
            this.Organizacion_id = organizacion_id;
            this.Codigo_formato = codigo_formato;
            this.Codigo_estado = codigo_estado;
        }


        #endregion

        #region GET's and SET's

        public int Codigo_id { get => codigo_id; set => codigo_id = value; }
        public int Organizacion_id { get => organizacion_id; set => organizacion_id = value; }
        public string Codigo_formato { get => codigo_formato; set => codigo_formato = value; }
        public string Codigo_estado { get => codigo_estado; set => codigo_estado = value; }



        #endregion
    }
}
