using SistemaRegistro.CapaIntegracion;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SistemaRegistroWeb
{
    public partial class frmIdioma : System.Web.UI.Page
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
                cargarIdiomas();
                formulario.Visible = false;
                


            }
        }

        private void cargarIdiomas()
        {
            using (GestorIdioma gestorIdioma = new GestorIdioma())
            {
                dt = gestorIdioma.listarIdioma("A");
                dgIdioma.DataSource = dt;
                dgIdioma.DataBind();
            }     

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (GestorIdioma gestorIdioma = new GestorIdioma())
            {
                dt = gestorIdioma.FiltrarIdioma(txtFiltro.Value, "A");
                dgIdioma.DataSource = dt;
                dgIdioma.DataBind();

            }
        }

        protected void dgIdioma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                

                using (GestorIdioma gestorIdioma = new GestorIdioma())
                {
                    ds = gestorIdioma.ConsultarIdioma(id);
                    dt = ds.Tables[0];
                }
                txtInicial.Value = dt.Rows[0]["Idioma_iniciales"].ToString();
                txtNombre.Value = dt.Rows[0]["Idioma_nombre"].ToString();
            }
            else
            {
                return;
            }

        }


        protected void Modificar(object sender, EventArgs e)
        {

            if (txtNombre.Value != "" && txtInicial.Value != "")
            {
                using (GestorIdioma gestorIdioma = new GestorIdioma())
                {
                    gestorIdioma.ModificarIdioma(id, txtNombre.Value, txtInicial.Value, "A");
                }


                cargarIdiomas();
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


        protected void dgIdioma_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgIdioma.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorIdioma gestorIdioma = new GestorIdioma())
                {

                    gestorIdioma.InactivarIdioma(id);
                    id = -1;
                    cargarIdiomas();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        private void reiniciarComponentes()
        {
            txtNombre.Value = "";
            txtInicial.Value = "";
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
            if (txtNombre.Value != "" && txtInicial.Value != "")
            {
                using (GestorIdioma gestorIdioma = new GestorIdioma())
                {
                    gestorIdioma.InsertarIdioma(txtNombre.Value, txtInicial.Value, "A");

                }

                cargarIdiomas();
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
    
    
    
        protected void IdiomaOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgIdioma.PageIndex = e.NewPageIndex;

            cargarIdiomas();
        }

    }
}