namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {

        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root = new HtmlElement(ElementType.Document,
                new HtmlElement(ElementType.Html,
                    new HtmlElement(ElementType.Head), new HtmlElement(ElementType.Body)));
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            return this.GetElementsByType(type)[0];
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            List<IHtmlElement> result = new List<IHtmlElement>();

            this.DFS(this.Root, type, ref result);

            return result;
        }

        private void DFS(IHtmlElement htmlElement, ElementType type, ref List<IHtmlElement> result)
        {      
            foreach (var child in htmlElement.Children)
            {
                this.DFS(child, type, ref result);
            }

            if (htmlElement.Type == type)
            {
                result.Add(htmlElement);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.BFS(Root, htmlElement);
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            IHtmlElement htmlElement = FindHtmlElement(Root, parent);
            htmlElement.Children.Insert(0, child);
            child.Parent = htmlElement;
        }

        private IHtmlElement FindHtmlElement(IHtmlElement htmlElement, IHtmlElement target)
        {
            if (htmlElement == target)
            {
                return htmlElement;
            }

            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(htmlElement);

            while (queue.Count != 0)
            {
                IHtmlElement element = queue.Dequeue();

                foreach (var child in element.Children)
                {
                    IHtmlElement returnedElement = this.FindHtmlElement(child, target);

                    if (returnedElement != null)
                    {
                        return returnedElement;
                    }

                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            IHtmlElement htmlElement = FindHtmlElement(Root, parent);
            htmlElement.Children.Add(child);
            child.Parent = htmlElement;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                IHtmlElement element = queue.Dequeue();

                if (element == htmlElement)
                {
                    IHtmlElement parent = element.Parent;
                    parent.Children.Remove(element);
                    return;
                }

                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }

            throw new InvalidOperationException();
        }

        public void RemoveAll(ElementType elementType)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                IHtmlElement element = queue.Dequeue();

                if (element.Type == elementType)
                {
                    IHtmlElement parent = element.Parent;
                    parent.Children.Remove(element);
                }

                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            IHtmlElement element = FindHtmlElement(this.Root, htmlElement);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            if (!element.Attributes.ContainsKey(attrKey))
            {
                element.Attributes.Add(attrKey, attrValue);
                return true;
            }

            return false;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            IHtmlElement element = FindHtmlElement(this.Root, htmlElement);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            if (element.Attributes.ContainsKey(attrKey))
            {
                element.Attributes.Remove(attrKey);
                return true;
            }

            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                IHtmlElement htmlElement = queue.Dequeue();

                if (htmlElement.Attributes.ContainsKey("id"))
                {
                    string value = htmlElement.Attributes["id"];
                    if (value == idValue)
                    {
                        return htmlElement;
                    }
                }

                foreach (var child in htmlElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public override string ToString()
        {
            return GetAsString();
        }

        private string GetAsString()
        {
            List<string> order = new List<string>();
            DFS(this.Root, ref order, 0);

            return string.Join(Environment.NewLine, order);
        }

        private bool BFS(IHtmlElement htmlElement, IHtmlElement target)
        {
            if (htmlElement == target)
            {
                return true;
            }

            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(htmlElement);

            while (queue.Count != 0)
            {
                IHtmlElement element = queue.Dequeue();

                foreach (var child in element.Children)
                {
                    bool contains = this.BFS(child, target);
                    if (contains)
                    {
                        return true;
                    }
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        private void DFS(IHtmlElement htmlElement, ref List<string> order, int count)
        {
            order.Add($"{new string(' ', count)}{htmlElement.Type}");

            foreach (var child in htmlElement.Children)
            {
                this.DFS(child, ref order, count + 2);
            }
        }
    }
}
