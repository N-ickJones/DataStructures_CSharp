namespace DataStructures
{
    interface IBinarySearchTree<T>
    {
        void Add(T value);
        void Add(T[] array);

        void Remove(T value);
        Node<T> RemoveRecursive(T value, Node<T> parent);
        Node<T> RemoveIterative(T value, Node<T> parent);

        Node<T> Find(T value);
        Node<T> FindRecursive(T value, Node<T> parent);
        Node<T> FindIterative(T value, Node<T> parent);

        void TraversePreOrder();
        void TraverseInOrder();
        void TraversePostOrder();

        void TraversePreOrderIterative(Node<T> parent);
        void TraversePreOrderRecursive(Node<T> parent);
        void TraverseInOrderIterative(Node<T> parent);
        void TraverseInOrderRecursive(Node<T> parent);
        void TraversePostOrderIterative(Node<T> parent);
        void TraversePostOrderRecursive(Node<T> parent);

        int GetTreeDepth();
    }
}