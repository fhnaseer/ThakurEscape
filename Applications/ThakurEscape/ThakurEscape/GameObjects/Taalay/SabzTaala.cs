using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Taalay
{
    class SabzTaala : TaalaBase
    {
        public SabzTaala(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected override Color Color
        {
            get { return Color.Green; }
        }

        protected override TaalaType TaalaType
        {
            get { return TaalaType.Sabz; }
        }
    }
}
