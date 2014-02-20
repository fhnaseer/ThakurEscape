using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Taalay
{
    class LaalTaala : TaalaBase
    {
        public LaalTaala(int rowPosition, int columnPosition)
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
            get { return Color.Red; }
        }

        protected override TaalaType TaalaType
        {
            get { return TaalaType.Laal; }
        }
    }
}
