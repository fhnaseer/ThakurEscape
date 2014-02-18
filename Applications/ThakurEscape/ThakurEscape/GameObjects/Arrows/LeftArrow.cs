using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Arrows
{
    class LeftArrow : ArrowBase
    {
        public LeftArrow(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected override SpriteEffects SpriteEffect { get { return SpriteEffects.FlipHorizontally; } }

        protected override Simat ArrowDirection
        {
            get { return Simat.Baain; }
        }
    }
}
