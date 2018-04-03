using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Keys
{
    public class LaalChaabi : ChaabiBase
    {
        public LaalChaabi(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        public override Color SpriteColor => Color.Red;

        public override ChaabiType ChaabiType => ChaabiType.Laal;
    }
}
