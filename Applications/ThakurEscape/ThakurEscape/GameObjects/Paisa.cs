using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class Paisa : GameObjectBase
    {
        public Paisa(int rowPosition, int columnPosition) : base(rowPosition, columnPosition)
        {
        }

        internal override string TextureContentPath
        {
            get { return Constants.PaisaImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Black);
        }
    }
}
