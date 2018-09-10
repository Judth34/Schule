using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawline3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Lines;
            int NumberOfLines = 0;
            int Direction = 0;
            int StartX = 0;
            int StartY = 0;
            int Length = 0;
            int NumberOfLinesMax = 7;
            int NumberOfLinesMin = 1;
            int KoordinatenMax = 30;
            int KoordinatenMin = 0;
            int LengthMax = 15;
            int LengthMin = 3;

            NumberOfLines = GetAValid(NumberOfLinesMin, NumberOfLinesMax, "Wie viele Linien willst du ausgeben(1 - 7):");
            Lines = new int[NumberOfLines, 4];

            for (int idx = 0; idx < NumberOfLines; idx++)
            {
                StartX = GetAValid(KoordinatenMin, KoordinatenMax, "Geben Sie die X Koordinate ein (0 - 30): ");
                Lines[idx, 0] = StartX;

                StartY = GetAValid(KoordinatenMin, KoordinatenMax, "Geben Sie die Y Koordinate(0 - 30) ein: ");
                Lines[idx, 1] = StartY;

                Length = GetAValid(LengthMin, LengthMax, "Geben Sie die Laenge(3 - 15) ein: ");
                Lines[idx, 2] = Length;

                Direction = GetAValid(0, 1, "Soll es eine horizontale(0) oder vertikale(1) Linie sein: ");
                Lines[idx, 3] = Direction;
            }
            Console.Clear();

            AlleLinien(Lines);

            Console.SetCursorPosition(0, 20);
        }

        static void AlleLinien(int[,] Linien)
        {
            int linienNummer;

            linienNummer = Linien.GetLength(0);

            for (int ZählerDerLinien = 0; ZählerDerLinien < linienNummer; ZählerDerLinien++)
            {
                drawlines(Linien[ZählerDerLinien, 0], Linien[ZählerDerLinien, 1], Linien[ZählerDerLinien, 2], Linien[ZählerDerLinien, 3]);
            }
        }

        static void drawlines(int StartX, int StartY, int Length, int Direction)
        {
            int senkrecht = 0;
            int waagerecht = 0;

            if (Direction == 0)
            {
                waagerecht = 1;
                senkrecht = 0;
            }
            else
            {
                senkrecht = 1;
                waagerecht = 0;
            }

            for (int idx = 0; idx < Length; idx++)
            {
                Console.SetCursorPosition(StartX, StartY);
                Console.WriteLine("*");
                StartX += waagerecht;
                StartY += senkrecht;

            }
        }

        static int GetAValid(int min, int max, string Eingabe)
        {
            int i;
            bool result;

            do
            {
                Console.WriteLine(Eingabe);
                result = int.TryParse(Console.ReadLine(), out i);

            } while (i < min || i > max || result == false);
            return i;

        }
    }
}
