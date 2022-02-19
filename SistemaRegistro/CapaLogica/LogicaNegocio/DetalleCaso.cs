using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class DetalleCaso
    {

        #region ATRIBUTOS
        protected int detalleCaso_id;
        protected int caso_id;
        protected int ciclo_id;
        protected int documento_id;
        protected DateTime detalleCaso_FechaRecibido;
        protected DateTime detalleCaso_FechaTraspaso;
        protected string detalleCaso_Descripcion;
        protected string detalleCaso_estado;

     


        #endregion


        #region CONSTRUCTORES

        public DetalleCaso(int detalleCaso_id, int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_FechaRecibido, DateTime detalleCaso_FechaTraspaso, string detalleCaso_Descripcion, string detalleCaso_estado)
        {
            this.DetalleCaso_id = detalleCaso_id;
            this.Caso_id = caso_id;
            this.Ciclo_id = ciclo_id;
            this.Documento_id = documento_id;
            this.DetalleCaso_FechaRecibido = detalleCaso_FechaRecibido;
            this.DetalleCaso_FechaTraspaso = detalleCaso_FechaTraspaso;
            this.DetalleCaso_Descripcion = detalleCaso_Descripcion;
            this.DetalleCaso_estado = detalleCaso_estado;
        }

        public DetalleCaso(int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_FechaRecibido, DateTime detalleCaso_FechaTraspaso, string detalleCaso_Descripcion, string detalleCaso_estado)
        {
            this.Caso_id = caso_id;
            this.Ciclo_id = ciclo_id;
            this.Documento_id = documento_id;
            this.DetalleCaso_FechaRecibido = detalleCaso_FechaRecibido;
            this.DetalleCaso_FechaTraspaso = detalleCaso_FechaTraspaso;
            this.DetalleCaso_Descripcion = detalleCaso_Descripcion;
            this.DetalleCaso_estado = detalleCaso_estado;
        }

        #endregion


        #region GET'S AND SET'S

        public int DetalleCaso_id { get => detalleCaso_id; set => detalleCaso_id = value; }
        public int Caso_id { get => caso_id; set => caso_id = value; }
        public int Ciclo_id { get => ciclo_id; set => ciclo_id = value; }
        public int Documento_id { get => documento_id; set => documento_id = value; }
        public DateTime DetalleCaso_FechaRecibido { get => detalleCaso_FechaRecibido; set => detalleCaso_FechaRecibido = value; }
        public DateTime DetalleCaso_FechaTraspaso { get => detalleCaso_FechaTraspaso; set => detalleCaso_FechaTraspaso = value; }
        public string DetalleCaso_Descripcion { get => detalleCaso_Descripcion; set => detalleCaso_Descripcion = value; }
        public string DetalleCaso_estado { get => detalleCaso_estado; set => detalleCaso_estado = value; }



        #endregion




    }
}
