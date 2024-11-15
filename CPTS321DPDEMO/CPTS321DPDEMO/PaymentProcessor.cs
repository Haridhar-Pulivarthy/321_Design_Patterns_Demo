using System;
using System.Collections.Generic;

namespace CPTS321DPDEMO
{
    // Singleton PaymentProcessor to manage all payments
    internal class PaymentProcessor
    {
        private static PaymentProcessor instance;

        private PaymentProcessor() { }

        public static PaymentProcessor Instance
        {
            get
            {
                if (instance == null)
                    instance = new PaymentProcessor();
                return instance;
            }
        }

        public void ProcessPayment(Payment payment, double amount)
        {
            payment.Process(amount);
        }
    }
}
