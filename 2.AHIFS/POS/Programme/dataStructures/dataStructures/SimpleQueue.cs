using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStructures
{
    class SimpleQueue : DataStructur
    {
        string[] data = null;
        int First = 0;
        int Rare = 0;

        public SimpleQueue(string Name) : base(Name)
        {
            ArrayErzeugen(capacity);
        }

        public SimpleQueue(string Name, int Capacity) : base(Name, Capacity)
        {
            ArrayErzeugen(capacity);
        }

        private void ArrayErzeugen(int capacity)
        {
            data = new string[capacity];
        }

        public override void Add(string NewElement)
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override bool Contains(string Element)
        {
            bool Found = false;

            for (int counter = 0; counter < capacity; counter++)
            {
                if (data[counter] == Element)
                {
                    Found = true;
                }
            }
            return Found;
        }

        public override bool IsEmpty()
        {
            return (First == 0);
        }

        public override bool IsFull()
        {
            return (Rare == capacity);
        }

        public override string Remove()
        {
            throw new NotImplementedException();
        }
    }
}
