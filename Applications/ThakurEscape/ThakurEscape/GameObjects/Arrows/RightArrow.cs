namespace ThakurEscape.GameObjects.Arrows
{
    class RightArrow : ArrowBase
    {
        public RightArrow(int rowPosition, int columnPosition)
            : base(rowPosition, columnPosition)
        {
        }

        protected override Simat ArrowDirection
        {
            get { return Simat.Daain; }
        }
    }
}