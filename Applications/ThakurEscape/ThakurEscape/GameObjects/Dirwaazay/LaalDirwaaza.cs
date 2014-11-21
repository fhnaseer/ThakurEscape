using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThakurEscape.GameObjects.Dirwaazay
{
    class LaalDirwaaza : DirwaazaBase
    {
        //public LaalDirwaaza(float x, float y, float width, float height)
        //    : this (new Vector2(x,y), width, height)
        //{
        //}

        public LaalDirwaaza(Vector2 position, float width, float height) 
            : base(position, width, height)
        {
        }

        internal override Texture2D Texture
        {
            get { return StaticTexture ?? (StaticTexture = GetTexture()); }
        }

        internal static Texture2D StaticTexture { get; set; }

        protected override Color Color
        {
            get { return Color.Red; }
        }

        protected override DirwaazaType DirwaazaType
        {
            get { return DirwaazaType.Laal; }
        }
    }
}
