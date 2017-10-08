using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.Screens
{
    internal delegate void ChangeEventHandler(object sender, ThakurEscapeGame.ScreenType e);

    internal abstract class ScreenBase
    {
        protected ScreenBase(float x, float y, float width, float height)
        {
            Width = width;
            Height = height;
            Position = new Vector2(x, y);
        }

        internal float Width { get; set; }
        internal float Height { get; set; }

        internal Vector2 Position { get; set; }

        internal Vector2 Size => new Vector2(Width, Height);

        internal Rectangle BoundingRectangle => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

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
