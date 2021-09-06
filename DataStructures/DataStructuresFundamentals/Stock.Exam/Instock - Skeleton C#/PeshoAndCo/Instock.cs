using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    private HashSet<string> labels;
    private OrderedSet<Product> alphabeticalOrderedProducts;
  //  private List<Product> products;
    

    private Dictionary<string, Product> productsByLabel;
    private Dictionary<double, List<string>> productsByPrice;
    private Dictionary<int, List<string>> productsByQuantity;


    public Instock()
    {
        this.labels = new HashSet<string>();
       // this.alphabeticalOrderedProducts = new OrderedSet<Product>();
       // this.products = new List<Product>();
        this.productsByLabel = new Dictionary<string, Product>();
        this.productsByPrice = new Dictionary<double, List<string>>();
        this.productsByQuantity = new Dictionary<int, List<string>>();
    }

    private IEnumerable<Product> Products => this.productsByLabel.Values;
  //  private OrderedSet<Product> alphabetical => new OrderedSet<Product>(this.products);

    public int Count => this.productsByLabel.Count;

    public void Add(Product product)
    {
        if (!this.Contains(product))
        {
            this.labels.Add(product.Label);
           // this.alphabeticalOrderedProducts.Add(product);
          //  this.products.Add(product);
            this.productsByLabel.Add(product.Label, product);
            this.AddProductsByPrice(product);
            this.AddProductsByQuantity(product);
        }
    }

    public void ChangeQuantity(string product, int quantity)
    {
        string label = product;

        if (!this.productsByLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }

        Product productObj = this.productsByLabel[label];
        // The last item should be the last changed or last added.
        // All collections should have same product objects
        this.productsByQuantity[productObj.Quantity].Remove(label);
        this.productsByLabel.Remove(label);       

        productObj.Quantity = quantity;

        AddProductsByQuantity(productObj);
        this.productsByLabel.Add(label, productObj);
        
    }

    public bool Contains(Product product)
    {
        return this.labels.Contains(product.Label);
    }

    public Product Find(int index)
    {
        if (!ValidIndex(index))
        {
            throw new IndexOutOfRangeException();
        }

       string label = this.labels.ElementAt(index);

        return this.productsByLabel[label];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        List<Product> products = new List<Product>();

        if (this.productsByPrice.ContainsKey(price))
        {
            List<string> labels = this.productsByPrice[price];

            foreach (var label in labels)
            {
                products.Add(this.productsByLabel[label]);
            }
        }

        return products;
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        List<Product> products = new List<Product>();

        if (this.productsByQuantity.ContainsKey(quantity))
        {
            List<string> labels = this.productsByQuantity[quantity];

            foreach (var label in labels)
            {
                products.Add(this.productsByLabel[label]);
            }
        }

        return products;
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        var collection = this.productsByPrice
            .Where(k => k.Key > lo && k.Key <= hi)
            .OrderByDescending(k => k.Key)
            .Select(x => x.Value);

        List<string> labels = new List<string>();

        foreach (var prod in collection)
        {
            labels.AddRange(prod);
        }

        List<Product> products = new List<Product>();
        foreach (var label in labels)
        {
            products.Add(this.productsByLabel[label]);
        }

        return products;
    }

    public Product FindByLabel(string label)
    {
        if (!this.labels.Contains(label))
        {
            throw new ArgumentException();
        }

        return this.productsByLabel[label];
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentException();
        }

        List<Product> products = new List<Product>(count);

        IEnumerable<string> labels = this.labels.OrderBy(x => x).Take(count);

        foreach (var label in labels)
        {
            products.Add(this.FindByLabel(label));
        }

        return products;
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentException();
        }

        IEnumerable<double> prices = this.productsByPrice.Keys.OrderByDescending(x => x);

        List<string> labels = new List<string>(count);

        foreach (var price in prices)
        {
            foreach (var item in this.productsByPrice[price])
            {
                labels.Add(item);
                if (labels.Count == count)
                {
                    break;
                }
            }

            if (labels.Count == count)
            {
                break;
            }
        }

        List<Product> products = new List<Product>();

        foreach (var label in labels)
        {
            products.Add(this.productsByLabel[label]);
        }

        return products;
    }

    public IEnumerator<Product> GetEnumerator()
    {
        return this.Products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }



    private bool ValidIndex(int index)
    {
        return index >= 0 && index < this.productsByLabel.Count;
    }

    private void AddProductsByPrice(Product product)
    {
        double price = product.Price;
        string label = product.Label;

        if (!this.productsByPrice.ContainsKey(price))
        {
            this.productsByPrice.Add(price, new List<string>());
        }

        this.productsByPrice[price].Add(label);
    }

    private void AddProductsByQuantity(Product product)
    {
        int quantity = product.Quantity;
        string label = product.Label;

        if (!this.productsByQuantity.ContainsKey(quantity))
        {
            this.productsByQuantity.Add(quantity, new List<string>());
        }

        this.productsByQuantity[quantity].Add(label);
    }
}
