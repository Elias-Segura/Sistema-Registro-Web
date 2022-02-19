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
    public class ServicioDepartamento : servicio, IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }
        public ServicioDepartamento()
        {

        }

      

        public string InsertarDepartamento(Departamento departamento)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Departamento");

            comando.CommandText = "InsertarDepartamento";

            comando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            comando.Parameters["Organizacion_id"].Value = departamento.Organizacion_id;

            comando.Parameters.Add("DepartamentoTipo_id", SqlDbType.Int);
            comando.Parameters["DepartamentoTipo_id"].Value = departamento.DepartementoTipoID;

            comando.Parameters.Add("Departamento_nombre", SqlDbType.VarChar);
            comando.Parameters["Departamento_nombre"].Value = departamento.Departamento_nombre;

            comando.Parameters.Add("Departamento_descripcion", SqlDbType.VarChar);
            comando.Parameters["Departamento_descripcion"].Value = departamento.Departamento_descripcion;

            comando.Parameters.Add("Departamento_estado", SqlDbType.VarChar);
            comando.Parameters["Departamento_estado"].Value = departamento.Departamento_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Departamento";

            Console.WriteLine("Fin Servicio Insertar Departamento");

            return respuesta;
        }

        public string ModificarDepartamento(Departamento departamento)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Departamento");

            comando.CommandText = "ModificarDepartamento";

            comando.Parameters.Add("Departamento_id", SqlDbType.Int);
            comando.Parameters["Departamento_id"].Value = departamento.Departamento_id;

            comando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            comando.Parameters["Organizacion_id"].Value = departamento.Organizacion_id;

            comando.Parameters.Add("DepartamentoTipo_id", SqlDbType.Int);
            comando.Parameters["DepartamentoTipo_id"].Value = departamento.DepartementoTipoID;

            comando.Parameters.Add("Departamento_nombre", SqlDbType.VarChar);
            comando.Parameters["Departamento_nombre"].Value = departamento.Departamento_nombre;

            comando.Parameters.Add("Departamento_descripcion", SqlDbType.VarChar);
            comando.Parameters["Departamento_descripcion"].Value = departamento.Departamento_descripcion;

            comando.Parameters.Add("Departamento_estado", SqlDbType.VarChar);
            comando.Parameters["Departamento_estado"].Value = departamento.Departamento_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Departamento";

            Console.WriteLine("Fin Servicio Modificar Departamento");

            return respuesta;
        }

        public DataSet ConsultarDepartamento(int id)
       {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarDepartamento");
            comando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            comando.Parameters["@Departamento_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable ListarDepartamento(string estado)
       {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Departamentos");
            comando.CommandText = "ListarDepartamentos";
            comando.Parameters.AddWithValue("@Departamento_estado", SqlDbType.VarChar);
            comando.Parameters["@Departamento_estado"].Value = estado;
            DataSet departamento = new DataSet();
            this.abrirConexion();

            departamento = this.seleccionarInformacion(comando);
            DataTable tabla = departamento.Tables[0];

            return tabla;
        }

        public DataTable FiltrarDepartamento(string departamentoNombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarDepartamento");

            comando.Parameters.AddWithValue("@Departamento_nombre", SqlDbType.VarChar);
            comando.Parameters["@Departamento_nombre"].Value = departamentoNombre;

            comando.Parameters.AddWithValue("@Departamento_estado", SqlDbType.VarChar);
            comando.Parameters["@Departamento_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public DataTable DepartamentoTramitePorOrg(int idOrg, int idTramite) // se obtiene los tramites por departamento y organizacion 
                                                                              //verificar que el departamento tenga el tramite indicado 
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("DepartamentosTramitesPorOrganizacion");

            comando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.VarChar);
            comando.Parameters["@Organizacion_id"].Value =idOrg;
            comando.Parameters.AddWithValue("@Tramite_id", SqlDbType.VarChar);
            comando.Parameters["@Tramite_id"].Value = idTramite;

            this.abrirConexion();

            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];

            return data;
        }

        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarDepartamentosInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string InactivarDepartamento(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Departamento");

            comando.CommandText = "InactivarDepartamento";
            comando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            comando.Parameters["@Departamento_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Departamento";

            Console.WriteLine("Fin Servicio Inactivar Departamento");

            return respuesta;

        }

        public string ActivarDepartamento(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Departamento");

            comando.CommandText = "ActivarDepartamento";
            comando.Parameters.AddWithValue("@Departamento_id", SqlDbType.Int);
            comando.Parameters["@Departamento_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Departamento";

            Console.WriteLine("Fin Servicio Activar Departamento");

            return respuesta;

        }
    }
}
