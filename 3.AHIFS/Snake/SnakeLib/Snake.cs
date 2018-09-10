using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLib
{
    public class Snake
    {
        #region Eigenschaften

        private int[,] snakeParts;
        private int[] kooFood;

        #endregion

        #region Konstruktor
        public Snake()
        {
            snakeParts = new int[3, 2];

            for (int i = 0; i < snakeParts.GetLength(0); i++)
            {
                snakeParts[i, 0] = 10 - i;
                snakeParts[i, 1] = 10;
            }
            kooFood = new int[2];
            kooFood[0] = 20;
            kooFood[1] = 10;
        }
        #endregion

        #region öffentliche - Methoden
        public int[,] GetKooSnake()
        {
            int[,] Koor = new int[snakeParts.GetLength(0), snakeParts.GetLength(1)];

            for (int i = 0; i < Koor.GetLength(0); i++)
            {
                Koor[i, 0] = snakeParts[i, 0];
                Koor[i, 1] = snakeParts[i, 1];
            }

            return Koor;
        }

        public void GoRight()
        {
            for (int i = snakeParts.GetLength(0) - 1; i > 0; i--)
            {
                snakeParts[i, 0] = snakeParts[i - 1, 0];
                snakeParts[i, 1] = snakeParts[i - 1, 1];
            }
            snakeParts[0, 0]++;

        }

        public void GoLeft()
        {
            for (int i = snakeParts.GetLength(0) - 1; i > 0; i--)
            {
                snakeParts[i, 0] = snakeParts[i - 1, 0];
                snakeParts[i, 1] = snakeParts[i - 1, 1];
            }
            snakeParts[0, 0]--;

        }

        public void GoUp()
        {
            for (int i = snakeParts.GetLength(0) - 1; i > 0; i--)
            {
                snakeParts[i, 0] = snakeParts[i - 1, 0];
                snakeParts[i, 1] = snakeParts[i - 1, 1];
            }

            snakeParts[0, 1]--;

        }

        public void GoDown()
        {
            for (int i = snakeParts.GetLength(0) - 1; i > 0; i--)
            {
                snakeParts[i, 0] = snakeParts[i - 1, 0];
                snakeParts[i, 1] = snakeParts[i - 1, 1];
            }
            snakeParts[0, 1]++;

        }

        public void SetFoodKoo(int x, int y)
        {
            kooFood[0] = x;
            kooFood[1] = y;
        }

        public int[] GetKooFood()
        {
            return kooFood;
        }

        public void GetBigger()
        {
            int[,] snake = snakeParts;
            snakeParts = new int[snakeParts.GetLength(0) + 1, snakeParts.GetLength(1) + 1];

            for (int i = 0; i < snake.GetLength(0); i++)
            {
                snakeParts[i, 0] = snake[i, 0];
                snakeParts[i, 1] = snake[i, 1];
            }
        }
        #endregion

        #region private - Methoden

        public void testGameOver()
        {
            for (int i = 1; i < snakeParts.GetLength(0); i++)
            {
                if (snakeParts[0, 0] == snakeParts[i, 0] && snakeParts[0, 1] == snakeParts[i, 1])
                    throw new Exception("Fehler!!");

                
            }

            if (snakeParts[0, 0] == 120 || snakeParts[0, 0] == -1) throw new Exception("Fehler");
            if (snakeParts[0, 1] == 29 || snakeParts[0, 1] == -1) throw new Exception("Fehler");

        }


        #endregion
    }
}
