using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaConexion
{
    public class servicio

    {
        private SqlConnection con;

        public servicio()
        {

            con = new SqlConnection(@"Data Source =DESKTOP-P6EV1BL\SQLDEV2019;Initial Catalog=SistemaRegistro; Trusted_Connection = yes; Integrated Security=True");
       

        }
        protected void abrirConexion()
        {
            try
            {
                con.Open();
                System.Diagnostics.Debug.WriteLine("Conexion Abierta");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("error connection");
            }
           

        }
        protected void cerrarConexion()
        {
           

            try
            {
                con.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        protected string ejecutarSentencia(string sentencia)
        {
            SqlCommand comando = new SqlCommand(sentencia, con);
            try
            {
                this.abrirConexion();
                comando.ExecuteScalar();
            }
            catch (Exception)
            {
                this.cerrarConexion();
            }
            this.cerrarConexion();
            return "";
        }
        protected string ejecutarSentencia(SqlCommand comando)
        {
            comando.Connection = con;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 6000;
            try
            {
                this.abrirConexion();
                comando.ExecuteScalar();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.cerrarConexion();
            }

            this.cerrarConexion();
            return "";
        }
        protected DataSet seleccionarInformacion(string sentencia)
        {

            try
            {

                DataSet data = new DataSet();
                SqlCommand sql = con.CreateCommand();
                sql.CommandText = sentencia;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sql;
                sqlDataAdapter.Fill(data);
                return data;
            }
            catch (Exception) 
            {
                return null; 
            }
        }
        protected DataSet seleccionarInformacion(SqlCommand comando)
        {
            DataSet data = new DataSet();
            try
            {
              
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();

                comando.CommandTimeout = 2000;
                comando.Connection = con;

                comando.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand = comando;
                sqlAdapter.Fill(data);

                return data;
            }
            catch (Exception)
            {
                return null; 
            }
           
        }

    }
}
