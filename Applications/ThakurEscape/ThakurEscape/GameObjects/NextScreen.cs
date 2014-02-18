using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class NextScreen : GameObjectBase
    {
        public NextScreen(int rowPosition, int columnPosition) : base(rowPosition, columnPosition)
        {
        }

        internal override string TextureContentPath
        {
            get { return Constants.NextScreenImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Green);
        }
    }
}
