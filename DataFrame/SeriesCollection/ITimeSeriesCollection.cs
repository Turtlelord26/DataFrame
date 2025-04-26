using Series;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface ITimeSeriesCollection<TIndex> : ISeriesCollection<TIndex, DateTime>
    {
        public ITimeSeries<TIndex> this[string seriesName] { get; set; }

        public ITimeSeriesCollection<TIndex> this[IEnumerable<string> seriesNames] { get; }
        public ITimeSeriesCollection<TIndex> this[IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public ITimeSeriesCollection<TIndex> this[Func<string, bool> seriesNameFilter] { get; }
        public ITimeSeriesCollection<TIndex> this[Func<ITimeSeries<TIndex>, bool> seriesFilter] { get; }
    }
}
