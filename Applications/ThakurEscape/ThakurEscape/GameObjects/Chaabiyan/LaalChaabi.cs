using Microsoft.Xna.Framework;

namespace ThakurEscape.GameObjects.Chaabiyan
{
    class LaalChaabi : ChaabiBase
    {
        public LaalChaabi(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected override Color Color
        {
            get { return Color.Red; }
        }

        protected override ChaabiType ChaabiType
        {
            get { return ChaabiType.Laal; }
        }
    }
}
