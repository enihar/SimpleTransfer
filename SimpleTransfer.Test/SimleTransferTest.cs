using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTransfer;

namespace SimpleTransfer.Test
{
    [TestClass]
    public class SimleTransferTest
    {
        Account accnt;
        TranscaionService service;

        [TestInitializeAttribute]
        public void setup()
        {
            accnt = new Account(123, 1000);
            service = new TranscaionService();
        }

        [TestMethod]
        public void Deposit_Test()
        {
            service.Deposit(accnt, 500);
            Assert.AreEqual(1500, accnt.Balance);
        }

        [TestMethod]
        public void Withdraw_Success_Test()
        {
            service.Withdraw(accnt, 500);

            //Assert.AreEqual("Successful", msg);
            Assert.AreEqual(500, accnt.Balance);  // Transaction successful without excepion
        }

        [TestMethod]
        [ExpectedException(typeof(NoAvailableFundException), "There is not enough fund available to make this transaction")]
        public void Withdraw_Failure_Test()
        {
            service.Withdraw(accnt, 1500);  // throws exception as overdraft is not allowed        
        }

        [TestMethod]
        public void SimpleTransfer_Success()
        {
            Account FromAccount = new Account(123, 1000);
            Account ToAccount = new Account(456, 2000);
            
            bool actual = service.TransferBetweenAccounts(FromAccount, ToAccount, 500);
            Assert.IsTrue(actual);  // Transaction successful without excepion
        }

        [TestMethod]
        [ExpectedException(typeof(NoAvailableFundException), "There is not enough fund available to make this transaction")]
        public void SimpleTransfer_Failure()
        {
            Account FromAccount = new Account(123, 1000);
            Account ToAccount = new Account(456, 2000);

            bool actual = service.TransferBetweenAccounts(FromAccount, ToAccount, 1500);
            
        }
    }
}
