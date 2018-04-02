using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ThakurEscape.Game.Storage
{
    public class LevelsStorageData
    {
        [XmlElement]
        public int NumberOfBoards => Levels.Count;

        private List<LevelStorage> _levels;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [XmlArrayItem("Levels")]
        public List<LevelStorage> Levels => _levels ?? (_levels = new List<LevelStorage>());

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
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
        public int NumberOfBoards => Boards.Count;

        [XmlElement]
        public int Taaqat { get; set; }

        private List<BoardStorage> _boards;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [XmlArrayItem("Boards")]
        public List<BoardStorage> Boards => _boards ?? (_boards = new List<BoardStorage>());
    }
}
