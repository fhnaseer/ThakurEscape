using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects
{
    public class Thakur : GameObjectBase
    {
        private MovementDirection _kithay;

        public Thakur(int row, int column)
            : base(row, column)
        {
            Kithay = MovementDirection.Right;
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        internal bool HasSabzChaabi { get; set; }
        internal bool HasLaalChaabi { get; set; }
        internal int Taaqat { get; set; }
        internal int Paisa { get; set; }

        internal MovementDirection Kithay
        {
            get => _kithay;
            private set
            {
                if (value == MovementDirection.Left ||
                    value == MovementDirection.Right)
                    _kithay = value;
            }
        }

        internal override string TextureContentPath
        {
            get => Constants.ThakurNormalImagePath;
            set { }
        }

        public override Color SpriteColor => Color.White;

        public override SpriteEffects SpriteEffect
        {
            get
            {
                var spriteEffect = SpriteEffects.None;
                if (Kithay == MovementDirection.Left)
                    spriteEffect = SpriteEffects.FlipHorizontally;
                return spriteEffect;
            }
        }

        internal void Move(MovementDirection kithay)
        {
            Kithay = kithay;

            switch (kithay)
            {
                case MovementDirection.Down:
                    Row++;
                    break;
                case MovementDirection.Up:
                    Row--;
                    break;
                case MovementDirection.Right:
                    Column++;
                    break;
                case MovementDirection.Left:
                    Column--;
                    break;
            }
            Taaqat--;
        }
    }
}
