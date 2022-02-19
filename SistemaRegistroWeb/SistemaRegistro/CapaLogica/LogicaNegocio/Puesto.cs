using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Puesto
    {

        #region ATRIBUTOS

        protected int puesto_id;
        protected string puesto_nombre;
        protected string puesto_estado;

     



        #endregion

        #region CONSTRUCTORES


        public Puesto(string puesto_nombre, string puesto_estado)
        {
            this.Puesto_nombre = puesto_nombre;
            this.Puesto_estado = puesto_estado;
        }

        public Puesto(int puesto_id, string puesto_nombre, string puesto_estado)
        {
            this.Puesto_id = puesto_id;
            this.Puesto_nombre = puesto_nombre;
            this.Puesto_estado = puesto_estado;
        }


        #endregion

        #region GET's and SET's
        public int Puesto_id { get => puesto_id; set => puesto_id = value; }
        public string Puesto_nombre { get => puesto_nombre; set => puesto_nombre = value; }
        public string Puesto_estado { get => puesto_estado; set => puesto_estado = value; }



        #endregion
    }
}
