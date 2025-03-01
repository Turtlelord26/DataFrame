using Index.IndexLabels;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface ITimeSeriesCollection<T> : ISeriesCollection<ITimeSeries<T>, T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public DateTime this[int rowNumber, string seriesName] { get; set; }
        public DateTime this[T rowIndex, string seriesName] { get; set; }
    }
}
