using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface INumericSeriesCollection<TIndex> : ISeriesCollection<TIndex, double>
    {
        public INumericSeries<TIndex> this[string seriesName] { get; set; }

        public INumericSeriesCollection<TIndex> this[IEnumerable<string> seriesNames] { get; }
        public INumericSeriesCollection<TIndex> this[IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public INumericSeriesCollection<TIndex> this[Func<string, bool> seriesNameFilter] { get; }
        public INumericSeriesCollection<TIndex> this[Func<INumericSeries<TIndex>, bool> seriesFilter] { get; }
    }
}
