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
    public class GestorDepartamentoTipo:  servicio ,IDisposable
    {
        public GestorDepartamentoTipo()
        {

        }
        public void Dispose()
        {

        }
        public DataTable ListarDepartamentoTipo()
        {
            using (ServicioDepartamentoTipo servicioDepartamentoTipo = new ServicioDepartamentoTipo())
            {
                return servicioDepartamentoTipo.ListarDepartamentoTipo();
            }
        }
    }
}
