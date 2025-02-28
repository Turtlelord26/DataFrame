using Index.IndexLabels;

namespace Series.TypedSeries
{
    public interface ITimeSeries<T> : ISeries<T> where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public abstract DateTime this[int rowNumber] { get; set; }
        public abstract DateTime this[T rowIndex] { get; set; }
        public abstract ITimeSeries<T> this[Range rowNumbers] { get; }
        public abstract ITimeSeries<T> this[IEnumerable<int> rowNumbers] { get; }
        public abstract ITimeSeries<T> this[IEnumerable<T> rowIndices] { get; }
        public abstract ITimeSeries<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public abstract ITimeSeries<T> this[IList<bool> rowNumberedFilter] { get; }
        public abstract ITimeSeries<T> this[Func<DateTime, bool> rowContentFilter] { get; }
        public abstract ITimeSeries<T> this[Func<T, bool> rowIndexFilter] { get; }
    }
}
