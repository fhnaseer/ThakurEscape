using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Dirwaazay
{
    internal abstract class DirwaazaBase : GameObjectBase
    {
        protected DirwaazaBase(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected abstract DirwaazaType DirwaazaType { get; }
        protected abstract Color Color { get; }

        internal override string TextureContentPath
        {
            get { return Constants.DirwaazaImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color);
        }
    }
}
