

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApi.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
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
   
    <h1>Registro</h1>
<form>
    <table border="1">
        <tr>
            <td> ID :</td>
            <td>
               
                <input id="idCliente" type="number" name="idCliente" />
            </td>
        </tr>
        <tr>
            <td>Nombre :</td>
            <td><input id="nombre" type="text" name="nombre" /></td>
        </tr>
     
        
        <tr>
            <td colspan="2">
                <input type="button" id="insert" 
                       value="Ingresar" />
              
            </td>
        </tr>
    </table>
    <br />
    <div id="msg"></div>
</form>
</body>
</html>
