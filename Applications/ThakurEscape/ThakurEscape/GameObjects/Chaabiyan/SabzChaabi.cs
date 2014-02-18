using Microsoft.Xna.Framework;

namespace ThakurEscape.GameObjects.Chaabiyan
{
    class SabzChaabi : ChaabiBase
    {
        public SabzChaabi(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

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
