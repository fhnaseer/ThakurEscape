namespace ThakurEscape.GameObjects
{
    static class Constants
    {
        public const string GraphicsFolderName = "Graphics";
        public const string TilesFolderName = "Tiles";

        public const string ChaabiImageName = "Chaabi.png";
        public const string DirwaazaImageName = "Dirwaaza.png";
        public const string PaisaImageName = "Paisa.png";
        public const string LeftArrowImageName = "LeftArrow.png";
        public const string MoutImageName = "Mout.png";
        public const string TaalaImageName = "Taala.png";
        public const string TaaqatImageName = "Taaqat.png";
        public const string TopArrowImageName = "TopArrow.png";
        public const string VictoryImageName = "Victory.png";
        public const string NextScreenImageName = "Victory.png";

        public const string BlackAndWhiteEintImageName = "BlockA1.png";

        public static string ChaabiImagePath
        {
            get { return ChaabiImageName.ToPath(GraphicsFolderName); }
        }

        public static string DirwaazaImagePath
        {
            get { return DirwaazaImageName.ToPath(GraphicsFolderName); }
        }

        public static string PaisaImagePath
        {
            get { return PaisaImageName.ToPath(GraphicsFolderName); }
        }

        public static string LeftArrowImagePath
        {
            get { return LeftArrowImageName.ToPath(GraphicsFolderName); }
        }

        public static string MoutImagePath
        {
            get { return MoutImageName.ToPath(GraphicsFolderName); }
        }

        public static string TaalaImagePath
        {
            get { return TaalaImageName.ToPath(GraphicsFolderName); }
        }

        public static string TaaqatImagePath
        {
            get { return TaaqatImageName.ToPath(GraphicsFolderName); }
        }

        public static string TopArrowImagePath
        {
            get { return TopArrowImageName.ToPath(GraphicsFolderName); }
        }

        public static string VictoryImagePath
        {
            get { return VictoryImageName.ToPath(GraphicsFolderName); }
        }

        public static string NextScreenImagePath
        {
            get { return NextScreenImageName.ToPath(GraphicsFolderName); }
        }

        public static string BlackAndWhiteAintImagePath
        {
            get { return BlackAndWhiteEintImageName.ToPath(TilesFolderName); }
        }

        public static string ToPath(this string input, string parentFolder)
        {
            return parentFolder + "\\" + input;
        }
    }
}
