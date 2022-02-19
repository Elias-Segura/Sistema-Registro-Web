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
    public class ServicioCodigo :  servicio ,IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public string InsertarCodigo(Codigo codigo)
        {   
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Codigo");
            
            comando.CommandText = "InsertarCodigo";
            
            comando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            comando.Parameters["Organizacion_id"].Value = codigo.Organizacion_id;

            comando.Parameters.Add("Codigo_formato", SqlDbType.VarChar);
            comando.Parameters["Codigo_formato"].Value = codigo.Codigo_formato;

            comando.Parameters.Add("Codigo_estado", SqlDbType.VarChar);
            comando.Parameters["Codigo_estado"].Value = codigo.Codigo_estado;


            respuesta = this.ejecutarSentencia(comando);
            
            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Codigo";
            
            Console.WriteLine("Fin Servicio Insertar Codigo");
            
            return respuesta;
        }

        public string ModificarCodigo(Codigo codigo)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Codigo");

            comando.CommandText = "ModificarCodigo";

            comando.Parameters.Add("Codigo_id", SqlDbType.Int);
            comando.Parameters["Codigo_id"].Value = codigo.Codigo_id;

            comando.Parameters.Add("Organizacion_id", SqlDbType.Int);
            comando.Parameters["Organizacion_id"].Value = codigo.Organizacion_id;

            comando.Parameters.Add("Codigo_formato", SqlDbType.VarChar);
            comando.Parameters["Codigo_formato"].Value = codigo.Codigo_formato;

            comando.Parameters.Add("Codigo_estado", SqlDbType.VarChar);
            comando.Parameters["Codigo_estado"].Value = codigo.Codigo_estado;


            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Codigo";

            Console.WriteLine("Fin Servicio Modificar Codigo");

            return respuesta;
        }


        public DataSet ConsultarCodigo(int id)
       {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarCodigo");
            comando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            comando.Parameters["@Codigo_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }
        public DataSet ConsultarCodigoOrg(int id)///obtiene formato de codigo de una organizacion 
        {
            comando = new SqlCommand();
            comando.CommandText = ("ConsultarCodigoOrg");
            comando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
            comando.Parameters["@Organizacion_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

       
        public DataTable ListarCodigo(string estado)
       {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Codigo");
            
            comando.CommandText = "ListarCodigos";
            
            comando.Parameters.AddWithValue("@Codigo_estado", SqlDbType.VarChar);
            comando.Parameters["@Codigo_estado"].Value = estado;

            DataSet codigo = new DataSet();
            this.abrirConexion();

            codigo = this.seleccionarInformacion(comando);
            DataTable tabla = codigo.Tables[0];

            return tabla;
        }

        public DataTable FiltrarCodigo(string codigoFormato, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarCodigo");

            comando.Parameters.AddWithValue("@Codigo_formato", SqlDbType.VarChar);
            comando.Parameters["@Codigo_formato"].Value = codigoFormato;

            comando.Parameters.AddWithValue("@Codigo_estado", SqlDbType.VarChar);
            comando.Parameters["@Codigo_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }
        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarCodigosInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string InactivarCodigo(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Codigo");

            comando.CommandText = "InactivarCodigo";
            comando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            comando.Parameters["@Codigo_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Codigo";

            Console.WriteLine("Fin Servicio Inactivar Codigo");

            return respuesta;

        }

        public string ActivarCodigo(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Codigo");

            comando.CommandText = "ActivarCodigo";
            comando.Parameters.AddWithValue("@Codigo_id", SqlDbType.Int);
            comando.Parameters["@Codigo_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Codigo";

            Console.WriteLine("Fin Servicio Activar Codigo");

            return respuesta;
        }
    }

}
