<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTramite.aspx.cs" Inherits="SistemaRegistroWeb.frmTramite" %>

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
        .auto-style2 {
            width: 48%;
            height: 12px;
        }
        .auto-style3 {
            width: 124px;
            height: 19px;
        }
        .auto-style4 {
            height: 19px;
        }
        .auto-style5 {
            display: block;
            width: 100%;
            height: calc(1.5em + .75rem + 2px);
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            margin-left: 30;
            background-color: #fff;
        }
        .auto-style6 {
            width: 21px;
            height: 19px;
        }
        .auto-style7 {
            display: block;
            width: 100%;
            height: calc(1.5em + .75rem + 2px);
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            margin-bottom: 0;
            background-color: #fff;
        }
        </style>
  
</head>
<body>
   <div>
         
        <form id="form1" runat="server">
         
            <%-- FORMULARIO  --%>
          <div   id="formulario" runat="server"  class="center" >

                        <h1 id="title">Trámite</h1>
                        
                        <div class="form-group">
                        <label>Nombre:</label>
                        <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" runat="server" />
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
                
                 <h1>Trámites</h1>
          
               <h5>&nbsp;<table class="auto-style2">
               <tr>
                   <td class="auto-style3">Buscar por :</td>
                   <td>           
               <asp:DropDownList ID="DrpTipoFiltro" runat="server" CssClass="auto-style7" AutoPostBack="True" OnSelectedIndexChanged="EvenIndexChanged">
               </asp:DropDownList>
                       </td>
                   <td class="auto-style6">           
                       &nbsp;</td>
                   <td class="auto-style4">           
               <asp:DropDownList ID="DrpDepartamento" runat="server" CssClass="auto-style5">
               </asp:DropDownList>
                   </td>
               </tr>
               </table>
                 </h5>

          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgTramite" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="Tramite_id"  OnRowCommand="dgTramite_RowCommand" OnRowDeleting="dgTramite_RowDeleting" OnPageIndexChanging="TramiteOnPageIndexChanging">
                <Columns>
                 
                    <asp:BoundField DataField="Tramite_nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Tramite_descripcion" HeaderText="Descripción" />
                    
                     <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Tramite_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
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
