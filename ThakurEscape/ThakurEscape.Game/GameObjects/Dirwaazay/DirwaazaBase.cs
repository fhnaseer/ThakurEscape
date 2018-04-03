namespace ThakurEscape.Game.GameObjects.Dirwaazay
{
    public abstract class DirwaazaBase : GameObjectBase
    {
        protected DirwaazaBase(int row, int column)
            : base(row, column)
        {
        }
        public abstract DirwaazaType DirwaazaType { get; }

        internal override string TextureContentPath
        {
            get => Constants.DirwaazaImagePath;
            set { }
        }
    }
}
