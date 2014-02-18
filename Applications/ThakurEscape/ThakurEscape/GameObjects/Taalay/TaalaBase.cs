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
