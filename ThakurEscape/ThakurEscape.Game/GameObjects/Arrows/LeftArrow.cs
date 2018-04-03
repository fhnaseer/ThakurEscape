using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Arrows
{
    internal class LeftArrow : ArrowBase
    {
        public LeftArrow(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        public override SpriteEffects SpriteEffect => SpriteEffects.FlipHorizontally;

        protected override Direction ArrowDirection => Direction.Left;
    }
}
