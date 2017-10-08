﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects
{
    public abstract class GameObjectBase
    {
        //protected GameObjectBase(float x, float y, float width, float height)
        //    : this(new Vector2(x, y), width, height)
        //{
        //}

        protected GameObjectBase(Vector2 position, float width, float height)
        {
            Position = position;
            Width = width;
            Height = height;
        }

        internal abstract string TextureContentPath { get; set; }

        internal abstract Texture2D Texture { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        protected Texture2D GetTexture()
        {
            return ThakurEscapeGame.GameContent.Load<Texture2D>(TextureContentPath);
        }

        public Vector2 Position { get; set; }

        public Rectangle BoundingRectangle => new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height);

        public float Width { get; protected set; }
        public float Height { get; protected set; }

        internal virtual void Update() { }
        internal abstract void Draw(SpriteBatch spriteBatch);
        internal void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(Texture, BoundingRectangle, color);
            //spriteBatch.Draw(Texture, position, null, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
