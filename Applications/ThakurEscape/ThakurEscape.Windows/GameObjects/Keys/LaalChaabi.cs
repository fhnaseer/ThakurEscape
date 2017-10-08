using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Keys
{
    public class LaalChaabi : ChaabiBase
    {
        public LaalChaabi(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public LaalChaabi(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        protected override Color Color => Color.Red;

        protected override ChaabiType ChaabiType => ChaabiType.Laal;
    }
}
