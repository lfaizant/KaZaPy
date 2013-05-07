<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayImage.aspx.cs" Inherits="WebClient.DisplayImage" %>

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
           <asp:Image ID="ImageCourante" runat="server" /> <!-- Runat : Cet attribut permet de spécifier où le traitement du composant doit être fait-->
        </p> 
        <p> 
           Image&nbsp;ID&nbsp;:&nbsp; 
           <asp:TextBox ID="ImageIDBox" runat="server" /> 
           <asp:Button ID="Visualiser" runat="server" OnClick="Visualiser_Click"  
           Text="Visualiser" /> 
        </p>
    </div>
    </form>
</body>
</html>
