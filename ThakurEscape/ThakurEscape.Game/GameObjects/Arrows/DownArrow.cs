using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Arrows
{
    internal class DownArrow : ArrowBase
    {
        public DownArrow(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        public override SpriteEffects SpriteEffect => SpriteEffects.FlipVertically;

        protected override Direction ArrowDirection => Direction.Down;
    }
}