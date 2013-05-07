<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebClient.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p> 
         Salut 
         <%  
              // Si la variable de session user est non nulle, 
              // on "écrit" sa valeur dans la page HTML que l'on génère 
              if (Session["user"] != null) 
              { 
                  Response.Write(Session["user"]); 
              } 
              else 
              { 
                  Response.Write("inconnu"); 
              } 
         %> 
        </p> 
        <p> 
             Nom : 
             <asp:TextBox ID="UserTextBox" runat="server" /> 
             <asp:Button ID="UserBouton" runat="server" OnClick="Authentifier_Click"  
             Text="Ok" /> 
        </p> 
    </div>
    </form>
</body>
</html>
