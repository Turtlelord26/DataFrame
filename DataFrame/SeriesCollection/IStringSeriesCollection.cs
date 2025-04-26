using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface IStringSeriesCollection<TIndex> : ISeriesCollection<TIndex, string>
    {
        public IStringSeries<TIndex> this[string seriesName] { get; set; }

        public IStringSeriesCollection<TIndex> this[IEnumerable<string> seriesNames] { get; }
        public IStringSeriesCollection<TIndex> this[IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IStringSeriesCollection<TIndex> this[Func<string, bool> seriesNameFilter] { get; }
        public IStringSeriesCollection<TIndex> this[Func<IStringSeries<TIndex>, bool> seriesFilter] { get; }
    }
}
