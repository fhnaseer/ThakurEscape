namespace ThakurEscape.Windows.GameObjects
{
    static class Constants
    {
        public const string GraphicsFolderName = "Graphics";
        public const string TilesFolderName = "Tiles";
        public const string ThakurFolderName = "Thakur";
        public const string FontsFolderName = "Fonts";

        public const string ChaabiImageName = "Chaabi";
        public const string DirwaazaImageName = "Dirwaaza";
        public const string PaisaImageName = "Paisa";
        public const string LeftArrowImageName = "LeftArrow";
        public const string MoutImageName = "Mout";
        public const string TaalaImageName = "Taala";
        public const string TaaqatImageName = "Taaqat";
        public const string TopArrowImageName = "TopArrow";
        public const string VictoryImageName = "Victory";
        public const string NextScreenImageName = "Victory";

        public const string NewGameImageName = "NewGame";
        public const string ExitGameImageName = "ExitGame";

        public const string BlackAndWhiteEintImageName = "BlockA1";

        public const string ThakurNormalImageName = "Thakur";

        public const string SegoeImageName = "Segoe";

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

        public static string NewGameImagePath
        {
            get { return NewGameImageName.ToPath(GraphicsFolderName); }
        }

        public static string ExitGameImagePath
        {
            get { return ExitGameImageName.ToPath(GraphicsFolderName); }
        }

        public static string BlackAndWhiteAintImagePath
        {
            get { return BlackAndWhiteEintImageName.ToPath(TilesFolderName); }
        }

        public static string ThakurNormalImagePath
        {
            get { return ThakurNormalImageName.ToPath(ThakurFolderName); }
        }

        public static string SegoeImagePath
        {
            get { return SegoeImageName.ToPath(FontsFolderName); }
        }

        public static string ToPath(this string input, string parentFolder)
        {
            return parentFolder + "\\" + input;
        }
    }
}
