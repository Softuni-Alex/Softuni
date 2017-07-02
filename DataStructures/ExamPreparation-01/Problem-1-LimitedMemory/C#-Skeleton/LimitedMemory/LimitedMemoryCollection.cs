using System.Collections;
using System.Collections.Generic;

namespace LimitedMemory
{
    public class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
    {
        private LinkedList<Pair<K, V>> priority;
        private Dictionary<K, LinkedListNode<Pair<K, V>>> elements;

        public LimitedMemoryCollection(int capacity)
        {
            this.Capacity = capacity;
            this.priority = new LinkedList<Pair<K, V>>();
            this.elements = new Dictionary<K, LinkedListNode<Pair<K, V>>>();
        }

        public int Capacity { get; private set; }

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Set(K key, V value)
        {
            if (!this.elements.ContainsKey(key))
            {
                if (this.Count >= this.Capacity)
                {
                    this.RemoveOldestElement();
                }

                this.AddElement(key, value);
            }
            else
            {
                var node = this.elements[key];

                this.priority.Remove(node);
                node.Value.Value = value;
                this.priority.AddFirst(node);
            }
        }

        public V Get(K key)
        {
            if (!this.elements.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            var node = this.elements[key];

            this.priority.Remove(node);
            this.priority.AddFirst(node);

            return node.Value.Value;
        }

        public IEnumerator<Pair<K, V>> GetEnumerator()
        {
            foreach (var node in this.priority)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void AddElement(K key, V value)
        {
            var node = new LinkedListNode<Pair<K, V>>(new Pair<K, V>(key, value));

            this.elements.Add(key, node);
            this.priority.AddFirst(node);
        }

        private void RemoveOldestElement()
        {
            var node = this.priority.Last;

            this.elements.Remove(node.Value.Key);
            this.priority.RemoveLast();
        }
    }
}
