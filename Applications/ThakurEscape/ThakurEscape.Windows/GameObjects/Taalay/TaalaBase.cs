using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Taalay
{
    public abstract class TaalaBase : GameObjectBase
    {
        //protected TaalaBase(float x, float y, float width, float height)
        //    : this (new Vector2(x,y), width, height)
        //{
        //}

        protected TaalaBase(Vector2 position, float width, float height)
            : base(position, width, height)
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
