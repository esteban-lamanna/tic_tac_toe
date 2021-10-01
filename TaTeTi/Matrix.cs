using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaTeTi
{
    public class Matrix
    {
        static readonly IList<Point> _arrayHorizontalFirstColumn = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0) };
        static readonly IList<Point> _arrayHorizontalSecondColumn = new List<Point> { new Point(0, 1), new Point(1, 1), new Point(2, 1) };
        static readonly IList<Point> _arrayHorizontalThirdColumn = new List<Point> { new Point(0, 2), new Point(1, 2), new Point(2, 2) };
        static readonly IList<Point> _arrayVerticalFirstColumn = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0) };
        static readonly IList<Point> _arrayVerticalSecondColumn = new List<Point> { new Point(0, 1), new Point(1, 1), new Point(2, 1) };
        static readonly IList<Point> _arrayVerticalThirdColumn = new List<Point> { new Point(0, 2), new Point(1, 2), new Point(2, 2) };
        static readonly IList<Point> _arrayFirstDiagonalColumn = new List<Point> { new Point(0, 0), new Point(1, 1), new Point(2, 2) };
        static readonly IList<Point> _arraySecondDiagonalColumn = new List<Point> { new Point(0, 2), new Point(1, 1), new Point(2, 0) };

        static readonly IList<IList<Point>> PossibleWinningCombinations = new List<IList<Point>>()
        {
          _arrayFirstDiagonalColumn,
          _arraySecondDiagonalColumn,
          _arrayHorizontalFirstColumn,
          _arrayHorizontalSecondColumn,
          _arrayHorizontalThirdColumn,
          _arrayVerticalFirstColumn,
          _arrayVerticalSecondColumn,
          _arrayVerticalThirdColumn,
        };

        public string Draw()
        {
            var blder = new StringBuilder();

            for (int y = 0; y < 3; y++)
            {
                blder.AppendLine();

                blder.Append($"Line {y}    ");

                for (int x = 0; x < 3; x++)
                {
                    if (x > 0)
                        blder.Append($"   ");

                    var item = Grid[x, y];

                    if (item == null)
                    {
                        blder.Append($"   ");
                        continue;
                    }

                    if (item.Player == Players.PlayerOne)
                    {
                        blder.Append($" X ");
                        continue;
                    }

                    blder.Append($" O ");
                }
            }

            return blder.ToString();
        }

        public Mark[,] Grid = new Mark[3, 3];

        public bool ValidatePositionAlreadyInUse(Mark currentMark)
        {
            var currentValue = Grid[currentMark.X, currentMark.Y];

            return currentValue != null;
        }

        public bool ComparePlayerMarksWithPossibleWinningCombination(IList<Mark> marks)
        {
            foreach (var combination in PossibleWinningCombinations)
            {
                var intersectionItems = combination.Intersect(marks, new IntersectionEqualitiyComparer());

                if (intersectionItems.Count() == 3)
                    return true;
            }

            return false;
        }

        public void PutMarkInMatrix(Mark mark)
        {
            Grid[mark.X, mark.Y] = mark;
        }

        public IList<Mark> GetPlayerMarks(Player player)
        {
            var list = new List<Mark>();

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    var currentItem = Grid[x, y];
                    if (currentItem == null)
                        continue;

                    if (currentItem.Player != player)
                        continue;

                    list.Add(currentItem);
                }
            }

            return list;
        }
    }
}