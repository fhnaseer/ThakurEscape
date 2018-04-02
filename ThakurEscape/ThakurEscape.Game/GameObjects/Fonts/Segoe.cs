using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Fonts
{
    internal sealed class Segoe : FontBase
    {
        private Segoe() { }

        // ReSharper disable once InconsistentNaming
        public static Segoe Instance { get; } = new Segoe();

        internal override SpriteFont SpriteFont => StaticSpriteFont ?? (StaticSpriteFont = GetTexture());

        internal static SpriteFont StaticSpriteFont { get; set; }

        internal override string SpriteFontPath
        {
            get { return Constants.SegoeImagePath; }
            set { }
        }

        internal void Draw(SpriteBatch spriteBatch, string text, Vector2 position, Color color,
            float scale, float depth)
        {
            Draw(spriteBatch, text, position, color, scale, SpriteEffects.None, depth);
        }
    }
}
