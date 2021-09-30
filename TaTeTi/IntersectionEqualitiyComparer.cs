using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TaTeTi
{
    public class IntersectionEqualitiyComparer : IEqualityComparer<Point>
    {
        public bool Equals([AllowNull] Point x, [AllowNull] Point y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode([DisallowNull] Point obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    }
}