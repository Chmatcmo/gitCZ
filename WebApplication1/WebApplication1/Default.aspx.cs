using System;
using System.Collections.Generic;

namespace WebApplication1
{
    // Code-behind pro Default.aspx — spravuje životní cyklus stránky a reakce na události tlačítek
    public partial class Default : System.Web.UI.Page
    {
        // Vlastnost pro sledování počtu "kliknutí" / indexu aktuálního čísla.
        // Hodnota je uložena ve ViewState, aby přežila postbacky (uloží se do __VIEWSTATE).
        private int AktualniCislo
        {
            get
            {
                if (ViewState["AktualniCislo"] == null)
                {
                    ViewState["AktualniCislo"] = 1; // výchozí hodnota
                }

                return (int)ViewState["AktualniCislo"];
            }
            set
            {
                ViewState["AktualniCislo"] = value;
            }
        }

        // První člen fibo posloupnosti (uložen ve ViewState, přežije postback)
        private int Prvni
        {
            get
            {
                if (ViewState["Prvni"] == null)
                {
                    ViewState["Prvni"] = 0; // výchozí první člen
                }
                return (int)ViewState["Prvni"];
            }
            set
            {
                ViewState["Prvni"] = value;
            }
        }

        // Druhý člen fibo posloupnosti (uložen ve ViewState)
        private int Druhe
        {
            get
            {
                if (ViewState["Druhe"] == null)
                {
                    ViewState["Druhe"] = 1; // výchozí druhý člen           
                }
                return (int)ViewState["Druhe"];
            }
            set
            {
                ViewState["Druhe"] = value;
            }
        }

        // Životní cyklus stránky: inicializace pouze při prvním načtení (IsPostBack == false)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializace počátečních hodnot pouze při prvním načtení stránky
                Prvni = 0;
                Druhe = 1;
                AktualniCislo = 1;

                // Nastavení počátečního textu labelu, který zobrazuje aktuální číslo
                lblCislo.Text = AktualniCislo.ToString();
            }
        }

        // Zpracování tlačítka "Zobrazit posloupnost"
        // Vygeneruje Fibonacciho posloupnost o zadané délce a výsledek zobrazí v lblVysledek
        protected void btnFibonacci_Click(object sender, EventArgs e)
        {
            // Validace vstupu: převod na int a omezení rozsahu
            if (!int.TryParse(txtPocet.Text, out int pocet) ||
                pocet < 1 ||
                pocet > 99)
            {
                lblVysledek.Text = "Zadejte počet prvků v rozsahu 1 až 99.";
                return;
            }

            List<int> posloupnost = new List<int>();

            int prvni = 0;
            int druhy = 1;

            // Složíme posloupnost do seznamu
            for (int i = 0; i < pocet; i++)
            {
                posloupnost.Add(prvni);

                int dalsi = prvni + druhy;
                prvni = druhy;
                druhy = dalsi;
            }

            // Výsledek zobrazíme jako čárou oddělený řetězec
            lblVysledek.Text = string.Join(", ", posloupnost);
        }

        // Tlačítko pro přidání dalšího Fibonacciho čísla do zobrazení (postupný režim)
        protected void btnDalsiCislo_Click(object sender, EventArgs e)
        {
            // Inkremenet indexu / počitadla
            AktualniCislo++;

            // Vypočítáme další člen jako součet dvou předchozích
            int fibonacci = Prvni + Druhe;

            // Připojíme nové číslo k existujícímu textu labelu.
            // Poznámka: lblCislo.Text existující obsah nerozepisuje, ale rozšiřuje.
            lblCislo.Text += ", " + fibonacci.ToString();

            // Posuneme okno: aktuální "druhé" se stane "prvním" pro další iteraci
            Prvni = Druhe;
            Druhe = fibonacci;
        }

        // Resetuje zobrazení a stav posloupnosti na výchozí hodnoty
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Vyčístíme text výsledku
            lblVysledek.Text = " ";

            // Vrátíme index i členy na počáteční hodnoty
            AktualniCislo = 1;
            Prvni = 0;
            Druhe = 1;

            // Aktualizujeme zobrazené číslo
            lblCislo.Text = AktualniCislo.ToString();
        }

        // Přesměrování na jinou stránku (např. Triangle.aspx) při kliknutí tlačítka
        protected void btnTriangle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Triangle.aspx");
        }
    }
}