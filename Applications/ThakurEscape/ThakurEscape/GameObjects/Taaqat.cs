using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class Taaqat : GameObjectBase
    {
        internal const int Steps = 26;

        public Taaqat(int rowPosition, int columnPosition) : base(rowPosition, columnPosition)
        {
        }

        internal override string TextureContentPath
        {
            get { return Constants.TaaqatImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Black);
        }
    }
}
