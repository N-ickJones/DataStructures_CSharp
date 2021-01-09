using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Node<T>
    {
        public Node(T data, Node<T> left = null, Node<T> right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Data { get; set; }
    }
}
