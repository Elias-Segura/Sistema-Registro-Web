using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;

namespace SistemaRegistro.CapaIntegracion
{
    public class GestorDocumentoTipo
    {
        public GestorDocumentoTipo()
        {

        }
        public void Dispose()
        {

        }

        public DataTable ListarDocumentoTipo()
        {
            using (ServicioDocumentoTipo servicioDocumentoTipo = new ServicioDocumentoTipo())
            {
                return servicioDocumentoTipo.ListarDocumentoTipo();
            }
        }
    }
}
