using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;
using SistemaRegistro.CapaConexion;
using System.Data;

namespace SistemaRegistro.CapaIntegracion
{
    public class GestorTramite:servicio, IDisposable

    {
        public void Dispose()
        {

        }
         public GestorTramite()
        {


        }

        public string insertarTramite(string nombre, string descripcion, string estado)
        {
            Tramite tramite = new Tramite(nombre, descripcion, estado); 
            using(ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.InsertarTramite(tramite);
            }
        }
        public string modificarTramite(int tramite_id, string nombre, string descripcion, string estado)
        {
            Tramite tramite = new Tramite(tramite_id, nombre, descripcion, estado);
            using (ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.ModificarTramite(tramite);
            }
        }

        public DataTable listarTramites(string estado)
        {
            using(ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.ListarTramite(estado);
            }
        }
        public DataTable TramiteDepartamento(int id)
        {
            using (ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.FiltrarTramiteDepartamento(id);
            }
        }
        public DataSet ConsultarTramite(int id)
        {
            using(ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.ConsultarTramite(id); 
            }
        }
        public DataSet ContarInactivos()
        {
            using (ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.ContarInactivos();
            }
        }

        public DataTable FiltrarTramite(string nombre, string estado)
        {
            using (ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.FiltrarTramite(nombre,estado);
            }
        }
        public string InactivarTramite(int id)
        {
            using (ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.InactivarTramite(id);
            }
        }

        public string ActivarTramite(int id)
        {
            using (ServicioTramite servicioTramite = new ServicioTramite())
            {
                return servicioTramite.ActivarTramite(id);
            }
        }

    }
}
