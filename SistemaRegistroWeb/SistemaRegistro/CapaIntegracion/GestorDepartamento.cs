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
    public class GestorDepartamento : servicio, IDisposable
    {
        public GestorDepartamento()
        {

        }
        public void Dispose()
        {

        }

        public string InsertarDepartamento(int organizacion_id, int departamentoTipo_id, string departamento_nombre, string departamento_descripcion, string departamento_estado)
        {
            Departamento departamento = new Departamento(organizacion_id,departamentoTipo_id,departamento_nombre,departamento_descripcion,departamento_estado);

            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.InsertarDepartamento(departamento);
            }
        }

        public string ModificarDepartamento(int departamento_id, int organizacion_id, int departamentoTipo_id, string departamento_nombre, string departamento_descripcion, string departamento_estado)
        {
            Departamento departamento = new Departamento(departamento_id,organizacion_id, departamentoTipo_id, departamento_nombre, departamento_descripcion, departamento_estado);

            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.ModificarDepartamento(departamento);
            }
        }

        public DataTable ListarDepartamento(string estado)
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.ListarDepartamento(estado);
            }
        }
        public DataSet ContarInactivos()
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.ContarInactivos();
            }
        }
        public DataSet ConsultarDepartamento(int id)
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.ConsultarDepartamento(id);
            }
        }

        public DataTable FiltrarDepartamento(string nombre, string estado)
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.FiltrarDepartamento(nombre,estado);
            }
        }

        public DataTable DepartamentoTramitePorOrg(int idOrg, int idTramite)
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.DepartamentoTramitePorOrg(idOrg, idTramite);
            }
        }

        
        public string InactivarDepartamento(int id)
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.InactivarDepartamento(id);
            }  
        }

        public string ActivarDepartamento(int id)
        {
            using (ServicioDepartamento servicioDepartamento = new ServicioDepartamento())
            {
                return servicioDepartamento.ActivarDepartamento(id);
            }
        }
    }
}
