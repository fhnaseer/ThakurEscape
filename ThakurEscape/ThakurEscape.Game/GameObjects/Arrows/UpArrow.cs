using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Arrows
{
    internal class UpArrow : ArrowBase
    {
        public UpArrow(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        protected override Direction ArrowDirection => Direction.Up;
    }
}
