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
    public class GestorRol: servicio, IDisposable
    {
        public GestorRol()
        {

        }
        public void Dispose()
        {

        }

        public DataTable ListarRol()
        {
            using (ServicioRol servicioRol = new ServicioRol())
            {
                return servicioRol.ListarRol();
            }
        }
    }
}
