using System;

namespace DatosAsincronicaListas
{
    class DoublyNode
    {
        public int value;
        public DoublyNode next;
        public DoublyNode prev;

        public DoublyNode(int value)
        {
            this.value = value;
            this.next = this.prev = null;
        }
    }

    public class CircularDoublyLinkedList
    {
        private DoublyNode tail;
        private int size;

        public CircularDoublyLinkedList()
        {
            this.tail = null;
            this.size = 0;
        }

        public void Clear()
        {
            this.tail = null;
            this.size = 0;
        }

        public bool IsEmpty() => this.size == 0;
        public int GetSize() => this.size;

        public void InsertAtStart(int element)
        {
            DoublyNode newNode = new DoublyNode(element);
            if (this.tail == null)
            {
                newNode.next = newNode;
                newNode.prev = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.tail.next;
                newNode.prev = this.tail;
                this.tail.next.prev = newNode;
                this.tail.next = newNode;
            }
            this.size++;
        }

        public void InsertAtEnd(int element)
        {
            InsertAtStart(element);
            this.tail = this.tail.next;
        }

        public void InsertAt(int element, int index)
        {
            if (index < 0 || index > this.size)
                throw new ArgumentOutOfRangeException("Index out of range");

            if (index == 0) { InsertAtStart(element); return; }
            if (index == this.size) { InsertAtEnd(element); return; }

            DoublyNode newNode = new DoublyNode(element);
            DoublyNode current = this.tail.next;
            for (int i = 0; i < index - 1; i++)
                current = current.next;

            newNode.next = current.next;
            newNode.prev = current;
            current.next.prev = newNode;
            current.next = newNode;
            this.size++;
        }

        public int RemoveAtStart()
        {
            if (this.tail == null)
                throw new Exception("Empty list");

            int value = this.tail.next.value;
            if (this.size == 1)
                this.tail = null;
            else
            {
                this.tail.next = this.tail.next.next;
                this.tail.next.prev = this.tail;
            }
            this.size--;
            return value;
        }

        public int RemoveAtEnd()
        {
            if (this.tail == null)
                throw new Exception("Empty list");

            int value = this.tail.value;
            if (this.size == 1)
                this.tail = null;
            else
            {
                this.tail.prev.next = this.tail.next;
                this.tail.next.prev = this.tail.prev;
                this.tail = this.tail.prev;
            }
            this.size--;
            return value;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.size)
                throw new ArgumentOutOfRangeException("Index out of range");

            if (index == 0) return RemoveAtStart();
            if (index == this.size - 1) return RemoveAtEnd();

            DoublyNode current = this.tail.next;
            for (int i = 0; i < index; i++)
                current = current.next;

            int value = current.value;
            current.prev.next = current.next;
            current.next.prev = current.prev;
            this.size--;
            return value;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "";

            DoublyNode current = this.tail.next;
            string result = "";
            do
            {
                result += current.value + ", ";
                current = current.next;
            } while (current != this.tail.next);

            return result.TrimEnd(',', ' ');
        }
    }
}
