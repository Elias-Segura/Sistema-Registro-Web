using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Idioma
    {
        #region ATRIBUTOS
        private int idioma_id;
        private string idioma_nombre;
        private string idioma_iniciales;
        private string idioma_estado;

        #endregion

        #region CONSTRUCTOR
        public Idioma()
        {

        }

        public Idioma( string idioma_nombre, string idioma_iniciales, string idioma_estado)
        {
            this.idioma_nombre = idioma_nombre;
            this.idioma_iniciales = idioma_iniciales;
            this.idioma_estado = idioma_estado;
        }

        public Idioma(int idioma_id, string idioma_nombre, string idioma_iniciales, string idioma_estado)
        {
            this.idioma_id = idioma_id;
            this.idioma_nombre = idioma_nombre;
            this.idioma_iniciales = idioma_iniciales;
            this.idioma_estado = idioma_estado;
        }
        #endregion

        #region GET's and SET's
        public int Idioma_id { get => idioma_id; set => idioma_id = value; }
        public string Idioma_nombre { get => idioma_nombre; set => idioma_nombre = value; }
        public string Idioma_iniciales { get => idioma_iniciales; set => idioma_iniciales = value; }
        public string Idioma_estado { get => idioma_estado; set => idioma_estado = value; }
        #endregion
    }
}
