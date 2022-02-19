using SistemaRegistro.CapaIntegracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SistemaRegistroWeb
{
    public partial class frmEmpleado : System.Web.UI.Page
    {
        static int id;
        DataSet ds;
        DataTable dt;

        public static string FechaNacimiento;
        public static string FechaIngreso;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string c = Request.QueryString["name"];
                if (c != "view")
                {
                    Response.Redirect("login.aspx");
                }
                cargarEmpleados();
                formulario.Visible = false;

                CldFechaNacimiento.Visible = false;
                CldFechaIngreso.Visible = false;

                cargarDepartamentos();
                cargarPuestos();
                cargarGenero();
                cargarEstadoCivil();
                    
            }
        }

        private void reiniciarComponentes()
        {
            txtFechaIngreso.Value = "";
            txtFechaNacimiento.Value = "";

            txtNombre.Value = "";
            txtPrimerApellido.Value = "";
            txtSegundoApellido.Value = "";

            DrpPuestos.SelectedValue = null;
            DrpDepartamentos.SelectedValue = null;
            DrpEstadoCivil.SelectedValue = null;
            DrpGenero.SelectedValue = null;
        }

        private void cargarEmpleados()
        {
            using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
            {
                dt = gestorEmpleado.listarEmpleado("A");
                dgEmpleado.DataSource = dt;
                dgEmpleado.DataBind();
            }
        }



        private void cargarDepartamentos()
        {
            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {

                DrpDepartamentos.DataSource = gestorDepartamento.ListarDepartamento("A");
                DrpDepartamentos.DataValueField = "Departamento_id";
                DrpDepartamentos.DataTextField = "Departamento_nombre";
                DrpDepartamentos.DataBind();
            }
        }


        private void cargarPuestos()
        {
            using (GestorPuesto gestorPuesto = new GestorPuesto())
            {

                DrpPuestos.DataSource = gestorPuesto.ListarPuesto();
                DrpPuestos.DataValueField = "Puesto_id";
                DrpPuestos.DataTextField = "Puesto_nombre";
                DrpPuestos.DataBind();
            }
        }




        private void cargarGenero()
        {
            using (GestorGenero gestorGenero = new GestorGenero())
            {
                DrpGenero.DataSource = gestorGenero.ListarGenero();
                DrpGenero.DataValueField = "Genero_id";
                DrpGenero.DataTextField = "Genero_nombre";
                DrpGenero.DataBind();

            }
        }
        private void cargarEstadoCivil()
        {
            using (GestorEstadoCivil gestorEstadoCivil = new GestorEstadoCivil())
            {
                DrpEstadoCivil.DataSource = gestorEstadoCivil.ListarEstadoCivil();
                DrpEstadoCivil.DataValueField = "EstadoCivil_id";
                DrpEstadoCivil.DataTextField = "TEstadoCivil_nombre";
                DrpEstadoCivil.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
            {
                dt = gestorEmpleado.FiltrarEmpleado(txtFiltro.Value, "A");
                dgEmpleado.DataSource = dt;
                dgEmpleado.DataBind();
            }
        }
        
        protected void dgEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                cargarDepartamentos();
                cargarPuestos();
                cargarGenero();
                cargarEstadoCivil();

                using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
                {
                    ds = gestorEmpleado.ConsultarEmpleado(id);
                    dt = ds.Tables[0];
                }

                DrpDepartamentos.SelectedValue = dt.Rows[0]["Departamento_id"].ToString();
                DrpPuestos.SelectedValue = dt.Rows[0]["Puesto_id"].ToString();
                DrpGenero.SelectedValue = dt.Rows[0]["Genero_id"].ToString();
                DrpEstadoCivil.SelectedValue = dt.Rows[0]["EstadoCivil_id"].ToString();


                txtNombre.Value = dt.Rows[0]["Empleado_nombre"].ToString();
                txtPrimerApellido.Value = dt.Rows[0]["Empleado_primerApellido"].ToString();
                txtSegundoApellido.Value = dt.Rows[0]["Empleado_segundoApellido"].ToString();

                txtFechaNacimiento.Value = dt.Rows[0]["Empleado_fechaNacimiento"].ToString();
                txtFechaIngreso.Value = dt.Rows[0]["Empleado_fechaIngreso"].ToString();

            }
            else
            {
                return;
            }

        }

        protected void Modificar(object sender, EventArgs e)
        {

            if (DrpDepartamentos.SelectedValue != null && DrpEstadoCivil.SelectedValue != null && DrpGenero.SelectedValue != null && DrpPuestos.SelectedValue != null && txtNombre.Value != "" && txtPrimerApellido.Value != "" && txtSegundoApellido.Value != "")
            {
                using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
                {
                     gestorEmpleado.ModificarEmpleado(id, int.Parse(DrpDepartamentos.SelectedValue.ToString()), int.Parse(DrpPuestos.SelectedValue.ToString()), int.Parse(DrpGenero.SelectedValue.ToString()), int.Parse(DrpEstadoCivil.SelectedValue.ToString()), txtNombre.Value, txtPrimerApellido.Value, txtSegundoApellido.Value, Convert.ToDateTime(FechaNacimiento), Convert.ToDateTime(FechaIngreso), "A");
                }


                cargarEmpleados();
                id = -1;
                ClientScript.RegisterStartupScript(GetType(), "Actualizado", "swal('Actualizado','El dato fue actualizado con exito', 'success')", true);
                formulario.Visible = false;
                contenedor.Visible = true;

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','Complete los campos requeridos', 'error')", true);

            }
        }


        protected void dgEmpleado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(dgEmpleado.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
                {

                    gestorEmpleado.InactivarEmpleado(id);
                    id = -1;
                    cargarEmpleados();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarComponentes();
            formulario.Visible = true;
            contenedor.Visible = false;

            cargarDepartamentos();
            cargarPuestos();
            cargarGenero();
            cargarEstadoCivil();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (DrpDepartamentos.SelectedValue != null && DrpEstadoCivil.SelectedValue != null && DrpGenero.SelectedValue != null && DrpPuestos.SelectedValue != null && txtNombre.Value != "" && txtPrimerApellido.Value != "" && txtSegundoApellido.Value != ""
                && txtFechaNacimiento.Value != "" && txtFechaIngreso.Value != "")
            {

                using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
                {
                    gestorEmpleado.InsertarEmpleado(int.Parse(DrpDepartamentos.SelectedValue.ToString()), int.Parse(DrpPuestos.SelectedValue.ToString()), int.Parse(DrpGenero.SelectedValue.ToString()), int.Parse(DrpEstadoCivil.SelectedValue.ToString()), txtNombre.Value, txtPrimerApellido.Value, txtSegundoApellido.Value, Convert.ToDateTime(FechaNacimiento), Convert.ToDateTime(FechaIngreso), "A");
                }


                cargarEmpleados();
                id = -1;
                ClientScript.RegisterStartupScript(GetType(), "Agregado", "swal('Agregado','El dato fue agregado con exito', 'success')", true);
                formulario.Visible = false;
                contenedor.Visible = true;

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','Complete los campos requeridos', 'error')", true);

            }
        }

        protected void btnFechaNacimiento_Click(object sender, EventArgs e)
        {
            CldFechaNacimiento.Visible = !CldFechaNacimiento.Visible;
        }

        protected void btnFechaIngreso_Click(object sender, EventArgs e)
        {
            CldFechaIngreso.Visible = !CldFechaIngreso.Visible;
        }
        protected void CldFechaNacimientoSelectionChanged(object sender, EventArgs e)
        {
            FechaNacimiento = CldFechaNacimiento.SelectedDate.ToString("yyyy-MM-dd");
            txtFechaNacimiento.Value = CldFechaNacimiento.SelectedDate.ToLongDateString();
            CldFechaNacimiento.Visible = false;
        }

         protected void CldFechaIngresoSelectionChanged(object sender, EventArgs e)
        {
            FechaIngreso = CldFechaIngreso.SelectedDate.ToString("yyyy-MM-dd");
            txtFechaIngreso.Value = CldFechaIngreso.SelectedDate.ToLongDateString();
            CldFechaIngreso.Visible = false;
        }

        protected void EmpleadoOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgEmpleado.PageIndex = e.NewPageIndex;

            cargarEmpleados();
        }

        
    }
}