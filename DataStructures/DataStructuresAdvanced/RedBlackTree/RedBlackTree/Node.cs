using System;

namespace RedBlackTree
{
    public class Node
    {
        public int Value { get; set; }

        public Color Color { get; set; }


        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node Parent { get; set; }

        public void Recolor()
        {
            Color = (Color)((int)Color * -1);
        }

        public override string ToString()
        {
            if (Color == Color.Black)
            {
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (Color == Color.Red)
            {
                //Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }

            return $"{this.Value}; Color:{this.Color}; Parent:{this.Parent}";
        }

    }

    public enum Color
    {
        Red = 1,
        Black = -1
    }
}
