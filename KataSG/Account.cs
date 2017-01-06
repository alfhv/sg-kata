using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataSG
{
    public class Account
    {
        private List<double> _transactions;

        public Account()
        {
            _transactions = new List<double>();
        }

        /// <summary>
        /// Accept positive amounts only, if negative received, it will be converted to positive
        /// Error could be raised but it is not in the scope of this kata
        /// </summary>
        /// <param name="amount">P</param>
        public void Deposit(double amount)
        {
            _transactions.Add(Math.Abs(amount));
        }

        /// <summary>
        /// Very simple implementation, enough for now
        /// </summary>
        /// <returns></returns>
        public double GetBalance()
        {
            return _transactions.Sum();
        }

        public void TransferTo(Account accountTarget, int transferAmount)
        {
            Withdrawal(transferAmount);
            accountTarget.Deposit(transferAmount);
        }

        /// <summary>
        /// Only positive amount also, as in Deposit(), we take care of negative convertion inside
        /// </summary>
        /// <param name="withdrawal"></param>
        public void Withdrawal(int withdrawal)
        {
            _transactions.Add(Math.Abs(withdrawal) * -1);
        }
    }
}
