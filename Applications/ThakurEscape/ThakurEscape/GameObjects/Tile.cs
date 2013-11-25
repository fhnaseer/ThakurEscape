using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    enum TileTexture
    {
        BlackAndWhite
    }

    class Tile : GameObjectBase
    {
        private string _textureContentPath;
        internal override string TextureContentPath
        {
            get { return _textureContentPath; }
            set { _textureContentPath = value; }
        }

        public Tile(TileTexture tileTexture, int row, int column)
            : base(row, column)
        {
            switch (tileTexture)
            {
                case TileTexture.BlackAndWhite:
                    _textureContentPath = "Tiles\\BlockA1.png";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tileTexture");
            }
        }

        internal static Tile LoadTiles(char tileType, int row, int column)
        {
            if (tileType == '#')
                return new Tile(TileTexture.BlackAndWhite, row, column);

            throw new NotImplementedException();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Position, Color.White);
        }
    }
}
