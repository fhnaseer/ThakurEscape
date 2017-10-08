using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects
{
    class NextBoard : GameObjectBase
    {
        //public NextBoard(float x, float y, float width, float height)
        //    : this (new Vector2(x,y), width, height)
        //{
        //}

        public NextBoard(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        internal override string TextureContentPath
        {
            get { return Constants.NextScreenImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Green);
        }
    }
}
