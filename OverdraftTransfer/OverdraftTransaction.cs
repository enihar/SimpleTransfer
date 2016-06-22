using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTransfer
{
    // inherited base class imlementation
    public class OverdraftTransctionService : TranscaionService
    {
        // overriding base class to implement new logic
        public override void Withdraw(Account accnt, double amount)
        {
            if (accnt.Balance > 0)  // checking if balance is not already overdrawn
            {
                if (amount > accnt.Balance)  // if amount to be withdrawn is greater than balance, adda a fee of 2%
                { 
                    AddFees(ref amount, accnt.Balance);
                }
                accnt.Balance -= amount;
                accnt.Balance = Math.Round(accnt.Balance, 2);
            }
            else
            {
                throw new NoAvailableFundException("There is not enough fund available to make this transaction");
            }
        }

        public static void AddFees(ref double amount, double balance)
        {
            double fees = Math.Round(((amount- balance) * 2) / 100, 2);

            amount += fees;
        }
    }
}
