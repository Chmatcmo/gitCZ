using System;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;

namespace WebApplication1.Tests
{
    [TestClass]
    public class DefaultTests
    {
        private TestableDefault page;

        [TestInitialize]
        public void Setup()
        {
            page = new TestableDefault();
        }

        [TestMethod]
        public void PageLoad_SetsInitialLabelTo1()
        {
            // Act
            page.CallPageLoad();

            // Assert
            Assert.AreEqual("1", page.LblCisloText);
        }

        [TestMethod]
        public void BtnFibonacci_ValidInput_DisplaysSequence()
        {
            // Arrange
            page.txtPocet.Text = "5"; // expect: 0, 1, 1, 2, 3

            // Act
            page.CallBtnFibonacci();

            // Assert
            Assert.AreEqual("0, 1, 1, 2, 3", page.LblVysledekText);
        }

        [TestMethod]
        public void BtnFibonacci_InvalidInput_ShowsError_ForNonNumeric()
        {
            // Arrange
            page.txtPocet.Text = "abc";

            // Act
            page.CallBtnFibonacci();

            // Assert
            Assert.AreEqual("Zadejte poèet prvkù v rozsahu 1 až 199.", page.LblVysledekText);
        }

        [TestMethod]
        public void BtnFibonacci_InvalidInput_ShowsError_ForOutOfRangeLow()
        {
            // Arrange
            page.txtPocet.Text = "0";

            // Act
            page.CallBtnFibonacci();

            // Assert
            Assert.AreEqual("Zadejte poèet prvkù v rozsahu 1 až 199.", page.LblVysledekText);
        }

        [TestMethod]
        public void BtnFibonacci_InvalidInput_ShowsError_ForOutOfRangeHigh()
        {
            // Arrange
            page.txtPocet.Text = "200";

            // Act
            page.CallBtnFibonacci();

            // Assert
            Assert.AreEqual("Zadejte poèet prvkù v rozsahu 1 až 199.", page.LblVysledekText);
        }

        [TestMethod]
        public void BtnDalsiCislo_AppendsNextFibonacciNumber()
        {
            // Arrange - initialize page as first load
            page.CallPageLoad();
            Assert.AreEqual("1", page.LblCisloText);

            // Act - add next number
            page.CallBtnDalsiCislo();

            // Assert - first fibonacci appended is 1 (0+1)
            Assert.AreEqual("1, 1", page.LblCisloText);

            // Act - add next again (should append 2)
            page.CallBtnDalsiCislo();

            // Assert
            Assert.AreEqual("1, 1, 2", page.LblCisloText);
        }

        [TestMethod]
        public void BtnReset_ResetsLabelsAndState()
        {
            // Arrange - change state by adding numbers
            page.CallPageLoad();
            page.CallBtnDalsiCislo();
            page.CallBtnDalsiCislo();
            Assert.AreNotEqual("1", page.LblCisloText);

            // Act - reset
            page.CallBtnReset();

            // Assert
            Assert.AreEqual(" ", page.LblVysledekText); // single space per implementation
            Assert.AreEqual("1", page.LblCisloText);
        }

        // Helper testable subclass that exposes protected members for testing
        private class TestableDefault : Default
        {
            public TestableDefault()
            {
                // initialize controls that normally come from designer
                lblCislo = new Label();
                lblVysledek = new Label();
                txtPocet = new TextBox();
            }

            // Expose controls' text for assertions
            public string LblCisloText => lblCislo.Text;
            public string LblVysledekText => lblVysledek.Text;

            // Expose the protected controls for arranging input
            public new TextBox txtPocet => base.txtPocet;

            // Public wrappers to invoke protected event handlers and lifecycle
            public void CallPageLoad() => Page_Load(this, EventArgs.Empty);
            public void CallBtnFibonacci() => btnFibonacci_Click(this, EventArgs.Empty);
            public void CallBtnDalsiCislo() => btnDalsiCislo_Click(this, EventArgs.Empty);
            public void CallBtnReset() => btnReset_Click(this, EventArgs.Empty);

            // Provide direct accessors used in tests
            public new Label lblCislo
            {
                get => base.lblCislo;
                set => base.lblCislo = value;
            }

            public new Label lblVysledek
            {
                get => base.lblVysledek;
                set => base.lblVysledek = value;
            }

            public new TextBox txtPocet
            {
                get => base.txtPocet;
                set => base.txtPocet = value;
            }
        }
    }
}