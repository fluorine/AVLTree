using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree {
    class Node<T>: IEnumerable<Node<T>>, IComparable<Node<T>> where T: IComparable<T> {
        //Node's data and properties
        public T   Value   { set; get; }
        public int Count   { private set; get; }
        public int Depth   { private set; get; }

        public int Balance {
            get {
                int balance = 0;
                if (Right != null)
                    balance += Right.Depth;

                if (Left != null)
                    balance -= Left.Depth;
                return balance;
            }
        }

        //Internal method to refresh Counter and Depth.
        private void refreshProperties() {
            //Update counter
            Count = 1;
            if (Left != null)
                Count += Left.Count;

            if (Right != null)
                Count += Right.Count;

            //Subtree's highest depth
            Depth = 1;
            if (Left != null && Right != null) {
                if (Left.Depth > Right.Depth)
                    Depth = Left.Depth + 1;
                else
                    Depth = Right.Depth + 1;
            } else {
                if (Left != null)
                    Depth = Left.Depth + 1;

                if (Right != null)
                    Depth = Right.Depth + 1;
            }
        }

        //Links
        private Node<T> left = null;
        public Node<T> Left {
            set {
                left = value;
                refreshProperties();
            }
            get {
                return left;
            }
        }
        
        private Node<T> right = null;
        public Node<T> Right {
            set {
                right = value;
                refreshProperties();
            }
            get {
                return right;
            }
        }

        //Constructor
        public Node(T value) {
            Value = value;

            //Default properties
            Count = 1;
            Depth = 1;
        }

        //Methods
        public Node<T> Add(Node<T> node) {
            switch (this.CompareTo(node)) {
                case 1:
                    if (Left != null)
                        Left = Left.Add(node);
                    else
                        Left = node;
                    break;
                case -1:
                    if (Right != null)
                        Right = Right.Add(node);
                    else
                        Right = node;
                    break;
            }
            //Restore this node's balance
            return getBalanced(this);
        }

        //Static methods for tree's transformations
        private static Node<T> getBalanced(Node<T> node) {
            if (node.Balance > 1) {
                if (node.Right.Right == null)
                    node.Right = rotateRight(node.Right);

                return rotateLeft(node);
            }

            if (node.Balance < -1) {
                if (node.Left.Left == null)
                    node.Left = rotateLeft(node.Left);

                return rotateRight(node);
            }

            return node;
        }

        private static Node<T> rotateRight(Node<T> node) {
            if (node.Left != null) {
                var basis = node.Left;
                node.Left = basis.Right;
                basis.Right = node;
                return basis;
            }
            return node;
        }

        private static Node<T> rotateLeft(Node<T> node) {
            if (node.Right != null) {
                var basis = node.Right;
                node.Right = basis.Left;
                basis.Left = node;
                return basis;
            }
            return node;
        }

        //Comparer
        public int CompareTo(Node<T> other) {
            return Value.CompareTo(other.Value);
        }

        //Iterator
        public IEnumerator<Node<T>> GetEnumerator() {
            if (Left != null)
                foreach (var i in Left)
                    yield return i;

            yield return this;

            if (Right != null)
                foreach (var i in Right)
                    yield return i;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        //Textual representation
        public void ToText(StringBuilder chain, int depth = 1) {
            if (Left != null) {
                //chain.Append("(");
                Left.ToText(chain, depth + 2);
                //chain.Append(")");
            }

            chain.Append(' ', depth);
            chain.Append(Value);
            chain.Append('\n');

            if (Right != null) {
                //chain.Append("(");
                Right.ToText(chain, depth + 2);
                //chain.Append(")");
            }
        }
    }
}
