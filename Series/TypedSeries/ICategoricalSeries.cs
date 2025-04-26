namespace Series.TypedSeries
{
    public interface ICategoricalSeries<TIndex> : ISeries<TIndex, int>
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public ICategoricalSeries<TIndex> this[Range rowNumbers] { get; set; }
        public ICategoricalSeries<TIndex> this[IEnumerable<TIndex> rowIndices] { get; }
        public ICategoricalSeries<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter] { get; }
        public ICategoricalSeries<TIndex> this[IList<bool> rowNumberedFilter] { get; }
        public ICategoricalSeries<TIndex> this[Func<TIndex, bool> rowIndexFilter] { get; }

        #region Other Accessors
        public ICategoricalSeries<TIndex> AtRow(IEnumerable<int> rowNumbers);
        #endregion
    }
}
