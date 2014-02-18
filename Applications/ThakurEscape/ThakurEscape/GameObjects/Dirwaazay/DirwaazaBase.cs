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
