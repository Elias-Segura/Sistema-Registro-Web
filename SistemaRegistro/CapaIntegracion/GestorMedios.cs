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
    public class GestorMedios:  servicio, IDisposable
    {
        public GestorMedios()
        {

        }
        public void Dispose()
        {

        }

        public DataTable ListarMedios()
        {
            using (ServicioMedios servicioMedios = new ServicioMedios())
            {
                return servicioMedios.ListarMedios();
            }
        }
    }
}
