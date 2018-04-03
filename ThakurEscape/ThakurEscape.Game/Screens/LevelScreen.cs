using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.Game.GameObjects;
using ThakurEscape.Game.Storage;

namespace ThakurEscape.Game.Screens
{
    internal class LevelScreen : FullScreenBase
    {
        public LevelScreen(int levelNumber)
        {
            RestartLevel(levelNumber);
        }

        internal void RestartLevel(int levelNumber)
        {
            var level = GameStorage.GetLevel(levelNumber);
            LevelNumber = level.LevelNumber;
            LevelStatus = LevelStatus.InProgress;
            Thakur = new Thakur(0, 0)
            {
                Taaqat = level.Taaqat,
                Paisa = 0
            };
            _board = new BoardScreen(LevelNumber, 1);
            _board.LoadBoard(Thakur);
            _levelController.Thakur = Thakur;
            _levelController.Board = _board;
        }

        internal int LevelNumber { get; set; }

        private BoardScreen _board;
        private readonly LevelControllerScreen _levelController = new LevelControllerScreen();

        internal Thakur Thakur { get; private set; }

        internal LevelStatus LevelStatus { get; private set; }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            _board.Draw(spriteBatch);
            _levelController.Draw(spriteBatch);
        }

        internal override void Update(GameTime gameTime)
        {
            _levelController.Update(gameTime);

            if (Thakur.Taaqat <= 0)
            {
                LevelStatus = LevelStatus.GameOver;
                // TODO: Display something to restart or go back.
                RestartLevel(LevelNumber);
            }
            if (_board.LevelStatus == LevelStatus.Completed)
            {
                LevelStatus = LevelStatus.Completed;
                // TODO: Display something to load next level or go back.
                LevelNumber++;
                RestartLevel(LevelNumber);
            }
        }

        internal override void HandleInput()
        {
        }
    }
}
