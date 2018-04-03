using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects
{
    internal class NextBoard : GameObjectBase
    {
        public NextBoard(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        internal override string TextureContentPath
        {
            get => Constants.NextScreenImagePath;
            set { }
        }
    }
}
