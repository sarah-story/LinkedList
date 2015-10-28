using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedLists;

namespace UnitTestDoublyLinkedLists
{
    // READ: http://msdn.microsoft.com/en-us/library/hh212233.aspx

    [TestClass]
    public class UnitTestDoublyLinkedListNode
    {
        [TestMethod]
        public void NodeConstructorStoresName()
        {
            DoublyLinkedListNode<string> node = new DoublyLinkedListNode<string>("foo");
            Assert.AreEqual("foo", node.Value);
        }

        [TestMethod]
        public void NodeDefaultNext()
        {
            DoublyLinkedListNode<string> node = new DoublyLinkedListNode<string>("foo");
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void NodeSetNext()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("bar");
            node1.Next = node2;
            Assert.AreEqual(node2, node1.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NodeNextCantBeThis()
        {
            DoublyLinkedListNode<string> node = new DoublyLinkedListNode<string>("foo");
            node.Next = node;
        }

        [TestMethod]
        public void NodeLastWhenLast()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("bar");
            node1.Next = node2;
            Assert.IsFalse(node1.IsLast()); 
        }

        [TestMethod]
        public void NodeLastWhenNotLast()
        {
            DoublyLinkedListNode<string> node = new DoublyLinkedListNode<string>("foo");
            Assert.IsTrue(node.IsLast());

        }

        // READ: http://msdn.microsoft.com/en-us/library/bsc2ak47.aspx
        [TestMethod]
        public void NodeEqualityWithEqualValues()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("foo");
            Assert.AreEqual(node1, node2); // Equivalent to: Assert.IsTrue(node1.Equals(node2));
        }

        [TestMethod]
        public void NodeEqualityWithString()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            Assert.AreNotEqual(node1, "foo");
        }

        [TestMethod]
        public void NodeEqualityWithNull()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            Assert.AreNotEqual(node1, null);
        }

        [TestMethod]
        public void NodeEqualityIgnoresNext()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            node1.Next = new DoublyLinkedListNode<string>("bob");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("foo");
            node2.Next = new DoublyLinkedListNode<string>("sally");
            Assert.AreEqual(node1, node2);
        }

        [TestMethod]
        public void NodeInequality()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("bar");
            Assert.AreNotEqual(node1, node2);
        }

        [TestMethod]
        public void NodeGreaterThan()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("bar");
            Assert.IsTrue(node1 > node2);
        }

        [TestMethod]
        public void NodeLesserThan()
        {
            DoublyLinkedListNode<string> node1 = new DoublyLinkedListNode<string>("foo");
            DoublyLinkedListNode<string> node2 = new DoublyLinkedListNode<string>("bar");
            Assert.IsTrue(node2 < node1);
        }

        [TestMethod]
        public void NodeToString()
        {
            DoublyLinkedListNode<string> node = new DoublyLinkedListNode<string>("foo");
            Assert.AreEqual("foo", node.ToString());
        }
    }
}