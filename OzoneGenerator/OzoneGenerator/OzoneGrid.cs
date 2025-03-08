using System;

namespace OzoneGenerator
{
    public class OzoneGrid
    {
        private const int Size = 27;
        private int[,] grid = new int[Size, Size];
        private Random random = new Random();

        public OzoneGrid()
        {
            Restart();
        }

        public int GetParcel(int row, int column)
        {
            return grid[row, column];
        }

        public void OzoneClean(int row, int column)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (grid[i, j] > 0) grid[i, j]--;
                }
            }

            int randRow, randCol;
            do
            {
                randRow = random.Next(1, Size - 1);
                randCol = random.Next(1, Size - 1);
            } while (grid[randRow, randCol] != 0);

            ApplyOzone(randRow, randCol);
        }

        public void PointClean(int row, int column)
        {
            if (grid[row, column] != -1)
                ApplyOzone(row, column);
        }

        private void ApplyOzone(int row, int column)
        {
            grid[row, column] = 5;
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newCol = column + dc[i];

                if (newRow >= 1 && newRow < Size - 1 && newCol >= 1 && newCol < Size - 1 && grid[newRow, newCol] != -1)
                {
                    grid[newRow, newCol] = 4;
                }
            }
        }

        public void Restart()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == 0 || i == Size - 1 || j == 0 || j == Size - 1)
                        grid[i, j] = -1; 
                    else
                        grid[i, j] = 0;
                }
            }
        }
    }
}
