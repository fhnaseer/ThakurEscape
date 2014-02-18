using Microsoft.Xna.Framework;

namespace ThakurEscape.GameObjects.Dirwaazay
{
    class SabzDirwaaza : DirwaazaBase
    {
        public SabzDirwaaza(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected override Color Color
        {
            get { return Color.Green; }
        }

        protected override DirwaazaType DirwaazaType
        {
            get { return DirwaazaType.Sabz; }
        }
    }
}
