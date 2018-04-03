using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Dirwaazay
{
    public class LaalDirwaaza : DirwaazaBase
    {
        public LaalDirwaaza(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        public override Color SpriteColor => Color.Red;

        public override DirwaazaType DirwaazaType => DirwaazaType.Laal;
    }
}
