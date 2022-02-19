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
    public class ServicioGenero: servicio, IDisposable
    {
        /// <summary>
        /// TGenero
        /// La Tabla TGenero se crea por el motivo que facilita la manipulación de la información 
        /// al momento que el usuario deba elegir su genero desde la interfaz, ya que de no ser así 
        /// dicha información dificultaría poder cargarla desde un ComboBox
        /// </summary>
        /// 
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioGenero()
        {

        }

        public DataTable ListarGenero()
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Genero");
            comando.CommandText = "ListarGeneros";

            DataSet Genero = new DataSet();
            this.abrirConexion();

            Genero = this.seleccionarInformacion(comando);
            DataTable tabla = Genero.Tables[0];

            return tabla;
        }
    }
}
