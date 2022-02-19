<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHistorialData.aspx.cs" Inherits="SistemaRegistroWeb.frmHistorialData" %>

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
                title: "Recuperar dato",
                text: "Estás seguro de recuperar este dato? ",
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
         
          

            <%-- CONTENEDOR --%>


           <div id="contenedor"  runat="server">
                
                 <h1 id="title" runat="server" ></h1>
                <h5 id="titleFiltro" runat="server" ></h5>
          <div class="form-inline" runat="server" >
                <input id="txtFiltro"  type="text" runat="server"  />
           <span id="Message" class="focus-input"  runat="server"  ></span>
             <asp:Button ID="btnFiltrar" runat="server" Text="" OnClick="Button1_Click" CssClass="bgimg3"  Width="30px" Height="30px" />
         
         </div>

        <div>
           <asp:GridView ID="dgVista" runat="server" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7" AutoGenerateColumns="False"  OnRowDeleting="dgVista_RowDeleting" OnPageIndexChanging="dgVista_PageIndexChanging" >
                <Columns>
                 
        
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="" runat="server"  OnClientClick="return Confirm(this); "  CommandName="Delete"   CssClass="bgimg4"  Width="30px" Height="30px" BorderStyle="None" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

        </div>
           </div>

            
                


    
             
      
    

    </form>
       



   </div>
      <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
