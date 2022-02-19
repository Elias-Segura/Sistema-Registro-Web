using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Ciclo
    {
        #region ATRIBUTOS
        private int ciclo_id;
        private int tramite_id;
        private int departamento_id;
        private string ciclo_orden;
        private string ciclo_estado;
        #endregion

        #region CONSTRUCTORES
        public Ciclo()
        {

        }

        public Ciclo(int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            this.Tramite_id = tramite_id;
            this.Departamento_id = departamento_id;
            this.Ciclo_orden = ciclo_orden;
            this.Ciclo_estado = ciclo_estado;
        }

        public Ciclo(int ciclo_id, int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            this.Ciclo_id = ciclo_id;
            this.Tramite_id = tramite_id;
            this.Departamento_id = departamento_id;
            this.Ciclo_orden = ciclo_orden;
            this.Ciclo_estado = ciclo_estado;
        }
        #endregion

        #region GET's and SET's
        public int Ciclo_id { get => ciclo_id; set => ciclo_id = value; }
        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public int Departamento_id { get => departamento_id; set => departamento_id = value; }
        public string Ciclo_orden { get => ciclo_orden; set => ciclo_orden = value; }
        public string Ciclo_estado { get => ciclo_estado; set => ciclo_estado = value; }
        #endregion

    }
}
