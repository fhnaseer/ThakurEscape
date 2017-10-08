using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects
{
    internal class Thakur : GameObjectBase
    {
        private KidherChalayHoBadshaho _kithay;

        public Thakur(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
            Kithay = KidherChalayHoBadshaho.Daain;
        }

        public Thakur(Vector2 position, float width, float height)
            : base(position, width, height)
        {
            Kithay = KidherChalayHoBadshaho.Daain;
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        internal bool HasReachedExit { get; set; }
        internal bool HasSabzChaabi { get; set; }
        internal bool HasLaalChaabi { get; set; }
        internal int Taaqat { get; set; }
        internal int Paisa { get; set; }

        internal KidherChalayHoBadshaho Kithay
        {
            get { return _kithay; }
            private set
            {
                if (value == KidherChalayHoBadshaho.Baain ||
                    value == KidherChalayHoBadshaho.Daain)
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
            if (Kithay == KidherChalayHoBadshaho.Baain)
                spriteEffect = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Texture, BoundingRectangle, null, Color.White, 0f, Vector2.Zero, spriteEffect, 0f);
        }

        internal void Move(KidherChalayHoBadshaho kithay)
        {
            Kithay = kithay;

            switch (kithay)
            {
                case KidherChalayHoBadshaho.Neechay:
                    Position += new Vector2(0f, Height);
                    break;
                case KidherChalayHoBadshaho.Ooper:
                    Position -= new Vector2(0f, Height);
                    break;
                case KidherChalayHoBadshaho.Daain:
                    Position += new Vector2(Width, 0f);
                    break;
                case KidherChalayHoBadshaho.Baain:
                    Position -= new Vector2(Width, 0f);
                    break;
            }
            Taaqat--;
        }
    }
}
