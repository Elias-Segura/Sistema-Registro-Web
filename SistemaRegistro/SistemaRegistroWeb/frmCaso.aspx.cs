using SistemaRegistro.CapaIntegracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SistemaRegistroWeb
{
    public partial class frmCaso : System.Web.UI.Page
    {
        static int id=-1;
        DataSet ds;
        DataTable dt;
       
        DateTime today = DateTime.Today;
        public static string selecedDate;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string c = Request.QueryString["name"];
                if (c != "view")
                {
                    Response.Redirect("login.aspx");
                }
                cargarCaso();
                formulario.Visible = false;
                txtFechaInicio.Value = DateTime.Today.ToLongDateString();

                CldFechaFinal.Visible = false;
                DrpTramiteFiltro.Visible = false;

                
                cargarDropList();
                cargarOrganizaciones();
                cargarTramites();

            }

            DrpTramite_SelectedIndexChanged(sender, e);
            DrpOrganizacion_SelectedIndexChanged(sender, e);
        }
     
        private void reiniciarComponentes()
        {
            txtFechaFinal.Value = "";

            txtCodigo.Value = "";
            DrpTramite.SelectedValue = null;
        }

        protected void cargarDropList()
        {
            ListItem list;
            list = new ListItem("Código");
            DrpTipoFiltro.Items.Add(list);
            list = new ListItem("Trámite");
            DrpTipoFiltro.Items.Add(list);
        }

        protected void cargarCaso()
        {
            using (GestorCaso gestorCaso = new GestorCaso())
            {
                dt = gestorCaso.listarCasos("A");
                dgCodigo.DataSource = dt;
                dgCodigo.DataBind();
            }
        }

        
      


        protected void cargarOrganizaciones()
        {
            using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
            {
                DrpOrganizacion.DataSource = gestorOrganizacion.listarOrganizacion("A");
                DrpOrganizacion.DataValueField = "Organizacion_id";
                DrpOrganizacion.DataTextField = "Organizacion_nombre";
                DrpOrganizacion.DataBind();
            }
        }

        protected void cargarTramites()
        {
            using (GestorTramite gestorTramite = new GestorTramite())
            {

                DrpTramite.DataSource = gestorTramite.listarTramites("A");
                DrpTramite.DataValueField = "Tramite_id";
                DrpTramite.DataTextField = "Tramite_nombre";
                DrpTramite.DataBind();

                DrpTramiteFiltro.DataSource = gestorTramite.listarTramites("A");
                DrpTramiteFiltro.DataValueField = "Tramite_id";
                DrpTramiteFiltro.DataTextField = "Tramite_nombre";
                DrpTramiteFiltro.DataBind();
            }
        }

        private void ConsultarTramite()
        {
            try
            {
                if (DrpTramite.SelectedValue != null)
                {
                    using (GestorTramite gestorTramite = new GestorTramite())
                    {
                        DataSet ds = new DataSet();
                        ds = gestorTramite.ConsultarTramite(int.Parse(DrpTramite.SelectedValue.ToString()));
                        DataTable dt = new DataTable();
                        dt = ds.Tables[0];
                        txtAreaDocumento.Value = dt.Rows[0]["Tramite_descripcion"].ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void EvenIndexChanged(object sender, EventArgs e)
        {
            if (DrpTipoFiltro.SelectedValue.ToString() =="Trámite")
            {
                DrpTramiteFiltro.Visible = true;
                txtFiltro.Value = null;
            }
            else
            {
                DrpTramiteFiltro.Visible = false;
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DrpTipoFiltro.SelectedValue != null)
            {

                if (DrpTipoFiltro.SelectedValue.ToString() == "Código" && txtFiltro.Value != "")
                {
                    using (GestorCaso gestorCaso = new GestorCaso())
                    {
                        dt = gestorCaso.FiltrarCasos(txtFiltro.Value, "A");
                        dgCodigo.DataSource = dt;
                        dgCodigo.DataBind();
                        txtFiltro.Value = null;
                        DrpTramiteFiltro.Visible = false;
                    }
                }
                else if (DrpTipoFiltro.SelectedValue.ToString() == "Código" && txtFiltro.Value == "")
                {
                    cargarCaso();
                }

                else if (DrpTipoFiltro.SelectedValue.ToString() == "Trámite" && DrpTramiteFiltro.SelectedValue != null)
                {

                    using (GestorCaso gestorCaso = new GestorCaso())
                    {
                        dt = gestorCaso.FiltrarCasoTramite(int.Parse(DrpTramiteFiltro.SelectedValue.ToString()));
                        dgCodigo.DataSource = dt;
                        dgCodigo.DataBind();
                        DrpTramiteFiltro.Visible = true;
                    }
                }
                txtFiltro.Value = null;
            }
        }
        

        protected void dgCaso_RowCommand(object sender, GridViewCommandEventArgs e)
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
                cargarTramites();



                using (GestorCaso gestorCaso = new GestorCaso())
                {
                    ds = gestorCaso.ConsultarCaso(id);
                    dt = ds.Tables[0];
                }

                DrpTramite.SelectedValue = dt.Rows[0]["Tramite_id"].ToString();
                txtCodigo.Value = dt.Rows[0]["Caso_codigo"].ToString();

                txtFechaInicio.Value = dt.Rows[0]["Caso_fechaInicio"].ToString();
                txtFechaFinal.Value = dt.Rows[0]["Caso_fechaFinal"].ToString();
            }
            else
            {
                return;
            }

        }
        
        protected void Modificar(object sender, EventArgs e)
        {
       
                if (txtCodigo.Value != "" && DrpOrganizacion.SelectedValue != null && DrpTramite.SelectedValue != null)
                {
                    using (GestorCaso gestorCaso = new GestorCaso())
                    {
                        gestorCaso.ModificarCaso(id, int.Parse(DrpTramite.SelectedValue.ToString()), txtCodigo.Value, Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")), Convert.ToDateTime(selecedDate), "A");
                    }
                    cargarCaso();
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

        
        protected void dgCodigo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(dgCodigo.DataKeys[e.RowIndex].Value);
            id = _id;

            if (id != -1)
            {
                using (GestorCaso gestorCaso = new GestorCaso())
                {

                    gestorCaso.InactivarCaso(id);
                    id = -1;
                    cargarCaso();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Eliminado','El dato fue eliminado', 'success')", true);
                }
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            reiniciarComponentes();
            formulario.Visible = true;
            contenedor.Visible = false;

            cargarOrganizaciones();
            cargarTramites();
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
        }

       
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Value != "" && DrpOrganizacion.SelectedValue != null && DrpTramite.SelectedValue != null && txtFechaFinal.Value != "")
            {
                using (GestorCaso gestorCaso = new GestorCaso())
                {
                   
                    gestorCaso.InsertarCaso(int.Parse(DrpTramite.SelectedValue.ToString()), txtCodigo.Value, Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")), Convert.ToDateTime(selecedDate), "A");
                  
                }


                cargarCaso();
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

        protected void btnFechaFinal_Click(object sender, EventArgs e)
        {
            CldFechaFinal.Visible = !CldFechaFinal.Visible;
        }

        protected void CldSelectionChanged(object sender, EventArgs e)
        {
            selecedDate = CldFechaFinal.SelectedDate.ToString("yyyy-MM-dd");
            txtFechaFinal.Value = CldFechaFinal.SelectedDate.ToLongDateString();
            CldFechaFinal.Visible = false;

        }

        protected void CasoOnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgCodigo.PageIndex = e.NewPageIndex;

            cargarCaso();
        }

        protected void DrpTramite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarTramite();
        }

        private void GenerarCodigo()
        {
            try
            {
                using (GestorCaso caso = new GestorCaso())
                {

                    DataTable dt = caso.GenerarCodigo(int.Parse(DrpOrganizacion.SelectedValue.ToString()));

                    if (dt.Rows.Count <= 0)
                    {
                        using (GestorCodigo gestorCodigo = new GestorCodigo())
                        {
                            DataSet ds = gestorCodigo.ConsultarCodigoOrg(int.Parse(DrpOrganizacion.SelectedValue.ToString()));
                            DataTable dtCodigo = ds.Tables[0];

                            if (dtCodigo.Rows.Count > 0)
                            {

                                //consulta si hay ciclos que tienen departamento de la organizacion y el tramite.
                                using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
                                {
                                    DataTable dtCiclo = gestorDepartamento.DepartamentoTramitePorOrg(int.Parse(DrpOrganizacion.SelectedValue.ToString()), int.Parse(DrpTramite.SelectedValue.ToString()));

                                    if (dtCiclo.Rows.Count > 0)
                                    {
                                        txtCodigo.Value = dtCodigo.Rows[0]["Codigo_formato"].ToString() + "0";
                                    }
                                    else
                                    {
                                        txtCodigo.Value = "";
                                        ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','No hay departamentos en la organización con este tramite', 'error')", true);
                                    }
                                }


                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','La organización no tiene un formato de código', 'error')", true);
                                txtCodigo.Value ="";
                            }
                        }

                    }
                    else
                    {

                        int p = int.Parse(dt.Rows[dt.Rows.Count - 1]["Caso_codigo"].ToString().Replace(dt.Rows[dt.Rows.Count - 1]["Codigo_formato"].ToString(), ""));
                        p = p + 1;
                        txtCodigo.Value = dt.Rows[dt.Rows.Count - 1]["Codigo_formato"].ToString() + p.ToString();

                    }


                }


            }
            catch (Exception)
            {

            }
        }
        protected void DrpOrganizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (id == -1){
                GenerarCodigo();
            }
            
        }
    }
}