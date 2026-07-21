using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
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
                lblCislo.Text = AktualniCislo.ToString();
            }
        }

        protected void btnFibonacci_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPocet.Text, out int pocet) || pocet < 1 || pocet > 47)
            {
                lblVysledek.Text = "Zadejte počet prvků v rozsahu 1 až 47.";
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
            AktualniCislo++;

            if (AktualniCislo > 46)
            {
                return;
            }
            
            int fibonacci = Prvni + Druhe;

            // Připojíme další číslo místo přepsání textu
            lblCislo.Text += ", " + fibonacci.ToString();

            Prvni = Druhe;
            Druhe = fibonacci;
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblVysledek.Text = " ";

            AktualniCislo = 1;
            Prvni = 0;
            Druhe = 1;
            lblCislo.Text = AktualniCislo.ToString();
        }

        // New: redirect to Triangle.aspx
        protected void btnTriangle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Triangle.aspx");
        }
    }
}