using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList
{
    public class LinkedSum
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var sum = 0;
            var current = new ListNode(0);
            var result = current;

            while (l1 != null || l2 != null)
            {

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                current.next = new ListNode(sum % 10);

                current = current.next;

                sum = sum > 9 ? 1 : 0;
            }

            if (sum != 0)
            {
                current.next = new ListNode(sum);
            }

            return result.next;
        }

        public void PrintList(ListNode l1)
        {
            while(l1 != null)
            {
                Console.WriteLine(l1.val);
                l1 = l1.next;
            }
        }
    }

    

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
