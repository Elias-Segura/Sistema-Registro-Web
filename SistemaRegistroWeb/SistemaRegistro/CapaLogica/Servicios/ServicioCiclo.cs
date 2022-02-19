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
    public class ServicioCiclo : servicio , IDisposable
    {
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public ServicioCiclo()
        {

        }

        public string InsertarCiclo(Ciclo ciclo) ///insertar ciclo
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Ciclo");

            comando.CommandText = "InsertarCiclo";

            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = ciclo.Tramite_id;

             comando.Parameters.Add("Departamento_id", SqlDbType.Int);
            comando.Parameters["Departamento_id"].Value = ciclo.Departamento_id;

            comando.Parameters.Add("Ciclo_orden", SqlDbType.VarChar);
            comando.Parameters["Ciclo_orden"].Value = ciclo.Ciclo_orden;

            comando.Parameters.Add("Ciclo_estado", SqlDbType.VarChar);
            comando.Parameters["Ciclo_estado"].Value = ciclo.Ciclo_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Ciclo";

            Console.WriteLine("Fin Servicio Insertar Ciclo");

            return respuesta;
        }

        public string ModificarCiclo(Ciclo ciclo) ///modificar ciclo
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Ciclo");

            comando.CommandText = "ModificarCiclo";

            comando.Parameters.Add("Ciclo_id", SqlDbType.Int);
            comando.Parameters["Ciclo_id"].Value = ciclo.Ciclo_id;

            comando.Parameters.Add("Tramite_id", SqlDbType.Int);
            comando.Parameters["Tramite_id"].Value = ciclo.Tramite_id;

            comando.Parameters.Add("Departamento_id", SqlDbType.Int);
            comando.Parameters["Departamento_id"].Value = ciclo.Departamento_id;

            comando.Parameters.Add("Ciclo_orden", SqlDbType.VarChar);
            comando.Parameters["Ciclo_orden"].Value = ciclo.Ciclo_orden;

            comando.Parameters.Add("Ciclo_estado", SqlDbType.VarChar);
            comando.Parameters["Ciclo_estado"].Value = ciclo.Ciclo_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Ciclo";

            Console.WriteLine("Fin Servicio Modificar Ciclo");

            return respuesta;
        }


        public DataSet ConsultarCiclo(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarCiclo");
            comando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            comando.Parameters["@Ciclo_id"].Value = id;
            DataSet data = new DataSet();

            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;
        }

        public DataTable ListarCiclo(string estado)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Ciclos");
            comando.CommandText = "ListarCiclos";
            comando.Parameters.AddWithValue("@Ciclo_estado", SqlDbType.VarChar);
            comando.Parameters["@Ciclo_estado"].Value = estado;
            DataSet ciclo = new DataSet();
            this.abrirConexion();

            ciclo = this.seleccionarInformacion(comando);
            DataTable tabla = ciclo.Tables[0];

            return tabla;
        }

        public DataTable FiltrarCiclo(string departamentoNombre, string estado) // filtrado de ciclo por nombre de departamento 
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarCiclo"); 

            comando.Parameters.AddWithValue("@Departamento_nombre", SqlDbType.VarChar);
            comando.Parameters["@Departamento_nombre"].Value = departamentoNombre;

            comando.Parameters.AddWithValue("@Ciclo_estado", SqlDbType.VarChar);
            comando.Parameters["@Ciclo_estado"].Value = estado;

            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public string InactivarCiclo(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Ciclo");

            comando.CommandText = "InactivarCiclo";
            comando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            comando.Parameters["@Ciclo_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Ciclo";

            Console.WriteLine("Fin Servicio Inactivar Ciclo");

            return respuesta;

        }
        public DataSet ContarInactivos() ///cuenta inactivos para el historial 
        {
            comando = new SqlCommand();
            comando.CommandText = ("ContarCiclosInactivos");

            DataSet data = new DataSet();
            this.abrirConexion();
            data = this.seleccionarInformacion(comando);
            this.cerrarConexion();

            return data;


        }
        public string ActivarCiclo(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Ciclo");

            comando.CommandText = "ActivarCiclo";
            comando.Parameters.AddWithValue("@Ciclo_id", SqlDbType.Int);
            comando.Parameters["@Ciclo_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Ciclo";

            Console.WriteLine("Fin Servicio Activar Ciclo");

            return respuesta;
        }
    }
}
