using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Dirwaazay
{
    public class SabzDirwaaza : DirwaazaBase
    {
        public SabzDirwaaza(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        public override Color SpriteColor => Color.Green;

        public override DirwaazaType DirwaazaType => DirwaazaType.Sabz;
    }
}
