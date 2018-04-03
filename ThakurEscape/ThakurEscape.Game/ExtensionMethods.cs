using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.Game.GameObjects;
using ThakurEscape.Game.Screens;

namespace ThakurEscape.Game
{
    internal static class ExtensionMethods
    {
        public static bool Contains(this GameObjectBase gameObject, ScreenBase screen, Vector2 position)
        {
            return GetBoundingRectangle(screen, gameObject, GameContext.Instance).Contains((int)position.X, (int)position.Y);
        }

        public static bool Contains(this GameObjectBase gameObject, ScreenBase screen, Point position)
        {
            return GetBoundingRectangle(screen, gameObject, GameContext.Instance).Contains(position.X, position.Y);
        }

        public static Rectangle GetBoundingRectangle(ScreenBase screen, GameObjectBase gameObject, GameContext gameContext)
        {
            var startX = (int)((screen.OriginX + gameObject.Column) * gameContext.GameObjectWidth);
            var startY = (int)((screen.OriginY + gameObject.Row) * gameContext.GameObjectHeight);
            var width = (int)gameContext.GameObjectWidth * gameObject.ColumnSpan;
            var height = (int)gameContext.GameObjectHeight * gameObject.RowSpan;
            return new Rectangle(startX, startY, width, height);
        }

        public static Rectangle GetBoundingRectangle(ScreenBase screen, GameContext gameContext)
        {
            var startX = (int)(screen.OriginX * gameContext.GameObjectWidth);
            var startY = (int)(screen.OriginY * gameContext.GameObjectHeight);
            var width = (int)gameContext.GameObjectWidth * screen.Columns;
            var height = (int)gameContext.GameObjectHeight * screen.Rows;
            return new Rectangle(startX, startY, width, height);
        }

        public static void Draw(this GameObjectBase gameObject, ScreenBase screen, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gameObject.Texture, GetBoundingRectangle(screen, gameObject, GameContext.Instance), null, gameObject.SpriteColor, 0f, new Vector2(), gameObject.SpriteEffect, 0);
        }
    }
}
