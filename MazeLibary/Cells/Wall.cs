namespace MazeLibrary.Cells
{
    /// <summary>
    /// Contains info about <c>Wall</c> cell.
    /// <para>Inherits from <c>BaseCell</c>.</para>
    /// </summary>
    public class Wall : BaseCell
    {
        /// <summary>
        /// Constructor of the <c>Wall</c> cell.
        /// </summary>
        /// <param name="x">X coordinate of the wall.</param>
        /// <param name="y">Y coordinate of the wall.</param>
        public Wall(int x, int y) : base(x, y, '#')
        {
        }

        /// <summary>
        /// Always returns false, because we can't step in this cell.
        /// </summary>
        /// <returns>always return false state.</returns>
        public override bool TryToStep()
        {
            return false;
        }
    }
}
