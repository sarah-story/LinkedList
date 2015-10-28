using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedLists;

namespace UnitTestSinglyLinkedLists
{
    // READ: http://msdn.microsoft.com/en-us/library/hh212233.aspx

    [TestClass]
    public class UnitTestSinglyLinkedListNode
    {
        [TestMethod]
        public void NodeConstructorStoresName()
        {
            SinglyLinkedListNode<string> node = new SinglyLinkedListNode<string>("foo");
            Assert.AreEqual("foo", node.Value);
        }

        [TestMethod]
        public void NodeDefaultNext()
        {
            SinglyLinkedListNode<string> node = new SinglyLinkedListNode<string>("foo");
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void NodeSetNext()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("bar");
            node1.Next = node2;
            Assert.AreEqual(node2, node1.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NodeNextCantBeThis()
        {
            SinglyLinkedListNode<string> node = new SinglyLinkedListNode<string>("foo");
            node.Next = node;
        }

        [TestMethod]
        public void NodeLastWhenLast()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("bar");
            node1.Next = node2;
            Assert.IsFalse(node1.IsLast()); 
        }

        [TestMethod]
        public void NodeLastWhenNotLast()
        {
            SinglyLinkedListNode<string> node = new SinglyLinkedListNode<string>("foo");
            Assert.IsTrue(node.IsLast());

        }

        // READ: http://msdn.microsoft.com/en-us/library/bsc2ak47.aspx
        [TestMethod]
        public void NodeEqualityWithEqualValues()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("foo");
            Assert.AreEqual(node1, node2); // Equivalent to: Assert.IsTrue(node1.Equals(node2));
        }

        [TestMethod]
        public void NodeEqualityWithString()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            Assert.AreNotEqual(node1, "foo");
        }

        [TestMethod]
        public void NodeEqualityWithNull()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            Assert.AreNotEqual(node1, null);
        }

        [TestMethod]
        public void NodeEqualityIgnoresNext()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            node1.Next = new SinglyLinkedListNode<string>("bob");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("foo");
            node2.Next = new SinglyLinkedListNode<string>("sally");
            Assert.AreEqual(node1, node2);
        }

        [TestMethod]
        public void NodeInequality()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("bar");
            Assert.AreNotEqual(node1, node2);
        }

        [TestMethod]
        public void NodeGreaterThan()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("bar");
            Assert.IsTrue(node1 > node2);
        }

        [TestMethod]
        public void NodeLesserThan()
        {
            SinglyLinkedListNode<string> node1 = new SinglyLinkedListNode<string>("foo");
            SinglyLinkedListNode<string> node2 = new SinglyLinkedListNode<string>("bar");
            Assert.IsTrue(node2 < node1);
        }

        [TestMethod]
        public void NodeToString()
        {
            SinglyLinkedListNode<string> node = new SinglyLinkedListNode<string>("foo");
            Assert.AreEqual("foo", node.ToString());
        }
    }
}