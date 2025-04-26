using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface ICategoricalSeriesCollection<TIndex> : ISeriesCollection<TIndex, int>
    {
        public ICategoricalSeries<TIndex> this[string seriesName] { get; set; }

        public ICategoricalSeriesCollection<TIndex> this[IEnumerable<string> seriesNames] { get; }
        public ICategoricalSeriesCollection<TIndex> this[IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public ICategoricalSeriesCollection<TIndex> this[Func<string, bool> seriesNameFilter] { get; }
        public ICategoricalSeriesCollection<TIndex> this[Func<ICategoricalSeries<TIndex>, bool> seriesFilter] { get; }
    }
}
