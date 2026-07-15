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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AktualniCislo = 1;
                lblCislo.Text = AktualniCislo.ToString();
            }
        }

        protected void btnFibonacci_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPocet.Text, out int pocet) ||
                pocet < 1 ||
                pocet > 90)
            {
                lblVysledek.Text =
                    "Zadejte počet prvků v rozsahu 1 až 90.";
                return;
            }

            List<long> posloupnost = new List<long>();

            long prvni = 0;
            long druhy = 1;

            for (int i = 0; i < pocet; i++)
            {
                posloupnost.Add(prvni);

                long dalsi = prvni + druhy;
                prvni = druhy;
                druhy = dalsi;
            }

            lblVysledek.Text = string.Join(", ", posloupnost);
        }

        protected void btnDalsiCislo_Click(object sender, EventArgs e)
        {
            AktualniCislo++;
            lblCislo.Text = AktualniCislo.ToString();
        }
    }
}