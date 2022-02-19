using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Caso
    {

        #region ATRIBUTOS
        public int caso_id;
        public int tramite_id;
        public string caso_codigo;
        public DateTime caso_fechaInicio;
        public DateTime caso_fechaFinal;
        public string caso_estado;

        #endregion


        #region CONSTRUCTORES
        public Caso(int caso_id, int tramite_id, string caso_codigo, DateTime caso_fechaInicio, DateTime caso_fechaFinal, string caso_estado)
        {
            this.Caso_id = caso_id;
            this.Tramite_id = tramite_id;
            this.Caso_codigo = caso_codigo;
            this.Caso_fechaInicio = caso_fechaInicio;
            this.Caso_fechaFinal = caso_fechaFinal;
            this.Caso_estado = caso_estado;
        }

        public Caso(int tramite_id, string caso_codigo, DateTime caso_fechaInicio, DateTime caso_fechaFinal, string caso_estado)
        {
            this.Tramite_id = tramite_id;
            this.Caso_codigo = caso_codigo;
            this.Caso_fechaInicio = caso_fechaInicio;
            this.Caso_fechaFinal = caso_fechaFinal;
            this.Caso_estado = caso_estado;
        }


        #endregion

        #region GET's and SET's
        public int Caso_id { get => caso_id; set => caso_id = value; }
        public int Tramite_id { get => tramite_id; set => tramite_id = value; }
        public string Caso_codigo { get => caso_codigo; set => caso_codigo = value; }
        public DateTime Caso_fechaInicio { get => caso_fechaInicio; set => caso_fechaInicio = value; }
        public DateTime Caso_fechaFinal { get => caso_fechaFinal; set => caso_fechaFinal = value; }
        public string Caso_estado { get => caso_estado; set => caso_estado = value; }
        #endregion
    }
}
