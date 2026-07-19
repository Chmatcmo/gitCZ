using System;
using System.Globalization;

namespace WebApplication1
{
    public partial class Triangle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // no special initialization required
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            // Try parse as double to allow fractional sides
            if (!double.TryParse(txtA.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double a) ||
                !double.TryParse(txtB.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double b) ||
                !double.TryParse(txtC.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double c) ||
                a <= 0 || b <= 0 || c <= 0)
            {
                lblTriangleResult.Text = "Zadejte kladná èísla pro všechny tøi strany.";
                return;
            }

            // Triangle inequality
            if (a + b > c && a + c > b && b + c > a)
            {
                lblTriangleResult.Text = "Ano — zadané délky mohou tvoøit trojúhelník.";
            }
            else
            {
                lblTriangleResult.Text = "Ne — zadané délky nemohou tvoøit trojúhelník.";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}