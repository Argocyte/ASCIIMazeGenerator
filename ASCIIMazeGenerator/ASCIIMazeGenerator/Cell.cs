using System;

namespace ASCIIMazeGenerator
{
    /// <summary>
    /// North, South, East, and West.
    /// </summary>
    [Flags]
    public enum Cardinal
    {
        NONE = 0,
        EAST = 1 << 0,
        NORTH = 1 << 1,
        SOUTH = 1 << 2,
        WEST = 1 << 3
    }
    /// <summary>
    /// A cell of a maze, which contains a path.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// an enum that stores the connections the cell has.
        /// </summary>
        public Cardinal Cardinals { get; set; }

        /// <summary>
        /// initialises the cell
        /// </summary>
        public Cell()
        {
            Cardinals = Cardinal.NONE;
        }

        /// <summary>
        /// check if the cell has been visited
        /// </summary>
        /// <returns>true if visited</returns>
        public bool Visited()
        {
            if (Cardinals == Cardinal.NONE) return false;

            else return true;
        }

        /// <summary>
        /// visits the cell, setting the cardinal that is passed through
        /// </summary>
        /// <param name="_cardinal">direction the cell is being visited from</param>
        public void Visit(Cardinal _cardinal)
        {
            Cardinals |= _cardinal;
        }

        /// <summary>
        /// outputs the cell, given the cardinals that are active
        /// </summary>
        /// <returns>the ASCII symbol which denotes the cell</returns>
        public char Output()
        {
            return Cardinals switch
            {
                Cardinal.NORTH | Cardinal.SOUTH | Cardinal.EAST | Cardinal.WEST => Passage.NORTHSOUTHEASTWEST,
                Cardinal.NORTH | Cardinal.SOUTH | Cardinal.EAST => Passage.NORTHSOUTHEAST,
                Cardinal.NORTH | Cardinal.SOUTH | Cardinal.WEST => Passage.NORTHSOUTHWEST,
                Cardinal.NORTH | Cardinal.EAST | Cardinal.WEST => Passage.NORTHEASTWEST,
                Cardinal.SOUTH | Cardinal.EAST | Cardinal.WEST => Passage.SOUTHEASTWEST,
                Cardinal.NORTH | Cardinal.SOUTH => Passage.NORTHSOUTH,
                Cardinal.SOUTH | Cardinal.EAST => Passage.SOUTHEAST,
                Cardinal.SOUTH | Cardinal.WEST => Passage.SOUTHWEST,
                Cardinal.NORTH | Cardinal.WEST => Passage.NORTHWEST,
                Cardinal.NORTH | Cardinal.EAST => Passage.NORTHEAST,
                Cardinal.EAST | Cardinal.WEST => Passage.EASTWEST,
                Cardinal.NORTH => Passage.NORTH,
                Cardinal.SOUTH => Passage.SOUTH,
                Cardinal.EAST => Passage.EAST,
                Cardinal.WEST => Passage.WEST,
                Cardinal.NONE => Passage.NONE,
                _ => Passage.NONE,
            };
        }
    }
}
