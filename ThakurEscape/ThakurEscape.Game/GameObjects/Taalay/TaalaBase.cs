namespace ThakurEscape.Game.GameObjects.Taalay
{
    public abstract class TaalaBase : GameObjectBase
    {
        protected TaalaBase(int row, int column)
            : base(row, column)
        {
        }

        public abstract TaalaType TaalaType { get; }

        internal override string TextureContentPath
        {
            get => Constants.TaalaImagePath;
            set { }
        }
    }
}
