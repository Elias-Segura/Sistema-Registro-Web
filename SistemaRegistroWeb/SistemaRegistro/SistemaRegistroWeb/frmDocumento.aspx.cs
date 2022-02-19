using SistemaRegistro.CapaIntegracion;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;



namespace SistemaRegistroWeb
{
    public partial class frmDocumento : System.Web.UI.Page
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
                cargarDocumento();


                Visualizar.Visible = false;
                formulario.Visible = false;
                btnEditarArchivo.Visible = false;
                btnEliminar.Visible = false;
                cargarTramite();
                cargarIdioma();
                cargarMedio();
            }
        }

        private void cargarDocumento()
        {
            using (GestorDocumento gestorDocumento = new GestorDocumento())
            {

                dt = gestorDocumento.listarDocumentos("A");
                dgDocumento.DataSource = dt;
                dgDocumento.DataBind();
            }
        }

        private void cargarTramite()
        {
            using (GestorTramite gestorTramite = new GestorTramite())
            {
                DrpTramites.DataSource = gestorTramite.listarTramites("A");
                DrpTramites.DataValueField = "Tramite_id";
                DrpTramites.DataTextField = "Tramite_nombre";
                DrpTramites.DataBind();
            }
        }
        private void cargarIdioma()
        {
            using (GestorIdioma gestorIdioma = new GestorIdioma())
            {
                DrpIdioma.DataSource = gestorIdioma.listarIdioma("A");
                DrpIdioma.DataValueField = "Idioma_id";
                DrpIdioma.DataTextField = "Idioma_nombre";
                DrpIdioma.DataBind();

            }
        }

        private void cargarMedio()
        {
            using (GestorMedios gestorMedio = new GestorMedios())
            {
                DrpMedio.DataSource = gestorMedio.ListarMedios();
                DrpMedio.DataValueField = "Medio_id";
                DrpMedio.DataTextField = "Medio_nombre";
                DrpMedio.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (GestorDocumento gestorDocumento = new GestorDocumento())
            {
                dt = gestorDocumento.FiltrarDocumento(txtFiltro.Value, "A");
                dgDocumento.DataSource = dt;
                dgDocumento.DataBind();

            }
        }

   

        protected string copyFile(string filePath){
            string fileName;
            string file = filePath;
            string rutaRelativa;
            
            string serverFile = Server.MapPath("~/Archivos/");

            fileName = Path.GetFileName(filePath);//Extensión
            bool exists = File.Exists(Server.MapPath("Archivos/" + fileName));

            if (exists)
            {
                rutaRelativa = "Archivos/" + fileName;

                return rutaRelativa;
            }
            else if (File.Exists(filePath))//Si existe se agrega
            {
                //ARCHIVO
                fileName = Path.GetFileName(file);//Extensión

                string destFile = System.IO.Path.Combine(serverFile, fileName);//Convina la ruta y el archivo

                System.IO.File.Copy(filePath, destFile, true);//Copia

                rutaRelativa = "Archivos/" + fileName;

                return rutaRelativa;
            }
            else
            {
                return "";
            }
        }
                
                
                

        protected void dgDocumento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {

                int _id = Convert.ToInt32(e.CommandArgument);
                id = _id;
                formulario.Visible = true;
                contenedor.Visible = false;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                btnEditarArchivo.Visible = true;
                btnAgregarArchivo.Visible = false;
                cargarTramite();
                cargarIdioma();
                cargarMedio();

                using (GestorDocumento gestorDocumento = new GestorDocumento())
                {
                    ds = gestorDocumento.ConsultarDocumento(id);
                    dt = ds.Tables[0];
                }

                DrpTramites.SelectedValue = dt.Rows[0]["Tramite_id"].ToString();
                DrpIdioma.SelectedValue = dt.Rows[0]["Idioma_id"].ToString();
                DrpMedio.SelectedValue = dt.Rows[0]["Medio_id"].ToString();

                txtNombre.Value = dt.Rows[0]["Documento_nombre"].ToString();
                txtArchivo.Value = dt.Rows[0]["Documento_ruta"].ToString();
                
                Container.Src = copyFile(dt.Rows[0]["Documento_ruta"].ToString()); 
                txtTipo.Value = dt.Rows[0]["Documento_tipo"].ToString();
                FUpld_Archivo.Visible = false;
                btnEliminar.Visible = true;
            }
            else
            {
                return;
            }

        }


        protected void Modificar(object sender, EventArgs e)
        {


             if (txtNombre.Value != "" && txtArchivo.Value != "" && txtTipo.Value != ""
              && DrpTramites.SelectedValue != null && DrpMedio.SelectedValue != null && DrpIdioma.SelectedValue != null)
            {
                using (GestorDocumento gestorDocumento = new GestorDocumento())
                {
                    gestorDocumento.ModificarDocumento(id, int.Parse(DrpTramites.SelectedValue.ToString()), int.Parse(DrpIdioma.SelectedValue.ToString()), int.Parse(DrpMedio.SelectedValue.ToString()), txtNombre.Value, txtArchivo.Value, txtTipo.Value, "A");
                }

                cargarDocumento();
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

        protected void dgDocumento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgDocumento.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorDocumento gestorDocumento = new GestorDocumento())
                {

                    gestorDocumento.InactivarDocumento(id);
                    id = -1;
                    cargarDocumento();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }




        }


        private void reiniciarComponentes()
        {
            DrpTramites.SelectedValue = null;
            DrpIdioma.SelectedValue = null;
            DrpMedio.SelectedValue = null;

            txtNombre.Value ="";
            txtArchivo.Value = "";
            txtTipo.Value = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarComponentes();
            formulario.Visible = true;
            contenedor.Visible = false;

            cargarTramite();
            cargarIdioma();
            cargarMedio();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            btnEditarArchivo.Visible = false; 



        }

        protected void btnAgregar_Click(object sender, EventArgs e) 
        {
            if (txtNombre.Value != "" && txtArchivo.Value != "" && txtTipo.Value != ""
            && DrpTramites.SelectedValue != null && DrpMedio.SelectedValue != null && DrpIdioma.SelectedValue != null)
            {
                using (GestorDocumento gestorDocumento = new GestorDocumento())
                {
                    gestorDocumento.InsertarDocumento(int.Parse(DrpTramites.SelectedValue.ToString()), int.Parse(DrpIdioma.SelectedValue.ToString()), int.Parse(DrpMedio.SelectedValue.ToString()), txtNombre.Value, txtArchivo.Value, txtTipo.Value, "A");
                }

                cargarDocumento();
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


        


        protected void DocumentoOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgDocumento.PageIndex = e.NewPageIndex;

            cargarDocumento();
        }

        protected void ClickSubirClick(object sender, EventArgs e)
        {
            string extension = System.IO.Path.GetExtension(FUpld_Archivo.FileName);
            if (txtArchivo.Value != "")
            {
                btnEliminar.Visible = false;
                FUpld_Archivo.Visible = true;
                Visualizar.Visible = false;
                formulario.Visible = true;

            }
            
            else if (FUpld_Archivo.HasFile)//Si hay un archivo seleccionado
            {
                if (extension == ".jpg" || extension == ".PNG" || extension == ".pdf")//Extension
                {

                    FUpld_Archivo.SaveAs(Server.MapPath("~/Archivos/" + FUpld_Archivo.FileName));
                    txtArchivo.Value = Server.MapPath("~/Archivos/" + FUpld_Archivo.FileName);

                    btnEliminar.Visible = true;
                    FUpld_Archivo.Visible = false;
                    Visualizar.Visible = false;
                    formulario.Visible = true;
                    btnAgregarArchivo.Visible = false;
                    btnEditarArchivo.Visible = true;

                    ClientScript.RegisterStartupScript(GetType(), "Agregado", "swal('Agregado','El archivo fue agregado con exito', 'success')", true);
                }
                else
                {
              
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','No es una extensión válida', 'error')", true);
                }
            }
            else
            {
     
                ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','Seleccione un archivo', 'error')", true);
            }
        }

        protected void ClickEliminar(object sender, EventArgs e)
        {
            if (txtArchivo.Value != "")
            {
                txtArchivo.Value = "";
                FUpld_Archivo.Visible = true;
                btnEliminar.Visible = false;

            }
            else
            {
                btnEliminar.Visible = false;
            }
        }

        protected void ClickVisualizar(object sender, EventArgs e)
        {
            try
            {
                if (txtArchivo.Value != "")
                {
                    btnEliminar.Visible = true;
                }
                else
                {
                    btnEliminar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                this.Session["exceptionMessage"] = ex.Message;
                System.Diagnostics.Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            formulario.Visible = contenedor.Visible = false;
            Visualizar.Visible = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            FUpld_Archivo.SaveAs(Server.MapPath("~/Archivos/" + FUpld_Archivo.FileName));
            txtArchivo.Value = Server.MapPath("~/Archivos/" + FUpld_Archivo.FileName);

            btnEliminar.Visible = true;
            FUpld_Archivo.Visible = false;
            Visualizar.Visible = true;
            formulario.Visible = false;
           
        }

 
    }
}