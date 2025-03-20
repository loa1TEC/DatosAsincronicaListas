using System;

namespace DatosAsincronicaListas
{
    class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
    }

    public class CircularSinglyLinkedList
    {
        private Node tail;
        private int size;

        public CircularSinglyLinkedList()
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
            Node newNode = new Node(element);
            if (this.tail == null)
            {
                newNode.next = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.tail.next;
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
                throw new ArgumentOutOfRangeException("Invalid index");

            if (index == 0)
            {
                InsertAtStart(element);
            }
            else
            {
                Node newNode = new Node(element);
                Node current = this.tail.next;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                newNode.next = current.next;
                current.next = newNode;
                if (current == this.tail)
                    this.tail = newNode;
                this.size++;
            }
        }

        public void RemoveAtStart()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List is empty");

            if (this.size == 1)
            {
                this.tail = null;
            }
            else
            {
                this.tail.next = this.tail.next.next;
            }
            this.size--;
        }

        public void RemoveAtEnd()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List is empty");

            if (this.size == 1)
            {
                this.tail = null;
            }
            else
            {
                Node current = this.tail.next;
                while (current.next != this.tail)
                {
                    current = current.next;
                }
                current.next = this.tail.next;
                this.tail = current;
            }
            this.size--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.size)
                throw new ArgumentOutOfRangeException("Invalid index");

            if (index == 0)
            {
                RemoveAtStart();
            }
            else
            {
                Node current = this.tail.next;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                current.next = current.next.next;
                if (current.next == this.tail.next)
                    this.tail = current;
                this.size--;
            }
        }

        public override string ToString()
        {
            if (IsEmpty()) return "";

            Node current = this.tail.next;
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
