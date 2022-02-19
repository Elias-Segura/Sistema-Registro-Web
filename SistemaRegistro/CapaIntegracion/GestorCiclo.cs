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
    public class GestorCiclo : servicio , IDisposable
    {
        public GestorCiclo()
        {

        }
        public void Dispose()
        {

        }

        public string InsertarCiclo(int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            Ciclo ciclo = new Ciclo(tramite_id, departamento_id, ciclo_orden, ciclo_estado);

            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.InsertarCiclo(ciclo);
            }
               
        }

        public string ModificarCiclo(int ciclo_id, int tramite_id, int departamento_id, string ciclo_orden, string ciclo_estado)
        {
            Ciclo ciclo = new Ciclo(ciclo_id,tramite_id,departamento_id,ciclo_orden,ciclo_estado);

            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.ModificarCiclo(ciclo);
            }      
        }


        public DataTable ListarCiclo(string estado)
        {
            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.ListarCiclo(estado);
            }      
        }

        public DataSet ConsultarCiclo(int id)
        {
            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.ConsultarCiclo(id);
            }
        }
        public DataSet ContarInactivos()
        {
            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.ContarInactivos();
            }
        }

        public DataTable FiltrarCiclo(string nombre,string estado)
        {
            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.FiltrarCiclo(nombre,estado);
            }
        }
        public string InactivarCiclo(int id)
        {
            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.InactivarCiclo(id);
            }
        }

        public string ActivarCiclo(int id)
        {
            using (ServicioCiclo servicioCiclo = new ServicioCiclo())
            {
                return servicioCiclo.ActivarCiclo(id);
            }
        }
    }
}
