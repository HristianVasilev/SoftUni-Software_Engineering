namespace RedBlackTree
{
    using System;
    using System.Text;

    public class RedBlackTree
    {
        public Node Root { get; set; }

        public void Insert(int value)
        {
            if (this.Root == null)
            {
                this.Root = CreateNewNode(value);
                this.Root.Color = Color.Black;
                return;
            }

            this.Root = Insert(this.Root, value);
        }

        public void ConsolePrint(Node node, int indent)
        {
            if (node == null) return;

            ConsolePrint(node.RightChild, indent + 6);

            //Console.BackgroundColor = ConsoleColor.White;
            Console.Write(new string(' ', indent));
            Console.WriteLine($"{node}");
            Console.BackgroundColor = ConsoleColor.White;

            ConsolePrint(node.LeftChild, indent + 6);
        }




        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return CreateNewNode(value);
            }

            if (value < node.Value)
            {
                Node newNode = Insert(node.LeftChild, value);

                if (node.LeftChild == null)
                {
                    node.LeftChild = newNode;
                    newNode.Parent = node;
                    Rebalance(newNode);
                }
            }
            else
            {
                Node newNode = Insert(node.RightChild, value);

                if (node.RightChild == null)
                {
                    node.RightChild = newNode;
                    newNode.Parent = node;
                    Rebalance(newNode);
                }
            }

            return node;
        }

        private void Rebalance(Node node)
        {
            if (node == null) return;

            if (node == this.Root)
            {
                node.Color = Color.Black;
                return;
            }

            Node parent = node.Parent;
            Node grandParent = parent?.Parent;

            if (IsDoubleRed(node))
            {
                Node uncle = GetUncle(node);

                if (uncle == null || uncle.Color == Color.Black)
                {
                    // Rotations
                    Node newGrandParent = Rotations(node);
                    if (grandParent == Root)
                    {
                        this.Root = newGrandParent;
                    }

                    parent.Recolor();
                    grandParent.Recolor();

                    //if (grandParent.Value < grandParent.Parent?.Value)
                    //{
                    //    grandParent.Parent.LeftChild = newGrandParent;
                    //}
                    //else if (grandParent.Value < grandParent.Parent?.Value)
                    //{
                    //    grandParent.Parent.RightChild = newGrandParent;
                    //}

                    Rebalance(newGrandParent);
                }
                else
                {
                    // Recoloring
                    uncle.Recolor();
                    parent.Recolor();
                    grandParent.Recolor();

                    Rebalance(grandParent);
                }
            }
        }

        private Node Rotations(Node node)
        {
            Node parent = node.Parent;
            Node grandParent = parent?.Parent;

            Node newGrandParent = grandParent;

            if (node.Value > parent.Value && parent.Value > grandParent.Value)
            {
                newGrandParent = RedBlackTreeRotations.LeftRotation(grandParent);
            }

            return newGrandParent;
        }

        private Node GetUncle(Node node)
        {
            Node parent = node.Parent;
            Node grandParent = parent?.Parent;

            if (parent.Value < grandParent.Value)
            {
                return grandParent.RightChild;
            }

            return grandParent.LeftChild;
        }

        private Node CreateNewNode(int value)
        {
            return new Node()
            {
                Value = value,
                Color = Color.Red
            };
        }



        private bool IsDoubleRed(Node node)
        {
            return node.Color == Color.Red && node.Parent?.Color == Color.Red;
        }

    }
}
