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
    public class ServicioDocumento : servicio, IDisposable
    {
        private SqlCommand comando;
        private string respuesta;


        public void Dispose()
        {

        }
        public ServicioDocumento()
        {
            comando = new SqlCommand();
            respuesta = "";
        }

        public string InsertarDocumento(Documento documento)
        {

            comando = new SqlCommand();
            Console.WriteLine("Gestor insertar Documento");

            comando.CommandText = ("InsertarDocumento");

            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = documento.Tramite_id;

            comando.Parameters.Add("Idioma_id", SqlDbType.Int);
            comando.Parameters["Idioma_id"].Value = documento.Idioma_id;

            comando.Parameters.Add("Medio_id", SqlDbType.Int);
            comando.Parameters["Medio_id"].Value = documento.Medio_id;

            comando.Parameters.Add("Documento_nombre", SqlDbType.VarChar);
            comando.Parameters["Documento_nombre"].Value = documento.Documento_nombre;

            comando.Parameters.Add("Documento_ruta", SqlDbType.VarChar);
            comando.Parameters["Documento_ruta"].Value = documento.Documento_ruta;

            comando.Parameters.Add("Documento_tipo", SqlDbType.VarChar);
            comando.Parameters["Documento_tipo"].Value = documento.Documento_tipo;

            comando.Parameters.Add("Documento_estado", SqlDbType.VarChar);
            comando.Parameters["Documento_estado"].Value = documento.Documento_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Documento";

            Console.WriteLine("Fin Servicio Insertar Documento");

            return respuesta;
        }

        public string ModificarDocumento(Documento documento)
        {

            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Documento");

            comando.CommandText = ("ModificarDocumento");

            comando.Parameters.Add("Documento_id", SqlDbType.Int);
            comando.Parameters["Documento_id"].Value = documento.Documento_id;

            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = documento.Tramite_id;

            comando.Parameters.Add("Idioma_id", SqlDbType.Int);
            comando.Parameters["Idioma_id"].Value = documento.Idioma_id;

            comando.Parameters.Add("Medio_id", SqlDbType.Int);
            comando.Parameters["Medio_id"].Value = documento.Medio_id;

            comando.Parameters.Add("Documento_nombre", SqlDbType.VarChar);
            comando.Parameters["Documento_nombre"].Value = documento.Documento_nombre;

            comando.Parameters.Add("Documento_ruta", SqlDbType.VarChar);
            comando.Parameters["Documento_ruta"].Value = documento.Documento_ruta;

            comando.Parameters.Add("Documento_tipo", SqlDbType.VarChar);
            comando.Parameters["Documento_tipo"].Value = documento.Documento_tipo;

            comando.Parameters.Add("Documento_estado", SqlDbType.VarChar);
            comando.Parameters["Documento_estado"].Value = documento.Documento_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Documento";

            Console.WriteLine("Fin Servicio Modificar Documento");

            return respuesta;
        }

        public DataSet ConsultarDocumento(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarDocumento");
            comando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            comando.Parameters["@Documento_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable ListarDocumentos(string estado)
        {
            DataSet setData = new DataSet();

            comando = new SqlCommand();
            comando.CommandText = ("ListarDocumentos");
            comando.Parameters.AddWithValue("@Documento_estado", SqlDbType.VarChar);
            comando.Parameters["@Documento_estado"].Value = estado;
            this.abrirConexion();

            setData = this.seleccionarInformacion(comando);

            DataTable data = setData.Tables[0];

            return data;
        }
        public DataTable FiltrarDocumentos(string nombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarDocumento");

            comando.Parameters.AddWithValue("@Caso_codigo", SqlDbType.VarChar);
            comando.Parameters["@Caso_codigo"].Value = nombre;

            comando.Parameters.AddWithValue("@Documento_estado", SqlDbType.VarChar);
            comando.Parameters["@Documento_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarDocumentosInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }
        public string InactivarDocumento(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Documento");

            comando.CommandText = "InactivarDocumento";
            comando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            comando.Parameters["@Documento_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Documento";

            Console.WriteLine("Fin Servicio Inactivar Documento");

            return respuesta;

        }

        public string ActivarDocumento(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Documento");

            comando.CommandText = "ActivarDocumento";
            comando.Parameters.AddWithValue("@Documento_id", SqlDbType.Int);
            comando.Parameters["@Documento_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion activar Documento";

            Console.WriteLine("Fin Servicio activar Documento");

            return respuesta;

        }
    }
}
