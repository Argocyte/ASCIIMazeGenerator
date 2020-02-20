using System;

namespace ASCIIMazeGenerator
{
    [Flags]
    public enum Cardinal
    {
        NONE = 0,
        EAST = 1 << 0,
        NORTH = 1 << 1,
        SOUTH = 1 << 2,
        WEST = 1 << 3
    }
}
