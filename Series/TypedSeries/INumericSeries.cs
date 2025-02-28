using Index.IndexLabels;

namespace Series.TypedSeries
{
    public interface INumericSeries<T> : ISeries<T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public double this[int rowNumber] { get; set; }
        public double this[T rowIndex] { get; set; }
        public INumericSeries<T> this[Range rowNumbers] { get; }
        public INumericSeries<T> this[IEnumerable<int> rowNumbers] { get; }
        public INumericSeries<T> this[IEnumerable<T> rowIndices] { get; }
        public INumericSeries<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public INumericSeries<T> this[IList<bool> rowNumberedFilter] { get; }
        public INumericSeries<T> this[Func<double, bool> rowContentFilter] { get; }
        public INumericSeries<T> this[Func<T, bool> rowIndexFilter] { get; }
    }
}
