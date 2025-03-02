using Index;
using Index.IndexLabels;
using Series.TypedSeries;

namespace Series
{
    public interface ISeries<T> where T : IIndexLabel
    {
        //Section
        //Properties

        public IIndex<T> Index { get; set; }

        public int Count { get; }

        public string Name { get; set; }

        //Section
        //Series Builders
        //Used by typed series to support series creation through function application. For maximum versatility, each typed series supports transformation to all others.

        internal IBoolSeries<T> MakeSeriesPreservingIndex(IIndex<T> index, IList<bool> data, string seriesName);
        internal ICategoricalSeries<T> MakeSeriesPreservingIndex(IIndex<T> index, IList<int> data, string seriesName);
        internal INumericSeries<T> MakeSeriesPreservingIndex(IIndex<T> index, IList<double> data, string seriesName);
        internal IStringSeries<T> MakeSeriesPreservingIndex(IIndex<T> index, IList<string> data, string seriesName);
        internal ITimeSeries<T> MakeSeriesPreservingIndex(IIndex<T> index, IList<DateTime> data, string seriesName);
    }
}
