using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStructures
{
    class SimpleStack : DataStructur
    {
        string[] data = null;
        int topOfStack = 0;

        public SimpleStack(string Name) : base(Name)
        {
            ArrayErzeugen(capacity);
        }
        
        public SimpleStack(string Name, int Capacity) : base(Name, Capacity)
        {
            ArrayErzeugen(capacity);
        }

        private void ArrayErzeugen(int capacity)
        {
            data = new string[capacity];
        }

        public override bool IsEmpty()
        {
            return (topOfStack == 0);
        }

        public override bool IsFull()
        {
            return (topOfStack == capacity);
        }

        public override void Add(string NewElement)
        {
            if (IsFull())
            {
                throw new Exception("Array zu klein!");
            }

            data[topOfStack] = NewElement;
            topOfStack++;
        }

        public override string Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Array ist leer!");
            }
            topOfStack--;
            return data[topOfStack];                    
        }

        public override void Clear()
        {
            for(int idx = 0; idx < topOfStack; idx++)
            {
                data[idx] = null;
            }

            topOfStack = 0;
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
    }
}