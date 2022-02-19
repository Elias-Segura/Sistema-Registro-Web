using SistemaRegistro.CapaIntegracion;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SistemaRegistroWeb
{
    public partial class frmHistorialData : System.Web.UI.Page
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

                #region CALLS
                if (Request.QueryString["function"] == "Departamento")
                {
                    ColumnsDepartamento();
                    cargarDepartamento();
                   
                }else if(Request.QueryString["function"] == "Ciclo")
                {
                    ColumnsCiclos();
                    cargarCiclos();
                }
                else if (Request.QueryString["function"] == "Codigo")
                {
                    ColumnsCodigo();
                    cargarCodigo();
                }
                else if (Request.QueryString["function"] == "Caso")
                {
                    ColumnsCasos();
                    cargarCaso();
                }
                else if (Request.QueryString["function"] == "Empleado")
                {
                    ColumnsEmpleados();
                    cargarEmpleados();
                }
                else if (Request.QueryString["function"] == "Tramite")
                {
                    ColumnsTramites();
                    cargarTramites();
                }
                else if (Request.QueryString["function"] == "Organizacion")
                {
                    ColumnsOrganizaciones();
                    cargarOrganizacion();
                }
                else if (Request.QueryString["function"] == "DetalleCaso")
                {
                    ColumnsDetalleCasos();
                    cargarDetalleCasos();
                }
                else if (Request.QueryString["function"] == "Documento")
                {
                    ColumnsDocumentos();
                    cargarDocumentos();
                }
                else if (Request.QueryString["function"] == "Idioma")
                {
                    ColumnsIdiomas();
                    cargarIdiomas();
                }


                #endregion
            }




 



        }

        protected void ColumnsIdiomas()
        {
            
            dgVista.DataKeyNames = new string[] { "Idioma_id" };
            title.InnerText = "Idiomas";
            titleFiltro.InnerText = "Buscar por nombre:";


            BoundField b = new BoundField();
            b.DataField = "Idioma_nombre";
            b.HeaderText = "Nombre";
            dgVista.Columns.Add(b);


            b = new BoundField();
            b.DataField = "Idioma_iniciales";
            b.HeaderText = "Iniciales";
            dgVista.Columns.Add(b);


        }

        protected void ColumnsDocumentos()
        {
            dgVista.DataKeyNames = new string[] { "Documento_id" };
            title.InnerText = "Documentos";
            titleFiltro.InnerText = "Buscar por código:";


            BoundField b = new BoundField();
            b.DataField = "Tramite_nombre";
            b.HeaderText = "Trámite";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Idioma_nombre";
            b.HeaderText = "Idioma";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Medio_nombre";
            b.HeaderText = "Medio";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Documento_nombre";
            b.HeaderText = "Nombre";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Documento_ruta";
            b.HeaderText = "Archivo";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Documento_tipo";
            b.HeaderText = "Tipo";
            dgVista.Columns.Add(b);
        }

        protected void ColumnsDetalleCasos()
        {
            dgVista.DataKeyNames = new string[] { "DetalleCaso_id" };
            title.InnerText = "Detalle Casos";
            titleFiltro.InnerText = "Buscar por código:";


            BoundField b = new BoundField();
            b.DataField = "Caso_codigo";
            b.HeaderText = "Código";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Ciclo_orden";
            b.HeaderText = "Ciclo";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Documento_nombre";
            b.HeaderText = "Documento";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "DetalleCaso_fechaRecibido";
            b.HeaderText = "Fecha de Recibido";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "DetalleCaso_fechaTraspaso";
            b.HeaderText = "Fecha de Traspaso";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "DetalleCaso_descripcion";
            b.HeaderText = "Descripción";
            dgVista.Columns.Add(b);
        }

        protected void ColumnsOrganizaciones()
        {
            dgVista.DataKeyNames = new string[] { "Organizacion_id" };
            title.InnerText = "Organizaciones";
            titleFiltro.InnerText = "Buscar por nombre:";


            BoundField b = new BoundField();
            b.DataField = "Organizacion_nombre";
            b.HeaderText = "Nombre";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Organizacion_tipo";
            b.HeaderText = "Tipo";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Organizacion_descripcion";
            b.HeaderText = "Descripción";
            dgVista.Columns.Add(b);



        }
        protected void ColumnsTramites()
        {

            dgVista.DataKeyNames = new string[] { "Tramite_id" };
            title.InnerText = "Tramites";
            titleFiltro.InnerText = "Buscar por nombre:";


            BoundField b = new BoundField();
            b.DataField = "Tramite_nombre";
            b.HeaderText = "Nombre";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Tramite_descripcion";
            b.HeaderText = "Descripción";
            dgVista.Columns.Add(b);

        }
        protected void ColumnsEmpleados()
        {
            dgVista.DataKeyNames = new string[] { "Empleado_id" };
            title.InnerText = "Empleados";
            titleFiltro.InnerText = "Buscar por nombre:";


            BoundField b = new BoundField();
            b.DataField = "Departamento_nombre";
            b.HeaderText = "Departamento";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Puesto_nombre";
            b.HeaderText = "Puesto";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Genero_nombre";
            b.HeaderText = "Genero";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "TEstadoCivil_nombre";
            b.HeaderText = "Estado Civil";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Empleado_nombre";
            b.HeaderText = "Nombre";
            dgVista.Columns.Add(b);


            b = new BoundField();
            b.DataField = "Empleado_primerApellido";
            b.HeaderText = "Primer Apellido";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Empleado_segundoApellido";
            b.HeaderText = "Segundo Apellido";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Empleado_fechaNacimiento";
            b.HeaderText = "Fecha Nacimiento";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Empleado_fechaIngreso";
            b.HeaderText = "Fecha Ingreso";
            dgVista.Columns.Add(b);







        }
          protected void ColumnsCasos()
         {

            dgVista.DataKeyNames = new string[] { "Caso_id" };
            title.InnerText = "Casos";
            titleFiltro.InnerText = "Buscar por código:";



            BoundField b = new BoundField();
            b.DataField = "Caso_codigo";
            b.HeaderText = "Código";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Caso_fechaInicio";
            b.HeaderText = "Fecha Inicio";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Caso_fechaFinal";
            b.HeaderText = "Fecha Final";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Tramite_nombre";
            b.HeaderText = "Tramite";
            dgVista.Columns.Add(b);

            b = new BoundField();
            b.DataField = "Tramite_nombre";
            b.HeaderText = "Tramite";
            dgVista.Columns.Add(b);







        }

        protected void ColumnsCodigo()
        {


            dgVista.DataKeyNames = new string[] { "Codigo_id" };
            title.InnerText = "Códigos";
            titleFiltro.InnerText = "Buscar por formato:";

            BoundField b = new BoundField();
            b.DataField = "Organizacion_nombre";
            b.HeaderText = "Organización";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Codigo_formato";
            b.HeaderText = "Formato";
            dgVista.Columns.Add(b);



        }

        protected void ColumnsCiclos()
        {
                 

            dgVista.DataKeyNames = new string[] { "Ciclo_id" };
            title.InnerText = "Ciclos";
            titleFiltro.InnerText = "Buscar por departamento:";

            BoundField b = new BoundField();
            b.DataField = "Tramite_nombre";
            b.HeaderText = "Tramite";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Departamento_nombre";
            b.HeaderText = "Departamento";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Ciclo_orden";
            b.HeaderText = "Orden";
            dgVista.Columns.Add(b);
   


        }
        protected void ColumnsDepartamento()
        {

            dgVista.DataKeyNames = new string[] { "Departamento_id" };
            title.InnerText = "Departamentos";
            titleFiltro.InnerText = "Buscar por nombre:"; 
            BoundField b = new BoundField();
            b.DataField = "Departamento_nombre";
            b.HeaderText = "Nombre";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Departamento_descripcion";
            b.HeaderText = "Descripción";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "Organizacion_nombre";
            b.HeaderText = "Organización";
            dgVista.Columns.Add(b);
            b = new BoundField();
            b.DataField = "DepartamentoTipo_nombre";
            b.HeaderText = "Tipo";
            dgVista.Columns.Add(b);

        }
        protected void cargarDepartamento()
        {

            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {
                dt = gestorDepartamento.ListarDepartamento("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void cargarCiclos()
        {
            using (GestorCiclo gestorCiclo = new GestorCiclo())
            {

                dt = gestorCiclo.ListarCiclo("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();


            }

        }
        protected void cargarCodigo()
        {
            using (GestorCodigo gestorCodigo = new GestorCodigo())
            {

                dt = gestorCodigo.ListarCodigo("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();


            }

        }

        protected void cargarCaso()
        {
            using (GestorCaso gestorCaso = new GestorCaso())
            {

                dt = gestorCaso.listarCasos("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }

        }
        protected void cargarEmpleados()
        {
            using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
            {

                dt = gestorEmpleado.listarEmpleado("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }

        }
        protected void cargarTramites()
        {
            using (GestorTramite gestorTramite = new GestorTramite())
            {
                dt = gestorTramite.listarTramites("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }
        }

        protected void cargarOrganizacion()
        {
            using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
            {
                dt = gestorOrganizacion.listarOrganizacion("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }
        }

        protected void cargarDetalleCasos()
        {
            using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
            {
                dt = gestorDetalleCaso.listarDetalleCasos("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }
        }
        protected void cargarDocumentos()
        {
            using (GestorDocumento gestorDocumento = new GestorDocumento())
            {
                dt = gestorDocumento.listarDocumentos("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }
        }
        protected void cargarIdiomas()
        {
            using (GestorIdioma gestorIdioma = new GestorIdioma())
            {
                dt = gestorIdioma.listarIdioma("I");
                dgVista.DataSource = dt;
                dgVista.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region CALLS
            if (Request.QueryString["function"] == "Departamento")
            {
                FiltrarDepartamento();
            }else if(Request.QueryString["function"] == "Ciclo")
            {
                FiltrarCiclo();
            }
            else if (Request.QueryString["function"] == "Codigo")
            {
                FiltrarCodigo();
            }
            else if (Request.QueryString["function"] == "Caso")
            {
                FiltrarCaso();
            }
            else if (Request.QueryString["function"] == "Empleado")
            {
                FiltrarEmpleado();
            }
            else if (Request.QueryString["function"] == "Tramite")
            {
                FiltrarEmpleado();
            }
            else if (Request.QueryString["function"] == "Organizacion")
            {
                FiltrarOrganizacion();
            }
            else if (Request.QueryString["function"] == "Detallecaso")
            {
                FiltrarDetalleCaso();
            }
            else if (Request.QueryString["function"] == "Documento")
            {
                FiltrarDocumento();
            }
            else if (Request.QueryString["function"] == "Idioma")
            {
                FiltrarIdioma();
            }


            #endregion
        }

        protected void FiltrarDepartamento()
        {
            using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
            {
                dt = gestorDepartamento.FiltrarDepartamento(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarCiclo()
        {
            using (GestorCiclo gestorCiclo = new GestorCiclo())
            {
                dt = gestorCiclo.FiltrarCiclo(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarCodigo()
        {
            using (GestorCodigo gestorCodigo = new GestorCodigo())
            {
                dt = gestorCodigo.FiltrarCodigo(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }

        protected void FiltrarCaso()
        {
            using (GestorCaso gestorCaso = new GestorCaso())
            {
                dt = gestorCaso.FiltrarCasos(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }

        protected void FiltrarEmpleado()
        {
            using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
            {
                dt = gestorEmpleado.FiltrarEmpleado(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarTramite()
        {
            using (GestorTramite gestorTramite = new GestorTramite())
            {
                dt = gestorTramite.FiltrarTramite(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarOrganizacion()
        {
            using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
            {
                dt = gestorOrganizacion.FiltrarOrganizacion(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarDetalleCaso()
        {
            using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
            {
                dt = gestorDetalleCaso.FiltrarDetalleCaso(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarDocumento()
        {
            using (GestorDocumento gestorDetalleCaso = new GestorDocumento())
            {
                dt = gestorDetalleCaso.FiltrarDocumento(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void FiltrarIdioma()
        {
            using (GestorIdioma gestorIdioma = new GestorIdioma())
            {
                dt = gestorIdioma.FiltrarIdioma(txtFiltro.Value, "I");
                dgVista.DataSource = dt;
                dgVista.DataBind();

            }
        }
        protected void dgVista_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if(dgVista.DataKeys.Count > 0)
            {
                int _id = Convert.ToInt32(dgVista.DataKeys[e.RowIndex].Value);
                id = _id;
                #region CALLS
                if (Request.QueryString["function"] == "Departamento")
                {
                    RecuperarDepartamento();
                }
                else if (Request.QueryString["function"] == "Ciclo")
                {
                    RecuperarCiclos();
                }
                else if (Request.QueryString["function"] == "Codigo")
                {
                    RecuperarCodigos();
                }
                else if (Request.QueryString["function"] == "Caso")
                {
                    RecuperarCasos();
                }
                else if (Request.QueryString["function"] == "Empleado")
                {
                    RecuperarEmpleados();
                }
                else if (Request.QueryString["function"] == "Tramite")
                {
                    RecuperarTramites();
                }
                else if (Request.QueryString["function"] == "Organizacion")
                {
                    RecuperarOrganizaciones();
                }
                else if (Request.QueryString["function"] == "DetalleCaso")
                {
                    RecuperarDetalleCasos();
                }
                else if (Request.QueryString["function"] == "Documento")
                {
                    RecuperarDocumento();
                }
                else if (Request.QueryString["function"] == "Idioma")
                {
                    RecuperarIdioma();
                }
                #endregion
            }


        }

        protected void RecuperarDepartamento()
        {

            if (id != -1)
            {
                using (GestorDepartamento gestorDepartamento = new GestorDepartamento())
                {

                    gestorDepartamento.ActivarDepartamento(id);
                    id = -1;
                    cargarDepartamento();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }
        protected void RecuperarCiclos()
        {

            if (id != -1)
            {
                using (GestorCiclo gestorCiclo = new GestorCiclo())
                {

                    gestorCiclo.ActivarCiclo(id);
                    id = -1;
                    cargarCiclos();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }
        protected void RecuperarCodigos()
        {

            if (id != -1)
            {
                using (GestorCodigo gestorCodigo = new GestorCodigo())
                {

                    gestorCodigo.ActivarCodigo(id);
                    id = -1;
                    cargarCodigo();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }
        protected void RecuperarCasos()
        {

            if (id != -1)
            {
                using (GestorCaso gestorCaso = new GestorCaso())
                {

                    gestorCaso.ActivarCaso(id);
                    id = -1;
                    cargarCaso();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }

        protected void RecuperarEmpleados()
        {

            if (id != -1)
            {
                using (GestorEmpleado gestorEmpleado = new GestorEmpleado())
                {

                    gestorEmpleado.ActivarEmpleado(id);
                    id = -1;
                    cargarEmpleados();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }
        protected void RecuperarTramites()
        {

            if (id != -1)
            {
                using (GestorTramite gestorTramite = new GestorTramite())
                {

                    gestorTramite.ActivarTramite(id);
                    id = -1;
                    cargarTramites();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }


        protected void RecuperarOrganizaciones()
        {

            if (id != -1)
            {
                using (GestorOrganizacion gestorOrganizacion = new GestorOrganizacion())
                {

                    gestorOrganizacion.ActivarOrganizacion(id);
                    id = -1;
                    cargarOrganizacion();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }
        protected void RecuperarDetalleCasos()
        {

            if (id != -1)
            {
                using (GestorDetalleCaso gestorDetalleCaso = new GestorDetalleCaso())
                {

                    gestorDetalleCaso.ActivarDetalleCaso(id);
                    id = -1;
                    cargarDetalleCasos();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }

        protected void RecuperarDocumento()
        {

            if (id != -1)
            {
                using (GestorDocumento gestorDocumento = new GestorDocumento())
                {

                    gestorDocumento.ActivarDocumento(id);
                    id = -1;
                    cargarDocumentos();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }
        protected void RecuperarIdioma()
        {

            if (id != -1)
            {
                using (GestorIdioma gestorIdioma = new GestorIdioma())
                {

                    gestorIdioma.ActivarIdioma(id);
                    id = -1;
                    cargarIdiomas();
                    ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Recuperado','El dato fue recuperado', 'success')", true);
                }
            }
        }



        protected void dgVista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgVista.PageIndex = e.NewPageIndex;

            #region CALLS
            if (Request.QueryString["function"] == "Departamento")
            {
                cargarDepartamento();
            }
            else if (Request.QueryString["function"] == "Ciclo")
            {
                cargarCiclos();
            }
            else if (Request.QueryString["function"] == "Codigo")
            {
                cargarCodigo();
            }
            else if (Request.QueryString["function"] == "Caso")
            {
                cargarCaso();
            }
            else if (Request.QueryString["function"] == "Empleado")
            {
                cargarEmpleados();
            }
            else if (Request.QueryString["function"] == "Tramite")
            {
                cargarTramites();
            }
            else if (Request.QueryString["function"] == "Organizacion")
            {
                cargarOrganizacion();
            }
            else if (Request.QueryString["function"] == "DetalleCaso")
            {
                cargarDetalleCasos();
            }
            else if (Request.QueryString["function"] == "Documento")
            {
                cargarDocumentos();
            }
            else if (Request.QueryString["function"] == "Idioma")
            {
                cargarIdiomas();
            }
            #endregion
        }
    }
}