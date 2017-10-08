using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ThakurEscape.Windows.Storage
{
    public class LevelsStorageData
    {
        [XmlElement]
        public int NumberOfBoards { get { return Levels.Count; } }

        private List<LevelStorage> _levels;
        [XmlArrayItem("Levels")]
        public List<LevelStorage> Levels
        {
            get { return _levels ?? (_levels = new List<LevelStorage>()); }
        }

        internal static LevelsStorageData AllLevelsData()
        {
            var levelsData = new LevelsStorageData();
            levelsData.Levels.Add(GetLevelData(1));
            return levelsData;
        }

        internal static LevelStorage GetLevelData(int levelNumber)
        {
            if (levelNumber == 1)
            {
                var level = new LevelStorage
                {
                    LevelNumber = 1,
                    Taaqat = 25,
                };
                var boards = BoardsStorageData.GetBoards(levelNumber);
                foreach (var board in boards)
                    level.Boards.Add(board);
                return level;
            }

            throw new NotImplementedException();
        }
    }

    public class LevelStorage
    {
        [XmlElement]
        public int LevelNumber { get; set; }

        [XmlElement]
        public int NumberOfBoards { get { return Boards.Count; } }

        [XmlElement]
        public int Taaqat { get; set; }

        private List<BoardStorage> _boards;
        [XmlArrayItem("Boards")]
        public List<BoardStorage> Boards
        {
            get { return _boards ?? (_boards = new List<BoardStorage>()); }
        }
    }
}
