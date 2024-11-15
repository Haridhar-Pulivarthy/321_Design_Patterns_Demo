using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS321DPDEMO
{
    // Strategy Pattern: Payment methods as separate strategies
    internal class PayPalPayment : Payment
    {
        public PayPalPayment(double balance) : base(balance, "Credit Card") { }

        public override void Process(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Paid {amount} with {MethodName}. Remaining balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"Insufficient funds on {MethodName}.");
            }
        }

        public override object Clone()
        {
            return new PayPalPayment(Balance);
        }
    }
}
