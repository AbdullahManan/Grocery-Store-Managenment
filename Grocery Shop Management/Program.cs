using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_Shop_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager.LoadProducts();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\t\t\t\t\t========== Grocery Store Management==========");
                Console.ResetColor();
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Sell Product");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Select an Option from 1 to 5:");
                
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ProductManager.AddProduct();
                        break;
                    case "2":
                        ProductManager.ViewProducts();
                        break;
                    case "3":
                        ProductManager.DeleteProduct();
                        break;
                    case "4":
                        ProductManager.SellProduct();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();





            }

        }
    }
}
