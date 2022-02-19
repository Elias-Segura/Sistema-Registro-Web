<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCaso.aspx.cs" Inherits="SistemaRegistroWeb.frmCaso" %>

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
        .auto-style4 {
            width: 749px;
            height: 21px;
        }
        .auto-style5 {
            width: 9px;
            height: 21px;
        }
        .auto-style10 {
            width: 117px;
            height: 25px;
        }
        .auto-style22 {
            width: 251px;
            height: 25px;
        }
        .auto-style23 {
            height: 27px;
        }
        .auto-style24 {
            width: 117px;
            height: 33px;
        }
        .auto-style26 {
            width: 251px;
            height: 33px;
        }
        .auto-style27 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
        .auto-style28 {
            width: 231px;
            height: 33px;
        }
        .auto-style29 {
            width: 231px;
            height: 25px;
        }
        </style>








  
</head>
<body>
   <div>
         
        <form id="form1" runat="server">
         
            <%-- FORMULARIO  --%>
          <div   id="formulario" runat="server"  class="center" >

                        <h1 id="title">Caso</h1>
                      
                         <div class="form-group">
                            <label >Trámite:</label>
                             <asp:DropDownList ID="DrpTramite" runat="server" CssClass="form-control" OnSelectedIndexChanged="DrpTramite_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                         </div>

                       <div class="form-group">
                            <label >Organización</label>
                              <asp:DropDownList ID="DrpOrganizacion" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DrpOrganizacion_SelectedIndexChanged"></asp:DropDownList>
                      </div>
                        <div class="form-group">
                            <label>Documentos:</label>
                            <textarea class="form-control" id="txtAreaDocumento" rows="3" runat="server"  disabled="disabled"></textarea >
                      </div>
                      <div class="form-group">
                        <label>Código:</label>
                        <input type="text" class="form-control" id="txtCodigo" placeholder="Codigo" runat="server" disabled="disabled" />
                      </div>
                        
                       <div class="form-group">
                        <label>Fecha Inicio:</label>
                            <table class="w-100">
                               <tr>
                                   <td class="auto-style4">
                                        <input type="text" class="form-control" id="txtFechaInicio" placeholder="dd/MM/aaaa" runat="server" disabled="disabled"/></td>
                                   <td class="auto-style5">
                                        <asp:Button ID="btnFechaInicio" Runat="server" Text="..." CssClass="btn-primary"  Height="37px" Width="50px" ></asp:Button>
                                   </td>
                               </tr>
                           </table>
                      </div>

                        <div class="form-group">
                           <label>Fecha Final:</label>
                               <table class="w-100">
                                  <tr>
                                      <td class="auto-style4">
                           <input type="text" class="form-control" id="txtFechaFinal" placeholder="dd/MM/aaaa" runat="server" disabled="disabled"/></td>
                                      <td class="auto-style5">
                           <asp:Button ID="btnFechaFinal" Runat="server" Text="..." CssClass="btn-primary"  Height="37px" Width="50px" OnClick="btnFechaFinal_Click"></asp:Button>
                                      </td>
                               
                                  </tr>
                                
                              </table>
                           &nbsp;<asp:Calendar ID="CldFechaFinal" runat="server" OnSelectionChanged="CldSelectionChanged" class="mb-0"></asp:Calendar>
                             
                         </div>

                        
                     
                       <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="Modificar"/>
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="btnAgregar_Click"/>
                        
          </div>


            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1>Casos</h1>
                <h5>&nbsp;<table class="auto-style23">
               <tr>
                   <td class="auto-style24">Buscar por :</td>
                   <td class="auto-style28">           
               <asp:DropDownList ID="DrpTipoFiltro" runat="server" CssClass="auto-style27" AutoPostBack="True" OnSelectedIndexChanged="EvenIndexChanged" Height="34px" Width="215px">
               </asp:DropDownList>
                       </td>
                   <td class="auto-style26">           
               <asp:DropDownList ID="DrpTramiteFiltro" runat="server" CssClass="form-control" Height="35px" Width="249px">
               </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style10">&nbsp;</td>
                   <td class="auto-style29">           
                       &nbsp;</td>
                   <td class="auto-style22">           
                       &nbsp;</td>
               </tr>
               </table>
                 </h5>


          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgCodigo" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="Caso_id"  OnRowCommand="dgCaso_RowCommand" OnRowDeleting="dgCodigo_RowDeleting" OnPageIndexChanging="CasoOnPageIndexChanging" >
                <Columns>
                 
                    <asp:BoundField DataField="Caso_codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Caso_fechaInicio" HeaderText="Fecha Inicio" />
                    <asp:BoundField DataField="Caso_fechaFinal" HeaderText="Fecha Final" />
                    <asp:BoundField DataField="Tramite_nombre" HeaderText="Trámite" />
                     <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Caso_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
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

