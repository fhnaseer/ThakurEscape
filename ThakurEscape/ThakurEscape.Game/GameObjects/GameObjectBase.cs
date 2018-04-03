using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects
{
    public abstract class GameObjectBase
    {
        protected GameObjectBase(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public virtual int ColumnSpan { get; protected set; } = 1;

        public virtual int RowSpan { get; protected set; } = 1;

        internal abstract string TextureContentPath { get; set; }

        internal abstract Texture2D Texture { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        protected Texture2D GetTexture()
        {
            return ThakurEscapeGame.GameContent.Load<Texture2D>(TextureContentPath);
        }

        public virtual SpriteEffects SpriteEffect => SpriteEffects.None;

        public virtual Color SpriteColor => Color.Black;
    }
}
