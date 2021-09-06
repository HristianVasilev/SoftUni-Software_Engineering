namespace Queue
{
    class Queue<T>
    {
        class Node<T>
        {
            public Node(T element)
            {
                this.Element = element;
            }

            public T Element { get; set; }
            public Node<T> Next { get; set; }
        }

        private Node<T> head;
        private int size;

        public Queue()
        {

        }

        public int Count => this.size;

        public void Clear()
        {
            this.head = null;
            this.size = 0;
        }

        public bool Contains(T item)
        {
            Node<T> currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node<T> current = this.head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            this.size++;
        }

        public T Dequeue()
        {
            Node<T> first = this.head;

            if (first is null)
            {
                throw new System.InvalidOperationException("Queue is empty!");
            }

            this.head = this.head.Next;
            this.size--;

            return first.Element;
        }

        public T Peek()
        {
            return this.head.Element;
        }

    }
}
