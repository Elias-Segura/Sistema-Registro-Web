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
    public class GestorCodigo :  servicio , IDisposable
    {
        public GestorCodigo()
        {

        }
        public void Dispose()
        {

        }

        public string InsertarCodigo(int organizacion_id, string codigo_formato, string codigo_estado)
        {
            Codigo codigo = new Codigo(organizacion_id,codigo_formato,codigo_estado);

            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.InsertarCodigo(codigo);
            }
        }

        public string ModificarCodigo(int codigo_id, int organizacion_id, string codigo_formato, string codigo_estado)
        {
            Codigo codigo = new Codigo(codigo_id, organizacion_id, codigo_formato, codigo_estado);

            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.ModificarCodigo(codigo);
            }
        }

        public DataTable ListarCodigo(string estado)
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.ListarCodigo(estado);
            } 
        }

        public DataSet ContarInactivos()
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.ContarInactivos();
            }
        }

        public DataSet ConsultarCodigo(int id)
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.ConsultarCodigo(id);
            }
        }
        public DataSet ConsultarCodigoOrg(int id)
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.ConsultarCodigoOrg(id);
            }
        }
       
        public DataTable FiltrarCodigo(string formato, string estado)
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.FiltrarCodigo(formato,estado);
            }
        }

        public string InactivarCodigo(int id)
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.InactivarCodigo(id);
            }
        }

        public string ActivarCodigo(int id)
        {
            using (ServicioCodigo servicioCodigo = new ServicioCodigo())
            {
                return servicioCodigo.ActivarCodigo(id);
            }
        }
    }
}
