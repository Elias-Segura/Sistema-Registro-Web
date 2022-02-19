using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;


namespace SistemaRegistro.CapaIntegracion
{
    public class GestorDetalleCaso : servicio, IDisposable
    {
        public GestorDetalleCaso()
        {

        }

        public void Dispose()
        {

        }

        public string InsertarDetalleCaso(int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_FechaRecibido, DateTime detalleCaso_FechaTraspaso, string detalleCaso_Descripcion, string detalleCaso_estado)
        {
            DetalleCaso detalleCaso = new DetalleCaso(caso_id, ciclo_id, documento_id, detalleCaso_FechaRecibido, detalleCaso_FechaTraspaso, detalleCaso_Descripcion, detalleCaso_estado);

            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.InsertarDetalleCaso(detalleCaso);
            }
        }

        public string ModificarDetalleCaso(int detalleCaso_id, int caso_id, int ciclo_id, int documento_id, DateTime detalleCaso_FechaRecibido, DateTime detalleCaso_FechaTraspaso, string detalleCaso_Descripcion, string detalleCaso_estado)
        {
            DetalleCaso detalleCaso = new DetalleCaso(detalleCaso_id, caso_id, ciclo_id, documento_id, detalleCaso_FechaRecibido, detalleCaso_FechaTraspaso, detalleCaso_Descripcion, detalleCaso_estado);

            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.ModificarDetalleCaso(detalleCaso);
            }
        }

        public DataTable listarDetalleCasos(string estado)
        {
            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.ListarDetalleCasos(estado);
            }
        }

        public DataSet ConsultarDetalleCaso(int id)
        {
            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.ConsultarDetalleCaso(id);
            }
        }

        public DataSet ContarInactivos()
        {
            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.ContarInactivos();
            }
        }

        public DataTable FiltrarDetalleCaso(string codigo, string estado)
        {
            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.FiltrarDatos(codigo, estado);
            }
        }

        public string InactivarDetalleCaso(int id)
        {
            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.InactivarDetalleCaso(id);
            }
        }

        public string ActivarDetalleCaso(int id)
        {
            using (ServicioDetalleCaso servicioDetalleCaso = new ServicioDetalleCaso())
            {
                return servicioDetalleCaso.ActivarDetalleCaso(id);
            }
        }
    }
}
