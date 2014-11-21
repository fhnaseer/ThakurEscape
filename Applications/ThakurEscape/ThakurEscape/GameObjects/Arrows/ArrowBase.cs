using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Arrows
{
    abstract class ArrowBase : GameObjectBase
    {
        //protected ArrowBase(float x, float y, float width, float height)
        //    : this (new Vector2(x,y), width, height)
        //{
        //}

        protected ArrowBase(Vector2 position, float width, float height) 
            : base(position, width, height)
        {
        }

        protected abstract Simat ArrowDirection { get; }
        protected virtual SpriteEffects SpriteEffect { get { return SpriteEffects.None; } }

        internal override string TextureContentPath
        {
            get
            {
                if (ArrowDirection == Simat.Daain || ArrowDirection == Simat.Baain)
                    return Constants.LeftArrowImagePath;
                return Constants.TopArrowImagePath;
            }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingRectangle, null, Color.White, 0f, new Vector2(), SpriteEffect, 0);
        }
    }
}
