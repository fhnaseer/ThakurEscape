using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Dirwaazay
{
    public class SabzDirwaaza : DirwaazaBase
    {
        public SabzDirwaaza(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public SabzDirwaaza(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        protected override Color Color => Color.Green;

        protected override DirwaazaType DirwaazaType => DirwaazaType.Sabz;
    }
}
