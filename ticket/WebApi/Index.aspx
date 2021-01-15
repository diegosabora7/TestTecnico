

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApi.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <link rel="stylesheet" type="text/css" href="styles.css">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
   
     $(function () {
        $("[id*=insert]").click(function () {
            var id = $.trim($("[id*=idCliente]").val());
            var nombre = $.trim($("[id*=nombre]").val());
            console.log("id=" + id + "---" + nombre);
            var obj = {};
            obj.idCliente = id;
            obj.nombre = nombre;
             
            $.ajax({
                type: "POST",
                url: "http://localhost:63517/api/cola/registrar",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    window.location.reload()
                    $("#msg").html(r);
                    alert(r);
                    
                },
                error: function (r) {
                  $("#msg").html("Error al procesar");
                },
                failure: function (r) {
                    alert(r.responseText);
                }
            });
            return false;
        });
     });

    

</script>
<body>
<div>
  <h1 style="text-align:center">Registro de datos para atención al Cliente</h1>
  <form>
    <table cellpadding="10px;" align="center">
    <thead colspan="2">
    </thead>
    
    <!-- value 1-->

    <tbody>
      <tr>
        <td class="titles">Id<span style="color:rgba(202,27,45,1.00);">*</span></td>
        <td><input type="text" name="idCliente" id="idCliente" class="auto typebox" ></td>
      </tr>
      
      <!--value 2-->
      <tr>
        <td class="titles">Nombre<span style="color:rgba(202,27,45,1.00);">*</span></td>
        <td><input type="text" name="nombre" id="nombre" data-a-sign="$" class="auto typebox"></td>
      </tr>
      
      <!--buttons-->
      <tr>
        <td colspan="1"><input type="submit" id="insert" value="Guardar"  class="total totalbtn typebox" style="height:30px; fontsize:18px; color:white; background-color:rgba(202,27,45,1.00);"></td>
       
      </tr>
      
          </tbody>
  </table>
      </form>
</div>
<div id="hidden-results" style="margin-top:50px;display:none;">
  </div>
    
</body>
</html>
