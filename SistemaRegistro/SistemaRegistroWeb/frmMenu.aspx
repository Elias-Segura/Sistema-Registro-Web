<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMenu.aspx.cs" Inherits="SistemaRegistroWeb.frmMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    	  

<head runat="server">

        <title>Sistema Registro</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet"/>
		
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
	<link rel="stylesheet" href="css/style.css"/>

</head>  
<body>
   <form id="form1" runat="server">
   	<div class="wrapper d-flex align-items-stretch">
			<nav id="sidebar">

                <div class="custom-menu">
					<button type="button" id="sidebarCollapse" class="btn btn-primary"  >
	        </button>
        </div>
	  		<div class="img bg-wrap text-center py-4">
	  			<div class="user-logo">
	  				<div class="img" style="background-image: url(images/persona.png);"></div>
	  				<h3 id="NameUser" runat="server">ADMIN </h3>
	  			</div>
	  		</div>
       
<ul class="list-unstyled components mb-5">
                 
          <li  >
              <a href="#"  onserverclick="loadDepartamentos" runat="server">Departamentos</a>
          </li>
          <li >
            <a href="#"  onserverclick="loadCasos" runat="server" >Casos</a>  
          </li>
          <li>
            <a href="#" onserverclick="loadEmpleados" runat="server"> Empleados</a> 
          </li>
          <li>
            <a href="#" onserverclick="loadTramites" runat="server">Tramites</a>
          </li>
          <li>
            <a href="#"  onserverclick="loadCiclos"  runat="server"> Ciclos</a>
          </li>
             <li>
            <a href="#" onserverclick="loadOrganizaciones"  runat="server"> Organizaciones</a>
          </li>
             <li>
            <a href="#"  onserverclick="loadCodigos"  runat="server">Códigos</a>
          </li>
             <li>
            <a href="#" onserverclick="loadDetalleCasos" runat="server"> Detalle Caso</a>  
          </li>
             <li> 
            <a href="#" onserverclick="loadDocumentos" runat="server"> Documentos</a> 
          </li>
             <li>
            <a href="#" onserverclick="loadIdiomas" runat="server"> Idiomas</a> 
          </li>
    
          <li class="active" id="historial" runat="server">
                <a href="#historialSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Historial</a>
                <ul class="collapse list-unstyled" id="historialSubmenu" runat="server">
                    <li>
                        <a href="#" onserverclick="loadDepartamentosH"  runat="server">Departamentos</a>
                    </li>
                     <li>
                        <a href="#" onserverclick="loadCasosH"  runat="server">   Casos </a>
                    </li>
                     <li>
                        <a href="#" onserverclick="loadEmpleadosH"  runat="server"> Empleados </a>
                    </li>
                     <li>
                        <a href="#" onserverclick="loadTramitesH"  runat="server">Tramites</a>
                    </li>
                    <li>
                        <a href="#" onserverclick="loadCiclosH"  runat="server">   Ciclos</a>
                    </li>
                     <li>
                        <a href="#" onserverclick="loadOrganizacionesH"  runat="server">Organizaciones</a>
                    </li>
                     <li>
                        <a href="#" onserverclick="loadCodigosH"  runat="server">Códigos</a>
                    </li>

                     <li>
                        <a href="#" onserverclick="loadDetalleCasosH"  runat="server"> Detalle Caso</a>
                    </li>

                     <li>
                        <a href="#" onserverclick="loadDocumentosH"  runat="server">   Documentos</a>
                    </li>
                     <li>
                        <a href="#" onserverclick="loadIdiomasH"  runat="server">   Idiomas</a>
                    </li>
                </ul>
            </li>




             <li id="usuarios" runat="server">
            <a href="#" onserverclick="loadUsuarios" runat="server"> Usuarios</a> 
          </li>
          <li>
            <a href="#"  onserverclick="CerrarSesion"  runat="server"> Cerrar Sesión</a> 
          </li>
        </ul>
    	</nav>

        <!-- Page Content  -->


      <div id="content" class="p-4 p-md-5 pt-5">
        <iframe id="main" src ="" width="100%" height="650px" runat="server" frameBorder="0">
           
         </iframe>
      
      </div>
		</div>

    <script src="js/jquery.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
       
	<script src="Styles/jquery/jquery-3.2.1.min.js"></script>


    </form>




</body>
</html>
