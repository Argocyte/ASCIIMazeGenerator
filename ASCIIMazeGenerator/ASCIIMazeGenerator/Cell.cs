using System;

namespace ASCIIMazeGenerator
{
    /// <summary>
    /// A cell of a maze, which can be connected from N, E, S and W. A cell can output itself.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Has this Cell been visited?
        /// </summary>
        public bool Visited { get; private set; }

        /// <summary>
        /// Is this Cell connected from the North?
        /// </summary>
        bool ConnectedNorth { get; set; }

        /// <summary>
        /// Is this Cell connected from the East?
        /// </summary>
        bool ConnectedEast { get; set; }

        /// <summary>
        /// Is this Cell connected from the South?
        /// </summary>
        bool ConnectedSouth { get; set; }

        /// <summary>
        /// Is this Cell connected from the West?
        /// </summary>
        bool ConnectedWest { get; set; }
        
        /// <summary>
        /// Initialises the Cell, setting all the boolean values to false.
        /// </summary>
        public Cell()
        {
            Visited = ConnectedEast = ConnectedNorth = ConnectedSouth = ConnectedWest = false;
        }

        /// <summary>
        /// Visits the cell, and connects it to the direction given.
        /// </summary>
        /// <param name="direction">Cardinal direction the cell is connected from e.g 'N' for North.</param>
        public void VisitCell(char direction)
        {
            if (Connected(direction))//Sets the cell to being connected from the specified direction.
            {
                Visited = true;
            }
        }

        /// <summary>
        /// Finds what walls are defined by the connections made.
        /// </summary>
        /// <returns>A char which shows the paths available.</returns>
        public char OutputCell()
        {
            if (ConnectedNorth)
            {
                if (ConnectedSouth)
                {
                    if (ConnectedEast)
                    {
                        if (ConnectedWest) return '╬';//Connected from all directions.
                        else return '╠';//Connected from all directions but West.
                    }
                    if (ConnectedWest) return '╣';//Connected from all directions but East.
                    else return '║';//Connected from north and south.
                }
                if (ConnectedEast)
                {
                    if (ConnectedWest) return '╩';//Connected from all directions but South.
                    else return '╚';//Connected from North and East.
                }
                if (ConnectedWest) return '╝';//Connected from North and West.
                else return '║';//Connected only from North (Couldn't locate a 'capped' character.)
            }
            if (ConnectedSouth)
            {
                if (ConnectedEast)
                {
                    if (ConnectedWest) return '╦';//Connected from all directions but North.
                    else return '╔';//Connected from East and South.
                }
                if (ConnectedWest) return '╗';//Connected from West and South.
                else return '║';//Connected only from South (Couldn't locate a 'capped' character.)
            }
            if (ConnectedEast)
            {
                if (ConnectedWest) return '═';//Connected from East and West.
                else return '═';//Connected only from East (Couldn't locate a 'capped' character.)
            }
            if (ConnectedWest) return '═';//Connected only from West (Couldn't locate a 'capped' character.)
            else return '█';//No connection. Will only output if ERROR.
        }

        /// <summary>
        /// Sets the direction the cell is connected from.
        /// </summary>
        /// <param name="direction">Cardinal direction the cell is connected from e.g 'N' for North.</param>
        /// <returns>true if succesful, false if the direction given is not a proper input.</returns>
        bool Connected(char direction)
        {
            switch (direction)
            {
                case 'N':
                    ConnectedNorth = true;
                    return true;
                case 'E':
                    ConnectedEast = true;
                    return true;
                case 'S':
                    ConnectedSouth = true;
                    return true;
                case 'W':
                    ConnectedWest = true;
                    return true;
                default:
                    Console.WriteLine("There was an error!");
                    return false;
            }
        }
    }
}
