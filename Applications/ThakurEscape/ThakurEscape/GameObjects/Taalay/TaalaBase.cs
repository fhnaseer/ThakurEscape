using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Taalay
{
    abstract class TaalaBase : GameObjectBase
    {
        protected TaalaBase(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected abstract TaalaType TaalaType { get; }
        protected abstract Color Color { get; }

        internal override string TextureContentPath
        {
            get { return Constants.TaalaImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color);
        }
    }
}
