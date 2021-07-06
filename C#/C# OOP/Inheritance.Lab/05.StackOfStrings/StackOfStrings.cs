using System.Collections.Generic;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                base.Push(item);
            }
        }

    }
}
