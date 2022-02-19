<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDetalleCaso.aspx.cs" Inherits="SistemaRegistroWeb.frmDetalleCaso" %>

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
            width: 110px;
        }
        .auto-style2 {
            width: 3630px;
        }
        .auto-style3 {
            width: 755px;
        }
        .auto-style4 {
            color: #fff;
            background-color: #007bff;
            border-color: #007bff;
            margin-left: 115;
        }
    </style>
  
</head>
<body>
   <div>
         
        <form id="form1" runat="server">
         
            <%-- FORMULARIO  --%>
          <div   id="formulario" runat="server"  class="center" >

                        <h1 id="title">Detalle Caso</h1>
                      
                         <div class="form-group">
                            <label >Código:</label>
                             <asp:DropDownList ID="DrpCodigo" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>

                       <div class="form-group">
                            <label >Departamento:</label>
                              <asp:DropDownList ID="DrpDepartamento" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>
                    
                       <div class="form-group">
                            <label >Documento:</label>
                              <asp:DropDownList ID="DrpDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>

                        <div class="form-group">
                            <label>Descripción:</label>
                            <textarea class="form-control" id="txtDescripcion" rows="3" runat="server"></textarea >
                      </div>

                           <div class="form-group">
                           <label>Fecha Recibido:</label>
                               <table class="w-100">
                                  <tr>
                                      <td class="auto-style3">
                           <input type="text" class="form-control" id="txtFechaRecibido" placeholder="dd/MM/aaaa" runat="server" disabled="disabled"/></td>
                                      <td class="auto-style5">
                           <asp:Button ID="btnFechaRecibido" Runat="server" Text="..." CssClass="btn-primary"  Height="37px" Width="50px" OnClick="btnFechaRecibido_Click"></asp:Button>
                                      </td>
                               
                                  </tr>
                                
                              </table>
                           &nbsp;<asp:Calendar ID="CldFechaRecibido" runat="server" OnSelectionChanged="CldFechaRecibidoSelectionChanged"></asp:Calendar>
                         </div>

                <div class="form-group">
                           <label>Fecha Traspaso:</label>
                               <table class="w-100">
                                  <tr>
                                      <td class="auto-style3">
                           <input type="text" class="form-control" id="txtFechaTraspaso" placeholder="dd/MM/aaaa" runat="server" disabled="disabled"/></td>
                                      <td class="auto-style5">
                           <asp:Button ID="btnFechaTraspaso" Runat="server" Text="..." CssClass="btn-primary"  Height="37px" Width="50px" OnClick="btnFechaTraspaso_Click"></asp:Button>
                                      </td>
                               
                                  </tr>
                                
                              </table>
                           &nbsp;<asp:Calendar ID="CldFechaTraspaso" runat="server" OnSelectionChanged="CldFechaTraspasoSelectionChanged"></asp:Calendar>
                         </div>

                   
                     
                       <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="Modificar"/>
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="btnAgregar_Click"/>
          </div>


            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1>Detalle Casos</h1>
           <h5>Buscar por código: </h5>
          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgDetalleCaso" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="DetalleCaso_id"  OnRowCommand="dgDetalleCaso_RowCommand" OnRowDeleting="dgDetalleCaso_RowDeleting" OnPageIndexChanging="DetalleCasoOnPageIndexChanging">
                <Columns>
                 
                    <asp:BoundField DataField="Caso_codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Ciclo_orden" HeaderText="Ciclo" />
                    <asp:BoundField DataField="Documento_nombre" HeaderText="Documento" />
                    <asp:BoundField DataField="DetalleCaso_fechaRecibido" HeaderText="Fecha de Recibido" />
                    <asp:BoundField DataField="DetalleCaso_fechaTraspaso" HeaderText="Fecha de Traspaso" />
                    <asp:BoundField DataField="DetalleCaso_descripcion" HeaderText="Descripción" />
                     <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("DetalleCaso_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
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

