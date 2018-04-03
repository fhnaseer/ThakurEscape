namespace ThakurEscape.Game.GameObjects.Keys
{
    public abstract class ChaabiBase : GameObjectBase
    {
        protected ChaabiBase(int row, int column)
            : base(row, column)
        {
        }

        public abstract ChaabiType ChaabiType { get; }

        internal override string TextureContentPath
        {
            get => Constants.ChaabiImagePath;
            set { }
        }
    }
}
