using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Taalay
{
    public class SabzTaala : TaalaBase
    {
        public SabzTaala(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        public override Color SpriteColor => Color.Green;

        public override TaalaType TaalaType => TaalaType.Sabz;
    }
}
