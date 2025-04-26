namespace Series.TypedSeries
{
    public interface ITimeSeries<TIndex> : ISeries<TIndex, DateTime>
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public ITimeSeries<TIndex> this[Range rowNumbers] { get; set; }
        public ITimeSeries<TIndex> this[IEnumerable<TIndex> rowIndices] { get; }
        public ITimeSeries<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter] { get; }
        public ITimeSeries<TIndex> this[IList<bool> rowNumberedFilter] { get; }
        public ITimeSeries<TIndex> this[Func<TIndex, bool> rowIndexFilter] { get; }

        #region Other Accessors
        public ITimeSeries<TIndex> AtRow(IEnumerable<int> rowNumbers);
        #endregion
    }
}
