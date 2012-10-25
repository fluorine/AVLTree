using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree {
    class AVLTree<T>: IEnumerable<T> where T: IComparable<T> {
        Node<T> root = null;
        public List<int> HistoricalBalances = new List<int>();
        public List<T> HistoricalRoots = new List<T>();

        //Properties
        public int Count {
            get {
                if (root != null)
                    return root.Count;
                else
                    return 0;
            }
        }

        //Methods
        public void Add(T value) {
            var node = new Node<T>(value);
            if (root != null)
                root = root.Add(node);
            else
                root = node;

            //Historials
            HistoricalBalances.Add(root.Balance);
            HistoricalRoots.Add(root.Value);
        }

        //To string
        public override string ToString() {
            if (root != null) {
                var chain = new StringBuilder();
                root.ToText(chain);
                return chain.ToString();
            } else {
                return base.ToString();
            }
        }

        //Enumerator
        public IEnumerator<T> GetEnumerator() {
            if (root != null)
                foreach (var i in root)
                    yield return i.Value;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
