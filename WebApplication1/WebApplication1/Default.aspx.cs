using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        // Maximální počet povolených čísel
        private const int MaxElements = 47;

        private int AktualniCislo
        {
            get
            {
                if (ViewState["AktualniCislo"] == null)
                {
                    ViewState["AktualniCislo"] = 1;
                }

                return (int)ViewState["AktualniCislo"];
            }
            set
            {
                ViewState["AktualniCislo"] = value;
            }
        }

        private int Prvni
        {
            get
            {
                if (ViewState["Prvni"] == null)
                {
                    ViewState["Prvni"] = 0;
                }
                return (int)ViewState["Prvni"];
            }
            set
            {
                ViewState["Prvni"] = value;
            }
        }
        private int Druhe
        {
            get
            {
                if (ViewState["Druhe"] == null)
                {
                    ViewState["Druhe"] = 1;
                }
                return (int)ViewState["Druhe"];
            }
            set
            {
                ViewState["Druhe"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Prvni = 0;
                Druhe = 1;
                AktualniCislo = 1;
                lblCislo.Text = "0, 1";

                // Skryjeme varování při prvním načtení
                lblLimit.Visible = false;
                btnDalsiCislo.Enabled = true;
            }
        }

        protected void btnFibonacci_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPocet.Text, out int pocet) || pocet < 1 || pocet > MaxElements)
            {
                lblVysledek.Text = $"Zadejte počet prvků v rozsahu 1 až {MaxElements}.";
                return;
            }

            List<int> posloupnost = new List<int>();

            int prvni = 0;
            int druhy = 1;

            for (int i = 0; i < pocet; i++)
            {
                posloupnost.Add(prvni);

                int dalsi = prvni + druhy;
                prvni = druhy;
                druhy = dalsi;
            }

            lblVysledek.Text = string.Join(", ", posloupnost);
        }

        protected void btnDalsiCislo_Click(object sender, EventArgs e)
        {
            // Přidání dalšího čísla
            AktualniCislo++;

            int fibonacci = Prvni + Druhe;

            lblCislo.Text += ", " + fibonacci.ToString();

            Prvni = Druhe;
            Druhe = fibonacci;

            // Po přidání zkontrolujeme, zda jsme nedosáhli limitu, a případně upozorníme
            if (AktualniCislo >= MaxElements)
            {
                lblLimit.Text = $"Dosaženo maxima ({MaxElements}).";
                lblLimit.Visible = true;
                btnDalsiCislo.Enabled = false;
            }
            else
            {
                lblLimit.Visible = false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblVysledek.Text = " ";

            AktualniCislo = 1;
            Prvni = 0;
            Druhe = 1;
            lblCislo.Text = AktualniCislo.ToString();

            // Reset varování a opět povolit tlačítko
            lblLimit.Visible = false;
            btnDalsiCislo.Enabled = true;
        }

        protected void btnTriangle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Triangle.aspx");
        }
    }
}