using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.Game.GameObjects.Menus
{
    public class ExitGame : GameObjectBase
    {
        public ExitGame(int row, int column)
            : base(row, column)
        {
        }

        internal override Texture2D Texture => StaticTexture ?? (StaticTexture = GetTexture());

        internal static Texture2D StaticTexture { get; set; }

        internal override string TextureContentPath
        {
            get => Constants.ExitGameImagePath;
            set { }
        }

        public override int ColumnSpan => 2;
    }
}
