namespace ThakurEscape.Game.Screens
{
    internal abstract class FullScreenBase : ScreenBase
    {
        protected FullScreenBase()
            : base(0, 0, GameContext.Rows, GameContext.Columns)
        {
        }
    }
}
