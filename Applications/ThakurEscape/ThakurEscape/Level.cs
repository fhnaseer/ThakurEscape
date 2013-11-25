using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.GameObjects;

namespace ThakurEscape
{
    enum LevelStatus
    {
        InProgress,
        Completed,
        GameOver
    }

    internal class Level
    {
        internal LevelStatus LevelStatus { get; private set; }
        private GameObjectBase[][] _gameObjects;
        private int _movesLeft;
        internal Thakur Player { get; private set; }
        internal int StarsCollected { get; private set; }

        internal int MovesLeft
        {
            get { return _movesLeft; }
            private set
            {
                _movesLeft = value;
                if (_movesLeft == 0)
                    LevelStatus = LevelStatus.GameOver;
            }
        }

        public Level()
        {
            var lines = new List<string>
                            {
                                "################",
                                "#......#########",
                                "#.########.#####",
                                "#.########.#####",
                                "#.#######.....##",
                                "#.#####p...##.##",
                                "#.###########..#",
                                "#.###....#####.#",
                                "#.....##.......#",
                                "################"
                            };
            LoadGameObjects(lines);
            LevelStatus = LevelStatus.InProgress;
            MovesLeft = 15;
        }

        private void LoadGameObjects(List<string> lines)
        {
            _gameObjects = new GameObjectBase[lines.Count][];
            for (int row = 0; row < lines.Count; row++)
            {
                _gameObjects[row] = new GameObjectBase[lines[row].Length];
                for (int column = 0; column < lines[0].Length; column++)
                {
                    if (lines[row][column] == '#')
                        _gameObjects[row][column] = Tile.LoadTiles(lines[row][column], row, column);
                    else if (lines[row][column] == 'p')
                        Player = new Thakur(row, column);
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            var bound1 = _gameObjects.GetUpperBound(0);
            for (var i = 0; i <= bound1; i++)
                for (var j = 0; j < _gameObjects[i].Length; j++)
                {
                    // If there is a visible tile in that position
                    if (_gameObjects[i][j] != null)
                        _gameObjects[i][j].Draw(spriteBatch);
                }
            Player.Draw(spriteBatch);

            spriteBatch.End();
        }

        internal void MovePlayer(KithayChalayHoBadshaho moveDirection)
        {
            var gameObject = GetNextTile((int)Player.RowPosition, (int)Player.ColumnPosition, moveDirection);
            if (CanMovePlayer(gameObject))
            {
                Player.Move(moveDirection);
                MovesLeft--;
            }
        }

        private static bool CanMovePlayer(GameObjectBase gameObject)
        {
            return (gameObject == null);
        }

        private GameObjectBase GetNextTile(int rowPosition, int columnPosition, KithayChalayHoBadshaho moveDirection)
        {
            switch (moveDirection)
            {
                case KithayChalayHoBadshaho.Khabbay:
                    columnPosition--;
                    break;
                case KithayChalayHoBadshaho.Sajjay:
                    columnPosition++;
                    break;
                case KithayChalayHoBadshaho.Utay:
                    rowPosition--;
                    break;
                case KithayChalayHoBadshaho.Thallay:
                    rowPosition++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("moveDirection");
            }
            return _gameObjects[rowPosition][columnPosition];
        }
    }
}
