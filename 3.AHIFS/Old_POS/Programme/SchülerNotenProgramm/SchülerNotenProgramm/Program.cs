using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchülerNotenProgramm
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] AlleNoten = null;
            int Schüler = 0;
            int Gegenstände = 0;
            int SchülerMax = 10;
            int SchülerMin = 1;
            int Note = 0;
            int NotenMax = 5;
            int NotenMin = 1;

            Schüler = GetValidNumber(SchülerMin, SchülerMax, "Wie viele Schüler: ");

            Gegenstände = GetValidNumber(SchülerMin, SchülerMax, "Wie viele Gegenstände: ");

            AlleNoten = new double[Schüler + 1, Gegenstände + 1];

            for (int SchülerIdx = 0; SchülerIdx < Schüler; SchülerIdx++)
            {
                for(int GegenständeIdx = 0; GegenständeIdx < Gegenstände; GegenständeIdx++)
                {
                    Note = GetValidNumber(NotenMin, NotenMax, "Gib " + (GegenständeIdx + 1) + " Note für den " + (SchülerIdx + 1) + " Schüler ein");
                    AlleNoten[SchülerIdx, GegenständeIdx] = Note;                    
                }
            }

            NotendurchschnittSchüler(AlleNoten);
            NotendurchschnittGegenstände(AlleNoten);
        }

        static int GetValidNumber(int Min, int Max, string UserInputMessage)
        {
            int Zahl = 0;
            bool gültigeZahl;

            do
            {
                Console.Write(UserInputMessage);
                gültigeZahl = int.TryParse(Console.ReadLine() ,out Zahl);
            } while (Zahl < Min || Zahl > Max || gültigeZahl == false);

            return Zahl;
        }

        static void NotendurchschnittSchüler(double[,] AlleNoten)
        {
            double Summe = 0;

            for (int SchülerIdx = 0; SchülerIdx < (AlleNoten.GetLength(0) - 1); SchülerIdx++)
            {
                for (int GegenstandIdx = 0; GegenstandIdx < AlleNoten.GetLength(1); GegenstandIdx++)
                {
                    Summe += AlleNoten[SchülerIdx, GegenstandIdx];
                }
                double durchschnitt = (Summe / (AlleNoten.GetLength(1) - 1));
                Console.Write("Notendurchschnitt " + (SchülerIdx + 1) + " Schülers: ");
                Console.WriteLine(durchschnitt);
                Summe = 0;
            }

            
        }

        static void NotendurchschnittGegenstände(double[,] AlleNoten)
        {
            double Summe = 0;

            for (int GegenstandIdx = 0; GegenstandIdx < (AlleNoten.GetLength(1) - 1); GegenstandIdx++)
            {
                for (int SchülerIdx = 0; SchülerIdx < AlleNoten.GetLength(0); SchülerIdx++)
                {
                    Summe += AlleNoten[SchülerIdx, GegenstandIdx];                    
                }
                double durchschnitt = (Summe / (AlleNoten.GetLength(0) - 1));
                Console.Write("Notendurchschnitt " + (GegenstandIdx + 1) + " Gegenstandes: ");
                Console.WriteLine(durchschnitt);
                Summe = 0;
            }
        }
    } 
}
