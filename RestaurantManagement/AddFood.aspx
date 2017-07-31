<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFood.aspx.cs" Inherits="RestaurantManagement.AddFood" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Name: <asp:TextBox ID="name" runat="server"></asp:TextBox> <br>
        Price: <asp:TextBox ID="price" runat="server"></asp:TextBox><br>
        Image: <asp:FileUpload ID="FileUpload" runat="server" /> <br>
        <asp:Button ID="add" runat="server" Text="Add Food" />
    </div>
    </form>
</body>
</html>
