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
    public class ServicioEstadoCivil: servicio , IDisposable
    {

        /// <summary>
        ///  TEstadoCivil
        ///  De acuerdo con la table empleado, se puede observar que el campo del Empleado_estadoCivil se puede
        ///  convertir en una tabla para una correcta normalización de la base de datos, ya que un estado civil 
        ///  puede ser el mismo para varios empleados.
        /// </summary>
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioEstadoCivil()
        {

        }

        public DataTable ListarEstadoCivil()
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Estado Civil");
            comando.CommandText = "ListarEstadosCivil";

            DataSet estadoCivil = new DataSet();
            this.abrirConexion();

            estadoCivil = this.seleccionarInformacion(comando);
            DataTable tabla = estadoCivil.Tables[0];

            return tabla;
        }
    }
}
