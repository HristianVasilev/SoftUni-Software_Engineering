using System;
using System.Diagnostics;
using Wintellect.PowerCollections;

namespace TestIt
{
    class Program
    {
        static void Main(string[] args)
        {

            Comparison<Transaction> comparison = new Comparison<Transaction>((x, y) => y.Amount.CompareTo(x.Amount));

            OrderedSet<Transaction> transactions = new OrderedSet<Transaction>(comparison);

            for (int i = 0; i < 100; i++)
            {
                Transaction transaction = new Transaction(i, TransactionStatus.Aborted, "empty", "empty", i * 2.0);
                transactions.Add(transaction);
            }

            ;

        }
    }
}
