﻿using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects
{
    public class Taaqat : GameObjectBase
    {
        internal const int Steps = 26;

        public Taaqat(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        internal override string TextureContentPath
        {
            get => Constants.TaaqatImagePath;
            set { }
        }
    }
}
