using Microsoft.Xna.Framework;

namespace ThakurEscape.GameObjects.Taalay
{
    class SabzTaala : TaalaBase
    {
        public SabzTaala(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

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
