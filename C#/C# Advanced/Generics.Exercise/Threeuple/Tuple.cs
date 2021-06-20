namespace Threeuple
{
    class Tuple<T1, T2, T3>
    {
        private T1 element1;
        private T2 element2;
        private T3 element3;

        public Tuple(T1 element1, T2 element2, T3 element3)
        {
            this.Element1 = element1;
            this.Element2 = element2;
            this.Element3 = element3;
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

        public T3 Element3
        {
            get { return this.element3; }
            set { this.element3 = value; }
        }

        public override string ToString()
        {
            return $"{this.Element1} -> {this.Element2} -> {this.Element3}";
        }
    }
}
