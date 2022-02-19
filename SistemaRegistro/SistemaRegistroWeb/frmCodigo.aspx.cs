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
    public partial class frmCodigo : System.Web.UI.Page
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
                cargarCodigo();
                cargarOrganizacion();
            }
        }
        private void cargarOrganizacion()
        {
            using (GestorOrganizacion gestorOganizacion = new GestorOrganizacion())
            {
                DrpOrganizacion.DataSource = gestorOganizacion.listarOrganizacion("A");
                DrpOrganizacion.DataValueField = "Organizacion_id";
                DrpOrganizacion.DataTextField = "Organizacion_nombre";
                DrpOrganizacion.DataBind();
            }
        }
        private void cargarCodigo()
        {
            using (GestorCodigo codigo = new GestorCodigo())
            {
                dt = codigo.ListarCodigo("A");
                dgCodigo.DataSource = dt;
                dgCodigo.DataBind();

            }

           


        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Value != "" && DrpOrganizacion.SelectedItem != null)
            {

                using (GestorCodigo gestorCodigo = new GestorCodigo())
                {
                    gestorCodigo.ModificarCodigo(id, int.Parse(DrpOrganizacion.SelectedValue.ToString()), txtCodigo.Value , "A");
                }
                cargarCodigo();
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
            if (txtCodigo.Value != "" && DrpOrganizacion.SelectedItem != null)
            {

                using (GestorCodigo gestorCodigo = new GestorCodigo())
                {
                    gestorCodigo.InsertarCodigo(int.Parse(DrpOrganizacion.SelectedValue.ToString()), txtCodigo.Value + "-", "A");
                }
                cargarCodigo();
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
            using (GestorCodigo gestorCodigo = new GestorCodigo())
            {

                dt = gestorCodigo.FiltrarCodigo(txtFiltro.Value, "A");
                dgCodigo.DataSource = dt;
                dgCodigo.DataBind();

            }
        }

        protected void dgCodigo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                cargarOrganizacion();
                using (GestorCodigo gestorCodigo = new GestorCodigo())
                {
                    ds= gestorCodigo.ConsultarCodigo(id);
                    dt = ds.Tables[0];
                }
                try
                {
                    txtCodigo.Disabled = true;
                    DrpOrganizacion.SelectedValue = dt.Rows[0]["Organizacion_id"].ToString();
                    txtCodigo.Value = dt.Rows[0]["Codigo_formato"].ToString();
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

        protected void dgCodigo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(dgCodigo.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorCodigo gestorCodigo = new GestorCodigo())
                {

                    gestorCodigo.InactivarCodigo(id);
                    id = -1;
                    cargarCodigo();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Disabled = false;
            formulario.Visible = true;
            contenedor.Visible = false;
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            txtCodigo.Value = "";
            cargarOrganizacion();
            DrpOrganizacion.SelectedValue = null;
            txtCodigo.Value = "";

        }

        protected void dgCodigo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgCodigo.PageIndex = e.NewPageIndex;

            cargarCodigo();
        }
    }
}