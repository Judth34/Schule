using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenprogramm_OOP
{
    class Noten
    {
        #region Eigenschaften
        int numberOfPupils;
        int numberOfSubjects;
        double[,] allMarks;
        #endregion

        #region Konstruktor(en)
        public Noten()
        {
            numberOfPupils = 1;
            numberOfSubjects = 11;

            allMarks = new double[(numberOfPupils + 1), (numberOfSubjects + 1)];
        }
        #endregion

        #region Properties
        public int NumberOfPupils
        {
            get { return numberOfPupils; }
            set
            {
                if (value > 0 && value < 10)
                {
                    numberOfPupils = value;
                    allMarks = new double[(numberOfPupils + 1), (numberOfSubjects + 1)];
                }
            }
        }

        public int NumberOfSubjects
        {
            get { return numberOfSubjects; }
            set
            {
                if (value > 0 && value < 10)
                {
                    numberOfSubjects = value;
                    allMarks = new double[(numberOfPupils + 1), (numberOfSubjects + 1)];
                }
            }
        }
        #endregion

        #region Öffentliche Methoden
        public int SaveMark(int Mark, int PupilIdx, int SubjectIdx)
        {
            int Result = 0;

            if (Mark < 1 || Mark > 5)
            {
                Result += 1;
            }

            if (PupilIdx < 0 || PupilIdx > 10)
            {
                Result += 10;
            }

            if (SubjectIdx < 0 || SubjectIdx > 10)
            {
                Result += 100;
            }

            if (Result == 0)
            {
                allMarks[PupilIdx, SubjectIdx] = Mark;
            }

            return Result;
        }

        public void AveragePupil()
        {
            double summe = 0;
            double durchschnitt = 0;

            for (int pupilidx = 0; pupilidx < (allMarks.GetLength(0) - 1); pupilidx++)
            {
                summe = 0;
                for (int GegenstandIdx = 0; GegenstandIdx < (allMarks.GetLength(1) - 1); GegenstandIdx++)
                {
                    summe += allMarks[pupilidx, GegenstandIdx];
                }
                durchschnitt = (summe / (allMarks.GetLength(1) - 1));
                allMarks[pupilidx, (allMarks.GetLength(1) - 1)] = durchschnitt;
                Console.WriteLine("Durchschnitt des {0} Schuelers: " + allMarks[pupilidx, (allMarks.GetLength(1) - 1)], (pupilidx + 1));
            }
        }

        public void AverageSubject()
        {
            double summe = 0;
            double durchschnitt = 0;

            for (int subjectIdx = 0; subjectIdx < (allMarks.GetLength(1) - 1); subjectIdx++)
            {
                summe = 0;
                for (int pupilIdx = 0; pupilIdx < allMarks.GetLength(0); pupilIdx++)
                {
                    summe += allMarks[pupilIdx, subjectIdx];
                }

                durchschnitt = (summe / (allMarks.GetLength(0) - 1));
                allMarks[(allMarks.GetLength(0)-1), subjectIdx] = durchschnitt;
                Console.WriteLine("Durchschnitt des {0} Gegenstandes: " + allMarks[(allMarks.GetLength(0) - 1), subjectIdx], (subjectIdx + 1));
            }
        }
        #endregion
    }
}


