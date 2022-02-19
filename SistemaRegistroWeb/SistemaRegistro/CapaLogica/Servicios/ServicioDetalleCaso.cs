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
    public class ServicioDetalleCaso : servicio, IDisposable
    {
        private SqlCommand comando;
        private string respuesta;


        public void Dispose()
        {

        }
        public ServicioDetalleCaso()
        {
            comando = new SqlCommand();
            respuesta = "";
        }

        public string InsertarDetalleCaso(DetalleCaso detalleCaso)
        {
            comando = new SqlCommand();
            Console.WriteLine("Insertando detalle caso");

            comando.CommandText = ("InsertarDetalleCaso");

            comando.Parameters.Add("Caso_id", SqlDbType.Int);
            comando.Parameters["Caso_id"].Value = detalleCaso.Caso_id;

            comando.Parameters.Add("Ciclo_id", SqlDbType.Int);
            comando.Parameters["Ciclo_id"].Value = detalleCaso.Ciclo_id;

            comando.Parameters.Add("Documento_id", SqlDbType.Int);
            comando.Parameters["Documento_id"].Value = detalleCaso.Documento_id;

            comando.Parameters.Add("DetalleCaso_fechaRecibido", SqlDbType.Date);
            comando.Parameters["DetalleCaso_fechaRecibido"].Value = detalleCaso.DetalleCaso_FechaRecibido;

            comando.Parameters.Add("DetalleCaso_fechaTraspaso", SqlDbType.Date);
            comando.Parameters["DetalleCaso_fechaTraspaso"].Value = detalleCaso.DetalleCaso_FechaTraspaso;

            comando.Parameters.Add("DetalleCaso_descripcion", SqlDbType.VarChar);
            comando.Parameters["DetalleCaso_descripcion"].Value = detalleCaso.DetalleCaso_Descripcion;

            comando.Parameters.Add("DetalleCaso_estado", SqlDbType.VarChar);
            comando.Parameters["DetalleCaso_estado"].Value = detalleCaso.DetalleCaso_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
            {
                respuesta = "El detalle caso se insertó correctamente";
            }

            Console.WriteLine("Fin servicio insertar detalle caso.");

            return respuesta;
        }

        public string ModificarDetalleCaso(DetalleCaso detalleCaso)
        {
            comando = new SqlCommand();
            Console.WriteLine("Modificando detalle caso");

            comando.CommandText = ("ModificarDetalleCaso");

            comando.Parameters.Add("DetalleCaso_id", SqlDbType.Int);
            comando.Parameters["DetalleCaso_id"].Value = detalleCaso.DetalleCaso_id;

            comando.Parameters.Add("Caso_id", SqlDbType.Int);
            comando.Parameters["Caso_id"].Value = detalleCaso.Caso_id;

            comando.Parameters.Add("Ciclo_id", SqlDbType.Int);
            comando.Parameters["Ciclo_id"].Value = detalleCaso.Ciclo_id;

            comando.Parameters.Add("Documento_id", SqlDbType.Int);
            comando.Parameters["Documento_id"].Value = detalleCaso.Documento_id;

            comando.Parameters.Add("DetalleCaso_fechaRecibido", SqlDbType.Date);
            comando.Parameters["DetalleCaso_fechaRecibido"].Value = detalleCaso.DetalleCaso_FechaRecibido;

            comando.Parameters.Add("DetalleCaso_fechaTraspaso", SqlDbType.Date);
            comando.Parameters["DetalleCaso_fechaTraspaso"].Value = detalleCaso.DetalleCaso_FechaTraspaso;

            comando.Parameters.Add("DetalleCaso_descripcion", SqlDbType.VarChar);
            comando.Parameters["DetalleCaso_descripcion"].Value = detalleCaso.DetalleCaso_Descripcion;

            comando.Parameters.Add("DetalleCaso_estado", SqlDbType.VarChar);
            comando.Parameters["DetalleCaso_estado"].Value = detalleCaso.DetalleCaso_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
            {
                respuesta = "El detalle caso se modifico correctamente";
            }

            Console.WriteLine("Fin servicio modificar detalle caso.");

            return respuesta;
        }

        public DataSet ConsultarDetalleCaso(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarDetalleCaso");
            comando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.VarChar);
            comando.Parameters["@DetalleCaso_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }


        public DataTable ListarDetalleCasos(string estado)
        {

            DataSet setData = new DataSet();

            comando = new SqlCommand();
            comando.CommandText = ("ListarDetalleCasos");
            comando.Parameters.AddWithValue("@DetalleCaso_estado", SqlDbType.VarChar);
            comando.Parameters["@DetalleCaso_estado"].Value = estado;

            DataSet detalleCaso = new DataSet();
            this.abrirConexion();

            detalleCaso = this.seleccionarInformacion(comando);
            DataTable tabla = detalleCaso.Tables[0];

            return tabla;
        }

        public DataSet ContarInactivos()
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarDetallesCasosInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable FiltrarDatos(string codigo, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarDetalleCaso");
            comando.Parameters.AddWithValue("@Caso_codigo", SqlDbType.VarChar);
            comando.Parameters["@Caso_codigo"].Value = codigo;

            comando.Parameters.AddWithValue("@DetalleCaso_estado", SqlDbType.VarChar);
            comando.Parameters["@DetalleCaso_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }
        public string InactivarDetalleCaso(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar detalle Caso");

            comando.CommandText = "InactivarDetalleCaso";
            comando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.Int);
            comando.Parameters["@DetalleCaso_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar detalle Caso";

            Console.WriteLine("Fin Servicio Inactivar detalle Caso");

            return respuesta;

        }

        public string ActivarDetalleCaso(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar detalle Caso");

            comando.CommandText = "ActivarDetalleCaso";
            comando.Parameters.AddWithValue("@DetalleCaso_id", SqlDbType.Int);
            comando.Parameters["@DetalleCaso_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar detalle Caso";

            Console.WriteLine("Fin Servicio Activar detalle Caso");

            return respuesta;

        }
    }
}
