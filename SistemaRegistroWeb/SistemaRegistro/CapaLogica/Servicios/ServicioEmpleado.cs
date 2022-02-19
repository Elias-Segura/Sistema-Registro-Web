using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;


namespace SistemaRegistro.CapaLogica.Servicios
{
    public class ServicioEmpleado : servicio , IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public ServicioEmpleado()
        {

        }

        public string InsertarEmpleado(Empleado empleado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Empleado");

            comando.CommandText = "InsertarEmpleado";

            comando.Parameters.Add("Departamento_id", SqlDbType.Int);
            comando.Parameters["Departamento_id"].Value = empleado.Departamento_id;

            comando.Parameters.Add("Puesto_id", SqlDbType.Int);
            comando.Parameters["Puesto_id"].Value = empleado.Puesto_id;

            comando.Parameters.Add("Genero_id", SqlDbType.Int);
            comando.Parameters["Genero_id"].Value = empleado.Genero_id;

            comando.Parameters.Add("EstadoCivil_id", SqlDbType.Int);
            comando.Parameters["EstadoCivil_id"].Value = empleado.EstadoCivil_id;

            comando.Parameters.Add("Empleado_nombre", SqlDbType.VarChar);
            comando.Parameters["Empleado_nombre"].Value = empleado.Empleado_nombre; 

            comando.Parameters.Add("Empleado_primerApellido", SqlDbType.VarChar);
            comando.Parameters["Empleado_primerApellido"].Value = empleado.Empleado_primerApellido;

            comando.Parameters.Add("Empleado_segundoApellido", SqlDbType.VarChar);
            comando.Parameters["Empleado_segundoApellido"].Value = empleado.Empleado_segundoApellido;

            comando.Parameters.Add("Empleado_fechaNacimiento", SqlDbType.Date);
            comando.Parameters["Empleado_fechaNacimiento"].Value = empleado.Empleado_fechaNacimiento;

            comando.Parameters.Add("Empleado_fechaIngreso", SqlDbType.Date);
            comando.Parameters["Empleado_fechaIngreso"].Value = empleado.Empleado_fechaIngreso;

            comando.Parameters.Add("Empleado_estado", SqlDbType.VarChar);
            comando.Parameters["Empleado_estado"].Value = empleado.Empleado_estado;
            
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Empleado";

            Console.WriteLine("Fin Servicio Insertar Empleado");

            return respuesta;
        }


        public string ModificarEmpleado(Empleado empleado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Empleado");

            comando.CommandText = "ModificarEmpleado";

            comando.Parameters.Add("Empleado_id", SqlDbType.Int);
            comando.Parameters["Empleado_id"].Value = empleado.Empleado_id;

            comando.Parameters.Add("Departamento_id", SqlDbType.Int);
            comando.Parameters["Departamento_id"].Value = empleado.Departamento_id;

            comando.Parameters.Add("Puesto_id", SqlDbType.Int);
            comando.Parameters["Puesto_id"].Value = empleado.Puesto_id;

            comando.Parameters.Add("Genero_id", SqlDbType.Int);
            comando.Parameters["Genero_id"].Value = empleado.Genero_id;

            comando.Parameters.Add("EstadoCivil_id", SqlDbType.Int);
            comando.Parameters["EstadoCivil_id"].Value = empleado.EstadoCivil_id;

            comando.Parameters.Add("Empleado_nombre", SqlDbType.VarChar);
            comando.Parameters["Empleado_nombre"].Value = empleado.Empleado_nombre;

            comando.Parameters.Add("Empleado_primerApellido", SqlDbType.VarChar);
            comando.Parameters["Empleado_primerApellido"].Value = empleado.Empleado_primerApellido;

            comando.Parameters.Add("Empleado_segundoApellido", SqlDbType.VarChar);
            comando.Parameters["Empleado_segundoApellido"].Value = empleado.Empleado_segundoApellido;

            comando.Parameters.Add("Empleado_fechaNacimiento", SqlDbType.Date);
            comando.Parameters["Empleado_fechaNacimiento"].Value = empleado.Empleado_fechaNacimiento;

            comando.Parameters.Add("Empleado_fechaIngreso", SqlDbType.Date);
            comando.Parameters["Empleado_fechaIngreso"].Value = empleado.Empleado_fechaIngreso;

            comando.Parameters.Add("Empleado_estado", SqlDbType.VarChar);
            comando.Parameters["Empleado_estado"].Value = empleado.Empleado_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Empleado";

            Console.WriteLine("Fin Servicio Insertar Empleado");

            return respuesta;
        }


        public DataSet ConsultarEmpleado(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarEmpleado");
            comando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            comando.Parameters["@Empleado_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable ListarEmpleado(string estado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Empleados");
            comando.CommandText = "ListarEmpleados";
            comando.Parameters.AddWithValue("@Empleado_estado", SqlDbType.VarChar);
            comando.Parameters["@Empleado_estado"].Value = estado;


            DataSet empleado = new DataSet();
            this.abrirConexion();

            empleado = this.seleccionarInformacion(comando);
            DataTable tabla = empleado.Tables[0];

            return tabla;
        }

        public DataTable FiltrarEmpleado(string empleadoNombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarEmpleado");
            comando.Parameters.AddWithValue("@Empleado_nombre", SqlDbType.VarChar);
            comando.Parameters["@Empleado_nombre"].Value = empleadoNombre;

            comando.Parameters.AddWithValue("@Empleado_estado", SqlDbType.VarChar);
            comando.Parameters["@Empleado_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }
        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarEmpleadosInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string InactivarEmpleado(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Empleado");

            comando.CommandText = "InactivarEmpleado";
            comando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            comando.Parameters["@Empleado_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Empleado";

            Console.WriteLine("Fin Servicio Inactivar Empleado");

            return respuesta;

        }

        public string ActivarEmpleado(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Empleado");

            comando.CommandText = "ActivarEmpleado";
            comando.Parameters.AddWithValue("@Empleado_id", SqlDbType.Int);
            comando.Parameters["@Empleado_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Empleado";

            Console.WriteLine("Fin Servicio Activar Empleado");

            return respuesta;
        }
    }
}
