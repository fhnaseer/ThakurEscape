using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.Screens
{
    internal delegate void ChangeEventHandler(object sender, ThakurEscapeGame.ScreenType e);

    internal abstract class ScreenBase
    {
        protected ScreenBase(int x, int y, int rows, int columns)
        {
            OriginX = x;
            OriginY = y;
            Rows = rows;
            Columns = columns;
        }

        public int OriginX { get; set; }

        public int OriginY { get; set; }

        public int Rows { get; }

        public int Columns { get; }

        internal abstract void Draw(SpriteBatch spriteBatch);

        internal abstract void Update(GameTime gameTime);

        internal abstract void HandleInput();

        public event ChangeEventHandler ChangeScreen;
        internal virtual void OnChangeScreen(ThakurEscapeGame.ScreenType screenType)
        {
            ChangeScreen?.Invoke(this, screenType);
        }
    }
}
