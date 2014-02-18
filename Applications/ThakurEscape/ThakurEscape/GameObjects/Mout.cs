using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class Mout : GameObjectBase
    {
        public Mout(int rowPosition, int columnPosition) : base(rowPosition, columnPosition)
        {
        }

        internal override string TextureContentPath
        {
            get { return Constants.MoutImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Black);
        }
    }
}
