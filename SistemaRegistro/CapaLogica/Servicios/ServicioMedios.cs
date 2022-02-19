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
    public class ServicioMedios: servicio, IDisposable
    {
        /// <summary>
        /// TMedio
        ///En vista que la tabla documentos debe llevar los medios, es decir si son de tipo físicos o bien de 
        ///correo electrónico se considera necesario la creación de la tabla TMedio la cual es la encargada de 
        ///manipular toda la información referente a los mismos.
        /// </summary>
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioMedios()
        {

        }

        public DataTable ListarMedios()
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Medios");
            comando.CommandText = "ListarMedios";

            DataSet medios = new DataSet();
            this.abrirConexion();

            medios = this.seleccionarInformacion(comando);
            DataTable tabla = medios.Tables[0];

            return tabla;
        }
    }
}
