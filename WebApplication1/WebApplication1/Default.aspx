<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Fibonacciho posloupnost</title>
    <link href="Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-center">
            <div class="card">
                <asp:Label ID="lblPocet" runat="server" Text="Počet prvků:" />

                <div class="controls">
                    <asp:TextBox ID="txtPocet" runat="server" TextMode="Number" Text="10" CssClass="small-input" />
                    <asp:Button ID="btnFibonacci" runat="server" Text="Zobrazit posloupnost" OnClick="btnFibonacci_Click" />
                </div>

                <asp:Label ID="lblVysledek" runat="server" />

                <hr />

                <h3>Fibonaccieho tlačítko</h3>

                <asp:Label ID="lblCislo" runat="server" Text="1" CssClass="number-badge" />

                <br /><br />

                <!-- Label pro zobrazení varování o max. počtu prvků -->
                <asp:Label ID="lblLimit" runat="server" CssClass="warning" Visible="false" />

                <asp:Button ID="btnDalsiCislo" runat="server" Text="Přidat další číslo" OnClick="btnDalsiCislo_Click" />

                <br /><br />

                <asp:Button ID="Reset" runat="server" Text="Reset" OnClick="btnReset_Click" />

                <br /><br />

                <asp:Button ID="btnTriangle" runat="server" Text="Kontrola trojúhelníku" OnClick="btnTriangle_Click" />
            </div>
        </div>
    </form>
</body>
</html>