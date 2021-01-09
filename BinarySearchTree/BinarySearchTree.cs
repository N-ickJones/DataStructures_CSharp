using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        private readonly IComparer<T> comparer;
        public Node<T> root;
        private readonly bool allowDuplicates;

        public BinarySearchTree(
            IComparer<T> _comparer = null,
            Node<T> _root = null,
            bool _allowDuplicates = false)
        {
            if (null == comparer)
                if (typeof(IComparable).IsAssignableFrom(typeof(T)) ||
                    typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                    comparer = Comparer<T>.Default;

            if (null == comparer)
                throw new ArgumentNullException("comparer", string.Format(
                    "There's no default comparer for {0} class, you should provide it explicitly.",
                    typeof(T).Name));

            comparer = _comparer;
            root = _root;
            allowDuplicates = _allowDuplicates;
        }

        public Node<T> AddRecursive(Node<T> parent, T value)
        {
            if (parent == null)
            {
                return new Node<T>(value);
            }

            if (LessThan(value, root.Data))
            {
                parent.Left = AddRecursive(parent.Left, value);
            }
            else if (GreaterThan(value, parent.Data))
            {
                parent.Right = AddRecursive(parent.Right, value);
            }

            return parent;
        }


        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (root == null)
            {
                root = newNode;
                return;
            }

            var currentNode = root;

            while (true)
            {
                if (LessThan(value, currentNode.Data))
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                }
                else if (GreaterThan(value, currentNode.Data))
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                }
                else
                {
                    if (allowDuplicates)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = newNode;
                            break;
                        }
                        else
                        {
                            newNode.Left = currentNode.Left;
                            newNode.Right = currentNode.Left.Right;
                            currentNode.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void Add(T[] array)
        {
            foreach (var value in array)
            {
                Add(value);
            }
        }

        public void Remove(T value)
        {
            root = RemoveRecursive(value, root);
        }
        public Node<T> RemoveIterative(T value, Node<T> parent)
        {
            return null;
        }

        public Node<T> RemoveRecursive(T value, Node<T> parent)
        {
            if (parent == null) return parent;

            if (LessThan(value, parent.Data))
            {
                parent.Left = RemoveRecursive(value, parent.Left);
            }
            else if (GreaterThan(value, parent.Data))
            {
                parent.Right = RemoveRecursive(value, parent.Right);
            }
            else
            {
                // 0-1 Children
                if (parent.Left == null)
                {
                    return parent.Right;
                }
                else if (parent.Right == null)
                {
                    return parent.Left;
                }

                // 2 Children - InOrderSuccessor & Delete
                parent.Data = MinValue(parent.Right);
                parent.Right = RemoveRecursive(parent.Data, parent.Right);
            }

            return parent;
        }

        public Node<T> Find(T value)
        {
            return FindIterative(value, root);
        }

        public Node<T> FindRecursive(T value, Node<T> parent)
        {
            if (parent != null)
            {
                if (LessThan(value, parent.Data))
                {
                    return FindRecursive(value, parent.Left);
                }
                else if (GreaterThan(value, parent.Data))
                {
                    return FindRecursive(value, parent.Right);
                }
                else
                {
                    return parent;
                }
            }
            return null;
        }

        public Node<T> FindIterative(T value, Node<T> parent)
        {
            while (true)
            {
                if (parent == null) break;

                if (LessThan(value, parent.Data))
                {
                    parent = parent.Left;
                }
                else if (GreaterThan(value, parent.Data))
                {
                    parent = parent.Right;
                }
                else
                {
                    return parent;
                }
            }
            return null;
        }

        public void TraversePreOrder()
        {
            TraversePreOrderRecursive(root);
        }

        public void TraverseInOrder()
        {
            TraverseInOrderRecursive(root);
        }

        public void TraversePostOrder()
        {
            TraversePostOrderRecursive(root);
        }

        public void TraversePreOrderIterative(Node<T> parent = null)
        {

        }

        public void TraversePreOrderRecursive(Node<T> parent = null)
        {
            if (parent != null)
            {
                VisitRoot(parent);
                TraversePreOrderRecursive(parent.Left);
                TraversePreOrderRecursive(parent.Right);
            }
        }

        public void TraverseInOrderIterative(Node<T> parent)
        {

        }

        public void TraverseInOrderRecursive(Node<T> parent)
        {
            if (parent != null)
            {
                TraverseInOrderRecursive(parent.Left);
                VisitRoot(parent);
                TraverseInOrderRecursive(parent.Right);
            }
        }

        public void TraversePostOrderIterative(Node<T> parent = null)
        {
            var s1 = new Stack();
            var s2 = new Stack();

            if (parent == null) return;

            s1.Push(parent);

            while (s1.Count > 0)
            {
                var current = (Node<T>)s1.Pop();
                s2.Push(current);

                if (current.Left != null)
                    s1.Push(current.Left);
                if (current.Right != null)
                    s1.Push(current.Right);
            }

            while (s2.Count > 0)
            {
                Console.WriteLine($"{((Node<T>)s2.Pop()).Data}");
            }
        }

        public void TraversePostOrderRecursive(Node<T> parent = null)
        {
            if (parent != null)
            {
                TraversePostOrderRecursive(parent.Left);
                TraversePostOrderRecursive(parent.Right);
                VisitRoot(parent);
            }
        }

        public int GetTreeDepth()
        {
            return GetTreeDepth(root);
        }

        private int GetTreeDepth(Node<T> parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.Left), GetTreeDepth(parent.Right)) + 1;
        }

        private T MinValue(Node<T> node)
        {
            T minValue = node.Data;

            while (node.Left != null)
            {
                minValue = node.Left.Data;
                node = node.Left;
            }

            return minValue;
        }

        private void VisitRoot(Node<T> root)
        {
            Console.WriteLine($" {root.Data} ");
        }

        private bool LessThan(T x, T y)
        {
            return comparer.Compare(x, y) < 0;
        }

        private bool GreaterThan(T x, T y)
        {
            return comparer.Compare(x, y) > 0;
        }

        private bool EqualTo(T x, T y)
        {
            return comparer.Compare(x, y) == 0;
        }
    }

}