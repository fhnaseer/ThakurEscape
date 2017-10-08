using Microsoft.Xna.Framework;

namespace ThakurEscape.Windows
{
    internal static class ExtensionMethods
    {
        internal static bool Contains(this Rectangle rectangle, Vector2 position)
        {
            return rectangle.Contains((int)position.X, (int)position.Y);
        }
    }
}
