using System;
using System.Collections.Generic;
using System.Linq;
using ThakurEscape.Game.GameObjects.Arrows;
using ThakurEscape.Game.GameObjects.Dirwaazay;
using ThakurEscape.Game.GameObjects.Keys;
using ThakurEscape.Game.GameObjects.Taalay;

namespace ThakurEscape.Game.GameObjects
{
    public enum LevelStatus
    {
        InProgress,
        BoardCompleted,
        Completed,
        GameOver
    }

    public class Level
    {
        public Level(Thakur thakur, IList<string> lines)
        {
            Thakur = thakur;
            LevelStatus = LevelStatus.InProgress;
            LoadGameObjects(lines);
        }

        internal int Rows { get; private set; }
        internal int Columns { get; private set; }

        internal LevelStatus LevelStatus { get; set; }

        private GameObjectBase[][] _gameObjects;

        public GameObjectBase GetGameObject(int row, int column)
        {
            return _gameObjects[row][column];
        }

        private readonly List<DirwaazaBase> _dirwaazay = new List<DirwaazaBase>();
        private readonly List<ChaabiBase> _chaabiyaan = new List<ChaabiBase>();
        private readonly List<TaalaBase> _taalay = new List<TaalaBase>();
        internal Thakur Thakur { get; }
        internal int PaisaCollected { get; private set; }

        private void LoadGameObjects(IList<string> lines)
        {
            Rows = lines.Count;
            _gameObjects = new GameObjectBase[Rows][];
            for (var row = 0; row < Rows; row++)
            {
                Columns = lines[row].Length;
                _gameObjects[row] = new GameObjectBase[Columns];

                for (var column = 0; column < Columns; column++)
                {
                    switch (lines[row][column])
                    {
                        case '#':
                            _gameObjects[row][column] = Brick.LoadBrick(lines[row][column], row, column);
                            break;
                        case 'p':
                            Thakur.Row = column;
                            Thakur.Column = row;
                            break;
                        case 'G':
                            _gameObjects[row][column] = new Paisa(row, column);
                            break;
                        case 'E':
                            _gameObjects[row][column] = new Taaqat(row, column);
                            break;
                        case 'M':
                            _gameObjects[row][column] = new Mout(row, column);
                            break;
                        case '8':
                            _gameObjects[row][column] = new UpArrow(row, column);
                            break;
                        case '2':
                            _gameObjects[row][column] = new DownArrow(row, column);
                            break;
                        case '4':
                            _gameObjects[row][column] = new LeftArrow(row, column);
                            break;
                        case '6':
                            _gameObjects[row][column] = new RightArrow(row, column);
                            break;
                        case 'd':
                            _gameObjects[row][column] = new SabzDirwaaza(row, column);
                            _dirwaazay.Add((DirwaazaBase)_gameObjects[row][column]);
                            break;
                        case 'c':
                            _gameObjects[row][column] = new SabzChaabi(row, column);
                            _chaabiyaan.Add((ChaabiBase)_gameObjects[row][column]);
                            break;
                        case 't':
                            _gameObjects[row][column] = new SabzTaala(row, column);
                            _taalay.Add((TaalaBase)_gameObjects[row][column]);
                            break;
                        case 'D':
                            _gameObjects[row][column] = new LaalDirwaaza(row, column);
                            _dirwaazay.Add((DirwaazaBase)_gameObjects[row][column]);
                            break;
                        case 'C':
                            _gameObjects[row][column] = new LaalChaabi(row, column);
                            _chaabiyaan.Add((ChaabiBase)_gameObjects[row][column]);
                            break;
                        case 'T':
                            _gameObjects[row][column] = new LaalTaala(row, column);
                            _taalay.Add((TaalaBase)_gameObjects[row][column]);
                            break;
                        case 'V':
                            _gameObjects[row][column] = new Victory(row, column);
                            break;
                        case 'N':
                            _gameObjects[row][column] = new NextBoard(row, column);
                            break;
                    }
                }
            }
        }

        public void MovePlayer(MovementDirection direction)
        {
            if (direction == MovementDirection.None) return;
            var gameObject = GetNextTile(direction);
            if (!CanMovePlayer(gameObject, direction)) return;
            CollectGameObject(gameObject, direction);
        }

        private GameObjectBase GetNextTile(MovementDirection moveDirection)
        {
            var rowPosition = Thakur.Row;
            var columnPosition = Thakur.Column;
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
            if (gameObject is Brick || gameObject is DirwaazaBase)
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
                LevelStatus = LevelStatus.BoardCompleted;
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
                PaisaCollected++;

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
                LevelStatus = LevelStatus.Completed;

            EmptyGameObject(gameObject);
        }

        private void EmptyGameObject(GameObjectBase gameObject)
        {
            _gameObjects[gameObject.Row][gameObject.Column] = null;
        }
    }
}
