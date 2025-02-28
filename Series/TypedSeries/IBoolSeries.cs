using Index.IndexLabels;

namespace Series.TypedSeries
{
    public interface IBoolSeries<T> : ISeries<T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public abstract bool this[int rowNumber] { get; set; }
        public abstract bool this[T rowIndex] { get; set; }
        public abstract IBoolSeries<T> this[Range rowNumbers] { get; }
        public abstract IBoolSeries<T> this[IEnumerable<int> rowNumbers] { get; }
        public abstract IBoolSeries<T> this[IEnumerable<T> rowIndices] { get; }
        public abstract IBoolSeries<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public abstract IBoolSeries<T> this[IList<bool> rowNumberedFilter] { get; }
        public abstract IBoolSeries<T> this[Func<bool, bool> rowContentFilter] { get; }
        public abstract IBoolSeries<T> this[Func<T, bool> rowIndexFilter] { get; }
    }
}
