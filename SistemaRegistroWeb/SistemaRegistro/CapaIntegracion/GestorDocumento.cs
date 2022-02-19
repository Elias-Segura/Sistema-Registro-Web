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
    public class GestorDocumento : servicio, IDisposable
    {
        public GestorDocumento()
        {

        }

        public void Dispose()
        {

        }

        public string InsertarDocumento(int tramite_id, int idioma_id, int medio_id, string documento_nombre, string documento_ruta, string documento_tipo, string documento_estado)
        {
            Documento documento = new Documento(tramite_id, idioma_id, medio_id, documento_nombre, documento_ruta, documento_tipo, documento_estado);
            using (ServicioDocumento servicioDocumento = new ServicioDocumento())
            {
                return servicioDocumento.InsertarDocumento(documento);
            }
        }

        public string ModificarDocumento(int documento_id, int tramite_id, int idioma_id, int medio_id, string documento_nombre, string documento_ruta, string documento_tipo, string documento_estado)
        {
            Documento documento = new Documento(documento_id, tramite_id, idioma_id, medio_id, documento_nombre, documento_ruta, documento_tipo, documento_estado);
            using (ServicioDocumento servicioDocumento = new ServicioDocumento())
            {
                return servicioDocumento.ModificarDocumento(documento);
            }
        }

        public DataTable listarDocumentos(string estado)
        {
            using (ServicioDocumento servicioDocumentos = new ServicioDocumento())
            {
                return servicioDocumentos.ListarDocumentos(estado);
            }
        }
        public DataSet ContarInactivos()
        {
            using (ServicioDocumento servicioDocumentos = new ServicioDocumento())
            {
                return servicioDocumentos.ContarInactivos();
            }
        }
        public DataSet ConsultarDocumento(int id)
        {
            using (ServicioDocumento servicioDocumentos = new ServicioDocumento())
            {
                return servicioDocumentos.ConsultarDocumento(id);
            }
        }

        public DataTable FiltrarDocumento(string nombre, string estado)
        {
            using (ServicioDocumento servicioDocumentos = new ServicioDocumento())
            {
                return servicioDocumentos.FiltrarDocumentos(nombre, estado);
            }
        }

        public string InactivarDocumento(int id)
        {
            using (ServicioDocumento servicioDocumentos = new ServicioDocumento())
            {
                return servicioDocumentos.InactivarDocumento(id);
            }
        }


        public string ActivarDocumento(int id)
        {
            using (ServicioDocumento servicioDocumentos = new ServicioDocumento())
            {
                return servicioDocumentos.ActivarDocumento(id);
            }
        }
    }
}
