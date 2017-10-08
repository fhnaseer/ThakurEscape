using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Chaabiyan
{
    class SabzChaabi : ChaabiBase
    {
        public SabzChaabi(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public SabzChaabi(Vector2 position, float width, float height)
            : base(position, width, height)
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

        protected override ChaabiType ChaabiType
        {
            get { return ChaabiType.Sabz; }
        }
    }
}
