
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
    public class ServicioPuesto: servicio , IDisposable
    {
        /// <summary>
        /// TPuesto 
        /// Al igual que TEstadoCivil el campo Empleado_ puesto puede convertirse en una tabla, 
        /// ya que un puesto puede tener varios empleados y de esta forma se estaría logrando
        /// una correcta manipulación de la información.
        /// </summary>
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioPuesto()
        {

        }

        public DataTable ListarPuesto()
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Puesto");
            comando.CommandText = "ListarPuestos";

            DataSet puesto = new DataSet();
            this.abrirConexion();

            puesto = this.seleccionarInformacion(comando);
            DataTable tabla = puesto.Tables[0];

            return tabla;
        }
    }
}
