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
    public class GestorIdioma: servicio , IDisposable
    {
        public GestorIdioma()
        {

        }

        public void Dispose()
        {

        }

        public string InsertarIdioma(string idioma_nombre, string idioma_iniciales, string idioma_estado)
        {
            Idioma idioma =new Idioma(idioma_nombre, idioma_iniciales, idioma_estado);
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.InsertarIdioma(idioma);
            }
        }

        public string ModificarIdioma(int idioma_id, string idioma_nombre, string idioma_iniciales, string idioma_estado)
        {
            Idioma idioma = new Idioma(idioma_id,idioma_nombre, idioma_iniciales, idioma_estado);
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.ModificarIdioma(idioma);
            }
        }

        public DataTable listarIdioma(string estado)
        {
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.ListarIdioma(estado);
            }
        }

        public DataSet ContarInactivos()
        {
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.ContarInactivos();
            }
        }

        public DataSet ConsultarIdioma(int id)
        {
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.ConsultarIdioma(id);
            }
        }

        public DataTable FiltrarIdioma(string nombre, string estado)
        {
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.FiltrarIdioma(nombre,estado);
            }
        }
        public string InactivarIdioma(int id)
        {
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.InactivarIdioma(id);
            }
        }


        public string ActivarIdioma(int id)
        {
            using (ServicioIdioma servicioIdioma = new ServicioIdioma())
            {
                return servicioIdioma.ActivarIdioma(id);
            }
        }
    }
}
