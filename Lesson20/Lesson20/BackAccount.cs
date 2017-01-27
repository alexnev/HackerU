using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20
{
    class BackAccount
    {
        public delegate void OverdrawnEventHandler();
        public event OverdrawnEventHandler overdrawn;

        public decimal balance { get; set; }

        public void deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("positive amount only");
            balance += amount;
        }

        public void withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                if (overdrawn != null)
                    overdrawn();
            }
        }
    }
}
