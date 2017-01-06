using NUnit.Framework;
using System;

namespace KataSG.Tests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void Should_Proecss_Deposit()
        {
            var account = new Account();

            var deposits = new Random();
            var deposit1 = deposits.Next(0, 100);
            account.Deposit(deposit1);

            Assert.AreEqual(deposit1, account.GetBalance());
        }

        [Test]
        public void Should_Process_Deposits()
        {
            var account = new Account();

            var deposits = new Random();

            var deposit1 = deposits.Next(0, 100);
            account.Deposit(deposit1);

            var deposit2 = deposits.Next(0, 100);
            account.Deposit(deposit2);

            var deposit3 = deposits.Next(0, 100);
            account.Deposit(deposit3);

            Assert.AreEqual(deposit1 + deposit2 + deposit3, account.GetBalance());
        }

        [Test]
        public void Should_Process_Withdrawal()
        {
            var account = new Account();

            var deposits = new Random();

            var deposit1 = deposits.Next(0, 100);
            account.Deposit(deposit1);

            // second deposit to ensure balance is not negative
            var deposit2 = deposits.Next(0, 100);
            account.Deposit(deposit2);

            var withdrawal = deposits.Next(0, 100);
            account.Withdrawal(withdrawal);

            Assert.AreEqual(deposit1 + deposit2 - withdrawal, account.GetBalance());
        }

        [Test]
        public void Should_Transfer()
        {
            var accountSource = new Account();
            var accountTarget = new Account();

            var deposits = new Random();
            var deposit1 = deposits.Next(0, 100);
            accountSource.Deposit(deposit1);

            var deposit2 = deposits.Next(0, 100);
            accountSource.Deposit(deposit2);

            var transferAmount = deposits.Next(0, 100);

            accountSource.TransferTo(accountTarget, transferAmount);

            Assert.AreEqual(deposit1 + deposit2 - transferAmount, accountSource.GetBalance());
            Assert.AreEqual(transferAmount, accountTarget.GetBalance());
        }
    }
}
