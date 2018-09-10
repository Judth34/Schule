using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZahlenMatrix2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ZahlenSpeicher = null;
            int[,] AuswahlSpeicher = null;
            int GrößeDerZeilen = 0;
            int GrößeDerZeilenMax = 10;
            int GrößeDerZeilenMin = 1;
            int GrößeDerSpalten = 0;
            int GrößeDerSpaltenMax = 10;
            int GrößeDerSpaltenMin = 1;
            int MaxDerZahlen = 50;
            int MinDerZahlen = 1;
            int Auswahl = 0;

            GrößeDerZeilen = GetAValidNumber(GrößeDerZeilenMin, GrößeDerZeilenMax, "Wie viele Zeilen soll ihr Array haben: ");

            GrößeDerSpalten = GetAValidNumber(GrößeDerSpaltenMin, GrößeDerSpaltenMax, "Wie viele Spalten soll ihr Array haben: ");

            ZahlenSpeicher = new int[GrößeDerZeilen, GrößeDerSpalten];

            ZahlenEingeben(ZahlenSpeicher, MaxDerZahlen, MinDerZahlen);

            ZahlenAusgeben(ZahlenSpeicher);

            Auswahl = GetAValidNumber(MinDerZahlen, MaxDerZahlen, "Von wie vielen Zahlen wollen Sie die Summe haben: ");
            AuswahlSpeicher = new int[Auswahl, 2];

            for (int ZeilenIdx = 0; ZeilenIdx < AuswahlSpeicher.GetLength(0); ZeilenIdx++)
            {
                Auswahl = GetAValidNumber(1, 50, "Von welchen Zahlen wollen Sie die Summe haben: ");
                AuswahlSpeicher[ZeilenIdx, 0] = Auswahl;
            }

            BerechnungDesWertes(ZahlenSpeicher, AuswahlSpeicher);

            AusgabeDerSummen(AuswahlSpeicher);
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

        static void ZahlenAusgeben(int[,] ZahlenSpeicher)
        {
            for (int ZeilenIdx = 0; ZeilenIdx < ZahlenSpeicher.GetLength(0); ZeilenIdx++)
            {
                for (int SpaltenIdx = 0; SpaltenIdx < ZahlenSpeicher.GetLength(1); SpaltenIdx++)
                {
                    if (ZahlenSpeicher[ZeilenIdx, SpaltenIdx] < 10)
                    {
                        Console.Write(" 0" + ZahlenSpeicher[ZeilenIdx, SpaltenIdx] + " ");
                    }
                    else
                    {
                        Console.Write(" " + ZahlenSpeicher[ZeilenIdx, SpaltenIdx] + " ");
                    }
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
                    Console.WriteLine("Die Zahl muss zwischen " + min + " und " + max + " sein: ");
                }

            } while (Zahl < min || Zahl > max || GültigeZahl == false);

            return Zahl;
        }

        static void BerechnungDesWertes(int[,] ZahlenSpeicher, int[,] AuswahlSpeicher)
        {
            int Summe = 0;

            for (int AuswahlIdx = 0; AuswahlIdx < AuswahlSpeicher.GetLength(0); AuswahlIdx++)
            {
                Summe = 0;

                for (int ZeilenIdx = 0; ZeilenIdx < ZahlenSpeicher.GetLength(0); ZeilenIdx++)
                {
                    for (int SpaltenIdx = 0; SpaltenIdx < ZahlenSpeicher.GetLength(1); SpaltenIdx++)
                    {
                        if (ZahlenSpeicher[ZeilenIdx, SpaltenIdx] == AuswahlSpeicher[AuswahlIdx, 0])
                        {
                            Summe += ZeilenIdx * 100 + SpaltenIdx;
                            SpeichernDesWertes(AuswahlSpeicher, Summe, AuswahlIdx);
                        }
                    }
                }
            }
        }

        static void SpeichernDesWertes(int[,] AuswahlSpeicher, int Summe, int AuswahlIdx)
        {
            for(; AuswahlIdx < AuswahlSpeicher.GetLength(0);AuswahlIdx ++)
            {
                AuswahlSpeicher[AuswahlIdx, 1] = Summe;
            }
        }

        static void AusgabeDerSummen(int[,] AuswahlSpeicher)
        {
            for(int ZeilenIdx = 0; ZeilenIdx < AuswahlSpeicher.GetLength(0); ZeilenIdx++)
            {
                Console.Write("Die Summe der Zahl " + AuswahlSpeicher[ZeilenIdx, 0] + " ist: ");
                Console.WriteLine(AuswahlSpeicher[ZeilenIdx, 1]);
            }
        }
    }
}
