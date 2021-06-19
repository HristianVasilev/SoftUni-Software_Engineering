using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    class Box<T> where T: IComparable
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public T Element => this.element;

        public bool IsGreaterThan<T>(T comparisonValue) where T : IComparable
        {
            int res = this.element.CompareTo(comparisonValue);
            return res > 0;
        }

        public override string ToString()
        {
            return $"{this.element.GetType().FullName}: {this.element}";
        }
    }
}
