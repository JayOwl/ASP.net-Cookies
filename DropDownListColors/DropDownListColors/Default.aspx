<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColorPersistance.aspx.cs" Inherits="ColorPersistanceExample.ColorPersistance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Color Persistance</title>
    <!-- Example jQuery Reference -->
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <!-- Example jQuery Script to handle your event -->
    <script type='text/javascript'>
        $(function () {
            // When a color is chosen, set it as the background for this page
            $("#<%= Color.ClientID %>").change(function () {
                // Set the background to that color
                $("body").css('background', $(this).val());
            });
        });
    </script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <!-- A Drop down list with a collection of colors -->
        <asp:DropDownList ID="Color" runat="server">
            <asp:ListItem Value="initial">Normal</asp:ListItem>
            <asp:ListItem Value="red">Red</asp:ListItem>
            <asp:ListItem Value="yellow">Yellow</asp:ListItem>
            <asp:ListItem Value="blue">Blue</asp:ListItem>
            <asp:ListItem Value="url('http://www.webdesign.org/img_articles/1078/bg1.jpg')">Pattern</asp:ListItem>
        </asp:DropDownList>

        <!-- A Button to apply the pattern -->
        <asp:Button ID="ApplyPattern" runat="server" Text="Apply" OnClick="ApplyPattern_Click" />
    </form>
</body>
</html>