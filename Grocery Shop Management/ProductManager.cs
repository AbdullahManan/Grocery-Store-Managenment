using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Grocery_Shop_Management
{
    public static class ProductManager
    {
        private static string filePath = "products.txt";
        public static void LoadProducts()
        {

            if (!File.Exists(filePath))  // This checks if the file (products.txt) does not exist.
                return;


            // This reads all lines from the file into a string array.
            //Each line is one product entry like: "1,Milk,10,50"
            //lines[0] = first product, lines[1] = second, and so on.

            string[] lines = File.ReadAllLines(filePath);

            // A loop that goes through each line(each product).
            // line will be "1,Milk,10,50" for one product.
            foreach ( string line in lines )
            {
                //Splits the line by commas into an array of 4 values:
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    Product p = new Product
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Quantity = int.Parse(parts[2]),
                        Price = double.Parse(parts[3])

                    };
                    products.Add(p);

                }
            }
        }






        public static List<Product> products = new List<Product>();
        public static void AddProduct()
        {
            Console.Write("Enter Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price Per Unit: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product p = new Product
            {
                Id = id,
            Name = name,
            Quantity = quantity,
            Price = price
            };

            products.Add(p);
            string line = $"{p.Id},{p.Name},{p.Quantity},{p.Price}";
            File.AppendAllText(filePath, line + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Product Added and Saved Successfully");
            Console.ResetColor();
        }

        public static void ViewProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===Prodct List===");
            Console.ResetColor();
            
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}| Name: {p.Name}| Qty: {p.Quantity}| Price: {p.Price}");
            }
            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nothing Found! Add Product to View Here!");
                Console.ResetColor();

            }

        }

        public static void DeleteProduct()
        {
            Console.WriteLine("Enter Product ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product product = products.Find(p => p.Id == id);

                if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found!");
                Console.ResetColor();
            } else
            {
                products.Remove(product);
                SaveAllProducts();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Product deleted successfully.");
                Console.ResetColor();
            }
           
        }
        public static void SaveAllProducts()
        {
            List<string> lines = new List<string>();

            foreach (Product p in products)
            {
                string line = $"{p.Id},{p.Name},{p.Quantity},{p.Price}";
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }

        public static void SellProduct()
        {
            Console.Write("Enter Product ID to sell: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product product = products.Find(p => p.Id == id);

            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Product not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter quantity to sell: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (qty > product.Quantity)
            {
                Console.WriteLine(" Not enough stock. Available: " + product.Quantity);
                return;
            }

            double total = qty * product.Price;
            product.Quantity -= qty;

            SaveAllProducts(); // update file

            Console.WriteLine($" Sold {qty} x {product.Name}");
            Console.WriteLine($" Total Bill: Rs. {total}");
        }
    }
}
