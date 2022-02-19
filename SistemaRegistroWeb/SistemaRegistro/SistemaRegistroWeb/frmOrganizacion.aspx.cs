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
    public partial class frmOrganizacion : System.Web.UI.Page
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
                cargarOrganizaciones();


            }
        }

        protected void cargarOrganizaciones()
        {
            using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
            {
                dt = gestorOrganizacion.listarOrganizacion("A");
                dgOrganizacion.DataSource = dt;
                dgOrganizacion.DataBind();
            }
        }




        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtOrganizacion.Value != "" && txtTipo.Value != "" && txtDescripcion.Value != "")
            {

                using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
                {
                    gestorOrganizacion.ModificarOrganizacion(id, txtOrganizacion.Value, txtTipo.Value, txtDescripcion.Value, "A");
                }
                cargarOrganizaciones();
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
            if (txtOrganizacion.Value != "" && txtTipo.Value != "" && txtDescripcion.Value != "")
            {

                using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
                {
                    gestorOrganizacion.InsertarOrganizacion(txtOrganizacion.Value, txtTipo.Value, txtDescripcion.Value, "A");
                }
                cargarOrganizaciones();
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

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
            {

                dt = gestorOrganizacion.FiltrarOrganizacion(txtFiltro.Value, "A");
                dgOrganizacion.DataSource = dt;
                dgOrganizacion.DataBind();

            }
        }

        protected void dgOrganizacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;

                using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
                {
                    ds = gestorOrganizacion.ConsultarOrganizacion(id);
                    dt = ds.Tables[0];

                }
                try
                {
                    txtTipo.Value = dt.Rows[0]["Organizacion_tipo"].ToString();
                    txtOrganizacion.Value = dt.Rows[0]["Organizacion_nombre"].ToString();
                    txtDescripcion.Value = dt.Rows[0]["Organizacion_descripcion"].ToString();

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

        protected void dgOrganizacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(dgOrganizacion.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
                {

                    gestorOrganizacion.InactivarOrganizacion(id);
                    id = -1;
                    cargarOrganizaciones();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formulario.Visible = true;
            contenedor.Visible = false;
            cargarOrganizaciones();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            txtDescripcion.Value = "";
            txtOrganizacion.Value = "";
            txtTipo.Value = "";
            }

        protected void dgOrganizacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgOrganizacion.PageIndex = e.NewPageIndex;

            cargarOrganizaciones();
        }
    }
}