
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;


namespace SistemaRegistro.CapaIntegracion


{
   public class GestorCaso:servicio, IDisposable 
    {
        public GestorCaso()
        {

        }

        public void Dispose()
        {

        }

        public string InsertarCaso(int tramite_id, string caso_codigo, DateTime fechaInicio, DateTime fechaFinal, string caso_estado)
        {

            Caso caso = new Caso(tramite_id, caso_codigo, fechaInicio, fechaFinal, caso_estado); 
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.InsertarCaso(caso); 
            }
        }


        public string ModificarCaso(int caso_id,int tramite_id, string caso_codigo, DateTime fechaInicio, DateTime fechaFinal, string caso_estado)
        {

            Caso caso = new Caso(caso_id, tramite_id, caso_codigo, fechaInicio, fechaFinal, caso_estado);
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.ModificarCaso(caso);
            }
        }

        public DataTable listarCasos(string  estado)
        {
            using(ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.ListarCasos(estado);
            }
        }

        public DataTable listarCasosDetalleCasos(string estado)
        {
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.ListarCasosDetalleCasos(estado);
            }
        }

        public DataTable FiltrarCasoTramite(int id)
        {
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.FiltrarCasoTramite(id); 
            }
        }

        public DataTable GenerarCodigo(int id)
        {
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.GenerarCodigo(id); 
            }
        }
        public DataSet ConsultarCaso(int id)
        {
            using(ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.ConsultarCaso(id); 
            }
        }



        public DataSet ContarInactivos()
        {
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.ContarInactivos();
            }
        }
        public DataTable FiltrarCasos(string codigo, string estado)
        {
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.FiltrarDatos(codigo,estado);
            }
        }

        public string InactivarCaso(int id)
        {
            using(ServicioCaso servicioCaso =  new ServicioCaso())
            {
                return servicioCaso.InactivarCaso(id);
            }
        }

        public string ActivarCaso(int id)
        {
            using (ServicioCaso servicioCaso = new ServicioCaso())
            {
                return servicioCaso.ActivarCaso(id);
            }
        }
    }
}
