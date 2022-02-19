using SistemaRegistro.CapaIntegracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaRegistroWeb
{
    public partial class frmCiclo : System.Web.UI.Page
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
             
                formulario.Visible = false;
                cargarCiclos();
                cargarDepartamentos();
                cargarTramites();
            }



        }

        private void cargarDepartamentos()
        {
            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {
                DrpDepartamento.DataSource = gestorDepartamento.ListarDepartamento("A");
                DrpDepartamento.DataValueField = "Departamento_id";
                DrpDepartamento.DataTextField = "Departamento_nombre";
                DrpDepartamento.DataBind();
            }

        }
        private void cargarTramites()
        {
            using (GestorTramite gestorTramite = new GestorTramite())
            {

                DrpTramites.DataSource = gestorTramite.listarTramites("A");
                DrpTramites.DataValueField = "Tramite_id";
                DrpTramites.DataTextField = "Tramite_nombre";
                DrpTramites.DataBind();
            }

        }




        private void cargarCiclos()
        {
            using (GestorCiclo gestorCiclo = new GestorCiclo())
            {

                dt = gestorCiclo.ListarCiclo("A");
                dgCiclo.DataSource = dt;
                dgCiclo.DataBind();

              
            }
        
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (DrpDepartamento.SelectedValue != null && DrpTramites.SelectedValue != null && txtCiclo.Value != "")
            {


                using (GestorCiclo gestorCiclo = new GestorCiclo())
                {
                    gestorCiclo.ModificarCiclo(id, int.Parse(DrpTramites.SelectedValue.ToString()), int.Parse(DrpDepartamento.SelectedValue.ToString()), txtCiclo.Value, "A");
                }
                cargarCiclos();
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (DrpDepartamento.SelectedValue != null && DrpTramites.SelectedValue != null && txtCiclo.Value != "")
            {


                using (GestorCiclo gestorCiclo = new GestorCiclo())
                {
                    gestorCiclo.InsertarCiclo(int.Parse(DrpTramites.SelectedValue.ToString()), int.Parse(DrpDepartamento.SelectedValue.ToString()), txtCiclo.Value, "A");
                }
                cargarCiclos();
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            using (GestorCiclo gestorCiclo = new GestorCiclo())
            {

                dt = gestorCiclo.FiltrarCiclo(txtFiltro.Value, "A");
                dgCiclo.DataSource = dt;
                dgCiclo.DataBind();

            }
        }

        protected void dgCiclo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                cargarCiclos();
                cargarDepartamentos();
                cargarTramites();
                using (GestorCiclo gestorCiclo = new GestorCiclo())
                {
                    ds = gestorCiclo.ConsultarCiclo(id);
                    dt = ds.Tables[0];

                }
                try
                {
                    DrpTramites.SelectedValue = dt.Rows[0]["Tramite_id"].ToString();
                    DrpDepartamento.SelectedValue = dt.Rows[0]["Departamento_id"].ToString();
                    txtCiclo.Value = dt.Rows[0]["Ciclo_orden"].ToString();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                return;
            }
        }

        protected void dgCiclo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgCiclo.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorCiclo gestorCiclo = new GestorCiclo())
                {

                    gestorCiclo.InactivarCiclo(id);
                    id = -1;
                    cargarCiclos();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formulario.Visible = true;
            contenedor.Visible = false;
            cargarDepartamentos();
            cargarTramites();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            DrpTramites.SelectedValue = null; 
            DrpDepartamento.SelectedValue = null;
            txtCiclo.Value = "";
        }

        protected void dgCiclo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgCiclo.PageIndex = e.NewPageIndex;

            cargarCiclos();
        }
    }
}