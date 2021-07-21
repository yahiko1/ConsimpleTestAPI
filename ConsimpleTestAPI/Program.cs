
using System;
using System.Collections.Generic;
using System.Linq;
using ConsimpleTestAPI.ConsimpleAPIClient;

namespace ConsimpleTestAPI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var client = new RestClient();

            while (true)
            {
                Console.WriteLine(
                    @"Press any key to make get request to 'https://tester.consimple.pro/' and see result");
                Console.WriteLine("Press 'EXIT' to end program");
                var input = Console.ReadLine();
                
                if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you for your attention (: ");
                    break;
                }
                
                Console.Clear();
                var response = client.GetAsync("", new Dictionary<string, string>()).GetAwaiter().GetResult();
                if (response == null)
                {
                    Console.WriteLine("Bad response :( ");
                    return;
                }
                
                Console.WriteLine("Result:\n");
                Console.WriteLine("Product name | Category name");
                foreach (var product in response.Products)
                {
                    var category = response.Categories.FirstOrDefault(x => x.Id == product.CategoryId);
                    Console.WriteLine($"{product.Name} | { (category == null ? string.Empty : category.Name) }");
                }
                Console.WriteLine("\n");
            }
            
        }
    }
}