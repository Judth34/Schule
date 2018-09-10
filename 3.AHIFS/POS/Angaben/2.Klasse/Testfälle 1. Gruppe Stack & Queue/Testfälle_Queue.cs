namespace Testprogramm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Funktioniert die Methode IsFull()? " + TestCase_IsFull());
            Console.WriteLine("Funktioniert die Methode IsEmpty()? " + TestCase_IsEmpty());
            Console.WriteLine("Funktioniert die Methode Enqueue()? " + TestCase_Enqueue());
            Console.WriteLine("Funktioniert die Methode Dequeue()? " + TestCase_Dequeue());
            Console.WriteLine("Funktioniert die Methode GetElement()? " + TestCase_GetElement());
            Console.WriteLine("Funktioniert die Methode Copy()? " + TestCase_Copy());
            Console.WriteLine("Funktioniert die Methode Merge()? " + TestCase_Merge());
            Console.WriteLine("Funktioniert die Methode Find()? " + TestCase_Find());
            
        }

        #region Testcases

        static bool TestCase_IsFull()       //Gragger Nicolas
        {
            SimpleQueue queueIsFull = new SimpleQueue(1);
            bool result = true;
            if (queueIsFull.IsFull())
            {
                result = false;
            }
            queueIsFull.Enqueue(5);
            if (!queueIsFull.IsFull())
            {
                result = false;
            }
            return result;
        }

        static bool TestCase_IsEmpty()  //Drabosenig Andreas
        {
            bool result = false;
            SimpleQueue q1 = new SimpleQueue(3);
            if (q1.IsEmpty() == true)
            {
                result = true;
            }
            return result;
        }

        static bool TestCase_Enqueue()      //Judth Marcel
        {
            SimpleQueue Queue1 = new SimpleQueue(1);
            int NumbertoQueue = 1;

            Queue1.Enqueue(NumbertoQueue);

            return (Queue1.GetElement() == NumbertoQueue);
        }

     private static bool TestCase_Dequeue()     //Hebein Fabian
        {
		bool status = true;
		int size = 5;
		int idx;
		SimpleQueue q1 = new SimpleQueue(size);
            
            for( idx = 0; idx < size; idx++)
            {
                q1.Enqueue(idx);
            }
            idx = 0;
            while(idx < size && status == true)
            {
                if(q1.Dequeue() != idx)
                {
                    status = false;
                }
                idx++;
            }
            if(status == true)
            {
                try
                {
                    status = false;
                    q1.Dequeue();
                }
                catch
                {
                    status = true;
                }
            }

            return status;
        }
           

        static bool TestCase_GetElement()   // Julian Blaschke
        {
            SimpleQueue queue1 = new SimpleQueue(10);
    
            queue1.Enqueue(13);

            if (!(queue1.GetElement() == 13))
            {
                return false;
            }


            return true;
        }

        static bool TestCase_Copy()         //Fahrgruber Samuel
        {
            int capacity = 100;
            int numberOfElements = 50;
            bool result = false;
            SimpleQueue q1 = new SimpleQueue(capacity);
            SimpleQueue q2;
            int idx;
            for (idx = 0; idx < numberOfElements; idx++)
            {
                q1.Enqueue(idx);
            }
            q2 = q1.Copy();
            if (q1 != q2)
            {
                result = true;
            }
            while (result == true && idx > 0)
            {
                try
                {
                    if (q1.Dequeue() != q2.Dequeue())
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
                idx--;
            }
            return result;
        }

        static bool TestCase_Merge()        //Kandut Nico
        {   //die 2. Queue wird auf den 1. gesetzt
            bool result = true;
            int testwert;
            SimpleQueue SimpleQueue01;
            SimpleQueue SimpleQueue02;
            SimpleQueue ResultingQueue;
            int idxCounter = 0;

            testwert = 3;
            SimpleQueue01 = new SimpleQueue(testwert + 4);
            SimpleQueue02 = new SimpleQueue(testwert);

            for (idxCounter = 0; idxCounter < testwert - 1; idxCounter++)
            {
                SimpleQueue01.Enqueue(idxCounter);
                SimpleQueue02.Enqueue(idxCounter + 10);
            }

            ResultingQueue = SimpleQueue01.Merge(SimpleQueue02);

            idxCounter = 0;

            try
            {
                while (result && idxCounter > testwert)
                {
                    if (ResultingQueue.Dequeue() != SimpleQueue02.Dequeue())
                    {
                        result = false;
                        idxCounter++;
                    }       
                }

                while (result && idxCounter > 0)
                {

                    if (ResultingQueue.Dequeue() != SimpleQueue01.Dequeue())
                    {
                        result = false;
                    }
                    idxCounter--;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        static bool TestCase_Find()         //Moritz Breschan
        {   //rgw gibt an wie viele Elemente gefunden wurde
            bool rgw = true;
            SimpleQueue s1 = new SimpleQueue(20);
            int counter = 0;
            for (counter = 0; counter < 10; counter++)
            {
                s1.Enqueue(counter);
            }
            for (counter = 9; counter >= 0; counter--)
            {
                s1.Enqueue(counter);
            }
            counter = 0;
            while (counter < 10 && rgw)
            {
                if (s1.Find(counter) != 2)
                {
                    rgw = false;
                }
                counter++;
            }
            return rgw;
        }

        
        private static bool TestCase_Resize()     //Melanie Bugelnig
        {
            int newCapacity = 5;
            SimpleQueue s1 = new SimpleQueue(newCapacity);
            bool result = true;
            int counter;

            for (counter = 0; counter < newCapacity; counter++)
            {
                s1.Enqueue(counter);
            }
            newCapacity = 10;

            s1.Resize(newCapacity);

            for (; counter < newCapacity; counter++)
            {
                s1.Enqueue(counter);

            }
            counter--;

            if (s1.GetElement() != counter)
            {
                result = false;
            }
            counter--;

            return result;
        }

        #endregion
    }
}
