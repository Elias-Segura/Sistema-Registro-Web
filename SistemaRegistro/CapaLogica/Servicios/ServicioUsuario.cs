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
    public class ServicioUsuario:  servicio , IDisposable
    {
        /// <summary>
        /// TUsuario 
        ///Tabla encarga de almacenar la información referente a los usuarios permitiendo de esta forma una 
        ///correcta manipulación y normalización de la base de datos, la misma está compuesta por los siguientes 
        ///campos: Rol, nombre del usuario, primer apellido, segundo apellido, contraseña y por último un estado
        ///con la función de indicar cuando un usuario esta activo o bien inactivo.
        /// </summary>
        private SqlCommand comando;
        private string respuesta;

        public void Dispose()
        {

        }

        public ServicioUsuario()
        {

        }

        public string InsertarUsuario(Usuario usuario)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Insertar Usuario");

            comando.CommandText = "InsertarUsuario";

            comando.Parameters.Add("Rol_id", SqlDbType.Int);
            comando.Parameters["Rol_id"].Value = usuario.Rol_id;

            comando.Parameters.Add("Usuario_nombre", SqlDbType.VarChar);
            comando.Parameters["Usuario_nombre"].Value = usuario.Usuario_nombre;

            comando.Parameters.Add("Usuario_primerApellido", SqlDbType.VarChar);
            comando.Parameters["Usuario_primerApellido"].Value = usuario.Usuario_primerApellido;

            comando.Parameters.Add("Usuario_segundoApellido", SqlDbType.VarChar);
            comando.Parameters["Usuario_segundoApellido"].Value = usuario.Usuario_segundoApellido;

            comando.Parameters.Add("Usuario_contrasenna", SqlDbType.VarChar);
            comando.Parameters["Usuario_contrasenna"].Value = usuario.Usuario_contrasenna;

            comando.Parameters.Add("Usuario_estado", SqlDbType.VarChar);
            comando.Parameters["Usuario_estado"].Value = usuario.Usuario_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Insertar Usuario";

            Console.WriteLine("Fin Servicio Insertar Usuario");

            return respuesta;
        }

        public string ModificarUsuario(Usuario usuario)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Modificar Usuario");

            comando.CommandText = "ModificarUsuario";

            comando.Parameters.Add("Usuario_id", SqlDbType.Int);
            comando.Parameters["Usuario_id"].Value = usuario.Usuario_id;

            comando.Parameters.Add("Rol_id", SqlDbType.Int);
            comando.Parameters["Rol_id"].Value = usuario.Rol_id;

            comando.Parameters.Add("Usuario_nombre", SqlDbType.VarChar);
            comando.Parameters["Usuario_nombre"].Value = usuario.Usuario_nombre;

            comando.Parameters.Add("Usuario_primerApellido", SqlDbType.VarChar);
            comando.Parameters["Usuario_primerApellido"].Value = usuario.Usuario_primerApellido;

            comando.Parameters.Add("Usuario_segundoApellido", SqlDbType.VarChar);
            comando.Parameters["Usuario_segundoApellido"].Value = usuario.Usuario_segundoApellido;

            comando.Parameters.Add("Usuario_contrasenna", SqlDbType.VarChar);
            comando.Parameters["Usuario_contrasenna"].Value = usuario.Usuario_contrasenna;

            comando.Parameters.Add("Usuario_estado", SqlDbType.VarChar);
            comando.Parameters["Usuario_estado"].Value = usuario.Usuario_estado;

            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Modificar Usuario";

            Console.WriteLine("Fin Servicio Modificar Usuario");

            return respuesta;
        }

        public DataSet ConsultarUsuario(int id)
        {
            comando = new SqlCommand();
            comando.CommandText = ("BuscarUsuario");
            comando.Parameters.AddWithValue("@Usuario_id", SqlDbType.Int);
            comando.Parameters["@Usuario_id"].Value = id;
            
            DataSet data = new DataSet();

            this.abrirConexion();

            data = this.seleccionarInformacion(comando);

            this.cerrarConexion();

            return data;
        }

        public DataTable ListarUsuario(string estado)
        {
            DataSet setData = new DataSet();
            Console.WriteLine("Gestor Listar Usuario");

            comando = new SqlCommand();
            comando.CommandText = ("ListarUsuarios"); //cambiar
            comando.Parameters.AddWithValue("@Usuario_estado", SqlDbType.VarChar);
            comando.Parameters["@Usuario_estado"].Value = estado;
            this.abrirConexion();

            setData = this.seleccionarInformacion(comando);

            DataTable data = setData.Tables[0];

            return data;
        }

        public DataTable FiltrarUsuario(string usuarioNombre, string estado)
        {
            DataSet setData = new DataSet();
            comando = new SqlCommand();
            comando.CommandText = ("FiltrarUsuario");
            comando.Parameters.AddWithValue("@Usuario_nombre", SqlDbType.VarChar);
            comando.Parameters["@Usuario_nombre"].Value = usuarioNombre;

            comando.Parameters.AddWithValue("@Usuario_estado", SqlDbType.VarChar);
            comando.Parameters["@Usuario_estado"].Value = estado;


            this.abrirConexion();
            setData = this.seleccionarInformacion(comando);
            DataTable data = setData.Tables[0];
            return data;
        }

        public string InactivarUsuario(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Inactivar Usuario");

            comando.CommandText = "InactivarUsuario";
            comando.Parameters.AddWithValue("@Usuario_id", SqlDbType.Int);
            comando.Parameters["@Usuario_id"].Value = id;
      
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Inactivar Usuario";

            Console.WriteLine("Fin Servicio Inactivar Usuario");

            return respuesta;

        }
        public string ActivarUsuario(int id)
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Activar Usuario");

            comando.CommandText = "ActivarUsuario";
            comando.Parameters.AddWithValue("@Usuario_id", SqlDbType.Int);
            comando.Parameters["@Usuario_id"].Value = id;
            respuesta = this.ejecutarSentencia(comando);

            if (respuesta == "")
                respuesta += "Se ha realizado correctamente la transaccion Activar Usuario";

            Console.WriteLine("Fin Servicio Activar Usuario");

            return respuesta;

        }


        public DataSet verificarUsuario(string nombre, string contrasenna)
        {
           
            comando = new SqlCommand();
            comando.CommandText = ("VerificarUsuario"); // cambiar
            comando.Parameters.AddWithValue("@Usuario_nombre", SqlDbType.VarChar);
            comando.Parameters["@Usuario_nombre"].Value = nombre;
            comando.Parameters.AddWithValue("@Usuario_contrasenna", SqlDbType.VarChar);
            comando.Parameters["@Usuario_contrasenna"].Value = contrasenna;
      
            DataSet data = new DataSet();
            
            this.abrirConexion();
            
            data = this.seleccionarInformacion(comando);
            
            this.cerrarConexion();

            return data;
        }


    }
}
