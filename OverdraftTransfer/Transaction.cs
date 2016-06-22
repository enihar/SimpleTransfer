using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTransfer
{
    
    public class TranscaionService
    {
        public bool TransferBetweenAccounts(Account fromAccount, Account toAccount, double amount)
        {
                Withdraw(fromAccount, amount);
                Deposit(toAccount, amount);

                return true;
        }

        // making the method VIRTUAL to implement new logic in child class
        public virtual void Withdraw(Account accnt, double amount)
        {
            if (amount < accnt.Balance)
            {
                accnt.Balance -= amount;
            }
            else
            {
                throw new NoAvailableFundException("There is not enough fund available to make this transaction");
            }
        }

        public void Deposit(Account accnt, double amount)
        {
            accnt.Balance += amount;
        }
    }
}
