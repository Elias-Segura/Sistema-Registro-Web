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
    public class GestorGenero: servicio, IDisposable
    {
        public GestorGenero()
        {

        }
        public void Dispose()
        {

        }

        public DataTable ListarGenero()
        {
            using (ServicioGenero servicioGenero = new ServicioGenero())
            {
                return servicioGenero.ListarGenero();
            }
        }
    }
}
