using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface IBoolSeriesCollection<TIndex> : ISeriesCollection<TIndex, bool>
    {
        public IBoolSeries<TIndex> this[string seriesName] { get; set; }

        public IBoolSeriesCollection<TIndex> this[IEnumerable<string> seriesNames] { get; }
        public IBoolSeriesCollection<TIndex> this[IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IBoolSeriesCollection<TIndex> this[Func<string, bool> seriesNameFilter] { get; }
        public IBoolSeriesCollection<TIndex> this[Func<IBoolSeries<TIndex>, bool> seriesFilter] { get; }
    }
}
