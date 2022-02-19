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
    public class ServicioDocumentoTipo: servicio ,  IDisposable
    {
        private SqlCommand comando;

        public void Dispose()
        {

        }

        public ServicioDocumentoTipo()
        {

        }

        public DataTable ListarDocumentoTipo()
        {
            comando = new SqlCommand();
            Console.WriteLine("Gestor Listar Tipos de Documentos");
            comando.CommandText = "ListarDocumentoTipo";

            DataSet Documento_Tipo = new DataSet();
            this.abrirConexion();

            Documento_Tipo = this.seleccionarInformacion(comando);
            DataTable tabla = Documento_Tipo.Tables[0];

            return tabla;
        }
    }
}
