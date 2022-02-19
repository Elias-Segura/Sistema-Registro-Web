<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEmpleado.aspx.cs" Inherits="SistemaRegistroWeb.frmEmpleado" %>

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
  
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
        .auto-style3 {
            width: 750px;
        }
        .auto-style4 {
            height: 37px;
            width: 750px;
        }
    </style>
  
</head>
<body>
   <div>
         
        <form id="form1" runat="server">
         
            <%-- FORMULARIO  --%>
          <div   id="formulario" runat="server"  class="center" >

                      <h1 id="title">Empleado</h1>
                     
                      <div class="form-group">
                         <label >Departamento:</label>
                          <asp:DropDownList ID="DrpDepartamentos" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group">
                            <label >Puesto:</label>
                              <asp:DropDownList ID="DrpPuestos" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group">
                            <label >Genero:</label>
                              <asp:DropDownList ID="DrpGenero" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                        
                       <div class="form-group">
                            <label >Estado Civil:</label>
                              <asp:DropDownList ID="DrpEstadoCivil" runat="server" CssClass="form-control"></asp:DropDownList>
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
                           <label>Fecha Nacimiento:</label>
                               <table class="w-100">
                                  <tr>
                                      <td class="auto-style3">
                           <input type="text" class="form-control" id="txtFechaNacimiento" placeholder="dd/MM/aaaa" runat="server" disabled="disabled"/></td>
                                      <td class="auto-style5">
                           <asp:Button ID="btnFechaNacimiento" Runat="server" Text="..." CssClass="btn-primary"  Height="37px" Width="50px" OnClick="btnFechaNacimiento_Click"></asp:Button>
                                      </td>
                               
                                  </tr>
                                
                              </table>
                           &nbsp;<asp:Calendar ID="CldFechaNacimiento" runat="server" OnSelectionChanged="CldFechaNacimientoSelectionChanged"></asp:Calendar>
                         </div>

                    <div class="form-group">
                           <label>Fecha Ingreso:</label>
                               <table class="w-100">
                                  <tr>
                                      <td class="auto-style4">
                           <input type="text" class="form-control" id="txtFechaIngreso" placeholder="dd/MM/aaaa" runat="server" disabled="disabled"/></td>
                                      <td class="auto-style1">
                           <asp:Button ID="btnFechaIngreso" Runat="server" Text="..." CssClass="btn-primary"  Height="37px" Width="50px" OnClick="btnFechaIngreso_Click"></asp:Button>
                                      </td>
                               
                                  </tr>
                                
                              </table>
                           &nbsp;<asp:Calendar ID="CldFechaIngreso" runat="server" OnSelectionChanged="CldFechaIngresoSelectionChanged"></asp:Calendar>
                         </div>

                     
                       <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="Modificar"/>
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="btnAgregar_Click"/>
          </div>


            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1>Empleados</h1>
           <h5>Buscar por nombre: </h5>
          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgEmpleado" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="Empleado_id"  OnRowCommand="dgEmpleado_RowCommand" OnRowDeleting="dgEmpleado_RowDeleting" OnPageIndexChanging="EmpleadoOnPageIndexChanging" >
                <Columns>
                 
                    <asp:BoundField DataField="Departamento_nombre" HeaderText="Departamento" />
                    <asp:BoundField DataField="Puesto_nombre" HeaderText="Puesto" />
                    <asp:BoundField DataField="Genero_nombre" HeaderText="Genero" />
                    <asp:BoundField DataField="TEstadoCivil_nombre" HeaderText="Estado Civil" />
                    <asp:BoundField DataField="Empleado_nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Empleado_primerApellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="Empleado_segundoApellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="Empleado_fechaNacimiento" HeaderText="Fecha Nacimiento" />
                    <asp:BoundField DataField="Empleado_fechaIngreso" HeaderText="Fecha Ingreso" /> 
                    <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Empleado_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
                            <asp:Button Text="" runat="server"  OnClientClick="return Confirm(this); "  CommandName="Delete"   CssClass="bgimg2"  Width="30px" Height="30px" BorderStyle="None" />
                      
                       
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
              <br />
            <br />
              <asp:Button ID="btnNuevo"  runat="server" Text="Nuevo"  CssClass="btn-primary fixed-bottom"  Height="40px" Width="100px" OnClick="btnNuevo_Click" style="left: 0; right: 868px; bottom: 0"/>

        </div>
           </div>

            
                


    
             
      
    

    </form>
       



   </div>
      <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
