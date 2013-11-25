using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    internal abstract class GameObjectBase
    {
        protected GameObjectBase(int rowPosition, int columnPosition)
        {
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
        }

        internal abstract string TextureContentPath { get; set; }
        private Texture2D _texture;
        internal Texture2D Texture
        {
            get { return _texture ?? (_texture = ThakurEscapeGame.GameContent.Load<Texture2D>(TextureContentPath)); }
        }

        internal Vector2 Position { get { return new Vector2(ColumnPosition, RowPosition) * Size; } }
        internal Rectangle BoundingRectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); } }
        internal float RowPosition { get; set; }
        internal float ColumnPosition { get; set; }

        public float Width { get { return ThakurEscapeGame.GameWidth/16; } } //Texture.Width; } }
        public float Height { get { return ThakurEscapeGame.GameHeight/10; } } //Texture.Height; } }
        public Vector2 Size { get { return new Vector2(Width, Height); } }

        internal virtual void Update() { }
        internal abstract void Draw(SpriteBatch spriteBatch);
        internal void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Texture, BoundingRectangle, Color.White);
            //spriteBatch.Draw(Texture, position, null, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
