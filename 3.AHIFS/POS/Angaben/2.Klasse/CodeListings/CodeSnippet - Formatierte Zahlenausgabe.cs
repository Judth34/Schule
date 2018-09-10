for (int idxCol = 0; idxCol<NumberOfCols; idxCol++)
                {
                    Console.Write(String.Format("{0:000}", grid[idxRow, idxCol]) + " | ");
                }
                Console.WriteLine();
                Console.WriteLine(new String('-', (NumberOfCols + 1) * 5));