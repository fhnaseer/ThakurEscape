using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    internal class Thakur : GameObjectBase
    {
        private KidherChalayHoBadshaho _kithay;

        public Thakur(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
            Kithay = KidherChalayHoBadshaho.Daain;
        }

        internal bool HasSabzChaabi { get; set; }
        internal bool HasLaalChaabi { get; set; }
        internal int Taaqat { get; set; }

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
            get { return "Thakur\\Thakur.png"; }
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
                    RowPosition++;
                    break;
                case KidherChalayHoBadshaho.Ooper:
                    RowPosition--;
                    break;
                case KidherChalayHoBadshaho.Daain:
                    ColumnPosition++;
                    break;
                case KidherChalayHoBadshaho.Baain:
                    ColumnPosition--;
                    break;
            }
            Taaqat--;
        }
    }
}
