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
    public class ServicioIdioma : servicio , IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public ServicioIdioma()
        {

        }


        public string InsertarIdioma(Idioma idioma)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Idioma");

            comando.CommandText = "InsertarIdioma";

            comando.Parameters.Add("Idioma_nombre", SqlDbType.VarChar);
            comando.Parameters["Idioma_nombre"].Value = idioma.Idioma_nombre;

            comando.Parameters.Add("Idioma_iniciales", SqlDbType.VarChar);
            comando.Parameters["Idioma_iniciales"].Value = idioma.Idioma_iniciales;

            comando.Parameters.Add("Idioma_estado", SqlDbType.VarChar);
            comando.Parameters["Idioma_estado"].Value = idioma.Idioma_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Idioma";

            Console.WriteLine("Fin Servicio Insertar Idioma");

            return respuesta;
        }

        public string ModificarIdioma(Idioma idioma)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Idioma");

            comando.CommandText = "ModificarIdioma";

            comando.Parameters.Add("Idioma_id", SqlDbType.Int);
            comando.Parameters["Idioma_id"].Value = idioma.Idioma_id;

            comando.Parameters.Add("Idioma_nombre", SqlDbType.VarChar);
            comando.Parameters["Idioma_nombre"].Value = idioma.Idioma_nombre;

            comando.Parameters.Add("Idioma_iniciales", SqlDbType.VarChar);
            comando.Parameters["Idioma_iniciales"].Value = idioma.Idioma_iniciales;

            comando.Parameters.Add("Idioma_estado", SqlDbType.VarChar);
            comando.Parameters["Idioma_estado"].Value = idioma.Idioma_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Idioma";

            Console.WriteLine("Fin Servicio Modificar Idioma");

            return respuesta;
        }


        public DataSet ConsultarIdioma(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarIdioma");
            comando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            comando.Parameters["@Idioma_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable ListarIdioma(string estado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Idioma");
            comando.CommandText = "ListarIdiomas";
            comando.Parameters.AddWithValue("@Idioma_estado", SqlDbType.VarChar);
            comando.Parameters["@Idioma_estado"].Value = estado;
            DataSet idioma = new DataSet();
            this.abrirConexion();

            idioma = this.seleccionarInformacion(comando);
            DataTable tabla = idioma.Tables[0];

            return tabla;
        }

        public DataTable FiltrarIdioma(string nombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarIdioma");
            comando.Parameters.AddWithValue("@Idioma_nombre", SqlDbType.VarChar);
            comando.Parameters["@Idioma_nombre"].Value = nombre;

            comando.Parameters.AddWithValue("@Idioma_estado", SqlDbType.VarChar);
            comando.Parameters["@Idioma_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }
        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarIdiomasInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string InactivarIdioma(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Idioma");

            comando.CommandText = "InactivarIdioma";
            comando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            comando.Parameters["@Idioma_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Idioma";

            Console.WriteLine("Fin Servicio Inactivar Idioma");

            return respuesta;

        }

        public string ActivarIdioma(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Idioma");

            comando.CommandText = "ActivarIdioma";
            comando.Parameters.AddWithValue("@Idioma_id", SqlDbType.Int);
            comando.Parameters["@Idioma_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Idioma";

            Console.WriteLine("Fin Servicio Activar Idioma");

            return respuesta;
        }
    }
}
