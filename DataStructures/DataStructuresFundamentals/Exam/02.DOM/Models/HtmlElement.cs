namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            this.Type = type;
            SetParent(ref children);
            this.Children = new List<IHtmlElement>(children);
            this.Attributes = new Dictionary<string, string>();
        }


        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }

       

       

        private void SetParent(ref IHtmlElement[] children)
        {
            foreach (var child in children)
            {
                child.Parent = this;
            }
        }

    }
}
