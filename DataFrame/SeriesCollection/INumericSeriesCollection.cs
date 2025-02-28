using Index.IndexLabels;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface INumericSeriesCollection<T> : ISeriesCollection<INumericSeries<T>, T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public double this[int rowNumber, string seriesName] { get; set; }
        public double this[IIndexLabel rowName, string seriesName] { get; set; }
    }
}
