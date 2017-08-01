<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOrders.aspx.cs" Inherits="RestaurantManagement.ShowOrders1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="date" runat="server"></asp:TextBox>

        <asp:ImageButton ID="ImageButtonShowCalendar" runat="server" ImageUrl="~/OtherImages/calender.png" Height="24px" OnClick="ImageButtonShowCalendar_Click" /><br />
                    <asp:Calendar ID="CalendarDOB" runat="server" Visible="false" OnSelectionChanged="CalendarDOB_SelectionChanged"></asp:Calendar>
    <asp:GridView ID="gridView" runat="server"></asp:GridView> <br>
    Total Sales: <asp:Label ID="totalAmount" runat="server" Text="0" Font-Bold="True"></asp:Label> <br><br>
    <asp:Label ID="msg" runat="server" Text="No Data Found" Visible="false"></asp:Label><br>
        <asp:Button ID="prev" runat="server" Text="Previous Order" OnClick="prev_Click" /> 
        <asp:Button ID="next" style="margin-left:10%" runat="server" Text="Next Order" OnClick="next_Click"/>
        <asp:Button ID="back" runat="server" style="margin-left:10%" Text="Back" PostBackUrl="~/OrderWindow.aspx" /> 
    </div>
    </form>
</body>
</html>
