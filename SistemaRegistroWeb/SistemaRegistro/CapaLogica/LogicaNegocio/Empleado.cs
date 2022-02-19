using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRegistro.CapaLogica.LogicaNegocio
{
    public class Empleado
    {
        #region ATRIBUTOS
        private int empleado_id;
        private int departamento_id;
        private int puesto_id;
        private int genero_id;
        private int estadoCivil_id;
        private string empleado_nombre;
        private string empleado_primerApellido;
        private string empleado_segundoApellido;
        private DateTime empleado_fechaNacimiento;
        private DateTime empleado_fechaIngreso;
        private string empleado_estado;
        #endregion



        #region CONSTRUCTOR
        public Empleado()
        {

        }

        public Empleado(int departamento_id, int puesto_id, int genero_id, int estadoCivil_id, string empleado_nombre, string empleado_primerApellido, string empleado_segundoApellido, DateTime empleado_fechaNacimiento, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            this.departamento_id = departamento_id;
            this.puesto_id = puesto_id;
            this.genero_id = genero_id;
            this.estadoCivil_id = estadoCivil_id;
            this.empleado_nombre = empleado_nombre;
            this.empleado_primerApellido = empleado_primerApellido;
            this.empleado_segundoApellido = empleado_segundoApellido;
            this.empleado_fechaNacimiento = empleado_fechaNacimiento;
            this.empleado_fechaIngreso = empleado_fechaIngreso;
            this.empleado_estado = empleado_estado;
        }

        public Empleado(int empleado_id, int departamento_id, int puesto_id, int genero_id, int estadoCivil_id, string empleado_nombre, string empleado_primerApellido, string empleado_segundoApellido, DateTime empleado_fechaNacimiento, DateTime empleado_fechaIngreso, string empleado_estado)
        {
            this.empleado_id = empleado_id;
            this.departamento_id = departamento_id;
            this.puesto_id = puesto_id;
            this.genero_id = genero_id;
            this.estadoCivil_id = estadoCivil_id;
            this.empleado_nombre = empleado_nombre;
            this.empleado_primerApellido = empleado_primerApellido;
            this.empleado_segundoApellido = empleado_segundoApellido;
            this.empleado_fechaNacimiento = empleado_fechaNacimiento;
            this.empleado_fechaIngreso = empleado_fechaIngreso;
            this.empleado_estado = empleado_estado;
        }
        #endregion

        #region GET's and SET's
        public int Empleado_id { get => empleado_id; set => empleado_id = value; }
        public int Departamento_id { get => departamento_id; set => departamento_id = value; }
        public int Puesto_id { get => puesto_id; set => puesto_id = value; }
        public int Genero_id { get => genero_id; set => genero_id = value; }
        public int EstadoCivil_id { get => estadoCivil_id; set => estadoCivil_id = value; }
        public string Empleado_nombre { get => empleado_nombre; set => empleado_nombre = value; }
        public string Empleado_primerApellido { get => empleado_primerApellido; set => empleado_primerApellido = value; }
        public string Empleado_segundoApellido { get => empleado_segundoApellido; set => empleado_segundoApellido = value; }
        public DateTime Empleado_fechaNacimiento { get => empleado_fechaNacimiento; set => empleado_fechaNacimiento = value; }
        public DateTime Empleado_fechaIngreso { get => empleado_fechaIngreso; set => empleado_fechaIngreso = value; }
        public string Empleado_estado { get => empleado_estado; set => empleado_estado = value; }
        #endregion

    }
}
