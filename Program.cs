using SalesTaxCalculator.Models;
using SalesTaxCalculator.Repository;

public class Program
{
    public static void Main(string[] args)
    {
        var input1 = new List<Product>
        {
            new Product("1 book", 12.49m, false, true),
            new Product("1 music CD", 14.99m, false, false),
            new Product("1 chocolate bar", 0.85m, false, true)
        };

        Console.WriteLine("Output 1:");
        ReceiptGenerator.PrintReceipt(input1);
        Console.WriteLine();

        var input2 = new List<Product>
        {
            new Product("1 imported box of chocolates", 10.00m, true, true),
            new Product("1 imported bottle of perfume", 47.50m, true, false)
        };

        Console.WriteLine("Output 2:");
        ReceiptGenerator.PrintReceipt(input2);
        Console.WriteLine();

        var input3 = new List<Product>
        {
            new Product("1 imported bottle of perfume", 27.99m, true, false),
            new Product("1 bottle of perfume", 18.99m, false, false),
            new Product("1 packet of headache pills", 9.75m, false, true),
            new Product("1 imported box of chocolates", 11.25m, true, true)
        };

        Console.WriteLine("Output 3:");
        ReceiptGenerator.PrintReceipt(input3);
    }
}