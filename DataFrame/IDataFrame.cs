using DataFrame.SeriesCollection;
using Index;
using Index.IndexLabels;
using Series.TypedSeries;

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

        public IDataFrame<T> this[int rowNumber] { get; }
        public IDataFrame<T> this[T rowIndex] { get; }
        public IDataFrame<T> this[Range rowNumbers] { get; }
        public IDataFrame<T> this[IEnumerable<int> rowNumbers] { get; }
        public IDataFrame<T> this[IEnumerable<T> rowIndices] { get; }
        public IDataFrame<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public IDataFrame<T> this[IList<bool> rowNumberedFilter] { get; }
        public IDataFrame<T> this[Func<T, bool> rowIndexFilter] { get; }
    }
}
