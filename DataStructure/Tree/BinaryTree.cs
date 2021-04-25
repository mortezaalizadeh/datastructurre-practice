using System;

namespace DataStructure.Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root;

        public int Count
        {
            get
            {
                var count = 0;

                InOrderTraversal(_ => count++);

                return count;
            }
        }

        public void Add(T item)
        {
            if (_root == null)
                _root = new BinaryTreeNode<T>(item);
            else
                Add(item, _root);
        }

        public bool Contains(T item)
        {
            return Find(item, out _) != null;
        }

        public bool Remove(T item)
        {
            var foundNode = Find(item, out var parentNode);

            if (foundNode == null) return false;

            if (foundNode.Right == null)
            {
                if (parentNode == null)
                {
                    _root = foundNode.Left;
                }
                else
                {
                    var result = parentNode.Item.CompareTo(foundNode.Item);

                    switch (result)
                    {
                        case > 0:
                            parentNode.Left = foundNode.Left;
                            break;
                        case < 0:
                            parentNode.Right = foundNode.Left;
                            break;
                    }
                }
            }
            else if (foundNode.Right.Left == null)
            {
                if (parentNode == null)
                {
                    _root = foundNode.Right;
                }
                else
                {
                    var result = parentNode.Item.CompareTo(foundNode.Item);

                    switch (result)
                    {
                        case > 0:
                            parentNode.Left = foundNode.Right;
                            break;
                        case < 0:
                            parentNode.Right = foundNode.Right;
                            break;
                    }
                }
            }
            else
            {
                var leftMost = foundNode.Right.Left;
                var leftMostParent = foundNode.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = foundNode.Left;
                leftMost.Right = foundNode.Right;

                if (parentNode == null)
                {
                    _root = leftMost;
                }
                else
                {
                    var result = parentNode.Item.CompareTo(foundNode.Item);

                    switch (result)
                    {
                        case > 0:
                            parentNode.Left = leftMost;
                            break;
                        case < 0:
                            parentNode.Right = leftMost;
                            break;
                    }
                }
            }

            return true;
        }

        private static void Add(T item, BinaryTreeNode<T> node)
        {
            if (item.CompareTo(node.Item) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>(item);
                else
                    Add(item, node.Left);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode<T>(item);
                else
                    Add(item, node.Right);
            }
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _root);
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _root);
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _root);
        }

        private static void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            action(node.Item);
            PreOrderTraversal(action, node.Left);
            PreOrderTraversal(action, node.Right);
        }

        private static void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            InOrderTraversal(action, node.Left);
            action(node.Item);
            InOrderTraversal(action, node.Right);
        }

        private static void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PostOrderTraversal(action, node.Left);
            PostOrderTraversal(action, node.Right);
            action(node.Item);
        }

        private BinaryTreeNode<T> Find(T item, out BinaryTreeNode<T> parent)
        {
            var current = _root;
            parent = null;

            while (current != null)
            {
                var result = current.Item.CompareTo(item);

                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }
    }
}