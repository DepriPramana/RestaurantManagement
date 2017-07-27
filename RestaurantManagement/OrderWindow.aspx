<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderWindow.aspx.cs" Inherits="RestaurantManagement.OrderWindow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Fast Food Items" Font-Size="15" ></asp:Label>
        <asp:Panel ID="foodPanel" runat="server"></asp:Panel>
        <asp:PlaceHolder ID="food" runat="server"></asp:PlaceHolder>
        <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Pictures/3.jpg" Width="100" /> 
        <br>    <asp:Label ID="Labe1" runat="server" style="margin-left: 25px; margin-top: 0px" Text="Burger" Font-Size="13" ></asp:Label>--%>
    </div>
    </form>
</body>
</html>
