<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayAllAlbums.aspx.cs" Inherits="WebClient.DisplayAllAlbums" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <!-- Ajouter des images cliquables-->
           <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/album.jpg" OnClick="ImageButton1_Click" />
 
    </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
