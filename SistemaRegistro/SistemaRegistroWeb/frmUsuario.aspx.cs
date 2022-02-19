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
    public partial class frmUsuario : System.Web.UI.Page
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
                cargarUsuario();
                formulario.Visible = false;
                cargarRol();
            }
        }

        private void cargarUsuario()
        {
            using (GestorUsuario gestorUsuario = new GestorUsuario())
            {
                dt = gestorUsuario.listarUsuarios("A");
                dgUsuario.DataSource = dt;
                dgUsuario.DataBind();
            }
        }
        private void cargarRol()
        {
            using (GestorRol gestorRol = new GestorRol())
            {
                DrpRol.DataSource = gestorRol.ListarRol();
                DrpRol.DataValueField = "Rol_id";
                DrpRol.DataTextField = "Rol_tipo";
                DrpRol.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (GestorUsuario gestorUsuario = new GestorUsuario())
            {
                dt = gestorUsuario.FiltrarUsuario(txtFiltro.Value, "A");
                dgUsuario.DataSource = dt;
                dgUsuario.DataBind();
            }
        }


        protected void dgUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                cargarRol();

                using (GestorUsuario gestorUsuario = new GestorUsuario())
                {
                    ds = gestorUsuario.ConsultarUsuario(id);
                    dt = ds.Tables[0];
                }


                DrpRol.SelectedValue = dt.Rows[0]["Rol_id"].ToString();
                txtNombre.Value = dt.Rows[0]["Usuario_nombre"].ToString();
                txtPrimerApellido.Value = dt.Rows[0]["Usuario_primerApellido"].ToString();
                txtSegundoApellido.Value = dt.Rows[0]["Usuario_segundoApellido"].ToString();
                txtContrasenna.Value = dt.Rows[0]["Usuario_contrasenna"].ToString();
            }
            else
            {
                return;
            }

        }

       


        protected void dgUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgUsuario.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorUsuario gestorUsuario = new GestorUsuario())
                {

                    gestorUsuario.InactivarUsuario(id);
                    id = -1;
                    cargarUsuario();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }




        }

        private void reiniciarComponentes()
        {
            DrpRol.SelectedValue = null;
            txtNombre.  Value = "";
            txtPrimerApellido.Value = "";
            txtSegundoApellido.Value = "";
            txtContrasenna.Value = "";
        }

       
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarComponentes();
            formulario.Visible = true;
            contenedor.Visible = false;

            cargarRol();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;

        }

        protected void Modificar(object sender, EventArgs e)
        {
            if (DrpRol.SelectedValue != null && txtNombre.Value != "" && txtPrimerApellido.Value != "" && txtSegundoApellido.Value != "" && txtContrasenna.Value != "")
            {
                using (GestorUsuario gestorUsuario = new GestorUsuario())
                {
                    gestorUsuario.ModificarUsuario(id, int.Parse(DrpRol.SelectedValue.ToString()), txtNombre.Value, txtPrimerApellido.Value, txtSegundoApellido.Value, txtContrasenna.Value, "A");
                }

                cargarUsuario();
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
            if (DrpRol.SelectedValue != null && txtNombre.Value != "" && txtPrimerApellido.Value != "" && txtSegundoApellido.Value != "" && txtContrasenna.Value != "")
            {
                using (GestorUsuario gestorUsuario = new GestorUsuario())
                {
                    gestorUsuario.InsertarUsuario(int.Parse(DrpRol.SelectedValue.ToString()), txtNombre.Value, txtPrimerApellido.Value, txtSegundoApellido.Value, txtContrasenna.Value, "A");
                }

                cargarUsuario();
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


        protected void UsuarioOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgUsuario.PageIndex = e.NewPageIndex;

            cargarUsuario();
        }
    }
}