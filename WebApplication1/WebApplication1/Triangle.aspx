<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Triangle.aspx.cs" Inherits="WebApplication1.Triangle" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Kontrola trojúhelníku</title>
    <link href="Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-center">
            <div class="card">
                <h2>Kontrola, zda lze sestavit trojúhelník</h2>

                <div class="controls">
                    <asp:Label ID="lblA" runat="server" Text="Strana a:" />
                    <asp:TextBox ID="txtA" runat="server" TextMode="Number" Text="3" CssClass="small-input" />
                    <br /><br />

                    <asp:Label ID="lblB" runat="server" Text="Strana b:" />
                    <asp:TextBox ID="txtB" runat="server" TextMode="Number" Text="4" CssClass="small-input" />

                    <br /><br />
                    <asp:Label ID="lblC" runat="server" Text="Strana c:" />
                    <asp:TextBox ID="txtC" runat="server" TextMode="Number" Text="5" CssClass="small-input" />
                </div>

                <asp:Button ID="btnCheck" runat="server" Text="Zkontrolovat" OnClick="btnCheck_Click" />

                <br /><br />

                <asp:Label ID="lblTriangleResult" runat="server" />

                <br /><br />

                <asp:Button ID="btnBack" runat="server" Text="Zpìt" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>