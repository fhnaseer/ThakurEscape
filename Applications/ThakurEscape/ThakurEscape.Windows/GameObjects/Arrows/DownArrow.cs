using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Arrows
{
    class DownArrow : ArrowBase
    {
        public DownArrow(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public DownArrow(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected override SpriteEffects SpriteEffect { get { return SpriteEffects.FlipVertically; } }

        protected override Simat ArrowDirection
        {
            get { return Simat.Neechay; }
        }
    }
}