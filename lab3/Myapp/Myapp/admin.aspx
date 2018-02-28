<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Myapp.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        User Data<br />
        <asp:ListBox ID="ListBox1" runat="server" Height="204px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="507px"></asp:ListBox>
    
    </div>
        <asp:ListBox ID="ListBox2" runat="server" Height="208px" Width="507px"></asp:ListBox>
    </form>
</body>
</html>
