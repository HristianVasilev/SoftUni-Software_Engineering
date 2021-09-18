namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T key)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(key);
                return;
            }

            this.root = Insert(this.root, key);
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }



        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }

        private TreeNode<T> Insert(TreeNode<T> node, T newNodeValue)
        {
            if (node.IsLeaf())
            {
                // TODO: Merge key into the node
                return this.InsertNewElement(node, new TreeNode<T>(newNodeValue));
            }

            TreeNode<T> returnedNode;

            if (newNodeValue.CompareTo(node.LeftKey) < 0)
            {
                //  Implement going left in the existing tree
                returnedNode = Insert(node.LeftChild, newNodeValue);
                if (returnedNode == node.LeftChild)
                {
                    return node;
                }

                return this.InsertNewElement(node, returnedNode);
            }
            else if (node.IsTwoNode() || newNodeValue.CompareTo(node.RightKey) < 0)
            {
                //  Implement going middle
                returnedNode = Insert(node.MiddleChild, newNodeValue);
                if (returnedNode == node.MiddleChild)
                {
                    return node;
                }

                return this.InsertNewElement(node, returnedNode);
            }
            else
            {
                //  Implement going right
                returnedNode = Insert(node.RightChild, newNodeValue);
                if (returnedNode == node.RightChild)
                {
                    return node;
                }

                return this.InsertNewElement(node, returnedNode);
            }
        }

        private TreeNode<T> InsertNewElement(TreeNode<T> currentNode, TreeNode<T> newNode)
        {
            if (currentNode.IsTwoNode())
            {
                if (currentNode.LeftKey.CompareTo(newNode.LeftKey) < 0)
                {
                    currentNode.RightKey = newNode.LeftKey;
                    currentNode.MiddleChild = newNode.LeftChild;
                    currentNode.RightChild = newNode.MiddleChild;
                }
                else
                {
                    currentNode.RightKey = currentNode.LeftKey;
                    currentNode.LeftKey = newNode.LeftKey;

                    currentNode.RightChild = currentNode.MiddleChild;
                    currentNode.MiddleChild = newNode.MiddleChild;
                }

                return currentNode;
            }
            else if (currentNode.LeftKey.CompareTo(newNode.LeftKey) >= 0)
            {
                TreeNode<T> resultNode = new TreeNode<T>(currentNode.LeftKey)
                {
                    LeftChild = newNode,
                    MiddleChild = currentNode
                };

                newNode.LeftChild = currentNode.LeftChild;
                currentNode.LeftChild = currentNode.MiddleChild;
                currentNode.RightChild = null;

                currentNode.LeftKey = currentNode.RightKey;
                currentNode.RightKey = default;

                return resultNode;
            }
            else if (currentNode.RightKey.CompareTo(newNode.LeftKey) >= 0)
            {
                // TODO: Insert node into the middle
                newNode.MiddleChild = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = newNode.MiddleChild,
                    MiddleChild = currentNode.RightChild
                };

                newNode.LeftChild = currentNode;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newNode;
            }
            else
            {
                // TODO: Insert node into the right
                TreeNode<T> resultNode = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = currentNode,
                    MiddleChild = newNode
                };

                newNode.LeftChild = currentNode.RightChild;
                currentNode.RightChild = null;
                currentNode.RightKey = default;

                return resultNode;
            }
        }
    }
}
