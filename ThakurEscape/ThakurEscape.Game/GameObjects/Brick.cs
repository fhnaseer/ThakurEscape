using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ThakurEscape.Game.GameObjects
{
    public class Brick : GameObjectBase
    {
        public Brick(BrickTextureType brickTextureType, int row, int column)
            : base(row, column)
        {
            switch (brickTextureType)
            {
                case BrickTextureType.BlackAndWhite:
                    _textureContentPath = Constants.BlackAndWhiteAintImagePath;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(brickTextureType));
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

        public override Color SpriteColor => Color.White;

        internal static Brick LoadBrick(char tileType, int x, int y)
        {
            if (tileType == '#')
                return new Brick(BrickTextureType.BlackAndWhite, x, y);

            throw new NotImplementedException();
        }
    }
}
