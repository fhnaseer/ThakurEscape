using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Fonts
{
    internal sealed class Segoe : FontBase
    {
        private Segoe() { }

        // ReSharper disable once InconsistentNaming
        private static readonly Segoe _instance = new Segoe();
        public static Segoe Instance => _instance;

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
