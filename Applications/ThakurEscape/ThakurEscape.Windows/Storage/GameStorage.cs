//using System.IO;
//using System.Linq;
//using System.Xml.Serialization;

using System.Linq;

namespace ThakurEscape.Windows.Storage
{
    internal static class GameStorage
    {
        //const string FileName = "data.levels";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static void WriteLevels()
        {
            //var dataFile = IsolatedStorageFile.UserStoreForApplication;
            //if (dataFile.FileExists(FileName)) dataFile.DeleteFile(FileName);
            //using (var stream = dataFile.CreateFile(FileName))
            //{
            //    if (stream == null) return;
            //    var serializer = new XmlSerializer(typeof(LevelsStorageData));
            //    var levels = LevelsStorageData.AllLevelsData();
            //    serializer.Serialize(stream, levels);
            //}
        }

        public static LevelStorage GetLevel(int levelNumber)
        {
            return LevelsStorageData.GetLevelData(levelNumber);
            //var dataFile = IsolatedStorageFile.UserStoreForApplication;
            ////if (!dataFile.FileExists(FileName))
            //WriteLevels();
            //using (var stream = dataFile.OpenFile(FileName, FileMode.Open))
            //{
            //    var serializer = new XmlSerializer(typeof(LevelsStorageData));
            //    var levels = (LevelsStorageData)serializer.Deserialize(stream);
            //    return levels.Levels.FirstOrDefault(l => l.LevelNumber == levelNumber);
            //}
        }

        public static BoardStorage GetBoard(int levelNumber, int boardNumber)
        {
            var level = GetLevel(levelNumber);
            return level.Boards.ElementAt(boardNumber - 1);
        }
    }
}
