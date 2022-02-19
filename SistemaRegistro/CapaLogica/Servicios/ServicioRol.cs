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
    public class ServicioRol :  servicio , IDisposable
    {

        /// <summary>
        /// TRol 
        ///De acuerdo con lo solicitado en la descripción del proyecto se hace indispensable la creación de la tabla
        ///TRol en vista que el sistema podrá manejar distintos tipos de usuario y también para mantener una correcta 
        ///manipulación de la información. 
        /// </summary>
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioRol()
        {

        }

        public DataTable ListarRol()
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Roles");
            comando.CommandText = "ListarRoles";

            DataSet Rol = new DataSet();
            this.abrirConexion();

            Rol = this.seleccionarInformacion(comando);
            DataTable tabla = Rol.Tables[0];

            return tabla;
        } 
    }
}
