<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="WebApplication1.Default" %>
            
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Fibonacciho posloupnost</title>
    <!-- Odkaz na externí CSS pro centrování a styl karty -->
    <link href="Content/site.css" rel="stylesheet" />
</head>
<body>
    <!-- Formulář ASP.NET; všechna serverová ovládací prvky musí být uvnitř form runat="server" -->
    <form id="form1" runat="server">
        <!-- .page-center: flexbox wrapper pro vertikální i horizontální centrování obsahu -->
        <div class="page-center">
            <!-- .card: obdélník (panel) s paddingem, stínem a ohraničením -->
            <div class="card">
                <!-- Label popisující vstupní pole -->
                <!-- Serverový Label má ID, které se používá v code-behind -->
                <asp:Label
                    ID="lblPocet"
                    runat="server"
                    Text="Počet prvků:" />

                <!-- Skupina ovládacích prvků (input + tlačítko) -->
                <div class="controls">
                    <!-- TextBox pro zadání počtu prvků; TextMode="Number" umožní HTML5 numerický vstup -->
                    <asp:TextBox
                        ID="txtPocet"
                        runat="server"
                        TextMode="Number"
                        Text="10"
                        CssClass="small-input" />

                    <!-- Tlačítko, které spouští serverovou událost btnFibonacci_Click -->
                    <asp:Button
                        ID="btnFibonacci"
                        runat="server"
                        Text="Zobrazit posloupnost"
                        OnClick="btnFibonacci_Click" />
                </div>

                <!-- Label pro zobrazení výsledné posloupnosti -->
                <asp:Label
                    ID="lblVysledek"
                    runat="server" />

                <hr />

                <!-- Sekce pro postupné zobrazování Fibonacciho čísel -->
                <h3>Fibonaccieho tlačítko</h3>

                <!-- Label, který zobrazuje aktuální/poslední číslo; má CSS třídu pro badge styl -->
                <asp:Label
                    ID="lblCislo"
                    runat="server"
                    Text="1"
                    CssClass="number-badge" />

                <br /><br />

                <!-- Tlačítko pro přidání dalšího Fibonacciho čísla -->
                <asp:Button
                    ID="btnDalsiCislo"
                    runat="server"
                    Text="Přidat další číslo"
                    OnClick="btnDalsiCislo_Click" />

                <br /><br />

                <!-- Reset -- vrátí posloupnost do výchozího stavu -->
                <asp:Button
                    ID="Reset"
                    runat="server"
                    Text="Reset"
                    OnClick="btnReset_Click" />

                <br /><br />

                <!-- Navigační tlačítko (přesměrování na jinou stránku) -->
                <asp:Button
                    ID="btnTriangle"
                    runat="server"
                    Text="Kontrola trojúhelníku"
                    OnClick="btnTriangle_Click" />
            </div>
        </div>
    </form>
</body>
</html>