using System;
using System.Collections;
using System.Collections.Generic;


namespace TaskNo1
{
    public class GenericList <X> : IGenericList<X> 
    {
        
        private class GenericListEnumerator<X> : IEnumerator<X>
        {
            private GenericList<X> list;
            private int position = -1;

            public GenericListEnumerator(GenericList<X> list)
            {
                this.list = list;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                position++;
                return (position < list.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            public X Current
            {
                get
                {
                    try
                    {
                        return list.GetElement(position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException() { };
                    }
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        private X[] _internalStorage;

        /// <summary>
        /// Creates a Generic list, default size is 4.
        /// </summary>
        public GenericList() : this(4)
        {
        }

        /// <summary>
        /// Creates a Generic list with a defined initial size.
        /// </summary>
        /// <param name="initialSize">Initial size of the list.</param>
        public GenericList(int initialSize)
        {
            this._internalStorage = new X[initialSize];
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">Item we want to add to the list.</param>
        public void Add(X item)
        {
            if (_internalStorage[_internalStorage.Length - 1] != null)
            {
                X[] temp = new X[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }
            _internalStorage[this.Count] = item;
        }

        /// <summary>
        /// Removes the first occurrence of an item from the collection.
        /// If the item was not found the method does nothing.
        /// </summary>
        /// <param name="item">Item we want to remove.</param>
        /// <returns>Returns if removal was successful.</returns>
        public bool Remove(X item)
        {
            bool removed = false;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == null) break;
                if (!removed)
                {
                    if (_internalStorage[i].Equals(item))
                    {
                        removed = true;
                        if (i == _internalStorage.Length - 1) _internalStorage[i] = default(X);
                        else _internalStorage[i] = _internalStorage[i + 1];
                    }
                }
                else
                {
                    if (i == _internalStorage.Length - 1) _internalStorage[i] = default(X);
                    else _internalStorage[i] = _internalStorage[i + 1];
                }
            }
            return removed;
        }

        /// <summary>
        /// Removes the item at the given index in the collection.
        /// </summary>
        /// <param name="index">Element with the index which we want to remove.</param>
        /// <returns>Returns true if removal was successful.</returns>
        public bool RemoveAt(int index)
        {
            if (index >= _internalStorage.Length || index < 0)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
            if (index >= this.Count) return false;
            for (int i = index; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = (i == _internalStorage.Length - 1) ? default(X) : _internalStorage[i + 1];
            }
            return true;
        }

        /// <summary>
        /// Returns the item at the given index in the collection.
        /// </summary>
        /// <param name="index">Index of which we want to get an element from.</param>
        /// <returns>Returns the element at the given index.</returns>
        public X GetElement(int index)
        {
            if (index >= _internalStorage.Length || index < 0)
                throw new IndexOutOfRangeException("Index out of range.");
            return _internalStorage[index];
        }

        /// <summary>
        /// Returns the index of the item in the collection.
        /// If item is not found in the collection method returns -1.
        /// </summary>
        /// <param name="item">Item we are searching an index of.</param>
        /// <returns>Returns index of an element in the collection.</returns>
        public int IndexOf(X item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
        }

        /// <summary>
        /// Determines whether the collection contains a specific element.
        /// </summary>
        /// <param name="item">Searched item</param>
        /// <returns>Returns whether the collection contains a particular element.</returns>
        public bool Contains(X item)
        {
            return this.IndexOf(item) != -1;
        }

        /// <summary>
        /// Returns how many elements the list contains.
        /// </summary>
        public int Count
        {
            get
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i] == null) return i;
                    if (_internalStorage[i].Equals(default(X))) return i;
                }
                return _internalStorage.Length;
            }
        }

    }
}