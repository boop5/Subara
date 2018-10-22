namespace Assets.Scripts
{
    public static class PositionExtensions
    {
        public static int ToIndex(this Position pos)
        {
            return (pos.Row - 1) * GameGrid.Size + pos.Col - 1;
        }
    }
}