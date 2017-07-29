                                                                                                 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderWindow.aspx.cs" Inherits="RestaurantManagement.OrderWindow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">
.floatLeft { float: left; }
</style>
    <style type="text/css">
.floatRight { float: left; }
</style>
    <style type="text/css">
.inlineBlock { display: inline-block; }
</style>
    
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Fast Food Items" Font-Size="15" ></asp:Label>
        </br>
        <asp:Panel ID="foodSelectionPanel" runat="server" CssClass="floatLeft" >
           </asp:Panel>
        
        <div style="position: absolute; left: 55%; top: 0px; padding: 5px; width: 30%; height: auto; border-left: solid 3px Black;"><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /></div>
        <asp:Panel ID="orderPanel" runat="server" CssClass="floatRight" >
           
            <asp:GridView ID="orderGridView" style="margin-left:20%" runat="server">
                
            </asp:GridView>
        </asp:Panel>
        
    </div>
    </form>
</body>
</html>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        