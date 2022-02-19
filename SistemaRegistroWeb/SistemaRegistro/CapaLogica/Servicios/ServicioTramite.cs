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
    public class ServicioTramite : servicio , IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public ServicioTramite()
        {

        }


        public string InsertarTramite(Tramite tramite)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Tramite");

            comando.CommandText = "InsertarTramite";

            comando.Parameters.Add("Tramite_nombre", SqlDbType.VarChar);
            comando.Parameters["Tramite_nombre"].Value = tramite.Tramite_nombre;

            comando.Parameters.Add("Tramite_descripcion", SqlDbType.VarChar);
            comando.Parameters["Tramite_descripcion"].Value = tramite.Tramite_descripcion;

            comando.Parameters.Add("Tramite_estado", SqlDbType.VarChar);
            comando.Parameters["Tramite_estado"].Value = tramite.Tramite_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Tramite";

            Console.WriteLine("Fin Servicio Insertar Tramite");

            return respuesta;
        }

        public string ModificarTramite(Tramite tramite)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Tramite");

            comando.CommandText = "ModificarTramite";

            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = tramite.Tramite_id;

            comando.Parameters.Add("Tramite_nombre", SqlDbType.VarChar);
            comando.Parameters["Tramite_nombre"].Value = tramite.Tramite_nombre;

            comando.Parameters.Add("Tramite_descripcion", SqlDbType.VarChar);
            comando.Parameters["Tramite_descripcion"].Value = tramite.Tramite_descripcion;

            comando.Parameters.Add("Tramite_estado", SqlDbType.VarChar);
            comando.Parameters["Tramite_estado"].Value = tramite.Tramite_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Tramite";

            Console.WriteLine("Fin Servicio Modificar Tramite");

            return respuesta;
        }

        public DataSet ConsultarTramite(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarTramite"); // cambiar
            comando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            comando.Parameters["@Tramite_id"].Value = id;
            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable ListarTramite(string estado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Tramite");
            comando.CommandText = "ListarTramites";
            comando.Parameters.AddWithValue("@Tramite_estado", SqlDbType.VarChar);
            comando.Parameters["@Tramite_estado"].Value = estado;
            DataSet tramite = new DataSet();
            this.abrirConexion();

            tramite = this.seleccionarInformacion(comando);
            DataTable tabla = tramite.Tables[0];

            return tabla;
        }

        public DataTable FiltrarTramite(string tramiteNombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarTramite");
            
            comando.Parameters.AddWithValue("@Tramite_nombre", SqlDbType.VarChar);
            comando.Parameters["@Tramite_nombre"].Value = tramiteNombre;

            comando.Parameters.AddWithValue("@Tramite_estado", SqlDbType.VarChar);
            comando.Parameters["@Tramite_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public DataTable FiltrarTramiteDepartamento(int id)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("TramitesDepartamento");

            comando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            comando.Parameters["@Departamento_id"].Value = id;

     

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarTramitesInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string InactivarTramite(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Tramite");

            comando.CommandText = "InactivarTramite";
            comando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            comando.Parameters["@Tramite_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Tramite";

            Console.WriteLine("Fin Servicio Inactivar Tramite");

            return respuesta;

        }

        public string ActivarTramite(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Tramite");

            comando.CommandText = "ActivarTramite";
            comando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            comando.Parameters["@Tramite_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Tramite";

            Console.WriteLine("Fin Servicio Activar Tramite");

            return respuesta;

        }

     

    }
}
