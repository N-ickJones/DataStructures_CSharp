using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList
{
    public class LinkNode
    {
        public LinkNode()
        {

        }

        public void Run()
        {
            var values = new int[] { 3, 5, 6, 7, 2, 3, 4 };

            ListNode root;

            root = CreateList(values);
            PrintList(root);

            root = ReverseList(root);
            PrintList(root);

            root = DeleteNode(root, 7);
            PrintList(root);

            root = InsertNode(root, 8);
            PrintList(root);

        }

        //O(n)
        public ListNode ReverseList(ListNode root)
        {
            var current = root;
            ListNode next;
            ListNode prev = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        //O(n)
        public ListNode InsertNode(ListNode root, int value)
        {
            var current = root;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new ListNode(value);

            return root;
        }

        //O(1) to O(n)
        public ListNode DeleteNode(ListNode root, int target)
        {
            var current = root;
            ListNode prev = null;

            if (root != null && root.Value == target)
            {
                return root.Next;
            }

            while (current != null && current.Value != target)
            {
                prev = current;
                current = current.Next;
            }

            //Not Found
            if (current == null)
            {
                return root;
            }

            //Remove Node
            prev.Next = current.Next;

            return root;
        }

        //O(n)
        public ListNode CreateList(int[] values)
        {
            var root = new ListNode(values[0]);
            var current = root;

            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new ListNode(values[i]);
                current = current.Next;
            }

            return root;
        }

        public void PrintList(ListNode root)
        {
            var current = root;
            var printString = "Values: ";

            while (current != null)
            {
                printString += $"{current.Value} ";
                current = current.Next;
            }

            Console.WriteLine(printString);
        }

        public class ListNode
        {
            public ListNode(int value = 0, ListNode next = null)
            {
                Value = value;
                Next = next;
            }
            public int Value { get; set; }
            public ListNode Next { get; set; }
        }

    }
}
