using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    internal class Thakur : GameObjectBase
    {
        private MovementDirection _kithay;

        public Thakur(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
            Kithay = MovementDirection.Right;
        }

        public Thakur(Vector2 position, float width, float height)
            : base(position, width, height)
        {
            Kithay = MovementDirection.Right;
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        internal bool HasReachedExit { get; set; }
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
            get { return Constants.ThakurNormalImagePath; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            var spriteEffect = SpriteEffects.None;
            if (Kithay == MovementDirection.Left)
                spriteEffect = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Texture, BoundingRectangle, null, Color.White, 0f, Vector2.Zero, spriteEffect, 0f);
        }

        internal void Move(MovementDirection kithay)
        {
            Kithay = kithay;

            switch (kithay)
            {
                case MovementDirection.Down:
                    Position += new Vector2(0f, Height);
                    break;
                case MovementDirection.Up:
                    Position -= new Vector2(0f, Height);
                    break;
                case MovementDirection.Right:
                    Position += new Vector2(Width, 0f);
                    break;
                case MovementDirection.Left:
                    Position -= new Vector2(Width, 0f);
                    break;
            }
            Taaqat--;
        }
    }
}
