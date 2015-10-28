using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace DoublyLinkedLists
{
    public class DoublyLinkedListNode<T> : IComparable where T : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<DoublyLinkedListNode<T>> allNodes = new List<DoublyLinkedListNode<T>>();

        private DoublyLinkedListNode<T> next;
        public DoublyLinkedListNode<T> Next
        {
            get { return next; }
            set
            {
                if (value == this)
                {
                    throw new ArgumentException();
                }
                next = value;
            }
        }
        private DoublyLinkedListNode<T> prev;
        public DoublyLinkedListNode<T> Previous
        {
            get { return prev; }
            set
            {
                if (value == this)
                {
                    throw new ArgumentException();
                }
                prev = value;
            }
        }
        private T value;
        public T Value 
        {
            get
            {
                return value;
            }
            set { this.value = value; }
        }

        public static bool operator <(DoublyLinkedListNode<T> node1, DoublyLinkedListNode<T> node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(DoublyLinkedListNode<T> node1, DoublyLinkedListNode<T> node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public DoublyLinkedListNode(T val)
        {
            value = val;
            next = null;
            prev = null;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) { return 1; }
            DoublyLinkedListNode<T> otherNode = obj as DoublyLinkedListNode<T>;
            if (otherNode != null)
                return Value.CompareTo(otherNode.Value);
            else
                throw new ArgumentException();
        }

        public bool IsLast()
        {
            if (Next == null)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is DoublyLinkedListNode<T>)
            {
                DoublyLinkedListNode<T> other = (DoublyLinkedListNode<T>)obj;
                return Equals(other.Value, this.Value);
            }
            return false;
        }
    }
}
