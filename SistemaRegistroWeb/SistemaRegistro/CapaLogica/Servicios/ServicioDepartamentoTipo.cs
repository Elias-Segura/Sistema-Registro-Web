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
    public class ServicioDepartamentoTipo: servicio ,IDisposable
    {

        /// <summary>
        /// TDepartamentoTipo 
        ///La creación de la tabla TDepartamentoTipo como su nombre lo indica tiene la función de manejar los tipos
        ///de departamento de acuerdo con la organización correspondiente y esta estrictamente relacionada con la 
        ///tabla departamento.
        /// </summary>
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioDepartamentoTipo()
        {

        }

        public DataTable ListarDepartamentoTipo(){
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Tipo Departamento");
            comando.CommandText = "ListarDepartamentoTipo";

            DataSet DepartamentoTipo = new DataSet();
            this.abrirConexion();

            DepartamentoTipo = this.seleccionarInformacion(comando);
            DataTable tabla = DepartamentoTipo.Tables[0];

            return tabla;
        }
    }
}
