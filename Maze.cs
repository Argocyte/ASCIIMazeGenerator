using System;

namespace ASCIIMazeGenerator
{
    /// <summary>
    /// A 2D array of cells which can generate and output itself.
    /// </summary>
    public class Maze
    {
        /// <summary>
        /// 2D array of the cells in the maze. Each cell has directions the four cardianl directions it can be connected to.
        /// </summary>
        Cell[,] Cells;

        /// <summary>
        /// Initialises A Maze of x by y size.
        /// </summary>
        /// <param name="width">The Width of the maze, in cell count.</param>
        /// <param name="height">The Height of the maze, in cell count.</param>
        public Maze(int width, int height)
        {
            Cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
            Random rand = new Random();
            Generate(0, 0, 'N', rand);
        }

        /// <summary>
        /// Recursive function which visits a specified cell and goes to another cell adjacent until 
        /// all the cells around it are either connected to the cell, or visited by another path.
        /// </summary>
        /// <param name="x">x Coordinate of the cell.</param>
        /// <param name="y">y Coordinate of the cell.</param>
        /// <param name="direction">Direction the cell is being visited from.</param>
        /// <param name="rand">Passes a random number generator through, to allow the use of a seed throughout the code without a global variable.</param>
        void Generate(int x, int y, char direction, Random rand)
        {
            Cells[x, y].VisitCell(direction);
            string availableDirections = CheckDirection(x, y);
            while (availableDirections != "")//will visit each direction not currently visited around the current cell.
            {
                switch (availableDirections[rand.Next(availableDirections.Length)])//Picks a direction from the ones found.
                {
                    case 'N':
                        Generate(x, y - 1, 'S', rand);//Calls itself on the cell in the direction picked.
                        Cells[x, y].VisitCell('N');//Sets the original cell to be connected to the one the code traveled to above.
                        break;
                    case 'S':
                        Generate(x, y + 1, 'N', rand);
                        Cells[x, y].VisitCell('S');
                        break;
                    case 'E':
                        Generate(x + 1, y, 'W', rand);
                        Cells[x, y].VisitCell('E');
                        break;
                    case 'W':
                        Generate(x - 1, y, 'E', rand);
                        Cells[x, y].VisitCell('W');
                        break;
                    default:
                        break;
                }
                availableDirections = CheckDirection(x, y);//Esentially will remove the direction that was visited, and any that were visited before the program back-tracked.
            }
        }

        /// <summary>
        /// Finds which of the four cardinal directions can be visited from the cell of coordinates x and y.
        /// </summary>
        /// <param name="x">x Coordinate of the cell.</param>
        /// <param name="y">y Coordiante of the cell.</param>
        /// <returns>A list of Cardinal directions that can be visited from the cell of coordinates x and y.</returns>
        string CheckDirection(int x, int y)
        {
            string options = "";

            if (x > 0 && !Cells[x - 1, y].Visited) //checks if not against West edge of the array, and the cell to the west has not been visited yet.
            {
                options += "W"; //adds west as an option
            }
            if (y > 0 && !Cells[x, y - 1].Visited) //same as above but for north
            {
                options += "N";
            }
            if (y < Cells.GetLength(1)-1 && !Cells[x, y + 1].Visited) //checks if not against the south edge of the array, and same as above.
            {
                options += "S";
            }
            if (x < Cells.GetLength(0)-1 && !Cells[x + 1, y].Visited)//same as above but for East
            {
                options += "E";
            }
            return options;
        }

        /// <summary>
        /// Asks each cell what it's output is, and adds it to a string.
        /// </summary>
        /// <returns>Returns a string of ASCII text which resembels the maze defined in the array of Cells. The output is formatted for new lines.</returns>
        public string Display()
        {
            string output = "";
            for (int y = 0; y < Cells.GetLength(1); y++)//loops through each cell from top left to bottom right, adding it's output to the string.
            {
                for (int x = 0; x < Cells.GetLength(0); x++)
                {
                    output += Cells[x, y].OutputCell();
                }
                output += "\n";
            }
            return output;
        }
    }
}
