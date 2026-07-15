<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="WebApplication1.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Fibonacciho posloupnost</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label
                ID="lblPocet"
                runat="server"
                Text="Počet prvků:" />

            <asp:TextBox
                ID="txtPocet"
                runat="server"
                TextMode="Number"
                Text="10" />

            <asp:Button
                ID="btnFibonacci"
                runat="server"
                Text="Zobrazit Fibonacciho posloupnost"
                OnClick="btnFibonacci_Click" />

            <br /><br />

            <asp:Label
                ID="lblVysledek"
                runat="server" />

            <hr />

            <h3>Počítadlo</h3>

            <asp:Label
                ID="lblCislo"
                runat="server"
                Text="1"
                Font-Size="Large" />

            <br /><br />

            <asp:Button
                ID="btnDalsiCislo"
                runat="server"
                Text="Přidat další číslo"
                OnClick="btnDalsiCislo_Click" />
        </div>
    </form>
</body>
</html>