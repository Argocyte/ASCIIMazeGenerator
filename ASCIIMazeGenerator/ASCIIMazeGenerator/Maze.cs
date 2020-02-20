using System;
using System.Collections.Generic;
using System.Text;

namespace ASCIIMazeGenerator
{
    /// <summary>
    /// A 2D array of cells which can generate and output itself.
    /// </summary>
    public class Maze
    {
        /// <summary>
        /// 2D Jagged array (for performance) of the cells in the maze.
        /// </summary>
        public Cell[][] Cells;
        public int Width;
        public int Height;

        /// <summary>
        /// Initialises A Maze of x by y size.
        /// </summary>
        /// <param name="width">The Width of the maze, in cell count.</param>
        /// <param name="height">The Height of the maze, in cell count.</param>
        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[Width][];
            for (int x = 0; x < Width; x++)
            {
                Cells[x] = new Cell[Height];
                for (int y = 0; y < Height; y++)
                {
                    Cells[x][y] = new Cell();
                }
            }
            Random rand = new Random();
            Generate(0, 0, Cardinal.NORTH, rand);
        }

        /// <summary>
        /// Recursive function which visits a specified cell and goes to another cell adjacent until 
        /// all the cells around it are either connected to the cell, or visited by another path.
        /// </summary>
        /// <param name="x">x Coordinate of the cell.</param>
        /// <param name="y">y Coordinate of the cell.</param>
        /// <param name="direction">Direction the cell is being visited from.</param>
        /// <param name="rand">Passes a random number generator through, to allow the use of a seed throughout the code without a global variable.</param>
        private void Generate(int x, int y, Cardinal cardinal, Random rand)
        {
            Cells[x][y].Visit(cardinal);
            cardinal = GetCardinal(rand, x, y);
            while (cardinal != Cardinal.NONE)//will visit each direction not currently visited around the current cell.
            {
                switch (cardinal)
                {
                    case Cardinal.NORTH:
                        Generate(x, y - 1, Cardinal.SOUTH, rand);
                        break;
                    case Cardinal.EAST:
                        Generate(x + 1, y, Cardinal.WEST, rand);
                        break;
                    case Cardinal.SOUTH:
                        Generate(x, y + 1, Cardinal.NORTH, rand);
                        break;
                    case Cardinal.WEST:
                        Generate(x - 1, y, Cardinal.EAST, rand);
                        break;
                }
                Cells[x][y].Visit(cardinal);
                cardinal = GetCardinal(rand, x, y);
            }
        }

        /// <summary>
        /// Finds which of the four cardinal directions can be visited from the cell of coordinates x and y.
        /// </summary>
        /// <param name="x">x Coordinate of the cell.</param>
        /// <param name="y">y Coordiante of the cell.</param>
        /// <returns>A list of Cardinal directions that can be visited from the cell of coordinates x and y.</returns>
        private Cardinal GetCardinal(Random rand, int x, int y)
        {
            List<Cardinal> cardinals = new List<Cardinal>();

            if (x > 0 && !Cells[x - 1][y].Visited())
                cardinals.Add(Cardinal.WEST);
            if (y > 0 && !Cells[x][y - 1].Visited())
                cardinals.Add(Cardinal.NORTH);

            if (y < Height - 1 && !Cells[x][y + 1].Visited())
                cardinals.Add(Cardinal.SOUTH);
            if (x < Width - 1 && !Cells[x + 1][y].Visited())
                cardinals.Add(Cardinal.EAST);

            if (cardinals.Count == 0)
                cardinals.Add(Cardinal.NONE);

            return cardinals[rand.Next(cardinals.Count)];
        }

        /// <summary>
        /// Asks each cell what it's output is, and adds it to a string.
        /// </summary>
        /// <returns>Returns a string of ASCII text which resembels the maze defined in the array of Cells. The output is formatted for new lines.</returns>
        public string Display()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    stringBuilder.Append(Cells[x][y].Output());
                }
                if (y != Height - 1) stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }
    }
}
