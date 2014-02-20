using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Arrows
{
    class LeftArrow : ArrowBase
    {
        public LeftArrow(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected override SpriteEffects SpriteEffect { get { return SpriteEffects.FlipHorizontally; } }

        protected override Simat ArrowDirection
        {
            get { return Simat.Baain; }
        }
    }
}
