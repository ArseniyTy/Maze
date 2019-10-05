namespace MazeLibrary.Cells
{
    public class Wall : BaseCell
    {
        public Wall(int x, int y) : base(x, y, '#')
        {
        }

        public override bool TryToStep()
        {
            return false;
        }
    }
}
