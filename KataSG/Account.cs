using System;
using System.Collections.Generic;
using System.Linq;

namespace KataSG
{
    /// <summary>
    /// Only positive amounts expected in all operations
    /// No error check is done for now as it is not in the scope of this kata
    /// </summary>
    public class Account
    {
        private List<double> _transactions;

        public Account()
        {
            _transactions = new List<double>();
        }

        /// <summary>
        /// 1. Basic account operation (deposit)
        /// Accept positive amounts only, if negative received it will be converted to positive
        /// </summary>
        /// <param name="amount">P</param>
        public void Deposit(double amount)
        {
            _transactions.Add(EnsurePositive(amount));
        }

        /// <summary>
        /// 1. Basic account operation (withdrawal)
        /// Only positive amount expected, as in Deposit(), 
        /// take care of negative convertion just to avoid undesirable effects not handled for now
        /// </summary>
        /// <param name="withdrawal"></param>
        public void Withdrawal(double withdrawal)
        {
            _transactions.Add(EnsurePositive(withdrawal) * -1);
        }

        private double EnsurePositive(double amount)
        {
            return Math.Abs(amount);
        }

        /// <summary>
        /// Very simple implementation, enough for now
        /// </summary>
        /// <returns></returns>
        public double GetBalance()
        {
            return _transactions.Sum();
        }

        /// <summary>
        /// 2. Transfer to another client in the same bank
        /// (assuming "client" as account)
        /// </summary>
        /// <param name="accountTarget"></param>
        /// <param name="transferAmount"></param>
        public void TransferTo(Account accountTarget, double transferAmount)
        {
            Withdrawal(transferAmount);
            accountTarget.Deposit(transferAmount);
        }
    }
}
