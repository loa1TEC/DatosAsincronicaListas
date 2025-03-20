using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::DatosAsincronicaListas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ListTest
{
    [TestClass]
    public class CircularDoublyLinkedListTests
    {
        private CircularDoublyLinkedList list;

        [TestInitialize]
        public void Setup()
        {
            list = new CircularDoublyLinkedList();
        }

        [TestMethod]
        public void Test_InsertAtStart()
        {
            list.InsertAtStart(10);
            Assert.AreEqual("10", list.ToString());
            list.InsertAtStart(20);
            Assert.AreEqual("20, 10", list.ToString());
        }

        [TestMethod]
        public void Test_InsertAtEnd()
        {
            list.InsertAtEnd(10);
            Assert.AreEqual("10", list.ToString());
            list.InsertAtEnd(20);
            Assert.AreEqual("10, 20", list.ToString());
        }

        [TestMethod]
        public void Test_InsertAt()
        {
            list.InsertAtEnd(10);
            list.InsertAtEnd(30);
            list.InsertAt(20, 1);
            Assert.AreEqual("10, 20, 30", list.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_InsertAt_InvalidIndex()
        {
            list.InsertAt(10, 1);
        }

        [TestMethod]
        public void Test_RemoveAtStart()
        {
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.RemoveAtStart();
            Assert.AreEqual("20", list.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_RemoveAtStart_EmptyList()
        {
            list.RemoveAtStart();
        }

        [TestMethod]
        public void Test_RemoveAtEnd()
        {
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.RemoveAtEnd();
            Assert.AreEqual("10", list.ToString());
        }

        [TestMethod]
        public void Test_RemoveAt()
        {
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.InsertAtEnd(30);
            list.RemoveAt(1);
            Assert.AreEqual("10, 30", list.ToString());
        }

        [TestMethod]
        public void Test_Clear()
        {
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void Test_IsEmpty()
        {
            Assert.IsTrue(list.IsEmpty());
            list.InsertAtEnd(10);
            Assert.IsFalse(list.IsEmpty());
        }

        [TestMethod]
        public void Test_GetSize()
        {
            Assert.AreEqual(0, list.GetSize());
            list.InsertAtEnd(10);
            Assert.AreEqual(1, list.GetSize());
            list.InsertAtEnd(20);
            Assert.AreEqual(2, list.GetSize());
        }
    }

}
