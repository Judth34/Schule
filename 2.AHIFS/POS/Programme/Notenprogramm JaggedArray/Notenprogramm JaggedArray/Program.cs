using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenprogramm_JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variablen
            int[][] AllMarks = null;
            double[] NotendurchschnittGegenstände = null;
            double[] NotendurchschnittSchüler = null;
            int AnzahlSchüler = 0;
            int AnzahlSchülerMax = 10;
            int AnzahlSchülerMin = 1;
            int AnzahlGegenstände = 0;
            int AnzahlGegenständeMin = 1;
            int AnzahlGegenständeMax = 10;
            int NotenMax = 5;
            int NotenMin = 1;
            int GrößteAnzahlGegenstände = 0;
            #endregion

            AnzahlSchüler = GetAValidNumber(AnzahlSchülerMax, AnzahlSchülerMin, "Gib die Anzahl der Schüler ein: ");

            AllMarks = new int[AnzahlSchüler][];

            for (int ZeilenIdx = 0; ZeilenIdx < AllMarks.GetLength(0); ZeilenIdx++)
            {
                AnzahlGegenstände = GetAValidNumber(AnzahlGegenständeMax, AnzahlGegenständeMin, "Wie viele Noten hat der " + (ZeilenIdx + 1) + ". Schüler: ");
                AllMarks[ZeilenIdx] = new int[AnzahlGegenstände];
            }

            for (int SchülerIdx = 0; SchülerIdx < AllMarks.GetLength(0); SchülerIdx++)
            {
                for (int NotenIdx = 0; NotenIdx < AllMarks[SchülerIdx].Length; NotenIdx++)
                {
                    AllMarks[SchülerIdx][NotenIdx] = GetAValidNumber(NotenMax, NotenMin, "Gib die " + (NotenIdx + 1) + ". Note des " + (SchülerIdx + 1) + ". Schülers ein: ");
                }
            }

            GrößteAnzahlGegenstände = HerausfindenGrößteAnzahlVonGegenständen(AllMarks);

            NotendurchschnittGegenstände = new double [GrößteAnzahlGegenstände];

            NotendurchschnittSchüler = new double[AllMarks.GetLength(0)];

            BerechneNotendurchschnittSchüler(AllMarks, NotendurchschnittSchüler);

            BerechneNotendurschnittGegenstände(AllMarks, NotendurchschnittGegenstände);

            AusgabeDesNotendurchschnittsSchüler(NotendurchschnittSchüler);

            AusgabeDesNotendurchschnittsGegenstände(NotendurchschnittGegenstände);
        }

        static int GetAValidNumber(int Max, int Min, string UserInputMessage)
        {
            int Zahl = 0;
            bool gültigeZahl;

            do
            {
                Console.WriteLine(UserInputMessage);
                gültigeZahl = int.TryParse(Console.ReadLine(), out Zahl);
                if (Zahl < Min || Zahl > Max || gültigeZahl == false)
                {
                    Console.WriteLine("Falsch!!!\nGib bitte eine Zahl zwischen " + Min + " und " + Max + " ein: ");
                }
            } while (Zahl < Min || Zahl > Max || gültigeZahl == false);

            return Zahl;
        }

        static int HerausfindenGrößteAnzahlVonGegenständen(int[][] AllMarks)
        {
            int GrößteAnzahlGegenstände = 0;
            for (int Schüler = 0; Schüler < AllMarks.GetLength(0); Schüler++)
            {
                if (GrößteAnzahlGegenstände < AllMarks[Schüler].Length)
                {
                    GrößteAnzahlGegenstände = AllMarks[Schüler].Length;
                }
            }
            return GrößteAnzahlGegenstände;
        }

        static void BerechneNotendurchschnittSchüler(int[][] AllMarks, double [] NotendurchschnittSchüler)
        {
            double summe = 0;
            double Durchschnitt = 0;
            for (int SchülerIdx = 0; SchülerIdx < AllMarks.GetLength(0); SchülerIdx++)
            {
                summe = 0;
                for (int NotenIdx = 0; NotenIdx < AllMarks[SchülerIdx].Length; NotenIdx++)
                {
                    summe += AllMarks[SchülerIdx][NotenIdx];
                }
                Durchschnitt = summe / AllMarks[SchülerIdx].Length;
                NotendurchschnittSchüler[SchülerIdx] = Durchschnitt;
            }
        }

        static void BerechneNotendurschnittGegenstände(int[][] AllMarks, double [] NotendurchschnittGegenstände)
        {
            double Summe = 0;
            double Durchschnitt = 0;
            int AnzahlDerNoten = 0;

            for (int AnzahlderSchüler = 0; AnzahlderSchüler < AllMarks.GetLength(0); AnzahlderSchüler++)
            {
                for (int NotenIdx = 0; NotenIdx < AllMarks[AnzahlderSchüler].Length; NotenIdx++)
                {
                    AnzahlDerNoten = 0;
                    Summe = 0;
                    for (int SchülerIdx = 0; SchülerIdx < AllMarks.GetLength(0); SchülerIdx++)
                    {
                        if (NotenIdx < AllMarks[SchülerIdx].Length)
                        {
                            AnzahlDerNoten++;
                            Summe += AllMarks[SchülerIdx][NotenIdx];
                        }
                    }
                    Durchschnitt = Summe / AnzahlDerNoten;
                    NotendurchschnittGegenstände[NotenIdx] = Durchschnitt;
                }
            }
        }

        static void AusgabeDesNotendurchschnittsSchüler(double[] NotendurchschnittSchüler)
        {
            for (int SchülerIdx = 0; SchülerIdx < NotendurchschnittSchüler.GetLength(0); SchülerIdx++)
            {
                Console.WriteLine("Der Notendurchschnitt des " + (SchülerIdx + 1) + ". Schülers ist: " + NotendurchschnittSchüler[SchülerIdx]);
            }
        }

        static void AusgabeDesNotendurchschnittsGegenstände(double[] NotendurchschnittGegenstände)
        {
            for (int GegenstandIdx = 0; GegenstandIdx < NotendurchschnittGegenstände.GetLength(0); GegenstandIdx++)
            {
                Console.WriteLine("Der Notendurchschnitt des " + (GegenstandIdx + 1) + ". Gegenstandes ist: " + NotendurchschnittGegenstände[GegenstandIdx]);
            }
        }
    }
}