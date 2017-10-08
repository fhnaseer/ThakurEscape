using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects
{
    public class Taaqat : GameObjectBase
    {
        internal const int Steps = 26;

        public Taaqat(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public Taaqat(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

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
