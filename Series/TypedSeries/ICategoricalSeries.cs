using Index.IndexLabels;

namespace Series.TypedSeries
{
    public interface ICategoricalSeries<T> : ISeries<T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public abstract int this[int rowNumber] { get; set; }
        public abstract int this[T rowIndex] { get; set; }
        public abstract ICategoricalSeries<T> this[Range rowNumbers] { get; }
        public abstract ICategoricalSeries<T> this[IEnumerable<int> rowNumbers] { get; }
        public abstract ICategoricalSeries<T> this[IEnumerable<T> rowIndices] { get; }
        public abstract ICategoricalSeries<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public abstract ICategoricalSeries<T> this[IList<bool> rowNumberedFilter] { get; }
        public abstract ICategoricalSeries<T> this[Func<int, bool> rowContentFilter] { get; }
        public abstract ICategoricalSeries<T> this[Func<T, bool> rowIndexFilter] { get; }
    }
}
