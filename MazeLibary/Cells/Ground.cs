namespace MazeLibrary.Cells
{
    /// <summary>
    /// Contains info about <c>Ground</c> cell.
    /// <para>Inherits from <c>BaseCell</c>.</para>
    /// </summary>
    public class Ground : BaseCell
    {
        /// <summary>
        /// Constructor of the <c>Ground</c> cell.
        /// </summary>
        /// <param name="x">X coordinate of the ground.</param>
        /// <param name="y">Y coordinate of the ground.</param>
        public Ground(int x, int y) : base(x, y, ' ')
        {
        }

        /// <summary>
        /// Always returns true, because we can step in this cell.
        /// </summary>
        /// <returns>always return true state.</returns>
        public override bool TryToStep()
        {
            return true;
        }
    }
}
