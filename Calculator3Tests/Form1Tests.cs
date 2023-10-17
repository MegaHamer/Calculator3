using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorTests
{
    [TestClass()]
    public class chisloTests
    {
        [TestMethod()]
        public void chislo_100InString_100InDouble()
        {
            string primer = "100";
            int ot = 0;
            int ido = 2;
            double expected = 100;

            Form1 c = new Form1();
            double actual = c.chislo(primer,ot,ido);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chislo_Minus100InString_Minus100InDouble()
        {
            string primer = "-100";
            int ot = 0;
            int ido = primer.Length-1;
            double expected = -100;

            Form1 c = new Form1();
            double actual = c.chislo(primer, ot, ido);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chislo_10Comma1InString_10Comma1InDouble()
        {
            string primer = "10,1";
            int ot = 0;
            int ido = primer.Length - 1;
            double expected = 10.1;

            Form1 c = new Form1();
            double actual = c.chislo(primer, ot, ido);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void chislo_Minus10Comma1InString_Minus10Comma1InDouble()
        {
            string primer = "-10,1";
            int ot = 0;
            int ido = primer.Length - 1;
            double expected = -10.1;

            Form1 c = new Form1();
            double actual = c.chislo(primer, ot, ido);

            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass()]
    public class countScobkaTest
    {
        [TestMethod()]
        public void countScobka_6scobka_6return()
        {
            string primer = "-(32+2/14)*((44)/-43)";
            int ot = 0;
            int ido = primer.Length - 1;
            int expexted = 6;

            Form1 c = new Form1();
            int actual = c.countScobka(primer, ot, ido);

            Assert.AreEqual(expexted, actual);
        }
    }

}