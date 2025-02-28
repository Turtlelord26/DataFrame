using DataFrame.SeriesCollection;
using Index;
using Index.IndexLabels;

namespace DataFrame
{
    public interface IDataFrame<T> where T : IIndexLabel
    {
        public IIndex<T> RowIndex { get; set; }

        public INumericSeriesCollection<T> Numeric { get; }
        public ICategoricalSeriesCollection<T> Categorical { get; }
        public IStringSeriesCollection<T> Descriptive { get; }
        public ITimeSeriesCollection<T> Temporal { get; }
        public IBoolSeriesCollection<T> Binary { get; }
    }
}
