using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class Queue<T>: IEnumerable<T>, ICloneable, IEquatable<T>
    {
        #region fields
        /// <summary>
        /// fields
        /// </summary>
        private T[] store;
        private int count;
        #endregion
        #region property
        /// <summary>
        /// property
        /// </summary>
        public int Count => count;
        #endregion
        #region c-or
        /// <summary>
        /// c-or without param
        /// </summary>
        public Queue()
        {
            store = new T[20];
            count = 0;
        }
        /// <summary>
        /// c-or with param
        /// </summary>
        /// <param name="size">size</param>
        public Queue(int size)
        {
            if (size <= 0) throw new ArgumentException("Size should be more than zero!");
            store = new T[size];
        }
        /// <summary>
        /// c-or
        /// </summary>
        /// <param name="queue">queue</param>
        public Queue(IEnumerable<T> queue)
        {
            Queue qu = queue as Queue;
            if (qu == null) throw new ArgumentNullException($"{nameof(qu)} is null!");
            foreach (T element in queue)
                Enqueue(element);
        }
        #endregion
        /// <summary>
        /// checking of contains el.
        /// </summary>
        /// <param name="agr">element for finding</param>
        /// <returns>true or false</returns>
        public bool Contains(T agr)
        {
            for (int i = 0; i < Count; i++)
                if (agr.Equals(store[i])) return true;
            return false;
        }
        /// <summary>
        /// clearing of queue
        /// </summary>
        public void Clear()
        {
            store = default(T[]);
            count = 0;
        }
        /// <summary>
        /// adding element
        /// </summary>
        /// <param name="element">element</param>
        public void Enqueue(T element)
        {
            if (Contains(element)) throw new ArgumentException("there are already exist this element!");
            if (count == store.Length) Resize();
            store[count++] = element;
        }
        /// <summary>
        /// removing element
        /// </summary>
        public void Dequeue()
        {
            if (Count == 0) throw new Exception("Queue is empty!");
            for (int i = 0; i < store.Length - 1; i++)
            {
                store[i] = store[i + 1];
            }
            store[store.Length - 1] = default(T);
            count--;
        }
        /// <summary>
        /// Method returns first element
        /// </summary>
        /// <returns>first element</returns>
        public T Peek()
        {
            if (Count == 0) throw new Exception("Queue is empty!");
            return store[0];
        }
        #region overloperators
        /// <summary>
        /// equlity
        /// </summary>
        /// <param name="lhs">first queue</param>
        /// <param name="rhs">second queue</param>
        /// <returns>true or false</returns>
        public static bool operator==(Queue<T> lhs, Queue<T> rhs)
        {
            if (lhs.Equals(rhs)) return true;
            return false;
        }
        /// <summary>
        /// equlity
        /// </summary>
        /// <param name="lhs">first queue</param>
        /// <param name="rhs">second queue</param>
        /// <returns>true or false</returns>
        public static bool operator!=(Queue<T> lhs, Queue<T> rhs)
        {
            if (lhs.Equals(rhs)) return false;
            return true;
        }
        #endregion
        /// <summary>
        /// Cloning
        /// </summary>
        /// <returns>new equals object</returns>
        public Queue<T> Clone()
        {
            return new Queue<T>(this);
        }
        /// <summary>
        /// return iterator
        /// </summary>
        /// <returns>Iterator</returns>
        public IEnumerator<T> GetEnumerator() => new Iterator(this);
        /// <summary>
        /// return iterator
        /// </summary>
        /// <returns>Iterator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new Iterator(this);
        /// <summary>
        /// convert to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < store.Length; i++)
                str.Append(store[i].ToString());
            return str.ToString();
        }
        /// <summary>
        /// checking on equals
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            Queue queue = obj as Queue;
            if (queue == null) throw new ArgumentException();
            if (this.Count != queue.Count) return false;
            for (int i = 0; i < queue.Count; i++)
            {
                if (this.ToString() == queue.ToString()) return true;
            }
            return false;
        }
        /// <summary>
        /// struct for iteration on queue.
        /// </summary>
        private struct Iterator:IEnumerator<T>
        {
            private Queue<T> queue;
            private int index;
            public Iterator(Queue<T> queue)
            {
                index = -1;
                this.queue = queue;
            }
            public T Current
            {
                get
                {
                    if (index == -1 || index == queue.Count) throw new ArgumentException();
                    return queue.store[index];
                }
            }
            object IEnumerator.Current => Current;
            public bool MoveNext() => index++ < queue.Count;
            public void Reset() { index = -1; }
            public void Dispose() { }
        }
        /// <summary>
        /// resizing
        /// </summary>
        private void Resize()
        {
            T[] arr = new T[store.Length + 20];
            for (int i = 0; i < store.Length; i++) 
            {
                arr[i] = store[i];
            }
            store = arr;
        }
        /// <summary>
        /// checking of equals
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public bool Equals(T obj)
        {
            if (obj.Equals(this)) return true;
            return false;
        }
        /// <summary>
        /// checking of equals
        /// </summary>
        /// <returns>true or false</returns>
        object ICloneable.Clone()
        {
            return new Queue<T>(this);
        }
    }
}
