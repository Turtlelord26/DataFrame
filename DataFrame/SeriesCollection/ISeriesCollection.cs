using Series;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface ISeriesCollection<TIndex, TData> : ICollection<ISeries<TIndex, TData>>
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        #region Indexers
        public TData this[int rowNumber, string seriesName] { get; set; }
        public TData this[TIndex rowIndex, string seriesName] { get; set; }

        public IDataFrame<TIndex> this[Range rowNumbers, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[IEnumerable<int> rowNumbers, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[IEnumerable<TIndex> rowIndices, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[IList<bool> rowNumberedFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[Func<double, bool> rowContentFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[Func<TIndex, bool> rowIndexFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<TIndex> this[Range rowNumbers, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IEnumerable<int> rowNumbers, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IEnumerable<TIndex> rowIndices, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IList<bool> rowNumberedFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[Func<double, bool> rowContentFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilters] { get; }
        public IDataFrame<TIndex> this[Func<TIndex, bool> rowIndexFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[Range rowNumbers, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IEnumerable<int> rowNumbers, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IEnumerable<TIndex> rowIndices, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[IList<bool> rowNumberedFilter, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[Func<double, bool> rowContentFilter, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<TIndex> this[Func<TIndex, bool> rowIndexFilter, Func<string, bool> seriesNameFilter] { get; }
        #endregion

        #region Name-based and plural versions of ICollection methods.
        public void Add(IEnumerable<ISeries<TIndex, TData>> series);
        public bool Contains(string seriesName);
        public bool Remove(string seriesName);
        public void Remove(IEnumerable<ISeries<TIndex, TData>> series);
        public void Remove(IEnumerable<string> seriesNames);
        #endregion
    }
}
