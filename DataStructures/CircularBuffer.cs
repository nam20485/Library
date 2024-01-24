using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class CircularBuffer<TValue> : DsCollectionBase<TValue>//, ICollection<TValue>
    {
        private readonly TValue[] _items;

        private int _readIndex;     // _head
        private int _writeIndex;    // _tail    

        //private int _head;
        //private int _tail;  
        private bool _full;

        public int Capacity => _items.Length;

        public override int Count
        {
            get
            {
                if (_full)
                {
                    return Capacity;
                }
                else
                {
                    if (_readIndex >= _writeIndex)
                    {
                        return _readIndex - _writeIndex;
                    }
                    else
                    {
                        return Capacity + _readIndex - _writeIndex;
                    }
                }

                //size_t size = max_size_;

                //if (!full_)
                //{
                //    if (head_ >= tail_)
                //    {
                //        size = head_ - tail_;
                //    }
                //    else
                //    {
                //        size = max_size_ + head_ - tail_;
                //    }
                //}

                //return size;
            }
        }

        public CircularBuffer(int capacity)
        {
            _items = new TValue[capacity];            
            _readIndex = 0;
            _writeIndex = 0;
            _full = false;
        }

        public CircularBuffer(IEnumerable<TValue> collection)
            : this(collection.Count())
        {
            AddRange(collection);
        }

        public override void Add(TValue item)
        {
            AddLast(item);
        }

        public void AddLast(TValue item)
        {
            var overWroteReadIndex = false;
            if (_writeIndex == _readIndex)
            {
                overWroteReadIndex = true;
            }

            _items[_writeIndex] = item;
            Increment(ref _writeIndex);

            if (overWroteReadIndex)
            {
                // we just overwrote the oldest item, increment the readIndex;
                Increment(ref _readIndex);
            }           
        }

        public override bool Contains(TValue item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(TValue item)
        {
            var index = _readIndex;
            while (index <= _writeIndex)
            {
                if (Equals(_items[index], item))
                {
                    return index;
                }
                Increment(ref index);
            }
            return -1; ;
        }

        public override void Clear()
        {
            _writeIndex = 0;
            _readIndex = 0;
            Array.Clear(_items);
        }

        private void Increment(ref int index)
        {
            index++;
            if (index == Capacity)
            {
                index = 0;
            }
        }

        private void Decrement(ref int index)
        {
            index--;
            if (index == -1)
            {
                index = Capacity - 1;
            }
        }

        public override TValue Remove()
        {
            return RemoveFirst();
        }

        public void Enqueue(TValue value)
        {
            AddLast(value);
        }

        public TValue Dequeue()
        {
            return RemoveFirst();
        }

        private TValue RemoveFirst()
        {
            if (_writeIndex == _readIndex)
            {
                throw new InvalidOperationException("Cannot remove from empty buffer.");
            }
            else
            {
                var item = Peek();
                Increment(ref _readIndex);
                return item;
            }            
        }

        public TValue Peek()
        {
            if (_writeIndex == _readIndex)
            {
                throw new InvalidOperationException("Buffer is empty.");
            }
            return _items[_readIndex];
        }

        public override IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override IDsCollection<TValue> CopyOf()
        {
            throw new NotImplementedException();
        }

        protected override string GetStringRepresentation()
        {
            var sb = new StringBuilder();
            sb.Append(ToList());
            sb.Append(Environment.NewLine);

            if (_readIndex < _writeIndex)
            {                
                sb.Append(new string(' ', _readIndex*3+1));
                sb.Append('r');
                sb.Append(new string(' ', (_writeIndex - _readIndex) * 3));
                sb.Append('w');

            }
            else if (_writeIndex == _readIndex)
            {
                sb.Append(new string(' ', _readIndex * 3+1));
                sb.Append("rw");
            }
            else
            {
                sb.Append(new string(' ', _writeIndex * 3+1));
                sb.Append('r');
                sb.Append(new string(' ', (_readIndex - _writeIndex) * 3));
                sb.Append('w');
            }
            return sb.ToString();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            
        }       
    }
}
