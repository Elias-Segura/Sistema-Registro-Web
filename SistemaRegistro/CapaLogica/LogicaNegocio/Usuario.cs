using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Usuario
    {
        #region ATRIBUTOS
        protected int usuario_id;
        protected int rol_id;
        protected string usuario_nombre;
        protected string usuario_primerApellido;
        protected string usuario_segundoApellido;
        protected string usuario_contrasenna;
        protected string usuario_estado;
        #endregion


        #region CONSTRUCTOR
        public Usuario()
        {

        }

        public Usuario(int rol_id, string usuario_nombre, string usuario_primerApellido, string usuario_segundoApellido, string usuario_contrasenna, string usuario_estado)
        {
            this.rol_id = rol_id;
            this.usuario_nombre = usuario_nombre;
            this.usuario_primerApellido = usuario_primerApellido;
            this.usuario_segundoApellido = usuario_segundoApellido;
            this.usuario_contrasenna = usuario_contrasenna;
            this.usuario_estado = usuario_estado;
        }

        public Usuario(int usuario_id, int rol_id, string usuario_nombre, string usuario_primerApellido, string usuario_segundoApellido, string usuario_contrasenna, string usuario_estado)
        {
            this.usuario_id = usuario_id;
            this.rol_id = rol_id;
            this.usuario_nombre = usuario_nombre;
            this.usuario_primerApellido = usuario_primerApellido;
            this.usuario_segundoApellido = usuario_segundoApellido;
            this.usuario_contrasenna = usuario_contrasenna;
            this.usuario_estado = usuario_estado;
        }
        #endregion

        #region GET'S AND SET'S
        public int Usuario_id { get => usuario_id; set => usuario_id = value; }
        public int Rol_id { get => rol_id; set => rol_id = value; }
        public string Usuario_nombre { get => usuario_nombre; set => usuario_nombre = value; }
        public string Usuario_primerApellido { get => usuario_primerApellido; set => usuario_primerApellido = value; }
        public string Usuario_segundoApellido { get => usuario_segundoApellido; set => usuario_segundoApellido = value; }
        public string Usuario_contrasenna { get => usuario_contrasenna; set => usuario_contrasenna = value; }
        public string Usuario_estado { get => usuario_estado; set => usuario_estado = value; }
        #endregion
    }
}
