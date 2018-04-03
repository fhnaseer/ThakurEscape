using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.Game.GameObjects;
using ThakurEscape.Game.Storage;

namespace ThakurEscape.Game.Screens
{
    internal class BoardScreen : ScreenBase
    {
        public BoardScreen(int level, int boardNumber)
            : base(0, 0, GameContext.Rows - 1, GameContext.Rows)
        {
            LevelNumber = level;
            BoardNumber = boardNumber;
        }

        internal int LevelNumber { get; }
        internal int BoardNumber { get; private set; }

        private Level _level;
        internal GameObjects.LevelStatus LevelStatus => _level.LevelStatus;

        internal Thakur Thakur { get; set; }

        internal void LoadBoard(Thakur thakur)
        {
            Thakur = thakur;
            var boardData = GameStorage.GetBoard(LevelNumber, BoardNumber);
            _level = new Level(Thakur, boardData.BoardData);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Thakur.Draw(this, spriteBatch);
            for (var i = 0; i < _level.Rows; i++)
                for (var j = 0; j < _level.Columns; j++)
                    _level.GetGameObject(i, j)?.Draw(this, spriteBatch);

            spriteBatch.End();
        }

        internal override void HandleInput()
        {
        }

        internal override void Update(GameTime gameTime)
        {
        }

        public void MovePlayer(MovementDirection direction)
        {
            _level.MovePlayer(direction);
            if (_level.LevelStatus == GameObjects.LevelStatus.BoardCompleted)
            {
                BoardNumber++;
                LoadBoard(Thakur);
            }
            if (Thakur.Taaqat == 0)
                RestartLevel();
        }

        private void RestartLevel()
        {
            BoardNumber = 1;
        }
    }
}
