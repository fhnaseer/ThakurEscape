using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Keys
{
    public class SabzChaabi : ChaabiBase
    {
        public SabzChaabi(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public SabzChaabi(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        protected override Color Color => Color.Green;

        protected override ChaabiType ChaabiType => ChaabiType.Sabz;
    }
}
