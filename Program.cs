namespace ProductPriceCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Price Calculator");
            Console.WriteLine("What product will you be purchasing today?");
            var product = Console.ReadLine();

            Console.WriteLine("How many products do you want to buy");
            if (!int.TryParse(Console.ReadLine(), out var totalProducts))
            {
                Console.WriteLine("You must enter a valid number");
                return;
            }
            
            Console.WriteLine("How much do you want to pay for each product?");
            if (!double.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("You must enter a valid number");
                return;
            }

            Console.WriteLine("How much is the VAT in percent?");
            if (!double.TryParse(Console.ReadLine(), out var vat))
            {
                Console.WriteLine("You must enter a valid number");
                return;
            }

            double totalPrice;
            if (vat <= 0)
            { 
                totalPrice = CalculatePrice(totalProducts, price);
            }
            else
            {                 
                totalPrice = CalculatePrice(totalProducts, price, vat / 100); 
            }
            Console.WriteLine($"You bought {totalProducts} {product} for {totalPrice:F2}kr including VAT");                       
        }
        private static double CalculatePrice(
            int totalProducts, double price, double vat = 0.25)
        {
            return totalProducts * price * (1 + vat);
        }
    }
}
