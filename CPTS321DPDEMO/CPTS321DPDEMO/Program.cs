using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS321DPDEMO
{
    public class Program
    {
        static void Main(string[] args)
        {
            var processor = PaymentProcessor.Instance;

            Payment creditCard = new CreditCardPayment(200);
            Payment paypal = new PayPalPayment(50);

            List<Payment> paymentMethods = new List<Payment> { creditCard, paypal };

            while (true)
            {
                Console.WriteLine("\n1. View Items\n2. View Payment Methods\n3. Make a Purchase\n4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Items for sale:");
                        Console.WriteLine("1. Hat - $15\n2. T-Shirt - $30\n3. Jacket - $150");
                        break;

                    case "2":
                        foreach (var paymentMethod in paymentMethods)
                        {
                            Console.WriteLine($"{paymentMethod.MethodName} balance: {paymentMethod.Balance}");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Select an item to purchase:");
                        Console.WriteLine("1. Hat - $15\n2. T-Shirt - $30\n3. Jacket - $150");
                        Console.Write("Choice: ");
                        string itemChoice = Console.ReadLine();

                        double amount = itemChoice switch
                        {
                            "1" => 15,
                            "2" => 30,
                            "3" => 150,
                            _ => 0
                        };

                        if (amount == 0)
                        {
                            Console.WriteLine("Invalid item choice.");
                            continue;
                        }

                        Console.WriteLine("Select payment method:\n1. Credit Card\n2. PayPal");
                        Console.Write("Choice: ");
                        string paymentChoice = Console.ReadLine();

                        if (paymentChoice == "1")
                        {
                            processor.ProcessPayment(creditCard, amount);
                        }
                        else if (paymentChoice == "2")
                        {
                            processor.ProcessPayment(paypal, amount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid payment method.");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
