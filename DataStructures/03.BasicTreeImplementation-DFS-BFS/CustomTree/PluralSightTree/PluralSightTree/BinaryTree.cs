using System;
using System.Collections;
using System.Collections.Generic;

namespace PluralSightTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; set; }

        public void Add(T value)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(value);
            }
            else
            {
                this.AddTo(this.root, value);
            }

            this.Count++;
        }

        public bool Remove(T value)
        {
            Node<T> current;
            Node<T> parent;

            current = this.FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            this.Count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    this.root = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    this.root = current.Right;
                }
                else
                {
                    int reuslt = parent.CompareTo(current.Value);
                    if (reuslt > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (reuslt < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                var leftMostParent = current.Right;

                while (leftMostParent.Left != null)
                {
                    leftMostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftMostParent.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    this.root = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }

        public bool Contains(T value)
        {
            Node<T> parent;

            return this.FindWithParent(value, out parent) != null;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            this.PreOrderTraversal(action, this.root);
        }

        private void PreOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                this.PreOrderTraversal(action, node.Left);
                this.PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            this.PostOrderTraversal(action, this.root);
        }

        private void PostOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                this.PostOrderTraversal(action, node.Left);
                this.PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            this.InOrderTraversal(action, this.root);
        }

        private void InOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                this.InOrderTraversal(action, node.Left);
                action(node.Value);
                this.InOrderTraversal(action, node.Right);
            }
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}

        public void Clear()
        {
            this.root = null;
            this.Count = 0;
        }

        private void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    this.AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    this.AddTo(node.Right, value);
                }
            }
        }

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            var current = this.root;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);

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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
