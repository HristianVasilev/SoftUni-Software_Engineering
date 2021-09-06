using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private HashSet<int> transactionIds;
    //   private HashSet<Transaction> transactions;
    private Dictionary<int, Transaction> transactionsDict;
    private Dictionary<TransactionStatus, List<int>> statusCollecton;
    private Dictionary<double, List<int>> amountCollection;

    public Chainblock()
    {
        this.transactionIds = new HashSet<int>();
        // this.transactions = new HashSet<Transaction>();
        this.transactionsDict = new Dictionary<int, Transaction>();
        this.statusCollecton = new Dictionary<TransactionStatus, List<int>>();
        this.amountCollection = new Dictionary<double, List<int>>();
    }

    private IEnumerable<Transaction> Transactions => this.transactionsDict.Values;

    public int Count => this.transactionsDict.Count;

    public void Add(Transaction tx)
    {
        if (!this.Contains(tx))
        {
            this.transactionIds.Add(tx.Id);
            //  this.transactions.Add(tx);
            this.transactionsDict.Add(tx.Id, tx);
            AddTransactionToStatusCollection(tx);
            AddTransactionToAmountCollection(tx);
        }
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        Transaction transaction = this.GetById(id);
        transaction.Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        return this.Contains(tx.Id);
    }

    public bool Contains(int id)
    {
        return this.transactionIds.Contains(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        List<Transaction> transactions = new List<Transaction>();

        IEnumerable<int> ids = this.amountCollection
            .Where(k => k.Key >= lo && k.Key <= hi)
            .SelectMany(x => x.Value);

        foreach (var id in ids)
        {
            transactions.Add(this.transactionsDict[id]);
        }

        return transactions;
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        throw new NotImplementedException();
    }

    public Transaction GetById(int id)
    {
        EnsureThatTransactionExists(id);

        return this.transactionsDict[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!this.statusCollecton.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        List<int> ids = this.statusCollecton[status];

        Comparison<Transaction> comparison = new Comparison<Transaction>((x, y) => y.Amount.CompareTo(x.Amount));
        OrderedSet<Transaction> transactions = new OrderedSet<Transaction>(comparison);

        foreach (var id in ids)
        {
            transactions.Add(this.transactionsDict[id]);
        }

        return transactions;
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        if (!this.statusCollecton.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        List<int> ids = this.statusCollecton[status];

        Comparison<Transaction> comparison = new Comparison<Transaction>((x, y) => y.Amount.CompareTo(x.Amount));
        OrderedSet<Transaction> transactions = new OrderedSet<Transaction>(comparison);

        foreach (var id in ids)
        {
            Transaction transaction = this.transactionsDict[id];

            if (transaction.Amount <= amount)
            {
                transactions.Add(transaction);
            }
        }

        return transactions;
    }


    public void RemoveTransactionById(int id)
    {
        EnsureThatTransactionExists(id);

        Transaction transaction = this.GetById(id);
        this.transactionsDict.Remove(id);
        this.statusCollecton[transaction.Status].Remove(transaction.Id);
    }



    public IEnumerator<Transaction> GetEnumerator()
    {
        return this.Transactions.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }



    private void EnsureThatTransactionExists(int id)
    {
        if (!this.Contains(id))
        {
            throw new InvalidOperationException();
        }
    }

    private void AddTransactionToStatusCollection(Transaction tx)
    {
        TransactionStatus status = tx.Status;

        if (!this.statusCollecton.ContainsKey(status))
        {
            this.statusCollecton.Add(status, new List<int>());
        }

        this.statusCollecton[status].Add(tx.Id);
    }

    private void AddTransactionToAmountCollection(Transaction tx)
    {
        double amount = tx.Amount;

        if (!this.amountCollection.ContainsKey(amount))
        {
            this.amountCollection.Add(amount, new List<int>());
        }

        this.amountCollection[amount].Add(tx.Id);
    }
}

