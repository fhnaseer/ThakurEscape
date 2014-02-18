using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class Victory : GameObjectBase
    {
        public Victory(int rowPosition, int columnPosition) : base(rowPosition, columnPosition)
        {
        }

        internal override string TextureContentPath
        {
            get { return Constants.VictoryImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Black);
        }
    }
}
