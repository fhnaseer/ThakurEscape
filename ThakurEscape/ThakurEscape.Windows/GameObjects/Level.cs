using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.GameObjects.Arrows;
using ThakurEscape.GameObjects.Dirwaazay;
using ThakurEscape.GameObjects.Keys;
using ThakurEscape.GameObjects.Taalay;
using ThakurEscape.Screens;

namespace ThakurEscape.GameObjects
{
    public enum LevelStatus
    {
        InProgress,
        Completed,
        GameOver
    }

    public class Level
    {
        internal int Rows { get; private set; }
        internal int Columns { get; private set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LevelStatus LevelStatus { get; }
        private GameObjectBase[][] _gameObjects;
        private readonly List<DirwaazaBase> _dirwaazay = new List<DirwaazaBase>();
        private readonly List<ChaabiBase> _chaabiyaan = new List<ChaabiBase>();
        private readonly List<TaalaBase> _taalay = new List<TaalaBase>();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Thakur Thakur { get; private set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal int PaisaCollected { get; private set; }
        public Level()
        {
            var lines = new List<string>
            {
                "####################",
                "#p...G.........dEE6#",
                "######.###.###E#EE##",
                "###.4..#E..#########",
                "###.################",
                "###.################",
                "###.CT.DDD.....d....",
                "#####28###.###M#..##",
                "##c....#t..#########",
                "####################"
            };
            LoadGameObjects(lines);
            LevelStatus = LevelStatus.InProgress;
        }

        private void LoadGameObjects(List<string> lines)
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
                            _gameObjects[row][column] = Eint.LoadEint(lines[row][column], row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case 'p':
                            Thakur = new Thakur(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case 'G':
                            _gameObjects[row][column] = new Paisa(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case 'E':
                            _gameObjects[row][column] = new Taaqat(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case 'M':
                            _gameObjects[row][column] = new Mout(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case '8':
                            _gameObjects[row][column] = new UpArrow(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case '2':
                            _gameObjects[row][column] = new DownArrow(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case '4':
                            _gameObjects[row][column] = new LeftArrow(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case '6':
                            _gameObjects[row][column] = new RightArrow(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                        case 'd':
                            _gameObjects[row][column] = new SabzDirwaaza(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            _dirwaazay.Add((DirwaazaBase)_gameObjects[row][column]);
                            break;
                        case 'c':
                            _gameObjects[row][column] = new SabzChaabi(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            _chaabiyaan.Add((ChaabiBase)_gameObjects[row][column]);
                            break;
                        case 't':
                            _gameObjects[row][column] = new SabzTaala(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            _taalay.Add((TaalaBase)_gameObjects[row][column]);
                            break;
                        case 'D':
                            _gameObjects[row][column] = new LaalDirwaaza(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            _dirwaazay.Add((DirwaazaBase)_gameObjects[row][column]);
                            break;
                        case 'C':
                            _gameObjects[row][column] = new LaalChaabi(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            _chaabiyaan.Add((ChaabiBase)_gameObjects[row][column]);
                            break;
                        case 'T':
                            _gameObjects[row][column] = new LaalTaala(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            _taalay.Add((TaalaBase)_gameObjects[row][column]);
                            break;
                        case 'V':
                            _gameObjects[row][column] = new Victory(row, column, BoardScreen.GameObjectWidth, BoardScreen.GameObjectHeight);
                            break;
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            Thakur.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            var bound1 = _gameObjects.GetUpperBound(0);
            for (var i = 0; i <= bound1; i++)
                for (var j = 0; j < _gameObjects[i].Length; j++)
                {
                    // If there is a visible tile in that position
                    if (_gameObjects[i][j] != null)
                        _gameObjects[i][j].Draw(spriteBatch);
                }

            spriteBatch.End();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void MovePlayer(MovementDirection kidher)
        {
            var gameObject = GetNextTile((int)Thakur.Position.Y, (int)Thakur.Position.X, kidher);
            if (!CanMovePlayer(gameObject, kidher)) return;
            CollectGameObject(gameObject, kidher);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private GameObjectBase GetNextTile(int rowPosition, int columnPosition, MovementDirection moveDirection)
        {
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void CollectGameObject(GameObjectBase gameObject, MovementDirection kidher)
        {
            Thakur.Move(kidher);
            if (gameObject == null)
                return;

            if (gameObject is ArrowBase)
            {
                Thakur.Move(kidher);
                return;
            }

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

            EmptyGameObject(gameObject);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void EmptyGameObject(GameObjectBase gameObject)
        {
            _gameObjects[(int)gameObject.Position.Y][(int)gameObject.Position.X] = null;
        }
    }
}
