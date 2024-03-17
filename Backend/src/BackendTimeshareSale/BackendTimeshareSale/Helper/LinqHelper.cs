namespace BackendTimeshareSale.Helper
{
    public static class LinqHelper
    {
        public static IEnumerable<T> ToPageList<T>(this IEnumerable<T> src, int curPage, int perPage)
        {
            return src.Skip(curPage * perPage).Take(perPage);
        }
    }
}
