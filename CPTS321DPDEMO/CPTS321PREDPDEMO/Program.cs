using System;

namespace CPTS321PREDPDEMO
{
    class PaymentProcessor
    {
        private string paymentMethod;
        private double balance;
        private double amount;

        public PaymentProcessor(string paymentMethod, double balance)
        {
            this.paymentMethod = paymentMethod;
            this.balance = balance;
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"{paymentMethod} balance: {balance}");
        }

        public void ProcessPayment(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Paid {amount} with {paymentMethod}. Remaining balance: {balance}");
            }
            else
            {
                Console.WriteLine($"Insufficient funds on {paymentMethod}.");
            }
        }

        public double GetBalance() => balance;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cardProcessor = new PaymentProcessor("Credit Card", 200);
            var paypalProcessor = new PaymentProcessor("PayPal", 50);

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
                        cardProcessor.DisplayBalance();
                        paypalProcessor.DisplayBalance();
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
                            cardProcessor.ProcessPayment(amount);
                        }
                        else if (paymentChoice == "2")
                        {
                            paypalProcessor.ProcessPayment(amount);
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
