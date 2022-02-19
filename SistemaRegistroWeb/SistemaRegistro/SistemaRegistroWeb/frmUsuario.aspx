﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUsuario.aspx.cs" Inherits="SistemaRegistroWeb.frmUsuario" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


    


<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/table.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css"
        rel="stylesheet" type="text/css" />
   
    
    <%-- ELIMINAR --%>
    <script>
        var object = { status: false, ele: null };
        function Confirm(ev) {

            if (object.status) { return true; }

            swal({
                title: "Estás seguro?",
                text: "Eliminar este dato",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Aceptar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: true,
               
            },
            function () {
                    object.status = true;
                    object.ele = ev;
                    object.ele.click();
             });



            return false; 


        }
    </script>
  
</head>
<body>
   <div>
         
        <form id="form1" runat="server">
         
            <%-- FORMULARIO  --%>
          <div   id="formulario" runat="server"  class="center" >

                        <h1 id="title">Usuario</h1>
                      
                         <div class="form-group">
                            <label >Rol:</label>
                             <asp:DropDownList ID="DrpRol" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>

                        <div class="form-group">
                        <label>Nombre:</label>
                        <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" runat="server" />
                      </div>

                      <div class="form-group">
                        <label>Primer Apellido:</label>
                        <input type="text" class="form-control" id="txtPrimerApellido" placeholder="Apellido" runat="server" />
                      </div>

                      <div class="form-group">
                        <label>Segundo Apellido:</label>
                        <input type="text" class="form-control" id="txtSegundoApellido" placeholder="Apellido" runat="server" />
                      </div>
              
                      <div class="form-group">
                        <label>Contraseña:</label>
                        <input type="text" class="form-control" id="txtContrasenna" placeholder="Contraseña" runat="server" />
                      </div>       

                     
                       <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="Modificar"/>
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="btnAgregar_Click"/>
          </div>


            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1>Usuarios</h1>
           <h5>Buscar por nombre: </h5>
          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgUsuario" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="Usuario_id"  OnRowCommand="dgUsuario_RowCommand" OnRowDeleting="dgUsuario_RowDeleting" OnPageIndexChanging="UsuarioOnPageIndexChanging" >
                <Columns>
                 
                    <asp:BoundField DataField="Rol_tipo" HeaderText="Rol" />
                    <asp:BoundField DataField="Usuario_nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Usuario_primerApellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="Usuario_segundoApellido" HeaderText="Segundo Apellido" />
                     <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Usuario_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
                            <asp:Button Text="" runat="server"  OnClientClick="return Confirm(this); "  CommandName="Delete"   CssClass="bgimg2"  Width="30px" Height="30px" BorderStyle="None" />
                      
                       
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

              <asp:Button ID="btnNuevo"  runat="server" Text="Nuevo"  CssClass="btn-primary fixed-bottom"  Height="40px" Width="100px" OnClick="btnNuevo_Click"/>

        </div>
           </div>

            
                


    
             
      
    

    </form>
       



   </div>
      <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
