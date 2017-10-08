﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Windows.GameObjects.Arrows
{
    internal class UpArrow : ArrowBase
    {
        public UpArrow(float x, float y, float width, float height)
            : this(new Vector2(x, y), width, height)
        {
        }

        public UpArrow(Vector2 position, float width, float height)
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        protected override Direction ArrowDirection => Direction.Up;
    }
}
