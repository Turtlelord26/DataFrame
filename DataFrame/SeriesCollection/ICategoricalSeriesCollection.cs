using Index.IndexLabels;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface ICategoricalSeriesCollection<T> : ISeriesCollection<ICategoricalSeries<T>, T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public int this[int rowNumber, string seriesName] { get; set; }
        public int this[IIndexLabel rowName, string seriesName] { get; set; }
    }
}
