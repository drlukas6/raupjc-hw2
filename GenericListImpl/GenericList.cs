using System;
using System.Collections;
using System.Collections.Generic;


namespace TaskNo1
{
    public class GenericList <X> : IGenericList<X>
    {
        
        private class GenericListEnumerator<X> : IEnumerator<X>
        {

            public GenericList<X> list;            
            private int position = -1;
            private int t = 0;

            public GenericListEnumerator(GenericList<X> list)
            {
                this.list = list;
            }
            
            public bool MoveNext()
            {
                position++;
                return(position < list.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            public X Current
            {
                get {
                    try
                    {
                        return list.GetElement(position);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw  new InvalidOperationException();
                    }
                    
                }
            }


            object IEnumerator.Current
            {
                get { return Current; }
            }
            
            public void Dispose()
            {
               
            }
        }
        
        
        private X[] _internalStorage;
        private int initialSize;
        
        
        public GenericList(int initialSize)
        {
            initialSize = this.initialSize;
            Console.WriteLine("Default is " + default(X));
            if (initialSize < 0)
            {
                throw new NotSupportedException();
            }
            _internalStorage = new X[initialSize];
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = default(X);
            }
            
        }

        public GenericList()
        {
            _internalStorage = new X[4];
            Console.WriteLine("Default is " + default(X));
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = default(X);
            }
        }
        
        
        public void Add(X item)
        {
            int itemCount = counter(_internalStorage);
            try
            {
                _internalStorage[itemCount] = item;
                Console.WriteLine("Element: " + item + " Succesfully added!");
            }
            catch (IndexOutOfRangeException e)
            {
                // Console.WriteLine("Array is not long enough. Attempting to migrate data to a larger one.");
                // Console.WriteLine("Old array lenght: " + _internalStorage.Length);
                X[] newArray = new X[(_internalStorage.Length) * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    newArray[i] = _internalStorage[i];
                }
                _internalStorage = newArray;
                _internalStorage[itemCount] = item;
                Console.WriteLine("Element: " + item + " Succesfully added!");
                /*
                Console.WriteLine("New array lenght: " + _internalStorage.Length + " Elements: ");
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    Console.WriteLine(_internalStorage[i]);
                } 
                */
            }
        }

        public bool Remove(X item)
        {
            int position = 0;
            bool found = false;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == null)
                {
                    return false;
                }
                if (_internalStorage[i].Equals(item))
                {
                    position = i;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                RemoveAt(position);
                return true;
            }
            else
            {
                return found;
            }
        }

        public bool RemoveAt(int index)
        {
            try
            {
                
                for (int i = index+1; i < _internalStorage.Length; i++)
                {
                    _internalStorage[i - 1] = _internalStorage[i];
                }
                _internalStorage[_internalStorage.Length - 1] = default(X);
                
                /*
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    Console.WriteLine(_internalStorage[i]);
                }
                */
                return true;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
                return false;
            }
        }

        public X GetElement(int index)
        {
            try
            {
                return _internalStorage[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get
            {
                int counterofItems = counter(_internalStorage);
                return counterofItems;
            }
        }
        public void Clear()
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = default(X);
            }
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        
        public int counter(X[] arrayToCount)
        {
            int len = arrayToCount.Length;
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                if (arrayToCount[i] == null)
                {
                    break;
                }
                if (!arrayToCount[i].Equals(default(X))) 
                {
                    sum = sum + 1;
                }
            }
            return sum;
        }
       
        public IEnumerator <X> GetEnumerator() {
            return new GenericListEnumerator <X> (this); 
        }
        
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator(); 
        }


    }
}