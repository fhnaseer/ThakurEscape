using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Taalay
{
    class LaalTaala : TaalaBase
    {
        public LaalTaala(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public LaalTaala(Vector2 position, float width, float height)
            : base(position, width, height)
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
