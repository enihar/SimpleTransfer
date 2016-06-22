using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleTransfer.Test
{
    [TestClass]
    public class OverdraftAllowedTest
    {
        [TestMethod]
        public void Withdraw_Success_Test()
        {
            Account accnt = new Account(123, 1000);
            TranscaionService service = new OverdraftTransctionService();
            service.Withdraw(accnt, 1500.89);
            Assert.AreEqual(-510.91, accnt.Balance);  // Transaction successful with additional fees 
        }

        [TestMethod]
        [ExpectedException(typeof(NoAvailableFundException), "There is not enough fund available to make this transaction")]
        public void Withdraw_Failure_Test()
        {
            Account accnt = new Account(123, -1);
            TranscaionService service = new OverdraftTransctionService();
            service.Withdraw(accnt, 5);  // throws exception as account balance is already overdrawn
        }


        [TestMethod]
        public void OverdraftTransfer_Success()
        {
            Account FromAccount = new Account(123, 1000);
            Account ToAccount = new Account(456, 2000);

            TranscaionService service = new OverdraftTransctionService();

            bool actual = service.TransferBetweenAccounts(FromAccount, ToAccount, 1500);
            Assert.IsTrue(actual);  // Overdraft transaction successful without excepion
        }

        [TestMethod]
        [ExpectedException(typeof(NoAvailableFundException), "There is not enough fund available to make this transaction")]
        public void OverdraftTransfer_Failure()
        {
            Account FromAccount = new Account(123, -1);
            Account ToAccount = new Account(456, 2000);

            TranscaionService service = new OverdraftTransctionService();

            bool actual = service.TransferBetweenAccounts(FromAccount, ToAccount, 5);

        }
    }
}
