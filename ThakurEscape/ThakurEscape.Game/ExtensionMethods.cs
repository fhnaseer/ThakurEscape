using Microsoft.Xna.Framework;

namespace ThakurEscape.Game
{
    public static class ExtensionMethods
    {
        public static bool Contains(this Rectangle rectangle, Vector2 position)
        {
            return rectangle.Contains((int)position.X, (int)position.Y);
        }
    }
}
