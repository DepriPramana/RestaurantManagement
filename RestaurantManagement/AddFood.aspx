<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFood.aspx.cs" Inherits="RestaurantManagement.AddFood" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=image.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Name: <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required." ForeColor="Red" ControlToValidate="name"></asp:RequiredFieldValidator><br>
        Unit Price: <asp:TextBox ID="unitPrice" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Invalid Price" ControlToValidate="unitPrice" MinimumValue="1" ForeColor="Red" ToolTip="numerical value only" MaximumValue="999" Type="Double"></asp:RangeValidator><br>
        Sale Price: <asp:TextBox ID="salePrice" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="salevalidator" runat="server" ErrorMessage="Invalid Price" ControlToValidate="salePrice" MinimumValue="1" ForeColor="Red" ToolTip="numerical value only" MaximumValue="999" Type="Double"></asp:RangeValidator> <br>

        Image: <asp:Image ID="image" Height ="100%" runat="server" />
        <asp:FileUpload ID="fileUpload" runat="server" />
        <asp:Label ID="imageErroe" runat="server" Text="" ForeColor="Red"></asp:Label> <br>
        <asp:Button ID="add" runat="server" Text="Add Food" OnClick="add_Click" />
        <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Button ID="back" runat="server" Text="Back" PostBackUrl="~/OrderWindow.aspx"/>
    </div>
    </form>
</body>
</html>
