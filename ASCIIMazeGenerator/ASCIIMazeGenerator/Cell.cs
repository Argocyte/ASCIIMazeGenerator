namespace ASCIIMazeGenerator
{
    public class Cell
    {
        public Cardinal cardinal { get; set; }

        public Cell()
        {
            cardinal = Cardinal.NONE;
        }

        public bool Visited()
        {
            if (cardinal == Cardinal.NONE) return false;

            else return true;
        }

        public void VisitCell(Cardinal _cardinal)
        {
            cardinal |= _cardinal;
        }

        public char OutputCell()
        {
            return cardinal switch
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
