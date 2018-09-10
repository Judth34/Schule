using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahlenMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ZahlenSpeicher = null;
            int GrößeDerZeilen = 0;
            int GrößeDerZeilenMax = 10;
            int GrößeDerZeilenMin = 1;
            int GrößeDerSpalten = 0;
            int GrößeDerSpaltenMax = 10;
            int GrößeDerSpaltenMin = 1;
            int MaxDerZahlen = 50;
            int MinDerZahlen = 1;
            int AuswahlDerZahl = 0;

            GrößeDerZeilen = GetAValidNumber(GrößeDerZeilenMin, GrößeDerZeilenMax, "Gib die Größe der Zeilen ein: ");

            GrößeDerSpalten = GetAValidNumber(GrößeDerSpaltenMin, GrößeDerSpaltenMax, "Gib die Grösse der Spalten ein: ");

            ZahlenSpeicher = new int[GrößeDerZeilen, GrößeDerSpalten];

            
            ZahlenEingeben(ZahlenSpeicher, MaxDerZahlen, MinDerZahlen);

            ZahlenAusgeben(ZahlenSpeicher);

            AuswahlDerZahl = GetAValidNumber(MinDerZahlen, MaxDerZahlen, "Welche Zahl wollen Sie berechnen: ");

            BerechnungDesWertes(ZahlenSpeicher, AuswahlDerZahl);
        }

        static void ZahlenEingeben(int[,] ZahlenSpeicher, int MaxDerZahlen, int MinDerZahlen)
        {
            Random ZahlenImSpeicher = new Random();

            for (int ZeilenIdx = 0; ZeilenIdx < ZahlenSpeicher.GetLength(0); ZeilenIdx++)
            {
                for (int SpaltenIdx = 0; SpaltenIdx < ZahlenSpeicher.GetLength(1); SpaltenIdx++)
                {
                    ZahlenSpeicher[ZeilenIdx, SpaltenIdx] = ZahlenImSpeicher.Next(MinDerZahlen, MaxDerZahlen);
                }
            }
        }

        static void ZahlenAusgeben(int [,] ZahlenSpeicher)
        {
            for(int SpaltenIdx = 0; SpaltenIdx < ZahlenSpeicher.GetLength(0); SpaltenIdx++)
            {
                for(int ZeilenIdx = 0; ZeilenIdx < ZahlenSpeicher.GetLength(1); ZeilenIdx++)
                {
                    Console.Write(" " + ZahlenSpeicher[SpaltenIdx, ZeilenIdx] +" ");
                }
                Console.WriteLine("\n");
            }
        }

        static int GetAValidNumber(int min, int max, string UserInputMessage)
        {
            int Zahl = 0;
            bool GültigeZahl;

            do
            {
                Console.Write(UserInputMessage);
                GültigeZahl = int.TryParse(Console.ReadLine(), out Zahl);

                if (Zahl < min || Zahl > max || GültigeZahl == false)
                {
                    Console.WriteLine("Die Zahl muss zwischen {0}" + min + " und" + max + " sein: ");
                }

            } while (Zahl < min || Zahl > max || GültigeZahl == false);

            return Zahl;
        }

        static void BerechnungDesWertes(int[,] ZahlenSpeicher, int AuswahlderZahl)
        {
            int Summe = 0;

            for (int ZeilenIdx = 0; ZeilenIdx < ZahlenSpeicher.GetLength(0); ZeilenIdx++)
            {
                for (int SpaltenIdx = 0; SpaltenIdx < ZahlenSpeicher.GetLength(1); SpaltenIdx++)
                {
                    if (ZahlenSpeicher[ZeilenIdx, SpaltenIdx] == AuswahlderZahl)
                    {
                        Summe += (ZeilenIdx * 100 + SpaltenIdx);
                    }
                }
            }
            Console.WriteLine(Summe);
        }
    }
}
