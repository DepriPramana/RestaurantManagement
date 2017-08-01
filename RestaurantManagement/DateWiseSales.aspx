<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateWiseSales.aspx.cs" Inherits="RestaurantManagement.ShowOrders" %>

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
        Total Sales: <asp:Label ID="totalSalesAmount" runat="server" Text="" Font-Bold="True"></asp:Label> <br><br>
        <asp:Button ID="prev" runat="server" Text="Previous Day" OnClick="prev_Click" />
        <asp:Button ID="next" style="margin-left:10%" runat="server" Text="Next Day" OnClick="next_Click"/> 
        <asp:Button ID="back" style="margin-left:10%" runat="server" Text="Back" PostBackUrl="~/OrderWindow.aspx" />
    </div>
    </form>
</body>
</html>
