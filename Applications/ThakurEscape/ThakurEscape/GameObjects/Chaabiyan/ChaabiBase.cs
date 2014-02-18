using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Chaabiyan
{
    internal abstract class ChaabiBase : GameObjectBase
    {
        protected ChaabiBase(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected abstract ChaabiType ChaabiType { get; }
        protected abstract Color Color { get; }

        internal override string TextureContentPath
        {
            get { return Constants.ChaabiImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color);
        }
    }
}
