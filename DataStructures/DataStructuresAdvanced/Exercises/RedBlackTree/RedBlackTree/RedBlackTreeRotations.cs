namespace RedBlackTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class RedBlackTreeRotations
    {
        public static Node LeftRotation(Node node)
        {
            Node newNode = node.RightChild;

            if (newNode.LeftChild != null)
            {
                newNode.LeftChild.Parent = node;
            }

            node.RightChild = newNode.LeftChild;
            newNode.Parent = node.Parent;

            newNode.LeftChild = node;
            node.Parent = newNode;

            return newNode;
        }

        public static Node RightRotation(Node node)
        {
            Node newNode = node.LeftChild;
            newNode.Parent = node.Parent;

            if (newNode.RightChild != null)
            {
                newNode.RightChild.Parent = node;
            }

            node.LeftChild = newNode.RightChild;

            node.Parent = newNode;
            newNode.RightChild = node;

            return newNode;
        }


        public static Node LeftRightRotation(Node node)
        {
            // 1. Left rotation of left child.
            // 2. Right rotation of right child.
            node.LeftChild = LeftRotation(node.LeftChild);
            return RightRotation(node);
        }

        public static Node RightLeftRotation(Node node)
        {
            // 1. Right rotation of right child.
            // 2. Left rotation of left child.
            node.RightChild = RightRotation(node.RightChild);
            return LeftRotation(node);
        }

    }
}
