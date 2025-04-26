using Index;
using Series.TypedSeries;

namespace Series
{
    public static class SeriesFactory
    {
        public static IBoolSeries<TIndex> MakeSeries<TIndex>(IIndex<TIndex> index, IList<bool> data, string seriesName, bool deepCopyIndex = true, bool deepCopyData = true)
        {
            throw new NotImplementedException();
        }
        public static ICategoricalSeries<TIndex> MakeSeries<TIndex>(IIndex<TIndex> index, IList<int> data, string seriesName, bool deepCopyIndex = true, bool deepCopyData = true)
        {
            throw new NotImplementedException();
        }
        public static INumericSeries<TIndex> MakeSeries<TIndex>(IIndex<TIndex> index, IList<double> data, string seriesName, bool deepCopyIndex = true, bool deepCopyData = true)
        {
            throw new NotImplementedException();
        }
        public static IStringSeries<TIndex> MakeSeries<TIndex>(IIndex<TIndex> index, IList<string> data, string seriesName, bool deepCopyIndex = true, bool deepCopyData = true)
        {
            throw new NotImplementedException();
        }
        public static ITimeSeries<TIndex> MakeSeries<TIndex>(IIndex<TIndex> index, IList<DateTime> data, string seriesName, bool deepCopyIndex = true, bool deepCopyData = true)
        {
            throw new NotImplementedException();
        }
    }
}
