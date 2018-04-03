using Microsoft.Xna.Framework;

namespace ThakurEscape.Game.GameObjects.Arrows
{
    internal abstract class ArrowBase : GameObjectBase
    {
        protected ArrowBase(int row, int column)
            : base(row, column)
        {
        }

        protected abstract Direction ArrowDirection { get; }

        public override int ColumnSpan => 1;

        internal override string TextureContentPath
        {
            get
            {
                if (ArrowDirection == Direction.Right || ArrowDirection == Direction.Left)
                    return Constants.LeftArrowImagePath;
                return Constants.TopArrowImagePath;
            }
            set { }
        }

        public override Color SpriteColor => Color.White;
    }
}
