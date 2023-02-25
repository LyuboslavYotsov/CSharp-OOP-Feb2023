

using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddRange(List<string> strings)
        {
            foreach (var item in strings)
            {
                this.Push(item);
            }
        }
    }
}
