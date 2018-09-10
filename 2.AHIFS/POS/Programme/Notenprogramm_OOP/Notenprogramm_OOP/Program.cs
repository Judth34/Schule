using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenprogramm_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Noten Note = new Noten();
            int Mark = 0;
            Note.NumberOfPupils = 1;
            Note.NumberOfSubjects = 0;
            for (int pupilidx = 0; pupilidx < Note.NumberOfPupils; pupilidx++)
            {  
                for (int subjectidx = 0; subjectidx < Note.NumberOfSubjects; subjectidx++)
                {
                    Console.WriteLine((subjectidx + 1) + ". Note des " + (pupilidx + 1) + ". Schuelers: ");
                    Mark = int.Parse(Console.ReadLine());
                    Note.SaveMark(Mark, pupilidx, subjectidx);
                }
                
            }
            Note.AveragePupil();
            Note.AverageSubject();
        }
    }
}
