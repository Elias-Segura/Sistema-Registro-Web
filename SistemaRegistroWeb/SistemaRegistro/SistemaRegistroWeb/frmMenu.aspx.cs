using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaRegistroWeb
{
    public partial class frmMenu : System.Web.UI.Page
    {
        static string name=""; 
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                
            {
                if (name == "")
                {
                    Context.Items["Id"] = Request.QueryString["name"];
                    try
                    {
                        if (String.IsNullOrEmpty(Context.Items["Id"].ToString()) && name == "")
                        {
                            Response.Redirect("login.aspx");
                        }
                        else
                        {

                           
                            name = Request.QueryString["name"];

                                


                            if (Request.QueryString["rol"] != "ADMINISTRADOR")
                            {
                                historial.Visible = false;
                                usuarios.Visible = false;
                           
                            }

                        }




                    }
                    catch (Exception)
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                else
                {
                    name = Request.QueryString["name"];




                    if (Request.QueryString["rol"] != "ADMINISTRADOR")
                    {
                        historial.Visible = false;
                        usuarios.Visible = false;
                       
                    }
                }

                if (Request.QueryString["rol"] != "ADMINISTRADOR" && Request.QueryString["rol"] != "REGULAR")
                {
                    Response.Redirect("login.aspx");
                }

                NameUser.InnerText = name;



                main.Src = "frmDepartamento.aspx?name=view";

            }

           
        }
        protected void loadDepartamentos(object sender, EventArgs e)
        {
            
            main.Src = "frmDepartamento.aspx?name=view";

        }
        protected void loadCasos(object sender, EventArgs e)
        {

            main.Src = "frmCaso.aspx?name=view";
        }
        protected void loadCiclos(object sender, EventArgs e)
        {
            main.Src = "frmCiclo.aspx?name=view";
        }
        protected void loadTramites(object sender, EventArgs e)
        {
            main.Src = "frmTramite.aspx?name=view";
        }
        protected void loadEmpleados(object sender, EventArgs e)
        {

            main.Src = "frmEmpleado.aspx?name=view";

        }
        protected void loadOrganizaciones(object sender, EventArgs e)
        {

            main.Src = "frmOrganizacion.aspx?name=view";
           
        }
        protected void loadCodigos(object sender, EventArgs e)
        {
            main.Src = "frmcodigo.aspx?name=view";
        }

        protected void loadDetalleCasos(object sender, EventArgs e)
        {
            main.Src = "frmDetalleCaso.aspx?name=view";
        }

        protected void loadDocumentos(object sender, EventArgs e)
        {
            main.Src = "frmDocumento.aspx?name=view";
        }

        protected void loadIdiomas(object sender, EventArgs e)
        {
            main.Src = "frmIdioma.aspx?name=view";
        }
        protected void loadUsuarios(object sender, EventArgs e)
        {
            main.Src = "frmUsuario.aspx?name=view";
        }



        protected void loadDepartamentosH(object sender, EventArgs e)
        {
                 main.Src = "frmHistorialData.aspx?name=view&function=Departamento";
        }
        protected void loadCasosH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Caso";
        }
        protected void loadEmpleadosH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Empleado";
        }
        protected void loadTramitesH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Tramite";
        }
        protected void loadCiclosH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Ciclo";
        }
        protected void loadOrganizacionesH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Organizacion";
        }
        protected void loadCodigosH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Codigo";
        }
        protected void loadDetalleCasosH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=DetalleCaso";
        }

        protected void loadDocumentosH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Documento";
        }

        protected void loadIdiomasH(object sender, EventArgs e)
        {
            main.Src = "frmHistorialData.aspx?name=view&function=Idioma";
        }
        protected void CerrarSesion(object sender, EventArgs e)
        {
            Context.Items["Id"] = null;
            Response.Redirect("Login.aspx"); 
        }
    }
}