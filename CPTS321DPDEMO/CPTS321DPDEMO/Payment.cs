using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS321DPDEMO
{
    // Prototype Pattern: Cloneable payment class
    internal abstract class Payment : ICloneable
    {
        public double Balance { get; protected set; }
        public string MethodName { get; protected set; }

        public Payment(double balance, string methodName)
        {
            Balance = balance;
            MethodName = methodName;
        }

        public abstract void Process(double amount);
        public abstract object Clone();
    }
}
