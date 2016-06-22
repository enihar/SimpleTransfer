using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTransfer
{
    public class Account
    {
        private double balance;
        private int accountNumber;
        public Account(int accountNumber, double balance)
        {
            this.balance = balance;
            this.accountNumber = accountNumber;
        }
        
        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
    }
}
