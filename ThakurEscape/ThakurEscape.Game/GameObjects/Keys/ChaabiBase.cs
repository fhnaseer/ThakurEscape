using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Keys
{
    public abstract class ChaabiBase : GameObjectBase
    {
        //protected ChaabiBase(float x, float y, float width, float height)
        //    : this (new Vector2(x,y), width, height)
        //{
        //}

        protected ChaabiBase(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        protected abstract ChaabiType ChaabiType { get; }
        protected abstract Color Color { get; }

        internal override string TextureContentPath
        {
            get => Constants.ChaabiImagePath;
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color);
        }
    }
}
