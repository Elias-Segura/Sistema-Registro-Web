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
    public partial class frmDetalleCaso : System.Web.UI.Page
    {
        static int id;
        DataSet ds;
        DataTable dt;

        public static string FechaRecibido;
        public static string FechaTraspaso;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string c = Request.QueryString["name"];
                if (c != "view")
                {
                    Response.Redirect("login.aspx");
                }
                cargarDetalleCasos();
                formulario.Visible = false;

                CldFechaRecibido.Visible = false;
                CldFechaTraspaso.Visible = false;

                cargarCiclo();
                cargarCaso();
                cargarDocumento();
            }
        }
        private void cargarDetalleCasos()
        {
            using (GestorDetalleCaso detalleCaso = new GestorDetalleCaso())
            {
                dgDetalleCaso.DataSource = detalleCaso.listarDetalleCasos("A");
              

                dt = detalleCaso.listarDetalleCasos("A");
                dgDetalleCaso.DataSource = dt;
                dgDetalleCaso.DataBind();

            }
        }
        private void cargarCaso()
        {
            using (GestorCaso gestorCaso = new GestorCaso())
            {
                DrpCodigo.DataSource = gestorCaso.listarCasos("A");
                DrpCodigo.DataValueField = "Caso_id";
                DrpCodigo.DataTextField = "Caso_codigo";
                DrpCodigo.DataBind();
            }
        }

        private void cargarCiclo()
        {
            using (GestorCiclo gestorCiclo = new GestorCiclo())
            {

                DrpDepartamento.DataSource = gestorCiclo.ListarCiclo("A");
                DrpDepartamento.DataValueField = "Ciclo_id";
                DrpDepartamento.DataTextField = "Departamento_nombre";
                DrpDepartamento.DataBind();
            }
        }

        private void cargarDocumento()
        {
            using (GestorDocumento gestorDocumento = new GestorDocumento())
            {
                DrpDocumento.DataSource = gestorDocumento.listarDocumentos("A");
                DrpDocumento.DataValueField = "Documento_id";
                DrpDocumento.DataTextField = "Documento_nombre";
                DrpDocumento.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
            {
                dt = gestorDetalleCaso.FiltrarDetalleCaso(txtFiltro.Value, "A");
                dgDetalleCaso.DataSource = dt;
                dgDetalleCaso.DataBind();
            }
        }

        //Fechas
        protected void dgDetalleCaso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                cargarCiclo();
                cargarCaso();
                cargarDocumento();


                using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
                {
                    ds = gestorDetalleCaso.ConsultarDetalleCaso(id);
                    dt = ds.Tables[0];
                }

                DrpCodigo.SelectedValue = dt.Rows[0]["Caso_id"].ToString();
                DrpDepartamento.SelectedValue = dt.Rows[0]["Ciclo_id"].ToString();
                DrpDocumento.SelectedValue = dt.Rows[0]["Documento_id"].ToString();
                txtDescripcion.Value = dt.Rows[0]["DetalleCaso_descripcion"].ToString();

                txtFechaRecibido.Value = dt.Rows[0]["DetalleCaso_fechaRecibido"].ToString();
                txtFechaTraspaso.Value = dt.Rows[0]["DetalleCaso_fechaTraspaso"].ToString();
            }
            else
            {
                return;
            }

        }


        
        protected void Modificar(object sender, EventArgs e)
        {


            if (DrpCodigo.SelectedValue != null && DrpCodigo.SelectedValue != null && DrpDocumento.SelectedValue != null &&
                 txtDescripcion.Value != "" && txtFechaRecibido.Value != "" && txtFechaTraspaso.Value != "")
            {
                using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
                {
                    gestorDetalleCaso.ModificarDetalleCaso(id, int.Parse(DrpCodigo.SelectedValue.ToString()), int.Parse(DrpDepartamento.SelectedValue.ToString()), int.Parse(DrpDocumento.SelectedValue.ToString()), Convert.ToDateTime(FechaRecibido), Convert.ToDateTime(FechaTraspaso), txtDescripcion.Value, "A");
                }

                cargarDetalleCasos();
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

        protected void dgDetalleCaso_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgDetalleCaso.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
                {

                    gestorDetalleCaso.InactivarDetalleCaso(id);
                    id = -1;
                    cargarDetalleCasos();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }

        private void reiniciarComponentes()
        {
            txtFechaRecibido.Value = "";
            txtFechaTraspaso.Value = "";

            DrpCodigo.SelectedValue = null;
            DrpDepartamento.SelectedValue = null;
            DrpDocumento.SelectedValue = null;
            txtDescripcion.Value = null;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarComponentes();
            formulario.Visible = true;
            contenedor.Visible = false;

            cargarCiclo();
            cargarCaso();
            cargarDocumento();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
        }

        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (DrpCodigo.SelectedValue != null && DrpCodigo.SelectedValue != null && DrpDocumento.SelectedValue != null &&
                 txtDescripcion.Value != "" && txtFechaRecibido.Value != "" && txtFechaTraspaso.Value != "")
            {
                using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
                {
                    gestorDetalleCaso.InsertarDetalleCaso(int.Parse(DrpCodigo.SelectedValue.ToString()), int.Parse(DrpDepartamento.SelectedValue.ToString()), int.Parse(DrpDocumento.SelectedValue.ToString()), Convert.ToDateTime(FechaRecibido), Convert.ToDateTime(FechaTraspaso), txtDescripcion.Value, "A");
                }

                cargarDetalleCasos();
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

        protected void btnFechaTraspaso_Click(object sender, EventArgs e)
        {
         
            CldFechaTraspaso.Visible = !CldFechaTraspaso.Visible;
        }

        protected void btnFechaRecibido_Click(object sender, EventArgs e)
        {
            CldFechaRecibido.Visible = !CldFechaRecibido.Visible;
        }

        protected void CldFechaRecibidoSelectionChanged(object sender, EventArgs e)
        {
            FechaRecibido = CldFechaRecibido.SelectedDate.ToString("yyyy-MM-dd");
            txtFechaRecibido.Value = CldFechaRecibido.SelectedDate.ToLongDateString();
            CldFechaRecibido.Visible = false;
        }

        protected void CldFechaTraspasoSelectionChanged(object sender, EventArgs e)
        {
            FechaTraspaso = CldFechaTraspaso.SelectedDate.ToString("yyyy-MM-dd");
            txtFechaTraspaso.Value = CldFechaTraspaso.SelectedDate.ToLongDateString();
            CldFechaTraspaso.Visible = false;
        }
        

        protected void DetalleCasoOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgDetalleCaso.PageIndex = e.NewPageIndex;

            cargarDetalleCasos();
        }
    }
}