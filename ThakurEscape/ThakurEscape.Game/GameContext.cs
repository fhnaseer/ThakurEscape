namespace ThakurEscape.Game
{
    public class GameContext
    {
        private GameContext() { }

        private static GameContext _instance;
        public static GameContext Instance => _instance ?? (_instance = new GameContext());

        public const int Rows = 11;
        public const int Columns = 20;

        public float GameWidth { get; set; }

        public float GameHeight { get; set; }

        public float GameObjectWidth => GameWidth / Columns;

        public float GameObjectHeight => GameHeight / Rows;



    }
}