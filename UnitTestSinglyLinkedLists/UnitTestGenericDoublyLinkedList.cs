using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedLists;

namespace UnitTestDoublyLinkedLists
{
    [TestClass]
    public class UnitTestGenericDoublyLinkedList
    {
        [TestMethod]
        public void InitializingWithInt()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new int[] { 1, 2, 3, 4 });
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void SortingWithInt()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new int[] { 4, 1, 3, 2 });
            list.Sort();
            int[] expected = { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }
        
        [TestMethod]
        public void ToStringWithInt()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new int[] { 1, 2, 3, 4 });
            string expected = "{ \"1\", \"2\", \"3\", \"4\" }";
            Assert.AreEqual(expected, list.ToString());
        }

        [TestMethod]
        public void NodeEqualityWithInt()
        {
            DoublyLinkedListNode<int> node1 = new DoublyLinkedListNode<int>(1);
            DoublyLinkedListNode<int> node2 = new DoublyLinkedListNode<int>(1);
            Assert.AreEqual(node1, node2);
        }

        [TestMethod]
        public void NodeInequalityWithInt()
        {
            DoublyLinkedListNode<int> node1 = new DoublyLinkedListNode<int>(1);
            DoublyLinkedListNode<int> node2 = new DoublyLinkedListNode<int>(2);
            Assert.AreNotEqual(node1, node2);
        }
    }
}
