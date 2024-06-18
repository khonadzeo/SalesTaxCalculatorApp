using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxCalculator.Models;

namespace SalesTaxCalculator.Repository
{
    public static class ReceiptGenerator
    {
        public static void PrintReceipt(List<Product> products)
        {
            decimal totalTaxes = 0m;
            decimal totalPrice = 0m;

            foreach (var product in products)
            {
                decimal basicTax = TaxCalculator.CalculateBasicTax(product);
                decimal importDuty = TaxCalculator.CalculateImportDuty(product);
                decimal totalTax = basicTax + importDuty;
                decimal finalPrice = product.Price + totalTax;

                totalTaxes += totalTax;
                totalPrice += finalPrice;

                Console.WriteLine($"{product.Name}: {finalPrice:F2}");
            }

            Console.WriteLine($"Sales Taxes: {totalTaxes:F2}");
            Console.WriteLine($"Total: {totalPrice:F2}");
        }
    }
}
