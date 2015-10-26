using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode first;
        private SinglyLinkedListNode last;

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            if (values.Length == 0)
            {
                first = new SinglyLinkedListNode(null);
                last = new SinglyLinkedListNode(null);
            }
            else
            {
                first = new SinglyLinkedListNode((string)values[0]);
                last = new SinglyLinkedListNode((string)values[values.Length - 1]);
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if (last.Value != null)
            {
                SinglyLinkedListNode placeholder = last;
                last = new SinglyLinkedListNode(value);
                placeholder.Next = last;
            }
            else
            {
                last = new SinglyLinkedListNode(value);
                first = last;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            if (index == 0)
            {
                if (first.Value == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return first.Value;
                }
            }
            SinglyLinkedListNode element = first;
            for (int i = 0; i < index; i++)
            {
                if (element.Next == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                element = element.Next;
            }
            if (element.Value == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return element.Value;
            }
        }

        public string First()
        {
            return first.Value;
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            return last.Value;
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            List<string> array = new List<string>();
            SinglyLinkedListNode element = first;
            while (element != null && element.Value != null)
            {
                array.Add(element.Value);
                element = element.Next;
            }
            return array.ToArray();
        }

        public override string ToString()
        {
            if (first.Value == null) { return "{ }"; }
            string arrayString = String.Join("\", \"", this.ToArray());
            string output = String.Format("{{ \"{0}\" }}", arrayString);
            return output;
        }
    }
}
