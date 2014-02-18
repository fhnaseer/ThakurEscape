using Microsoft.Xna.Framework;

namespace ThakurEscape.GameObjects.Dirwaazay
{
    class LaalDirwaaza : DirwaazaBase
    {
        public LaalDirwaaza(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected override Color Color
        {
            get { return Color.Red; }
        }

        protected override DirwaazaType DirwaazaType
        {
            get { return DirwaazaType.Laal; }
        }
    }
}
