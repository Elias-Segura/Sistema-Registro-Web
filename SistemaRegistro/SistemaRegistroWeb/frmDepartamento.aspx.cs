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
    public partial class frmDepartamento : System.Web.UI.Page
    {
       
        static int id;
        DataSet ds;
        DataTable dt;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string c = Request.QueryString["name"];
                if (c != "view")
                {
                    Response.Redirect("login.aspx");
                }
                CargarDepartamentos();
                formulario.Visible = false;
                cargarOrganizaciones();

                
            }

        }

        protected void CargarDepartamentos()
        {
            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {
                dt = gestorDepartamento.ListarDepartamento("A");
                dgDepartamento.DataSource = dt;
                dgDepartamento.DataBind();

            }


        }

        protected void VerificarFiltro()
        {

            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {
                dt = gestorDepartamento.FiltrarDepartamento(txtFiltro.Value, "A");
                dgDepartamento.DataSource = dt;
                dgDepartamento.DataBind();

            }
        }

        protected void cargarOrganizaciones()
        {
            using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
            {

                DrpOrganizaciones.DataSource = gestorOrganizacion.listarOrganizacion("A");
                DrpOrganizaciones.DataValueField = "Organizacion_id";
                DrpOrganizaciones.DataTextField = "Organizacion_nombre";
                DrpOrganizaciones.DataBind();
            }
        }
        private void cargarTipoDepartamentos()
        {
            using (GestorDepartamentoTipo gestorDepartamentoTipo = new GestorDepartamentoTipo())
            {

                DrpTipoDepartamento.DataSource = gestorDepartamentoTipo.ListarDepartamentoTipo();
                DrpTipoDepartamento.DataValueField = "DepartamentoTipo_id";
                DrpTipoDepartamento.DataTextField = "DepartamentoTipo_nombre";
                DrpTipoDepartamento.DataBind();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {
                dt = gestorDepartamento.FiltrarDepartamento(txtFiltro.Value, "A");
                dgDepartamento.DataSource = dt;
                dgDepartamento.DataBind();

            }
        }
        protected void Departamento(object sender, GridViewCommandEventArgs e)
        {
           
            // do something
        }

        protected void dgDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgDepartamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id; 
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                cargarOrganizaciones();
                cargarTipoDepartamentos();

                using(GestorDepartamento gestorDepartamento = new GestorDepartamento())
                {
                    ds = gestorDepartamento.ConsultarDepartamento(id);
                    dt = ds.Tables[0];
                }

                DrpTipoDepartamento.SelectedValue = dt.Rows[0]["DepartamentoTipo_id"].ToString();
                DrpOrganizaciones.SelectedValue = dt.Rows[0]["Organizacion_id"].ToString();
                txtDepartamento.Value = dt.Rows[0]["Departamento_nombre"].ToString();
                txtDescripcion.Value = dt.Rows[0]["Departamento_descripcion"].ToString();
            }
            else
            {
                return; 
            }
           
        }





        protected void Modificar(object sender, EventArgs e)
        {

            

            if (txtDepartamento.Value != "" && txtDescripcion.Value != "" & DrpTipoDepartamento.SelectedValue != null && DrpOrganizaciones.SelectedValue != null)
            {

                using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
                {
                    gestorDepartamento.ModificarDepartamento(id, int.Parse(DrpOrganizaciones.SelectedValue.ToString()), int.Parse(DrpTipoDepartamento.SelectedValue.ToString()), txtDepartamento.Value, txtDescripcion.Value, "A");
                }
                CargarDepartamentos();
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
        protected void dgDepartamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgDepartamento.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
                {

                    gestorDepartamento.InactivarDepartamento(id);
                    id = -1;
                    CargarDepartamentos();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }




        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formulario.Visible = true;
            contenedor.Visible = false;

            cargarOrganizaciones();
            cargarTipoDepartamentos();
            btnModificar.Visible = false;
            btnAgregar.Visible = true; 



            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtDepartamento.Value != "" && txtDescripcion.Value != "" & DrpTipoDepartamento.SelectedValue != null && DrpOrganizaciones.SelectedValue != null)
            {

                using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
                {
                    gestorDepartamento.InsertarDepartamento(int.Parse(DrpOrganizaciones.SelectedValue.ToString()), int.Parse(DrpTipoDepartamento.SelectedValue.ToString()), txtDepartamento.Value, txtDescripcion.Value, "A");
                }
                CargarDepartamentos();
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

        protected void dgDepartamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
     
            dgDepartamento.PageIndex = e.NewPageIndex;

            CargarDepartamentos();
        }
    }
}