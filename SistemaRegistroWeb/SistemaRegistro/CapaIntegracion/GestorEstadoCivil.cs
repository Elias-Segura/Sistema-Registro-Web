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
    public class GestorEstadoCivil: servicio, IDisposable
    {
        public GestorEstadoCivil()
        {

        }

        public void Dispose()
        {

        }

        public DataTable ListarEstadoCivil()
        {
            using (ServicioEstadoCivil servicioEstadoCivil = new ServicioEstadoCivil())
            {
                return servicioEstadoCivil.ListarEstadoCivil();
            }
        }

    }
}
