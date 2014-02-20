using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Dirwaazay
{
    class SabzDirwaaza : DirwaazaBase
    {
        public SabzDirwaaza(int rowPosition, int columnPosition)
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

        protected override DirwaazaType DirwaazaType
        {
            get { return DirwaazaType.Sabz; }
        }
    }
}
