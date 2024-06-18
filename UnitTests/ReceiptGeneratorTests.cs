using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxCalculator.Models;
using SalesTaxCalculator.Repository;

namespace SalesTaxCalculator.UnitTests
{
    [TestClass]
    public class ReceiptGeneratorTests
    {
        private StringWriter stringWriter;

        [TestInitialize]
        public void SetUp()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TestCleanup]
        public void CleanUp()
        {
            stringWriter.Dispose();
            Console.SetOut(Console.Out);
        }

        [TestMethod]
        public void TestInput1()
        {
            var products = new List<Product>
        {
            new Product("1 book", 12.49m, false, true),
            new Product("1 music CD", 14.99m, false, false),
            new Product("1 chocolate bar", 0.85m, false, true)
        };

            ReceiptGenerator.PrintReceipt(products);

            var expectedOutput = "1 book: 12.49\n1 music CD: 16.49\n1 chocolate bar: 0.85\nSales Taxes: 1.50\nTotal: 29.83\n";
            var actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestInput2()
        {
            var products = new List<Product>
        {
            new Product("1 imported box of chocolates", 10.00m, true, true),
            new Product("1 imported bottle of perfume", 47.50m, true, false)
        };

            ReceiptGenerator.PrintReceipt(products);

            var expectedOutput = "1 imported box of chocolates: 10.50\n1 imported bottle of perfume: 54.65\nSales Taxes: 7.65\nTotal: 65.15\n";
            var actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestInput3()
        {
            var products = new List<Product>
        {
            new Product("1 imported bottle of perfume", 27.99m, true, false),
            new Product("1 bottle of perfume", 18.99m, false, false),
            new Product("1 packet of headache pills", 9.75m, false, true),
            new Product("1 imported box of chocolates", 11.25m, true, true)
        };

            ReceiptGenerator.PrintReceipt(products);

            var expectedOutput = "1 imported bottle of perfume: 32.19\n1 bottle of perfume: 20.89\n1 packet of headache pills: 9.75\n1 imported box of chocolates: 11.85\nSales Taxes: 6.70\nTotal: 74.68\n";
            var actualOutput = stringWriter.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
