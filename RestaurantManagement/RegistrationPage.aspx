<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="RestaurantManagement.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script runat="server">

    void Button1_Click(Object sender, EventArgs e) {
       Label13.Text = "Page is valid!";
    }
        </script>
<body>
    <form id="form1" runat="server">
    <div>
    
        Employee Registration<br />
        <br />
        Full Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="FullName" runat="server"></asp:TextBox>
      
       
      
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FullName" ErrorMessage="Full Name Required" ForeColor="#CC0000" SetFocusOnError="True"></asp:RequiredFieldValidator>
      
       
      
        <br />
        <br />
        Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="email" ErrorMessage="Email required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
&nbsp;
        
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Email is not valid" OnDataBinding="register_Click" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        
        <br />
        <br />
        Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="address" runat="server"></asp:TextBox>
       
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="address" ErrorMessage="Address Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
       
        <br />
        <br />
        Date Of Birth&nbsp;&nbsp;&nbsp; <asp:TextBox ID="date" runat="server"></asp:TextBox>

        <asp:ImageButton ID="ImageButtonShowCalendar" runat="server" ImageUrl="~/OtherImages/calender.png" Height="24px" OnClick="ImageButtonShowCalendar_Click" CausesValidation="false" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="date" ErrorMessage="DOB Required" ForeColor="#CC0000"></asp:RequiredFieldValidator><br />
                    <asp:Calendar ID="CalendarDOB" runat="server" Visible="false" OnSelectionChanged="CalendarDOB_SelectionChanged"></asp:Calendar>
       
        <br />
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox>
      
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pass" ErrorMessage="Password required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
      
        <br />
        <br />
        Confirm<br />
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="cpass" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;
       
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="pass" ControlToValidate="cpass" ErrorMessage="Password and confirm password do not match" ForeColor="#CC0000"></asp:CompareValidator>
       
        <br />
        <br />
        
        
        <asp:Button ID="back" runat="server" Text="Back" CausesValidation="false" PostBackUrl="~/OrderWindow.aspx" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" />
    
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Label ID="Label13" runat="server" Font-Size="18pt" ForeColor="#0000CC" ></asp:Label>
    
    </div>
    </form>
</body>
</html>
