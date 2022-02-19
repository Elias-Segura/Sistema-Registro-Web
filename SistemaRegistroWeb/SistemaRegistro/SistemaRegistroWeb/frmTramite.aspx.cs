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
    public partial class frmTramite : System.Web.UI.Page
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
                cargarTramite();
                formulario.Visible = false;
                DrpDepartamento.Visible = false;
                cargarDropList();
                cargarDepartamentos();
            }
        }

        protected void cargarDropList()
        {
            ListItem list;
            list = new ListItem("Nombre");
            DrpTipoFiltro.Items.Add(list);
            list = new ListItem("Departamento");
            DrpTipoFiltro.Items.Add(list);
        }


        private void cargarTramite()
        {
            using (GestorTramite gestorTramite = new GestorTramite())
            {
                
                dt = gestorTramite.listarTramites("A");
                dgTramite.DataSource = dt;
                dgTramite.DataBind();
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
        protected void EvenIndexChanged(object sender, EventArgs e)
        {
            if (DrpTipoFiltro.SelectedValue.ToString() == "Departamento")
            {
                DrpDepartamento.Visible = true;
                txtFiltro.Value = null;
            }
            else
            {
                DrpDepartamento.Visible = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DrpTipoFiltro.SelectedValue != null)
            {

                if (DrpTipoFiltro.SelectedValue.ToString() == "Nombre" && txtFiltro.Value != "")
                {
                    using (GestorTramite gestorTramite = new GestorTramite())
                    {
                        dt = gestorTramite.FiltrarTramite(txtFiltro.Value, "A");
                        dgTramite.DataSource = dt;
                        dgTramite.DataBind();
                        txtFiltro.Value = null;
                        DrpDepartamento.Visible = false;
                    }
                }
                else if (DrpTipoFiltro.SelectedValue.ToString() == "Departamento" && DrpDepartamento.SelectedValue != null)
                {

                    using (GestorTramite gestorTramite = new GestorTramite())
                    {
                        dt = gestorTramite.TramiteDepartamento(int.Parse(DrpDepartamento.SelectedValue.ToString()));
                        dgTramite.DataSource = dt;
                        dgTramite.DataBind();
                        DrpDepartamento.Visible = true;
                    }
                }
                txtFiltro.Value = null;
            }
        }


        protected void dgTramite_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
               

                using (GestorTramite gestorTramite = new GestorTramite())
                {
                    ds = gestorTramite.ConsultarTramite(id);
                    dt = ds.Tables[0];
                }
                txtNombre.Value = dt.Rows[0]["Tramite_nombre"].ToString();
                txtDescripcion.Value = dt.Rows[0]["Tramite_descripcion"].ToString();
            }
            else
            {
                return;
            }

        }

      

        protected void Modificar(object sender, EventArgs e)
        {

            if (txtNombre.Value != "" && txtDescripcion.Value != "")
            {
                using (GestorTramite gestorTramite = new GestorTramite())
                {
                    gestorTramite.modificarTramite(id, txtNombre.Value, txtDescripcion.Value, "A");
                }


                cargarTramite();
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

        protected void dgTramite_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgTramite.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorTramite gestorTramite = new GestorTramite())
                {

                    gestorTramite.InactivarTramite(id);
                    id = -1;
                    cargarTramite();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        private void reiniciarComponentes()
        {
            txtNombre.Value = "";
            txtDescripcion.Value = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarComponentes();
            formulario.Visible = true;
            contenedor.Visible = false;

       
            btnModificar.Visible = false;
            btnAgregar.Visible = true;

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Value != "" && txtDescripcion.Value != "")
            {
                using (GestorTramite gestorTramite = new GestorTramite())
                {
                    gestorTramite.insertarTramite(txtNombre.Value, txtDescripcion.Value, "A");
                }

                cargarTramite();
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




        protected void TramiteOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgTramite.PageIndex = e.NewPageIndex;

            cargarTramite();
        }
        
    }
}