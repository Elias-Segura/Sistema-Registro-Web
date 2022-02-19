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
    public class ServicioCaso:servicio, IDisposable
    {

        private SqlCommand comando;
        private string respuesta; 


        public void Dispose()
        {

        }
        public ServicioCaso()
        {
            comando = new SqlCommand();
            respuesta = ""; 
        }

        public string InsertarCaso(Caso caso) ///insertar casos 
        {

            comando = new SqlCommand();
            Console.WriteLine("Insertando caso");

            comando.CommandText = ("InsertarCaso");

            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = caso.tramite_id;

            comando.Parameters.Add("Caso_codigo", SqlDbType.VarChar);
            comando.Parameters["Caso_codigo"].Value = caso.caso_codigo;

            comando.Parameters.Add("Caso_fechaInicio", SqlDbType.Date);
            comando.Parameters["Caso_fechaInicio"].Value = caso.caso_fechaInicio;

            comando.Parameters.Add("Caso_fechaFinal", SqlDbType.Date);
            comando.Parameters["Caso_fechaFinal"].Value = caso.caso_fechaFinal;

            comando.Parameters.Add("Caso_estado", SqlDbType.VarChar);
            comando.Parameters["Caso_estado"].Value = caso.caso_estado;

            respuesta = this.ejecutarSentencia(comando);

            if(respuesta == "")
            {
                respuesta = "El caso se insertó correctamente";
            }

            Console.WriteLine("Fin servicio insertar caso.");

            return respuesta; 

        }


        public string ModificarCaso(Caso caso) ///Funcion para modificar un caso 
        {


            comando = new SqlCommand();
            Console.WriteLine("Moficando caso");

            comando.CommandText = ("ModificarCaso");

            comando.Parameters.Add("Caso_id", SqlDbType.Int);
            comando.Parameters["Caso_id"].Value = caso.caso_id;


            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = caso.tramite_id;

            comando.Parameters.Add("Caso_codigo", SqlDbType.VarChar);
            comando.Parameters["Caso_codigo"].Value = caso.caso_codigo;

            comando.Parameters.Add("Caso_fechaInicio", SqlDbType.Date);
            comando.Parameters["Caso_fechaInicio"].Value = caso.caso_fechaInicio;

            comando.Parameters.Add("Caso_fechaFinal", SqlDbType.Date);
            comando.Parameters["Caso_fechaFinal"].Value = caso.caso_fechaFinal;

            comando.Parameters.Add("Caso_estado", SqlDbType.VarChar);
            comando.Parameters["Caso_estado"].Value = caso.caso_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
            {
                respuesta = "El caso se modificó correctamente";
            }
            Console.WriteLine("Fin servicio modificar caso.");
            return respuesta;

        }
        public DataSet ConsultarCaso(int id) ///obtener un caso en especificio
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarCaso"); 
            comando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            comando.Parameters["@Caso_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataSet ContarInactivos() // funcion para mostrar la cantidad de inactivos en el historial de recuperacion. 
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarCasosInactivos"); 
          
            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public DataTable ListarCasos(string estado) // se obtienen todos los datos de los casos
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("ListarCasos"); 
            comando.Parameters.AddWithValue("@Caso_estado", SqlDbType.VarChar);
            comando.Parameters["@Caso_estado"].Value =estado;
            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public DataTable ListarCasosDetalleCasos(string estado) // 
        {

            DataSet setData = new DataSet();

            comando = new SqlCommand();
            comando.CommandText = ("ListarCasosDetalleCaso");
            comando.Parameters.AddWithValue("@Caso_estado", SqlDbType.VarChar);
            comando.Parameters["@Caso_estado"].Value = estado;

            DataSet detalleCaso = new DataSet();
            this.abrirConexion();

            detalleCaso = this.seleccionarInformacion(comando);
            DataTable tabla = detalleCaso.Tables[0];

            return tabla;
        }

        public DataTable GenerarCodigo(int id) /// busca los codigos de una organizacion en la tabla de casos
                                                 ///y genera un codigo respecto al formato y al ultimo insertado
        {
                DataSet setData = new DataSet();
                comando = new SqlCommand();
                comando.CommandText = ("GenerarCodigos"); 
                comando.Parameters.AddWithValue("@Organizacion_id", SqlDbType.Int);
                comando.Parameters["@Organizacion_id"].Value = id;
                this.abrirConexion();
                setData = this.seleccionarInformacion(comando);
                DataTable data = setData.Tables[0];
                return data;   
        }

        public DataTable FiltrarDatos(string codigo, string estado) ///filtrar datos por codigo 
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarCaso");
            
            comando.Parameters.AddWithValue("@Caso_codigo", SqlDbType.VarChar);
            comando.Parameters["@Caso_codigo"].Value = codigo;

            comando.Parameters.AddWithValue("@Caso_estado", SqlDbType.VarChar);
            comando.Parameters["@Caso_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public DataTable FiltrarCasoTramite(int id) /// casos por tramite
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarCasoTramite");
            comando.Parameters.AddWithValue("@Tramite_id", SqlDbType.Int);
            comando.Parameters["@Tramite_id"].Value = id;
            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }


        public string InactivarCaso(int id) /// inactivar casos  
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Caso");

            comando.CommandText = "InactivarCaso";
            comando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            comando.Parameters["@Caso_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Caso";

            Console.WriteLine("Fin Servicio Inactivar Caso");

            return respuesta;

        }
        public string ActivarCaso(int id) /// activar caso 
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Caso");

            comando.CommandText = "ActivarCaso";
            comando.Parameters.AddWithValue("@Caso_id", SqlDbType.Int);
            comando.Parameters["@Caso_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Caso";

            Console.WriteLine("Fin Servicio Activar Caso");

            return respuesta;

        }

    }
}
