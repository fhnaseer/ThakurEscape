using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    enum KithayChalayHoBadshaho
    {
        Sajjay,
        Khabbay,
        Utay,
        Thallay
    }

    internal class Thakur : GameObjectBase
    {
        private KithayChalayHoBadshaho _kithay;

        public Thakur(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
            Kithay = KithayChalayHoBadshaho.Sajjay;
        }

        internal KithayChalayHoBadshaho Kithay
        {
            get { return _kithay; }
            private set
            {
                if (value == KithayChalayHoBadshaho.Khabbay ||
                    value == KithayChalayHoBadshaho.Sajjay)
                    _kithay = value;
            }
        }

        internal override string TextureContentPath
        {
            get { return "Thakur\\Akram.png"; }
            set { }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            var spriteEffect = SpriteEffects.None;
            if (Kithay == KithayChalayHoBadshaho.Khabbay)
                spriteEffect = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Texture, BoundingRectangle, null, Color.White, 0f, Vector2.Zero, spriteEffect, 0f);
        }

        internal void Move(KithayChalayHoBadshaho kithay)
        {
            Kithay = kithay;

            if (kithay == KithayChalayHoBadshaho.Thallay)
                RowPosition++;
            else if (kithay == KithayChalayHoBadshaho.Utay)
                RowPosition--;
            else if (kithay == KithayChalayHoBadshaho.Sajjay)
                ColumnPosition++;
            else if (kithay == KithayChalayHoBadshaho.Khabbay)
                ColumnPosition--;
        }
    }
}
