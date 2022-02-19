<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaRegistroWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	 
	 <script language="C#" runat="server">

         protected void LoginCheck(object sender, EventArgs e)

         {

             if(txtNombre.Value.Length != 0 && txtContraseña.Value.Length != 0)
             {

                 using(SistemaRegistro.CapaIntegracion.GestorUsuario gestorUsuario = new SistemaRegistro.CapaIntegracion.GestorUsuario())
                 {
                     try
                     {
                         System.Data.DataTable dt = new System.Data.DataTable();
                         System.Data.DataSet data = gestorUsuario.verificarUsuario(txtNombre.Value,txtContraseña.Value);

                         if (data == null)
                         {
							  ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','Error de servidor', 'error')", true);
                         }
                         else
                         {
                             dt = data.Tables[0];
                         }

                         if (data.Tables[0].Rows.Count != 0)
                         {
                             SistemaRegistro.CapaLogica.LogicaNegocio.Usuario usuario = new SistemaRegistro.CapaLogica.LogicaNegocio.Usuario(int.Parse(dt.Rows[0]["Rol_id"].ToString()), dt.Rows[0]["Usuario_nombre"].ToString(), dt.Rows[0]["Usuario_primerApellido"].ToString(), dt.Rows[0]["Usuario_segundoApellido"].ToString(), dt.Rows[0]["Usuario_contrasenna"].ToString(), dt.Rows[0]["Usuario_estado"].ToString());

                             Context.Items["Id"] = (usuario.Usuario_nombre + " " + usuario.Usuario_primerApellido );
                             Response.Redirect("frmMenu.aspx?name=" + (usuario.Usuario_nombre + " " + usuario.Usuario_primerApellido ) + "&rol=" +dt.Rows[0]["Rol_tipo"].ToString());



                         }
                         else
                         {
                           
							  ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','Datos no validos', 'error')", true);
                         }


                     }
                     catch (Exception)
                     {

                     }


                 }
             }
             else
             {
             
				  ClientScript.RegisterStartupScript(GetType(), "Sistema Registro", "swal('Error','Complete los campos requeridos', 'error')", true);
             }




         }

</script>
	  


<head runat="server">
	
    <title>Sistema Registro</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
	<link rel="stylesheet" type="text/css" href="Styles/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">											
	<link rel="stylesheet" type="text/css" href="Styles/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="Styles/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="Styles/animsition/css/animsition.min.css">											
	<link rel="stylesheet" type="text/css" href="Styles/select2/select2.min.css">											 
	<link rel="stylesheet" type="text/css" href="Styles/daterangepicker/daterangepicker.css">
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
	      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css"
        rel="stylesheet" type="text/css" />


    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 1px;
        }
    </style>

	

</head>
<body>
   
	<div class="limiter">
		<div class="container">
			<div class="wrap">
				<form class="login validate-form p-l-55 p-r-55 p-t-178" runat="server" >
					<span class="login-form-title">
						Sistema Registro
					</span>

					<div class="wrap-input validate-input m-b-16" data-validate="Please enter username">
						
						<span class="focus-input1"></span>
					    <input id="txtNombre" type="text" runat="server" class="input" placeholder="Usuario" /></div>

					<div class="auto-style1" data-validate = "Please enter password">
						<input  class="input" type="password" name="pass" placeholder="Password" id="txtContraseña" runat="server">
						<span class="focus-input"></span>
					</div>
					<div class="ErrorMessage">
                                 <span id="Message" runat="server"></span>
                                   
                       </div>
			

					<div class="container-form-btn">
						<button id="log" class="login-form-btn" onserverclick="LoginCheck" runat="server">
							Iniciar Sesión</button>
					</div>
				
				
					<div>

						<div id="contenedor" runat="server">


						</div>
						<br />

					</div>
					
				</form>
			</div>
		</div>
	</div>



	<script src="Styles/jquery/jquery-3.2.1.min.js"></script>
	<script src="Styles/animsition/js/animsition.min.js"></script>
	<script src="Styles/bootstrap/js/popper.js"></script>
	<script src="Styles/bootstrap/js/bootstrap.min.js"></script>
	<script src="Styles/select2/select2.min.js"></script>
	<script src="Styles/daterangepicker/moment.min.js"></script>
	<script src="Styles/daterangepicker/daterangepicker.js"></script>
	<script src="Styles/countdowntime/countdowntime.js"></script>
	<script src="js/main.js"></script>
</body>
</html>
