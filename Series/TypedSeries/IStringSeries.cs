using Index.IndexLabels;

namespace Series.TypedSeries
{
    public interface IStringSeries<T> : ISeries<T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public abstract string this[int rowNumber] { get; set; }
        public abstract string this[T rowIndex] { get; set; }
        public abstract IStringSeries<T> this[Range rowNumbers] { get; }
        public abstract IStringSeries<T> this[IEnumerable<int> rowNumbers] { get; }
        public abstract IStringSeries<T> this[IEnumerable<T> rowIndices] { get; }
        public abstract IStringSeries<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public abstract IStringSeries<T> this[IList<bool> rowNumberedFilter] { get; }
        public abstract IStringSeries<T> this[Func<string, bool> rowContentFilter] { get; }
        public abstract IStringSeries<T> this[Func<T, bool> rowIndexFilter] { get; }
    }
}
