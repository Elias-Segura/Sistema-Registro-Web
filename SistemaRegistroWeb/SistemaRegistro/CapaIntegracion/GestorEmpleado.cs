using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;

using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;

namespace SistemaRegistro.CapaIntegracion
{
    public class GestorEmpleado: servicio, IDisposable
    {

        public GestorEmpleado()
        {

        }

        public void Dispose()
        {

        }

        public string InsertarEmpleado(int departamento_id, int puesto_id, int genero_id, int estadoCivil_id, string empleado_nombre, string empleado_primerApellido, string empleado_segundoApellido, DateTime empleado_fechaNacimiento, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            Empleado empleado = new Empleado(departamento_id, puesto_id, genero_id, estadoCivil_id,empleado_nombre,empleado_primerApellido,empleado_segundoApellido, empleado_fechaNacimiento,empleado_fechaIngreso,empleado_estado);

            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.InsertarEmpleado(empleado);
            }
        }

        public string ModificarEmpleado(int empleado_id, int departamento_id, int puesto_id, int genero_id, int estadoCivil_id, string empleado_nombre, string empleado_primerApellido, string empleado_segundoApellido, DateTime empleado_fechaNacimiento, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            Empleado empleado = new Empleado(empleado_id,departamento_id, puesto_id, genero_id, estadoCivil_id, empleado_nombre, empleado_primerApellido, empleado_segundoApellido, empleado_fechaNacimiento, empleado_fechaIngreso, empleado_estado);

            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.ModificarEmpleado(empleado);
            }
        }

        public DataTable listarEmpleado(string estado)
        {
            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.ListarEmpleado(estado);
            }
        }
        public DataSet ContarInactivos()
        {
            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.ContarInactivos();
            }
        }
        public DataSet ConsultarEmpleado(int id)
        {
            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.ConsultarEmpleado(id);
            }
        }

        public DataTable FiltrarEmpleado(string nombre, string estado)
        {
            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.FiltrarEmpleado(nombre,estado);
            }
        }

        public string InactivarEmpleado(int id)
        {
            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.InactivarEmpleado(id);
            }
        }

        public string ActivarEmpleado(int id)
        {
            using (ServicioEmpleado servicioEmpleado = new ServicioEmpleado())
            {
                return servicioEmpleado.ActivarEmpleado(id);
            }
        }
    }
}
