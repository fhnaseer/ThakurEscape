namespace ThakurEscape.GameObjects
{
    internal static class Constants
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

        public static string ChaabiImagePath => ChaabiImageName.ToPath(GraphicsFolderName);

        public static string DirwaazaImagePath => DirwaazaImageName.ToPath(GraphicsFolderName);

        public static string PaisaImagePath => PaisaImageName.ToPath(GraphicsFolderName);

        public static string LeftArrowImagePath => LeftArrowImageName.ToPath(GraphicsFolderName);

        public static string MoutImagePath => MoutImageName.ToPath(GraphicsFolderName);

        public static string TaalaImagePath => TaalaImageName.ToPath(GraphicsFolderName);

        public static string TaaqatImagePath => TaaqatImageName.ToPath(GraphicsFolderName);

        public static string TopArrowImagePath => TopArrowImageName.ToPath(GraphicsFolderName);

        public static string VictoryImagePath => VictoryImageName.ToPath(GraphicsFolderName);

        public static string NextScreenImagePath => NextScreenImageName.ToPath(GraphicsFolderName);

        public static string NewGameImagePath => NewGameImageName.ToPath(GraphicsFolderName);

        public static string ExitGameImagePath => ExitGameImageName.ToPath(GraphicsFolderName);

        public static string BlackAndWhiteAintImagePath => BlackAndWhiteEintImageName.ToPath(TilesFolderName);

        public static string ThakurNormalImagePath => ThakurNormalImageName.ToPath(ThakurFolderName);

        public static string SegoeImagePath => SegoeImageName.ToPath(FontsFolderName);

        public static string ToPath(this string input, string parentFolder)
        {
            return parentFolder + "\\" + input;
        }
    }
}
