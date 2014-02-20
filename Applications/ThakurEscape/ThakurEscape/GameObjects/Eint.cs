using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class Eint : GameObjectBase
    {
        private string _textureContentPath;
        internal override string TextureContentPath
        {
            get { return _textureContentPath; }
            set { _textureContentPath = value; }
        }

        public Eint(AintTextureType aintTextureType, int row, int column)
            : base(row, column)
        {
            switch (aintTextureType)
            {
                case AintTextureType.BlackAndWhite:
                    _textureContentPath = Constants.BlackAndWhiteAintImagePath;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("aintTextureType");
            }
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        internal static Eint LoadEint(char tileType, int row, int column)
        {
            if (tileType == '#')
                return new Eint(AintTextureType.BlackAndWhite, row, column);

            throw new NotImplementedException();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.White);
        }
    }
}
