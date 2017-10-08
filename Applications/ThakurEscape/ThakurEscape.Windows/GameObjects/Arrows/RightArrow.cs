using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Arrows
{
    class RightArrow : ArrowBase
    {
        public RightArrow(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public RightArrow(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected override Simat ArrowDirection
        {
            get { return Simat.Daain; }
        }
    }
}