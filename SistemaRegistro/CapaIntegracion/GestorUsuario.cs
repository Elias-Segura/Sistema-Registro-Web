using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaRegistro.CapaConexion;
using SistemaRegistro.CapaLogica.LogicaNegocio;
using SistemaRegistro.CapaLogica.Servicios;

namespace SistemaRegistro.CapaIntegracion
{
    public class GestorUsuario:servicio, IDisposable
    {
        public void Dispose() { }
        public GestorUsuario()
        {

        }

        public string InsertarUsuario(int rol_id, string nombre_usuario, string primerApellido, string segundoApellido, string usuario_contrasenna, string usuario_estado)
        {
            Usuario usuario = new Usuario(rol_id, nombre_usuario, primerApellido, segundoApellido, usuario_contrasenna, usuario_estado);
            using(ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.InsertarUsuario(usuario); 
            }

        }
        public string ModificarUsuario(int usuario_id, int rol_id, string nombre_usuario, string primerApellido, string segundoApellido, string usuario_contrasenna, string usuario_estado)
        {
            Usuario usuario = new Usuario(usuario_id, rol_id, nombre_usuario, primerApellido, segundoApellido, usuario_contrasenna, usuario_estado);
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.ModificarUsuario(usuario);
            }

        }

        public DataTable listarUsuarios(string estado)
        {
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.ListarUsuario(estado);
            }
        }
        public DataSet ConsultarUsuario(int id)
        {
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.ConsultarUsuario(id);
            }
        }

        public DataTable FiltrarUsuario(string nombre, string estado)
        {
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.FiltrarUsuario(nombre, estado);
            }
        }
        public string InactivarUsuario(int id)
        {
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.InactivarUsuario(id);
            }
        }

        public string ActivarUsuario(int id)
        {
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.ActivarUsuario(id);
            }
        }

        public DataSet verificarUsuario(string nombre, string contrasenna)
        {
            using (ServicioUsuario servicioUsuario = new ServicioUsuario())
            {
                return servicioUsuario.verificarUsuario(nombre, contrasenna);
            }
        }
    }
}
