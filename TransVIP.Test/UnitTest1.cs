using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransVIP;
using TransVIP.Transactions;

namespace TransVIP.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ThrowIfTransactionNameIsEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() => 
            {
                var transaction = new Transaction(string.Empty, 0, Direction.FromPlc);
            });
            
        }

        [TestMethod]
        public void ThrowIfTransactionMessageIDIsNotBetween0And65535()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var transaction = new Transaction(string.Empty, -1, Direction.FromPlc);
            });
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var transaction = new Transaction(string.Empty, 65555, Direction.FromPlc);
            });

        }

        [TestMethod]
        public void ThrowIfAddingDuplicateNameToTransaction()
        {
            var transaction = new Transaction("Test", 0, Direction.FromPlc);
            var tag = new Tag("TestTag");

            transaction.AddTag(tag);

            Assert.ThrowsException<DuplicateNameException>(() =>
            {
                transaction.AddTag(tag);
            });

        }
        

    }
}
