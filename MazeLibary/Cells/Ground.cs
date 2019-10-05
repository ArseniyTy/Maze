namespace MazeLibrary.Cells
{
    public class Ground : BaseCell
    {
        public Ground(int x, int y) : base(x, y, ' ')
        {
        }

        public override bool TryToStep()
        {
            return true;
        }
    }
}
