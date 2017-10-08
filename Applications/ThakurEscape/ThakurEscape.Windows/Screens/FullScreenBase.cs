namespace ThakurEscape.Windows.Screens
{
    abstract class FullScreenBase : ScreenBase
    {
        protected FullScreenBase()
            : base(0, 0, ThakurEscapeGame.GameWidth, ThakurEscapeGame.GameHeight)
        {
        }
    }
}
