using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;

namespace SistemaRegistro.CapaIntegracion
{
    public class GestorOrganizacion:servicio, IDisposable
    {
        public GestorOrganizacion()
        {

        }

        public void Dispose()
        {

        }

        public string InsertarOrganizacion(string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Organizacion organizacion = new Organizacion(organizacion_nombre, organizacion_tipo, organizacion_descripcion, organizacion_estado);

            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.InsertarOrganizacion(organizacion);
            }
        }

        public string ModificarOrganizacion(int organizacion_id, string organizacion_nombre, string organizacion_tipo, string organizacion_descripcion, string organizacion_estado)
        {
            Organizacion organizacion = new Organizacion(organizacion_id,organizacion_nombre, organizacion_tipo, organizacion_descripcion, organizacion_estado);

            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.ModificarOrganizacion(organizacion);
            }
        }

        public DataTable listarOrganizacion(string estado)
        {
            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.ListarOrganizacion( estado);
            }
        }

        public DataSet ContarInactivos()
        {
            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.ContarInactivos();
            }
        }

        public DataSet ConsultarOrganizacion(int id)
        {
            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.consultarOrganizacion(id);
            }
        }
        public DataTable FiltrarOrganizacion(string nombre, string estado)
        {
            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.FiltrarOrganizacion(nombre,estado);
            }
        }
        public string InactivarOrganizacion(int id)
        {
            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.InactivarOrganizacion(id);
            }
        }

        public string ActivarOrganizacion(int id)
        {
            using (ServicioOrganizacion servicioOrganizacion = new ServicioOrganizacion())
            {
                return servicioOrganizacion.ActivarOrganizacion(id);
            }
        }
    }
}
