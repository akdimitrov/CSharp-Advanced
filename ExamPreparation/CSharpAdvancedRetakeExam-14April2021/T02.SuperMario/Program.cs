using System;

namespace T02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] maze = new char[rows][];
            int marioRow = 0;
            int marioCol = 0;
            for (int row = 0; row < rows; row++)
            {
                string cols = Console.ReadLine();
                maze[row] = new char[cols.Length];
                for (int col = 0; col < cols.Length; col++)
                {
                    maze[row][col] = cols[col];
                    if (cols[col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            bool isPrincessSaved = false;
            while (lives > 0)
            {
                string[] cmd = Console.ReadLine().Split();
                string direction = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);

                maze[row][col] = 'B';
                maze[marioRow][marioCol] = '-';
                lives--;

                switch (direction)
                {
                    case "W": marioRow = marioRow - 1 >= 0 ? marioRow -= 1 : marioRow; break;
                    case "S": marioRow = marioRow + 1 < maze.Length ? marioRow += 1 : marioRow; break;
                    case "A": marioCol = marioCol - 1 >= 0 ? marioCol -= 1 : marioCol; break;
                    case "D": marioCol = marioCol + 1 < maze[row].Length ? marioCol += 1 : marioCol; break;
                }

                if (maze[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                }
                else if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    isPrincessSaved = true;
                    break;
                }

                maze[marioRow][marioCol] = lives > 0 ? 'M' : 'X';
            }

            Console.WriteLine(!isPrincessSaved ? $"Mario died at {marioRow};{marioCol}."
                : $"Mario has successfully saved the princess! Lives left: {lives}");

            foreach (var row in maze)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
