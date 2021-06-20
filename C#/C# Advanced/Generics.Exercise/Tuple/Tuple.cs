using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    class Tuple<T1, T2>
    {
        private T1 element1;
        private T2 element2;

        public Tuple(T1 element1, T2 element2)
        {
            this.element1 = element1;
            this.element2 = element2;
        }
        public T1 Element1
        {
            get { return this.element1; }
            set { this.element1 = value; }
        }

        public T2 Element2
        {
            get { return this.element2; }
            set { this.element2 = value; }
        }

        public override string ToString()
        {
            return $"{this.element1} -> {this.element2}";
        }
    }
}
