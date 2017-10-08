using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects
{
    public class Eint : GameObjectBase
    {
        public Eint(EintTextureType eintTextureType, float x, float y, float width, float height)
            : this(eintTextureType, new Vector2(x, y), width, height)
        {
        }

        public Eint(EintTextureType eintTextureType, Vector2 vector2, float width, float height)
            : base(vector2, width, height)
        {
            switch (eintTextureType)
            {
                case EintTextureType.BlackAndWhite:
                    _textureContentPath = Constants.BlackAndWhiteAintImagePath;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eintTextureType));
            }
        }

        private string _textureContentPath;
        internal override string TextureContentPath
        {
            get => _textureContentPath;
            set => _textureContentPath = value;
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        internal static Eint LoadEint(char tileType, float x, float y, float width, float height)
        {
            return LoadEint(tileType, new Vector2(x, y), width, height);
        }

        internal static Eint LoadEint(char tileType, Vector2 position, float width, float height)
        {
            if (tileType == '#')
                return new Eint(EintTextureType.BlackAndWhite, position, width, height);

            throw new NotImplementedException();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.White);
        }
    }
}
