using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    class Box<T>
    {
        private List<T> box;

        public Box()
        {
            this.box = new List<T>();
        }

        public int Count 
        {
            get => this.box.Count;
        }


        public void Add(T element)
        {
            this.box.Add(element);
        }

        public T Remove()
        {
            T element = this.box.Last();
            this.box.Remove(element);
            return element;
        }
    }
}
