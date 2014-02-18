using Microsoft.Xna.Framework;

namespace ThakurEscape.GameObjects.Taalay
{
    class LaalTaala : TaalaBase
    {
        public LaalTaala(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

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
