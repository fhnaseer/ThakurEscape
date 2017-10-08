using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Fonts
{
    internal abstract class FontBase
    {
        internal abstract string SpriteFontPath { get; set; }

        internal abstract SpriteFont SpriteFont { get; }

        protected SpriteFont GetTexture()
        {
            return ThakurEscapeGame.GameContent.Load<SpriteFont>(SpriteFontPath);
        }

        internal virtual void Update() { }

        internal virtual void Draw(SpriteBatch spriteBatch, string text, Vector2 position,
            Color color, float scale, SpriteEffects spriteEffect, float depth)
        {
            var origin = new Vector2(0, 0); //SpriteFont.MeasureString(text) / 2;
            spriteBatch.DrawString(SpriteFont, text, position, color,
                0, origin, scale, spriteEffect, depth);
        }
    }
}
