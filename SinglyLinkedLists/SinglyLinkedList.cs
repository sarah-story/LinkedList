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
        private int count;

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            if (values.Length == 0)
            {
                first = new SinglyLinkedListNode(null);
                last = new SinglyLinkedListNode(null);
                count = 0;
            }
            else
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode((string)values[0]);
                first = node;
                for (int i = 1; i < values.Length; i++)
                {
                    node.Next = new SinglyLinkedListNode((string)values[i]);
                    node = node.Next;   
                }
                last = node;
                count = values.Length;
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set
            {
                if (i >= count || i < 0) { throw new IndexOutOfRangeException(); }
                SinglyLinkedListNode element = first;
                for (int j = 0; j < i; j++)
                {
                    element = element.Next;
                }
                element.Value = value;
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode element = first;
            while (element != null)
            {
                if (element.Value == existingValue)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                    newNode.Next = element.Next;
                    element.Next = newNode;
                    count++;
                    break;
                }
                else if (element.Next == null) { throw new ArgumentException(); }
                else { element = element.Next; }
            }
        }

        public void AddFirst(string value)
        {
            if (first.Value != null)
            {
                SinglyLinkedListNode placeholder = first;
                first = new SinglyLinkedListNode(value);
                first.Next = placeholder;
            }
            else
            {
                first = new SinglyLinkedListNode(value);
                last = first;
            }
            count++;
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
            count++;
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return count;
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
            SinglyLinkedListNode element = first;
            for (int i = 0; i < count; i++)
            {
                if (element.Value == value)
                {
                    return i;
                }
                else
                {
                    element = element.Next;
                }
            }
            return -1;  
        }

        public bool IsSorted()
        {
            if (this.Count() == 0)
            {
                return true;
            }
            SinglyLinkedListNode element = first;
            for (int i = 0; i < count - 1; i++)
            {
                if (element.Next < element)
                {
                    return false;
                }
                element = element.Next;
            }
            return true;
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
            if (first.Value == value)
            {
                first = first.Next;
                count--;
                return;
            }
            SinglyLinkedListNode element = first;
            while (element.Next != null)
            {
                if (element.Next.Value == value)
                {
                    if (element.Next == last)
                    {
                        element.Next = null;
                        last = element;
                    }
                    else
                    {
                        element.Next = element.Next.Next;
                    }
                    count--;
                    return;
                }
                else
                {
                    element = element.Next;
                }
            }
        }

        public void Sort()
        {
            first = MergeSort(first);
            SinglyLinkedListNode element = first;
            for(int i = 0; i< count; i++)
            {
                if (element.IsLast())
                {
                    last = element;
                    return;
                }
                element = element.Next;
            }   
        }

        private SinglyLinkedListNode MergeSort(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode secondNode;
            if (head == null || head.Next == null) { return head; }
            else
            {
                secondNode = Split(head);
                return Merge(MergeSort(head), MergeSort(secondNode));
            }
        }

        private SinglyLinkedListNode Merge(SinglyLinkedListNode a, SinglyLinkedListNode b)
        {
           if (a == null) { return b; }
           else if (b == null) { return a; }
           else if (a.Value.CompareTo(b.Value) <= 0)
            {
                a.Next = Merge(a.Next, b);
                return a;
            }
           else
            {
                b.Next = Merge(b.Next, a);
                return b;
            }
        } 

        private SinglyLinkedListNode Split(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode placeholder;
            if (head == null || head.Next == null) { return null; }
            else
            {
                placeholder = head.Next;
                head.Next = placeholder.Next;
                placeholder.Next = Split(placeholder.Next);
                return placeholder;
            }
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
