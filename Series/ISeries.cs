using Index;
using Series.TypedSeries;

namespace Series
{
    public interface ISeries<TIndex, TData>
    {
        #region Indexers
        public TData this[TIndex rowIndex] { get; set; }
        #endregion

        #region Other Accessors
        //Getter and setter for data get/set by row number, due to disambiguation issues with an int indexer when TIndex is int.
        public TData AtRow(int rowIndex);
        public void SetByRow(int rowIndex, TData value);

        //Plural setters by row number. Unlike the plural getter, these don't need to use the subinterface types.
        public void SetByRow(IEnumerable<int> rowNumbers, IEnumerable<TData> values);
        public void SetByRow(IEnumerable<int> rowNumbers, ISeries<TIndex, TData> values);

        //As above, an indexer that filters on series contents cannot be disambiguated from the indexer that filters on TIndex, in case TIndex is the same as TData.
        //Instead of filtering directly to a new Series, this Where method produces a Bool series that can be used to index the calling (or another) series.
        public IBoolSeries<TIndex> Where(Func<TData, bool> predicate);
        #endregion

        #region Properties
        public IIndex<TIndex> Index { get; set; }

        public int Count { get; }

        public string Name { get; set; }
        #endregion
    }
}
