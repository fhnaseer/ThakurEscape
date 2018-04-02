using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Dirwaazay
{
    public abstract class DirwaazaBase : GameObjectBase
    {
        //protected DirwaazaBase(float x, float y, float width, float height)
        //    : this (new Vector2(x,y), width, height)
        //{
        //}

        protected DirwaazaBase(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        protected abstract DirwaazaType DirwaazaType { get; }
        protected abstract Color Color { get; }

        internal override string TextureContentPath
        {
            get => Constants.DirwaazaImagePath;
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color);
        }
    }
}
