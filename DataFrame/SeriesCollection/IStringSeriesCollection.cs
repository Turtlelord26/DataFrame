using Index.IndexLabels;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface IStringSeriesCollection<T> : ISeriesCollection<IStringSeries<T>, T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public string this[int rowNumber, string seriesName] { get; set; }
        public string this[IIndexLabel rowName, string seriesName] { get; set; }
    }
}
