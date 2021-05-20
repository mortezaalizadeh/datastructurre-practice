using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Tree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root;

        public BinaryTree()
        {
        }

        public BinaryTree(IEnumerable<T> items)
        {
            foreach (var item in items) Add(item);
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (_root == null)
                _root = new BinaryTreeNode<T>(item);
            else
                Add(item, _root);

            Count++;
        }

        public bool Contains(T item)
        {
            return Contains(item, _root);
        }

        private static bool Contains(T item, BinaryTreeNode<T> node)
        {
            if (node == null)
                return false;

            var result = item.CompareTo(node.Value);

            return result == 0 || Contains(item, result <= 0 ? node.Left : node.Right);
        }

        public void AddNonRecursive(T item)
        {
            if (_root == null)
                _root = new BinaryTreeNode<T>(item);
            else
                AddNonRecursive(item, _root);

            Count++;
        }

        private static void Add(T item, BinaryTreeNode<T> node)
        {
            if (item.CompareTo(node.Value) <= 0)
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

        private static void AddNonRecursive(T item, BinaryTreeNode<T> node)
        {
            while (true)
            {
                if (item.CompareTo(node.Value) <= 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTreeNode<T>(item);
                    }
                    else
                    {
                        node = node.Left;
                        continue;
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<T>(item);
                    }
                    else
                    {
                        node = node.Right;
                        continue;
                    }
                }

                break;
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

        public IEnumerable<T> PreOrderTraversal()
        {
            var items = new List<T>();

            PreOrderTraversal(items.Add, _root);

            return items;
        }

        public IEnumerable<T> InOrderTraversal()
        {
            var items = new List<T>();

            InOrderTraversal(items.Add, _root);

            return items;
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            var items = new List<T>();

            PostOrderTraversal(items.Add, _root);

            return items;
        }

        private static void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            action(node.Value);
            PreOrderTraversal(action, node.Left);
            PreOrderTraversal(action, node.Right);
        }

        private static void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            InOrderTraversal(action, node.Left);
            action(node.Value);
            InOrderTraversal(action, node.Right);
        }

        private static void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PostOrderTraversal(action, node.Left);
            PostOrderTraversal(action, node.Right);
            action(node.Value);
        }
    }
}