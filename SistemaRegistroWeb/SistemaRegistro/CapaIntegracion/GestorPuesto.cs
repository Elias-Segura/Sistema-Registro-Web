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
    public class GestorPuesto:servicio, IDisposable
    {
        public GestorPuesto()
        {

        }
        public void Dispose()
        {

        }

        public DataTable ListarPuesto()
        {
            using (ServicioPuesto servicioPuesto = new ServicioPuesto())
            {
                return servicioPuesto.ListarPuesto();
            }
        }
    }
}
