namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private IDictionary<string, Invoice> invoices;
        //  private IDictionary<DateTime, ISet<string>> invoicesByIssueDate;
        // private IDictionary<DateTime, ISet<string>> invoicesByDueDate;
        // private IDictionary<Department, ISet<string>> invoicesByDepartment;
        // private IDictionary<string, ISet<string>> invoicesByCompany;
        //  private ISet<string> paidInvoices;


        public Agency()
        {
            this.invoices = new Dictionary<string, Invoice>();
            //  this.invoicesByIssueDate = new SortedDictionary<DateTime, ISet<string>>();
            // this.invoicesByDueDate = new Dictionary<DateTime, ISet<string>>();
            //  this.invoicesByDepartment = new Dictionary<Department, ISet<string>>();
            //  this.invoicesByCompany = new Dictionary<string, ISet<string>>();
            //  this.paidInvoices = new SortedSet<string>();
        }


        public void Create(Invoice invoice)
        {
            if (this.Contains(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            Add(invoice);
        }

        public void ThrowInvoice(string number)
        {
            this.Remove(number);
        }

        public void ThrowPayed()
        {
            //string[] keys = this.paidInvoices.ToArray();
            string[] keys = this.invoices
                .Where(x => x.Value.Subtotal == 0)
                .Select(k => k.Key)
                .ToArray();

            foreach (var serialNumber in keys)
            {
                this.Remove(serialNumber);
            }

            // this.paidInvoices.Clear();
        }

        public int Count()
        {
            return this.invoices.Count;
        }

        public bool Contains(string number)
        {
            return this.invoices.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            //if (!this.invoicesByDueDate.ContainsKey(due.Date))
            //    throw new ArgumentException();

            //var filteredSerialNumbers = this.invoicesByDueDate[due.Date];

            //foreach (var serialNumber in filteredSerialNumbers)
            //{
            //    Invoice invoice = this.invoices[serialNumber];
            //    invoice.Subtotal = 0;
            //}

            IEnumerable<Invoice> filteredInvoices = this.invoices.Values
                .Where(i => i.DueDate.Date == due.Date);

            if (filteredInvoices.Count() == 0)
                throw new ArgumentException();

            foreach (var invoice in filteredInvoices)
            {
                invoice.Subtotal = 0;
            }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            //IEnumerable<string> filteredInvoicesSerialNumbers = this.invoicesByIssueDate
            //    .Where(k => k.Key >= start && k.Key <= end)
            //    .SelectMany(v => v.Value);

            //if (filteredInvoicesSerialNumbers.Count() == 0) return Enumerable.Empty<Invoice>();

            //ICollection<Invoice> filteredInvoices = this.GetInvoicesBySerialNumber(filteredInvoicesSerialNumbers);
            //return filteredInvoices;

            IEnumerable<Invoice> filteredInvoices = this.invoices.Values
                .Where(i => i.IssueDate.Date >= start.Date && i.IssueDate.Date <= end.Date)
                .OrderBy(i => i.IssueDate.Date).ThenBy(i => i.DueDate.Date);

            return filteredInvoices;
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            IEnumerable<string> filteredSerialNumbers = this.invoices.Keys
                .Where(sn => sn.Contains(serialNumber));

            if (filteredSerialNumbers.Count() == 0)
            {
                throw new ArgumentException();
            }

            ICollection<Invoice> filteredInvoices
                = this.GetInvoicesBySerialNumber(filteredSerialNumbers.Reverse());

            return filteredInvoices;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            //string[] filteredInvoicesSerialNumbers = this.invoicesByDueDate
            //    .Where(k => k.Key > start && k.Key < end)
            //    .SelectMany(v => v.Value)
            //    .ToArray();

            //if (filteredInvoicesSerialNumbers.Count() == 0)
            //    throw new ArgumentException();

            //ICollection<Invoice> invoices
            //    = this.GetInvoicesBySerialNumber(filteredInvoicesSerialNumbers);

            Invoice[] invoices = this.invoices.Values
             .Where(i => i.DueDate.Date > start.Date && i.DueDate.Date < end.Date)
             .ToArray();

            if (invoices.Length == 0)
                throw new ArgumentException();

            foreach (var invoice in invoices)
            {
                this.Remove(invoice.SerialNumber);
            }

            return invoices;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            //if (!this.invoicesByDepartment.ContainsKey(department))
            //{
            //    return Enumerable.Empty<Invoice>();
            //}

            //ISet<string> keys = this.invoicesByDepartment[department];

            //ICollection<Invoice> invoices = this.GetInvoicesBySerialNumber(keys);

            //return invoices.OrderByDescending(x => x.Subtotal).ThenBy(x => x.IssueDate);

            return this.invoices.Values
                  .Where(i => i.Department.Equals(department))
                  .OrderByDescending(i => i.Subtotal)
                  .ThenBy(i => i.IssueDate);
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            //if (!this.invoicesByCompany.ContainsKey(company))
            //    return Enumerable.Empty<Invoice>();

            //IEnumerable<string> keys = this.invoicesByCompany[company].Reverse();

            //ICollection<Invoice> invoices = this.GetInvoicesBySerialNumber(keys);
            return this.invoices.Values
                .Where(x => x.CompanyName == company)
                .OrderByDescending(x => x.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            //if (!this.invoicesByDueDate.ContainsKey(dueDate))
            //    throw new ArgumentException();

            //ISet<string> keys = this.invoicesByDueDate[dueDate];

            //foreach (var key in keys)
            //{
            //    this.invoices[key].DueDate = this.invoices[key].DueDate.AddDays(days);
            //}

            IEnumerable<Invoice> filteredInvoices = this.invoices.Values
                .Where(i => i.DueDate.Date.Equals(dueDate.Date));

            if (filteredInvoices.Count() == 0)
                throw new ArgumentException();

            foreach (var invoice in filteredInvoices)
            {
                invoice.DueDate = invoice.DueDate.AddDays(days);
            }

        }


        // Private


        // Add
        private void Add(Invoice invoice)
        {
            string serialNumber = invoice.SerialNumber;

            this.invoices.Add(serialNumber, invoice);
            //  this.AddToDictionary(invoice.IssueDate.Date, serialNumber, ref invoicesByIssueDate);
            //  this.AddToDictionary(invoice.DueDate.Date, serialNumber, ref invoicesByDueDate);
            // this.AddToDictionary(invoice.Department, serialNumber, ref invoicesByDepartment);
            //   this.AddToDictionary(invoice.CompanyName, serialNumber, ref invoicesByCompany);
            // this.CheckIfPaid(invoice);
        }

        private void AddToDictionary<TKey>(TKey key, string serialNumber, ref IDictionary<TKey, ISet<string>> dictionary)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new SortedSet<string>());
            }

            dictionary[key].Add(serialNumber);
        }

        //private void CheckIfPaid(Invoice invoice)
        //{
        //    if (invoice.Subtotal == 0)
        //    {
        //        this.paidInvoices.Add(invoice.SerialNumber);
        //    }
        //}


        // Remove
        // !!! Potential bug! The collections, passed into "RemoveFromCollection" method are not by referance!!!
        private void Remove(string number)
        {
            Invoice invoice = this.GetInvoice(number);

            if (invoice == null)
            {
                throw new ArgumentException();
            }

            this.invoices.Remove(number);
            // this.RemoveFromCollection(number, invoicesByIssueDate[invoice.IssueDate.Date]);
            // this.RemoveFromCollection(number, invoicesByDueDate[invoice.DueDate.Date]);
            // this.RemoveFromCollection(number, invoicesByDepartment[invoice.Department]);
            // this.RemoveFromCollection(number, invoicesByCompany[invoice.CompanyName]);
            // this.RemoveFromCollection(number, paidInvoices);
        }

        private void RemoveFromCollection(string serialNumber, ISet<string> collection)
        {
            collection.Remove(serialNumber);
        }


        // Get collection
        private List<Invoice> GetInvoicesBySerialNumber(IEnumerable<string> serialNumbers)
        {
            List<Invoice> invoices = new List<Invoice>();

            foreach (var number in serialNumbers)
            {
                invoices.Add(this.invoices[number]);
            }

            return invoices;
        }


        // Other

        private Invoice GetInvoice(string serialNumber)
        {
            if (!this.Contains(serialNumber)) return null;

            return this.invoices[serialNumber];
        }
    }
}
