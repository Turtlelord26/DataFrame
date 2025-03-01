using Index.IndexLabels;
using Series;
using Series.TypedSeries;

namespace DataFrame.SeriesCollection
{
    public interface ISeriesCollection<S, T> : ICollection<S> where S : ISeries<T>
                                                              where T : IIndexLabel
    {
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public S this[string seriesName] { get; set; }

        public ISeriesCollection<S, T> this[IEnumerable<string> seriesNames] { get; }
        public ISeriesCollection<S, T> this[IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public ISeriesCollection<S, T> this[Func<string, bool> seriesNameFilter] { get; }

        public IDataFrame<T> this[Range rowNumbers, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[IEnumerable<int> rowNumbers, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[IEnumerable<T> rowIndices, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[IBoolSeries<T> rowIndexedFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[IList<bool> rowNumberedFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[Func<double, bool> rowContentFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[Func<T, bool> rowIndexFilter, IEnumerable<string> seriesNames] { get; }
        public IDataFrame<T> this[Range rowNumbers, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<T> this[IEnumerable<int> rowNumbers, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<T> this[IEnumerable<T> rowIndices, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<T> this[IBoolSeries<T> rowIndexedFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<T> this[IList<bool> rowNumberedFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<T> this[Func<double, bool> rowContentFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilters] { get; }
        public IDataFrame<T> this[Func<T, bool> rowIndexFilter, IEnumerable<KeyValuePair<string, bool>> seriesNameFilter] { get; }
        public IDataFrame<T> this[Range rowNumbers, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<T> this[IEnumerable<int> rowNumbers, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<T> this[IEnumerable<T> rowIndices, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<T> this[IBoolSeries<T> rowIndexedFilter, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<T> this[IList<bool> rowNumberedFilter, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<T> this[Func<double, bool> rowContentFilter, Func<string, bool> seriesNameFilter] { get; }
        public IDataFrame<T> this[Func<T, bool> rowIndexFilter, Func<string, bool> seriesNameFilter] { get; }


        //Name-based and plural versions of ICollection methods.
        public void Add(IEnumerable<S> series);
        public bool Contains(string seriesName);
        public bool Remove(string seriesName);
        public void Remove(IEnumerable<S> series);
        public void Remove(IEnumerable<string> seriesNames);
    }
}
