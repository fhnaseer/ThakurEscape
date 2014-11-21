using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    class Eint : GameObjectBase
    {
        //public Eint(AintTextureType aintTextureType, float x, float y, float width, float height)
        //    : this(aintTextureType, new Vector2(x, y), width, height)
        //{
        //}

        public Eint(AintTextureType aintTextureType, Vector2 vector2, float width, float height)
            : base(vector2, width, height)
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

        private string _textureContentPath;
        internal override string TextureContentPath
        {
            get { return _textureContentPath; }
            set { _textureContentPath = value; }
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        //internal static Eint LoadEint(char tileType, float x, float y, float width, float height)
        //{
        //    return LoadEint(tileType, new Vector2(x, y), width, height);
        //}

        internal static Eint LoadEint(char tileType, Vector2 position, float width, float height)
        {
            if (tileType == '#')
                return new Eint(AintTextureType.BlackAndWhite, position, width, height);

            throw new NotImplementedException();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.White);
        }
    }
}
