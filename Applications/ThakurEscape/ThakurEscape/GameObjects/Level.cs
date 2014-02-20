using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using ThakurEscape.GameObjects.Arrows;
using ThakurEscape.GameObjects.Chaabiyan;
using ThakurEscape.GameObjects.Dirwaazay;
using ThakurEscape.GameObjects.Taalay;

namespace ThakurEscape.GameObjects
{
    enum LevelStatus
    {
        InProgress,
        Completed,
        GameOver
    }

    internal class Level
    {
        internal int Rows { get; private set; }
        internal int Columns { get; private set; }
        internal LevelStatus LevelStatus { get; private set; }
        private GameObjectBase[][] _gameObjects;
        private readonly List<DirwaazaBase> _dirwaazay = new List<DirwaazaBase>();
        private readonly List<ChaabiBase> _chaabiyaan = new List<ChaabiBase>();
        private readonly List<TaalaBase> _taalay = new List<TaalaBase>();
        internal Thakur Thakur { get; private set; }
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
                            _gameObjects[row][column] = Eint.LoadEint(lines[row][column], row, column);
                            break;
                        case 'p':
                            Thakur = new Thakur(row, column);
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
                            _dirwaazay.Add(_gameObjects[row][column] as DirwaazaBase);
                            break;
                        case 'c':
                            _gameObjects[row][column] = new SabzChaabi(row, column);
                            _chaabiyaan.Add(_gameObjects[row][column] as ChaabiBase);
                            break;
                        case 't':
                            _gameObjects[row][column] = new SabzTaala(row, column);
                            _taalay.Add(_gameObjects[row][column] as TaalaBase);
                            break;
                        case 'D':
                            _gameObjects[row][column] = new LaalDirwaaza(row, column);
                            _dirwaazay.Add(_gameObjects[row][column] as DirwaazaBase);
                            break;
                        case 'C':
                            _gameObjects[row][column] = new LaalChaabi(row, column);
                            _chaabiyaan.Add(_gameObjects[row][column] as ChaabiBase);
                            break;
                        case 'T':
                            _gameObjects[row][column] = new LaalTaala(row, column);
                            _taalay.Add(_gameObjects[row][column] as TaalaBase);
                            break;
                        case 'V':
                            _gameObjects[row][column] = new Victory(row, column);
                            break;
                    }
                }
            }
        }

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

        internal void MovePlayer(KidherChalayHoBadshaho kidher)
        {
            var gameObject = GetNextTile((int)Thakur.RowPosition, (int)Thakur.ColumnPosition, kidher);
            if (!CanMovePlayer(gameObject, kidher)) return;
            CollectGameObject(gameObject, kidher);
        }

        private GameObjectBase GetNextTile(int rowPosition, int columnPosition, KidherChalayHoBadshaho moveDirection)
        {
            switch (moveDirection)
            {
                case KidherChalayHoBadshaho.Baain:
                    columnPosition--;
                    break;
                case KidherChalayHoBadshaho.Daain:
                    columnPosition++;
                    break;
                case KidherChalayHoBadshaho.Ooper:
                    rowPosition--;
                    break;
                case KidherChalayHoBadshaho.Neechay:
                    rowPosition++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("moveDirection");
            }
            return _gameObjects[rowPosition][columnPosition];
        }

        private bool CanMovePlayer(GameObjectBase gameObject, KidherChalayHoBadshaho kidher)
        {
            if (gameObject == null)
                return true;
            if (gameObject is Eint || gameObject is DirwaazaBase)
                return false;

            if (!(gameObject is ArrowBase || gameObject is TaalaBase))
                return true;
            if (gameObject is LeftArrow && kidher == KidherChalayHoBadshaho.Baain)
                return true;
            if (gameObject is RightArrow && kidher == KidherChalayHoBadshaho.Daain)
                return true;
            if (gameObject is DownArrow && kidher == KidherChalayHoBadshaho.Neechay)
                return true;
            if (gameObject is UpArrow && kidher == KidherChalayHoBadshaho.Ooper)
                return true;
            if (gameObject is SabzTaala && Thakur.HasSabzChaabi)
                return true;
            if (gameObject is LaalTaala && Thakur.HasLaalChaabi)
                return true;

            return false;
        }

        private void CollectGameObject(GameObjectBase gameObject, KidherChalayHoBadshaho kidher)
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

        private void EmptyGameObject(GameObjectBase gameObject)
        {
            _gameObjects[(int)gameObject.RowPosition][(int)gameObject.ColumnPosition] = null;
        }
    }
}
