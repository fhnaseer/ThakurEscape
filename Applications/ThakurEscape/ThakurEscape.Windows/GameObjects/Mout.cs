using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    public class Mout : GameObjectBase
    {
        public Mout(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public Mout(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

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
