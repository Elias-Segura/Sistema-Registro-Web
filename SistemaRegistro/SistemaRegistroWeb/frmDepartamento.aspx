<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDepartamento.aspx.cs" Inherits="SistemaRegistroWeb.frmDepartamento" %>

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

                        <h1 id="title">Departamento</h1>
                      
                         <div class="form-group">
                            <label >Organización:</label>
                             <asp:DropDownList ID="DrpOrganizaciones" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>

                       <div class="form-group">
                            <label >Tipo Departamento</label>
                              <asp:DropDownList ID="DrpTipoDepartamento" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                      <div class="form-group">
                        <label>Departamento:</label>
                        <input type="text" class="form-control" id="txtDepartamento" placeholder="´Departamento" runat="server" />
                      </div>
                        <div class="form-group">
                            <label>Descripción:</label>
                            <textarea class="form-control" id="txtDescripcion" rows="3" runat="server"></textarea >
                      </div>
                     
                       <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="Modificar"/>
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="btnAgregar_Click"/>
          </div>


            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1>Departamentos</h1>
           <h5>Buscar por nombre: </h5>
          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgDepartamento" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="Departamento_id"  OnRowCommand="dgDepartamento_RowCommand" OnRowDeleting="dgDepartamento_RowDeleting" OnPageIndexChanging="dgDepartamento_PageIndexChanging" >
                <Columns>
                 
                    <asp:BoundField DataField="Departamento_nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Departamento_descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Organizacion_nombre" HeaderText="Organización" />
                    <asp:BoundField DataField="DepartamentoTipo_nombre" HeaderText="Tipo" />
                     <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Departamento_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
                            <asp:Button Text="" runat="server"  OnClientClick="return Confirm(this); "  CommandName="Delete"   CssClass="bgimg2"  Width="30px" Height="30px" BorderStyle="None" />
                      
                       
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

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
