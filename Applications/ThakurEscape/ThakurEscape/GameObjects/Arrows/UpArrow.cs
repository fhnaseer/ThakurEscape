namespace ThakurEscape.GameObjects.Arrows
{
    class UpArrow : ArrowBase
    {
        public UpArrow(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected override Simat ArrowDirection
        {
            get { return Simat.Ooper; }
        }
    }
}
