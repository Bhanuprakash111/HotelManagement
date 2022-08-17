<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HotelManagement.UI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="Tb" runat="server"></asp:TextBox> <br />
            <asp:Button ID="Btn" runat="server" Text="Button" OnClick="Button1_Click" /> <br />

            <asp:Literal ID="ltr" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
