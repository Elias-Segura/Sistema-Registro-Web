<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDocumento.aspx.cs" Inherits="SistemaRegistroWeb.frmDocumento" %>

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
      <script type="text/javascript">
          function showpreview(input) {

              if (input.files && input.files[0]) {

                  var reader = new FileReader();
                  reader.onload = function (e) {
                      $('#imgpreview').css('visibility', 'visible');
                      $('#imgpreview').attr('src', e.target.result);
                  }
                  reader.readAsDataURL(input.files[0]);
              }

          }
      </script>
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
       <script type="text/javascript">
           function previewFile() {


               var preview = document.querySelector('#<%=Container.ClientID %>');
               var file = document.querySelector('#<%=FUpld_Archivo.ClientID %>').files[0];
               var reader = new FileReader();



               reader.onloadend = function () {


                   preview.src = reader.result;


               }

               if (file) {
                   reader.readAsDataURL(file);
               } else {
                   preview.src = "";
               }



           }
       </script>

  
  
    <style type="text/css">
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
        .auto-style11 {
            height: 39px;
        }
        .auto-style20 {
            width: 177px;
            height: 56px;
        }
        .auto-style21 {
            width: 2568px;
            height: 56px;
        }
        .auto-style23 {
            height: 56px;
            width: 2575px;
        }
        .auto-style25 {
            margin-bottom: 1rem;
            height: 38px;
        }
        .auto-style26 {
            width: 38px;
            height: 39px;
        }
        .auto-style27 {
            width: 38px;
            height: 56px;
        }
        .auto-style29 {
            height: 368px;
        }
    </style>
  
</head>
<body>
   <div>
     
         
        <form id="form1" runat="server">
         
            <%-- FORMULARIO  --%>
          <div   id="formulario" runat="server"  class="center" >

                        <h1 id="title">Documento</h1>
                       
                         <div class="form-group">
                            <label >Trámite:</label>
                             <asp:DropDownList ID="DrpTramites" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>

                       <div class="form-group">
                            <label >Idioma:</label>
                              <asp:DropDownList ID="DrpIdioma" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>

                        <div class="form-group">
                            <label >Medio:</label>
                              <asp:DropDownList ID="DrpMedio" runat="server" CssClass="form-control"></asp:DropDownList>
                      </div>

                      <div class="form-group">
                        <label>Nombre:</label>
                        <input type="text" class="form-control" id="txtNombre" placeholder="Nombre" runat="server" />
                      </div>
                     
                       <div class="form-group">
                        <label>Tipo:</label>
                        <input type="text" class="form-control" id="txtTipo" placeholder="Tipo" runat="server" />
                      </div>
                     
                 
                      
                       <div class="auto-style25">
                        <label>Archivo:</label>
                        <asp:Button ID ="btnAgregarArchivo" runat="server" Text="" class="bgimg5" OnClick="btnAgregar_Click1" Height="30px" Width="40px" />
                        <asp:Button ID ="btnEditarArchivo" runat="server" Text="" class="bgimg6" OnClick="btnModificar_Click"  Height="30px" Width="40px"  />
                      </div>
                      


                       <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="Modificar"/>
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn-primary"  Height="40px" Width="100px" OnClick="btnAgregar_Click"/>
          </div>


            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1>
                     
                     Documentos</h1>
           <h5>Buscar por código: </h5>
          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="Button2" runat="server" Text="" OnClick="Button1_Click"  CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgDocumento" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False" DataKeyNames="Documento_id"  OnRowCommand="dgDocumento_RowCommand" OnRowDeleting="dgDocumento_RowDeleting" OnPageIndexChanging="DocumentoOnPageIndexChanging">
                <Columns>
                 
                    <asp:BoundField DataField="Idioma_nombre" HeaderText="Idioma" />
                    <asp:BoundField DataField="Medio_nombre" HeaderText="Medio" />
                    <asp:BoundField DataField="Documento_nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Documento_tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Tramite_nombre" HeaderText="Trámite" />
                     <asp:TemplateField>
                        <ItemTemplate>
                           
                            <asp:Button Text="" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Documento_id") %>'  CssClass="bgimg"  Width="30px" Height="30px" BorderStyle="None" />
                            <asp:Button Text="" runat="server"  OnClientClick="return Confirm(this); "  CommandName="Delete"   CssClass="bgimg2"  Width="30px" Height="30px" BorderStyle="None" />
                      
                       
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
              <br />
            <br />
              <asp:Button ID="Button1"  runat="server" Text="Nuevo"  CssClass="btn-primary fixed-bottom"  Height="40px" Width="100px" OnClick="btnNuevo_Click" style="left: 0; right: 868px; bottom: 0"/>

          

        </div>
           </div>

            
                

        <div id="Visualizar" runat ="server" >
             <div class="form-group">
                           &nbsp; <table class="w-100">
                               <tr>
                                   <td class="auto-style20">
                           <label>Archivo:</label></td>
                                   <td class="auto-style21">
                           <asp:FileUpload ID="FUpld_Archivo" runat="server" class="btn btn-success" onchange="previewFile()"/>
                                       <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-success" OnClick="ClickEliminar" />
                                      </td>
                                   <td class="auto-style23">
                                   </td>
                                   <td class="auto-style27">
                                   </td>
                               </tr>
                               <tr>
                                   <td class="auto-style11" colspan="3">
                      <input type="text" class="auto-style7" id="txtArchivo" placeholder="Ruta" runat="server" /></td>
                                   <td class="auto-style26">
                                       <asp:Button ID="Button4" runat="server" Text="Subir" class="btn btn-success" OnClick="ClickSubirClick" />
                                   </td>
                               </tr>
                               </table>
                         </div>
                <br/><br/>
                <iframe  id="Container"  runat="server"  src=""  width="700px" height="500px" frameBorder="0" class="embed-responsive embed-responsive-16by9 col-xs-12 text-center" ></iframe>

        </div>
    
             
      
    

    </form>
       



   </div>
      <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
