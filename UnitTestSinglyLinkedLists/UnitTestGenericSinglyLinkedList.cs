using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedLists;

namespace UnitTestSinglyLinkedLists
{
    [TestClass]
    public class UnitTestGenericSinglyLinkedList
    {
        [TestMethod]
        public void InitializingWithInt()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>(new int[] { 1, 2, 3, 4 });
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void SortingWithInt()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>(new int[] { 4, 1, 3, 2 });
            list.Sort();
            int[] expected = { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }
        
        [TestMethod]
        public void ToStringWithInt()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>(new int[] { 1, 2, 3, 4 });
            string expected = "{ \"1\", \"2\", \"3\", \"4\" }";
            Assert.AreEqual(expected, list.ToString());
        }

        [TestMethod]
        public void NodeEqualityWithInt()
        {
            SinglyLinkedListNode<int> node1 = new SinglyLinkedListNode<int>(1);
            SinglyLinkedListNode<int> node2 = new SinglyLinkedListNode<int>(1);
            Assert.AreEqual(node1, node2);
        }

        [TestMethod]
        public void NodeInequalityWithInt()
        {
            SinglyLinkedListNode<int> node1 = new SinglyLinkedListNode<int>(1);
            SinglyLinkedListNode<int> node2 = new SinglyLinkedListNode<int>(2);
            Assert.AreNotEqual(node1, node2);
        }
    }
}
