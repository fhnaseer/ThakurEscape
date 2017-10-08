using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.Windows.GameObjects;
using ThakurEscape.Windows.GameObjects.Arrows;
using ThakurEscape.Windows.GameObjects.Dirwaazay;
using ThakurEscape.Windows.GameObjects.Keys;
using ThakurEscape.Windows.GameObjects.Taalay;
using ThakurEscape.Windows.Storage;

namespace ThakurEscape.Windows.Screens
{
    internal class BoardScreen : ScreenBase
    {
        public BoardScreen(int level, int boardNumber)
            : base(0, 0, ThakurEscapeGame.GameWidth, GameObjectHeight * 10)
        {
            LevelNumber = level;
            BoardNumber = boardNumber;
        }

        internal int LevelNumber { get; private set; }
        internal int BoardNumber { get; private set; }

        internal int Rows { get; private set; }
        internal int Columns { get; private set; }
        private GameObjectBase[][] _gameObjects;
        internal static float GameObjectWidth = ThakurEscapeGame.GameWidth / 20;
        internal static float GameObjectHeight = ThakurEscapeGame.GameHeight / 11;

        private readonly List<DirwaazaBase> _dirwaazay = new List<DirwaazaBase>();
        private readonly List<ChaabiBase> _chaabiyaan = new List<ChaabiBase>();
        private readonly List<TaalaBase> _taalay = new List<TaalaBase>();
        internal Thakur Thakur { get; set; }

        internal void LoadBoard(Thakur thakur)
        {
            Thakur = thakur;
            var boardData = GameStorage.GetBoard(LevelNumber, BoardNumber);
            LoadGameObjects(boardData.BoardData);
        }

        internal static Vector2 GetPositionFromIndex(Vector2 basePosition, int row, int column)
        {
            return new Vector2(basePosition.X + column * GameObjectWidth,
                basePosition.Y + row * GameObjectHeight);
        }

        private static int GetColumnIndexFromPostiion(Vector2 relativePosition, Vector2 basePosition)
        {
            return (int)Math.Round((relativePosition.X - basePosition.X) / GameObjectWidth);
        }

        private static int GetRowIndexFromPostiion(Vector2 relativePosition, Vector2 basePosition)
        {
            return (int)Math.Round((relativePosition.Y - basePosition.Y) / GameObjectHeight);
        }

        private void LoadGameObjects(IReadOnlyList<string> lines)
        {
            Rows = lines.Count;
            _gameObjects = new GameObjectBase[Rows][];
            for (var row = 0; row < Rows; row++)
            {
                Columns = lines[row].Length;
                _gameObjects[row] = new GameObjectBase[Columns];

                for (var column = 0; column < Columns; column++)
                {
                    var relativePosition = GetPositionFromIndex(Position, row, column);
                    switch (lines[row][column])
                    {
                        case '#':
                            _gameObjects[row][column] = Eint.LoadEint(lines[row][column],
                                relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case 'p':
                            Thakur.Position = relativePosition;
                            break;
                        case 'G':
                            _gameObjects[row][column] = new Paisa(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case 'E':
                            _gameObjects[row][column] = new Taaqat(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case 'M':
                            _gameObjects[row][column] = new Mout(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case '8':
                            _gameObjects[row][column] = new UpArrow(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case '2':
                            _gameObjects[row][column] = new DownArrow(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case '4':
                            _gameObjects[row][column] = new LeftArrow(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case '6':
                            _gameObjects[row][column] = new RightArrow(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case 'd':
                            _gameObjects[row][column] = new SabzDirwaaza(relativePosition, GameObjectWidth, GameObjectHeight);
                            _dirwaazay.Add(_gameObjects[row][column] as DirwaazaBase);
                            break;
                        case 'c':
                            _gameObjects[row][column] = new SabzChaabi(relativePosition, GameObjectWidth, GameObjectHeight);
                            _chaabiyaan.Add(_gameObjects[row][column] as ChaabiBase);
                            break;
                        case 't':
                            _gameObjects[row][column] = new SabzTaala(relativePosition, GameObjectWidth, GameObjectHeight);
                            _taalay.Add(_gameObjects[row][column] as TaalaBase);
                            break;
                        case 'D':
                            _gameObjects[row][column] = new LaalDirwaaza(relativePosition, GameObjectWidth, GameObjectHeight);
                            _dirwaazay.Add(_gameObjects[row][column] as DirwaazaBase);
                            break;
                        case 'C':
                            _gameObjects[row][column] = new LaalChaabi(relativePosition, GameObjectWidth, GameObjectHeight);
                            _chaabiyaan.Add(_gameObjects[row][column] as ChaabiBase);
                            break;
                        case 'T':
                            _gameObjects[row][column] = new LaalTaala(relativePosition, GameObjectWidth, GameObjectHeight);
                            _taalay.Add(_gameObjects[row][column] as TaalaBase);
                            break;
                        case 'V':
                            _gameObjects[row][column] = new Victory(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                        case 'N':
                            _gameObjects[row][column] = new NextBoard(relativePosition, GameObjectWidth, GameObjectHeight);
                            break;
                    }
                }
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            Thakur.Draw(spriteBatch);
            var bound1 = _gameObjects.GetUpperBound(0);
            for (var row = 0; row <= bound1; row++)
                for (var column = 0; column < _gameObjects[row].Length; column++)
                {
                    // If there is a visible tile in that position
                    if (_gameObjects[row][column] != null)
                        _gameObjects[row][column].Draw(spriteBatch);
                }
        }

        internal override void HandleInput()
        {
        }

        internal override void Update(GameTime gameTime)
        {
        }

        internal void MovePlayer(MovementDirection kidher)
        {
            if (kidher == MovementDirection.None) return;
            var gameObject = GetNextTile(Thakur.Position, kidher);
            if (!CanMovePlayer(gameObject, kidher)) return;
            CollectGameObject(gameObject, kidher);
            if (Thakur.Taaqat <= 0)
                RestartLevel();
        }

        private void RestartLevel()
        {
            BoardNumber = 1;
        }

        private GameObjectBase GetNextTile(Vector2 position, MovementDirection moveDirection)
        {
            var rowPosition = GetRowIndexFromPostiion(position, Position);
            var columnPosition = GetColumnIndexFromPostiion(position, Position);
            switch (moveDirection)
            {
                case MovementDirection.Left:
                    columnPosition--;
                    break;
                case MovementDirection.Right:
                    columnPosition++;
                    break;
                case MovementDirection.Up:
                    rowPosition--;
                    break;
                case MovementDirection.Down:
                    rowPosition++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moveDirection));
            }
            return _gameObjects[rowPosition][columnPosition];
        }

        private bool CanMovePlayer(GameObjectBase gameObject, MovementDirection kidher)
        {
            if (gameObject == null)
                return true;
            if (gameObject is Eint || gameObject is DirwaazaBase)
                return false;

            if (!(gameObject is ArrowBase || gameObject is TaalaBase))
                return true;
            if (gameObject is LeftArrow && kidher == MovementDirection.Left)
                return true;
            if (gameObject is RightArrow && kidher == MovementDirection.Right)
                return true;
            if (gameObject is DownArrow && kidher == MovementDirection.Down)
                return true;
            if (gameObject is UpArrow && kidher == MovementDirection.Up)
                return true;
            if (gameObject is SabzTaala && Thakur.HasSabzChaabi)
                return true;
            if (gameObject is LaalTaala && Thakur.HasLaalChaabi)
                return true;

            return false;
        }

        private void CollectGameObject(GameObjectBase gameObject, MovementDirection kidher)
        {
            if (gameObject is NextBoard)
            {
                BoardNumber++;
                LoadBoard(Thakur);
                return;
            }

            Thakur.Move(kidher);
            if (gameObject == null)
                return;

            if (gameObject is ArrowBase)
            {
                Thakur.Move(kidher);
                return;
            }

            if (gameObject is Taaqat)
                Thakur.Taaqat += Taaqat.Steps;

            if (gameObject is SabzChaabi)
                Thakur.HasSabzChaabi = true;

            if (gameObject is LaalChaabi)
                Thakur.HasLaalChaabi = true;

            if (gameObject is Paisa)
                Thakur.Paisa++;

            if (gameObject is SabzTaala && Thakur.HasSabzChaabi)
            {
                foreach (var sabzDirwaaza in _dirwaazay.OfType<SabzDirwaaza>())
                    EmptyGameObject(sabzDirwaaza);
                Thakur.HasSabzChaabi = false;
            }

            if (gameObject is LaalTaala && Thakur.HasLaalChaabi)
            {
                foreach (var laalDirwaaza in _dirwaazay.OfType<LaalDirwaaza>())
                    EmptyGameObject(laalDirwaaza);
                Thakur.HasLaalChaabi = false;
            }

            if (gameObject is Victory)
                Thakur.HasReachedExit = true;

            EmptyGameObject(gameObject);
        }

        private void EmptyGameObject(GameObjectBase gameObject)
        {
            var rowPosition = GetRowIndexFromPostiion(gameObject.Position, Position);
            var columnPosition = GetColumnIndexFromPostiion(gameObject.Position, Position);
            _gameObjects[rowPosition][columnPosition] = null;
        }
    }
}
