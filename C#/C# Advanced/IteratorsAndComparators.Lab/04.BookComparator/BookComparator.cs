using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            int result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                result = -(x.Year.CompareTo(y.Year));
            }

            return result;
        }
    }
}
