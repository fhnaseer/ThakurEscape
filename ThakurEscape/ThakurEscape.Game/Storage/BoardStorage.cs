using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ThakurEscape.Game.Storage
{
    internal static class BoardsStorageData
    {
        internal static List<BoardStorage> GetBoards(int levelNumber)
        {
            var boards = new List<BoardStorage>();
            if (levelNumber == 1)
            {
                boards.Add(GetBoard(levelNumber, 1));
                boards.Add(GetBoard(levelNumber, 2));
            }
            return boards;
        }

        internal static BoardStorage GetBoard(int levelNumber, int boardNumber)
        {
            if (levelNumber == 1)
            {
                if (boardNumber == 1)
                    return new BoardStorage
                    {
                        BoardData = new List<string>
                        {
                            "####################",
                            "#p...G.........dEE6#",
                            "######.###.###E#EE##",
                            "###.4..#E..#########",
                            "###.################",
                            "###.################",
                            "###.CT.DDD.....d....N",
                            "#####28###.###M#..##",
                            "##c....#t..#########",
                            "####################"
                        }
                    };
                if (boardNumber == 2)
                    return new BoardStorage
                    {
                        BoardData = new List<string>
                        {
                            "####################",
                            "#p.E..........td..C#",
                            "######.###.###E#.G##",
                            "#G..4..#E..#####GG##",
                            "#G..#..#########GGG#",
                            "#G..#..#############",
                            "#G..4.........TD....N",
                            "#####28###.###M#EE##",
                            "##E....#c..#########",
                            "####################"
                        }
                    };
            }

            throw new NotImplementedException();
        }
    }

    public class BoardStorage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [XmlArrayItem]
        public List<string> BoardData { get; set; }
    }
}
