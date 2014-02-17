<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeDiff.aspx.cs" Inherits="lib_lab_TimeDiff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    
    </div>
    </form>
</body>
</html>
