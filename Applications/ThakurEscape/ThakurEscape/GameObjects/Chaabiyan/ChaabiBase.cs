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

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

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
