using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkedLists;

namespace UnitTestDoublyLinkedLists
{
    [TestClass]
    public class UnitTestDoublyLinkedList
    {
        [TestMethod]
        public void FirstOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            Assert.AreEqual(null, list.First());
        }

        [TestMethod]
        public void FirstOnShortList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            Assert.AreEqual("foo", list.First());
        }

        [TestMethod]
        public void FirstOnLongerList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            Assert.AreEqual("foo", list.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElementAt0OnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.ElementAt(0);
        }

        [TestMethod]
        public void ElementAt0()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            Assert.AreEqual("foo", list.ElementAt(0));
        }

        [TestMethod]
        public void ElementAt1()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("bar", list.ElementAt(1));
        }

        [TestMethod]
        public void ElementAtEndOfList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("grille", list.ElementAt(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElementAtN()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("bar");
            list.AddLast("grille");
            list.ElementAt(5);
        }

        // CHALLENGE: Implementing negative indices, such that -1 would return "grille" and -2 would return "bar". Write tests first!
        [TestMethod]
        public void ElementAtNegativeIndex()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("foo", list.ElementAt(-3));
        }
        
        [TestMethod]
        public void LastOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            Assert.AreEqual(null, list.Last());
        }

        [TestMethod]
        public void LastOnShortList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            Assert.AreEqual("foo", list.Last());
        }

        [TestMethod]
        public void LastOnLongerList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("grille", list.Last());
        }

        [TestMethod]
        public void ToStringOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            Assert.AreEqual("{ }", list.ToString());
        }

        [TestMethod]
        public void ToStringOnSingleItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            Assert.AreEqual("{ \"foo\" }", list.ToString());
        }

        [TestMethod]
        public void ToStringOnMultipleItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("{ \"foo\", \"bar\", \"grille\" }", list.ToString());
        }

        [TestMethod]
        public void ToArrayOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            string[] expected = new string[] { };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ToArrayOnSingleItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            string[] expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ToArrayOnMultipleItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            string[] expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }
        
        [TestMethod]
        public void AddFirstOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddFirst("foo");
            string[] expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void AddFirstOnLongerList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddFirst("grille");
            var expected = new string[] { "grille", "foo", "bar" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddAfterItemThatDoesntExist()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddAfter("cat", "grille");
        }

        [TestMethod]
        public void AddAfter()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("grille");
            // NOTE: This assert isn't necessary.  It is merely here to remind you of / verify the state of the list prior to inserting the new node.
            var expected = new string[] { "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());

            list.AddAfter("foo", "bar");
            expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void AddAfterLastItem()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddAfter("bar", "grille");
            var expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ConstructorWithOneArgument()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo");
            var expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ConstructorWithMultipleArguments()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            var expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListBracketAccessor()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            Assert.AreEqual("bar", list[1]);
        }

        [TestMethod]
        public void ListBracketAssignmentSetsItem()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list[2] = "cat";
            Assert.AreEqual("cat", list[2]);
        }

        [TestMethod]
        public void ListBracketAssignmentPreservesRestOfList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list[2] = "cat";
            var expected = new string[] { "foo", "bar", "cat" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveFirstNode()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list.Remove("foo");
            var expected = new string[] { "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveItemFromMiddleOfList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list.Remove("bar");
            var expected = new string[] { "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveLastItemFromList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list.Remove("grille");
            var expected = new string[] { "foo", "bar" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveNonExistentNode()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list.Remove("cat");
            var expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveWithDuplicateNodes()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille", "bar");
            list.Remove("bar");
            var expected = new string[] { "foo", "grille", "bar" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void CountEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void CountOneItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            Assert.AreEqual(1, list.Count());
        }
        
        [TestMethod]
        public void CountNItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            list.AddLast("baz");
            Assert.AreEqual(4, list.Count());
        }

        [TestMethod]
        public void CountChangesOnRemoval()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            list.Remove("foo");
            Assert.AreEqual(2, list.Count());
            list.Remove("bar");
            Assert.AreEqual(1, list.Count());
            list.Remove("grille");
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void IndexOfNodeInFirstPosition()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            Assert.AreEqual(0, list.IndexOf("foo"));
        }
        
        [TestMethod]
        public void IndexOfNodeInMiddlePosition()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            Assert.AreEqual(1, list.IndexOf("bar"));
        }

        [TestMethod]
        public void IndexOfNodeInLastPosition()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            Assert.AreEqual(2, list.IndexOf("grille"));
        }

        [TestMethod]
        public void IndexOfStringThatDoesntExist()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille");
            Assert.AreEqual(-1, list.IndexOf("cat"));
        }

        [TestMethod]
        public void IndexOfDuplicateNode()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "bar", "grille");
            Assert.AreEqual(1, list.IndexOf("bar"));
        }

        [TestMethod]
        public void IndexOfOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            Assert.AreEqual(-1, list.IndexOf("bar"));
        }

        [TestMethod]
        public void IsSortedOnEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnSingleItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo");
            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnListOfDuplicates()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "foo");
            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnUnsortedList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar");
            Assert.IsFalse(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnSortedList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("bar", "foo");
            Assert.IsTrue(list.IsSorted());
        }

        // This test is primarily to ensure that attempting to sort an empty list doesn't throw any exceptions
        [TestMethod]
        public void SortEmptyList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            list.Sort();
            var expected = new string[] { };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortSingleItemList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo");
            list.Sort();
            var expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortUnsortedList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar");
            list.Sort();
            var expected = new string[] { "bar", "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortSortedList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("bar", "cat", "foo", "grille");
            list.Sort();
            var expected = new string[] { "bar", "cat", "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortLongerList()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille", "zoo", "cat");
            list.Sort();
            var expected = new string[] { "bar", "cat", "foo", "grille", "zoo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortThenGetLast()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille", "zoo", "cat");
            list.Sort();
            Assert.AreEqual("zoo", list.Last());
        }

        [TestMethod]
        public void SortListWithDuplicates()
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>("foo", "bar", "grille", "bar");
            list.Sort();
            var expected = new string[] { "bar", "bar", "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }
    }
}
