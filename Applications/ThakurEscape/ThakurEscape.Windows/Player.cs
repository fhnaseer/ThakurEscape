using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows
{
    class Player
    {
        private Texture2D _playerTexture;
        private Vector2 _position;
        public int Width { get { return _playerTexture.Width; } }
        public int Height { get { return _playerTexture.Height; } }

        internal void Initialize(Texture2D texture, Vector2 position)
        {
            _playerTexture = texture;
            _position = position;
        }

        internal void Update()
        {

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
