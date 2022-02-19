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
    public class ServicioOrganizacion: servicio , IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public ServicioOrganizacion()
        {

        }

        public string InsertarOrganizacion(Organizacion organizacion)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Organizacion");

            comando.CommandText = "InsertarOrganizacion";

            comando.Parameters.Add("Organizacion_nombre", SqlDbType.VarChar);
            comando.Parameters["Organizacion_nombre"].Value = organizacion.Organizacion_nombre;

            comando.Parameters.Add("Organizacion_tipo", SqlDbType.VarChar);
            comando.Parameters["Organizacion_tipo"].Value = organizacion.Organizacion_tipo;

            comando.Parameters.Add("Organizacion_descripcion", SqlDbType.VarChar);
            comando.Parameters["Organizacion_descripcion"].Value = organizacion.Organizacion_descripcion;

            comando.Parameters.Add("Organizacion_estado", SqlDbType.VarChar);
            comando.Parameters["Organizacion_estado"].Value = organizacion.Organizacion_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Organizacion";

            Console.WriteLine("Fin Servicio Insertar Organizacion");

            return respuesta;
        }

        public string ModificarOrganizacion(Organizacion organizacion)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Organizacion");

            comando.CommandText = "ModificarOrganizacion";

            comando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            comando.Parameters["Organizacion_id"].Value = organizacion.Organizacion_id;

            comando.Parameters.Add("Organizacion_nombre", SqlDbType.VarChar);
            comando.Parameters["Organizacion_nombre"].Value = organizacion.Organizacion_nombre;

            comando.Parameters.Add("Organizacion_tipo", SqlDbType.VarChar);
            comando.Parameters["Organizacion_tipo"].Value = organizacion.Organizacion_tipo;

            comando.Parameters.Add("Organizacion_descripcion", SqlDbType.VarChar);
            comando.Parameters["Organizacion_descripcion"].Value = organizacion.Organizacion_descripcion;

            comando.Parameters.Add("Organizacion_estado", SqlDbType.VarChar);
            comando.Parameters["Organizacion_estado"].Value = organizacion.Organizacion_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Organizacion";

            Console.WriteLine("Fin Servicio Modificar Organizacion");

            return respuesta;
        }

        public DataSet consultarOrganizacion(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarOrganizacion");
            comando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            comando.Parameters["@Organizacion_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }


        public DataTable ListarOrganizacion(string estado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Organizacion");
            comando.CommandText = "ListarOrganizaciones";
            comando.Parameters.AddWithValue("@Organizacion_estado", SqlDbType.Int);
            comando.Parameters["@Organizacion_estado"].Value = estado;


            DataSet organizacion = new DataSet();
            this.abrirConexion();

            organizacion = this.seleccionarInformacion(comando);
            DataTable tabla = organizacion.Tables[0];

            return tabla;
        }

        public DataTable FiltrarOrganizacion(string organizacionNombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarOrganizacion");
            
            comando.Parameters.AddWithValue("@Organizacion_nombre", SqlDbType.VarChar);
            comando.Parameters["@Organizacion_nombre"].Value = organizacionNombre;

            comando.Parameters.AddWithValue("@Organizacion_estado", SqlDbType.VarChar);
            comando.Parameters["@Organizacion_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }
        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarOrganizacionesInactivas");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string InactivarOrganizacion(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Organizacion");

            comando.CommandText = "InactivarOrganizacion";
            comando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            comando.Parameters["@Organizacion_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Organizacion";

            Console.WriteLine("Fin Servicio Inactivar Organizacion");

            return respuesta;

        }

        public string ActivarOrganizacion(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Organizacion");

            comando.CommandText = "ActivarOrganizacion";
            comando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            comando.Parameters["@Organizacion_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Organizacion";

            Console.WriteLine("Fin Servicio Activar Organizacion");

            return respuesta;
        }
    }
}
  