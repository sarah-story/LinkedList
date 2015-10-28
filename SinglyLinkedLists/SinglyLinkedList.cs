using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList<T> where T : IComparable
    {
        private SinglyLinkedListNode<T> first;
        private SinglyLinkedListNode<T> last;
        private int count;

        public SinglyLinkedList(params T[] values)
        {
            if (values.Length == 0)
            {
                first = null;
                last = null;
                count = 0;
            }
            else
            {
                SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(values[0]);
                first = node;
                for (int i = 1; i < values.Length; i++)
                {
                    node.Next = new SinglyLinkedListNode<T>(values[i]);
                    node = node.Next;   
                }
                last = node;
                count = values.Length;
            }
        }

        public T this[int i]
        {
            get { return ElementAt(i); }
            set
            {
                if (i >= count || i < 0) { throw new IndexOutOfRangeException(); }
                SinglyLinkedListNode<T> element = first;
                for (int j = 0; j < i; j++)
                {
                    element = element.Next;
                }
                element.Value = value;
            }
        }

        public void AddAfter(T existingValue, T value)
        {
            SinglyLinkedListNode<T> element = first;
            while (element != null)
            {
                if (existingValue.Equals(element.Value))
                {
                    SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);
                    newNode.Next = element.Next;
                    element.Next = newNode;
                    count++;
                    break;
                }
                else if (element.Next == null) { throw new ArgumentException(); }
                else { element = element.Next; }
            }
        }

        public void AddFirst(T value)
        {
            if (first != null)
            {
                SinglyLinkedListNode<T> placeholder = first;
                first = new SinglyLinkedListNode<T>(value);
                first.Next = placeholder;
            }
            else
            {
                first = new SinglyLinkedListNode<T>(value);
                last = first;
            }
            count++;
        }

        public void AddLast(T value)
        {
            if (last != null)
            {
                SinglyLinkedListNode<T> placeholder = last;
                last = new SinglyLinkedListNode<T>(value);
                placeholder.Next = last;
            }
            else
            {
                last = new SinglyLinkedListNode<T>(value);
                first = last;
            }
            count++;
        }

        public int Count()
        {
            return count;
        }

        public T ElementAt(int index)
        {
            SinglyLinkedListNode<T> element = first;
            if (index == 0)
            {
                if (first == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return first.Value;
                }
            }
            else if (index < 0)
            {
                if (count + index < 0) { throw new ArgumentOutOfRangeException(); }
                else
                {
                    for (int i = 0; i < count + index; i++)
                    {
                        element = element.Next;
                    }
                    if (element == null) { throw new ArgumentOutOfRangeException(); }
                    return element.Value;
                }
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    if (element.Next == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    element = element.Next;
                }
                if (element == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return element.Value;
                }
            }
        }

        public T First()
        {
            if (first == null) { return default(T); }
            return first.Value;
        }

        public int IndexOf(T value)
        {
            SinglyLinkedListNode<T> element = first;
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(value, element.Value))
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
            if (Count() == 0 || Count() == 1) { return true; }
            SinglyLinkedListNode<T> element = first;
            for (int i = 0; i < count - 1; i++)
            {
                if (element.Next < element) { return false; }
                element = element.Next;
            }
            return true;
        }

        public T Last()
        {
            if (last == null) { return default(T); }
            return last.Value;
        }

        public void Remove(T value)
        {
            if (EqualityComparer<T>.Default.Equals(first.Value, value))
            {
                first = first.Next;
                count--;
                return;
            }
            SinglyLinkedListNode<T> element = first;
            while (element.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(element.Next.Value,value))
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
                    break;
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
        }

        private SinglyLinkedListNode<T> MergeSort(SinglyLinkedListNode<T> head)
        {
            SinglyLinkedListNode<T> secondHalf;
            if (head == null || head.Next == null) { return head; }
            else
            {
                secondHalf = Split(head);
                return Merge(MergeSort(head), MergeSort(secondHalf));
            }
        }

        private SinglyLinkedListNode<T> Merge(SinglyLinkedListNode<T> a, SinglyLinkedListNode<T> b)
        {
           if (a == null) { last = b; return b; }
           else if (b == null) { last = a; return a; }
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

        private SinglyLinkedListNode<T> Split(SinglyLinkedListNode<T> head)
        {
            SinglyLinkedListNode<T> secondHalf;
            if (head == null || head.Next == null) { return null; }
            else
            {
                secondHalf = head.Next;
                head.Next = secondHalf.Next;
                secondHalf.Next = Split(secondHalf.Next);
                return secondHalf;
            }
        }

        public T[] ToArray()
        {
            List<T> array = new List<T>();
            SinglyLinkedListNode<T> element = first;
            while (element != null && element.Value != null)
            {
                array.Add(element.Value);
                element = element.Next;
            }
            return array.ToArray();
        }

        public override string ToString()
        {
            if (first == null) { return "{ }"; }
            string arrayString = String.Join("\", \"", this.ToArray());
            string output = String.Format("{{ \"{0}\" }}", arrayString);
            return output;
        }
    }
}
