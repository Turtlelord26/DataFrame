using DataFrame.SeriesCollection;
using Index;
using Series.TypedSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFrame.Generic
{
    public interface IDataFrame<TIndex>
    {
        #region Indexers
        public IIndex<TIndex> RowIndex { get; set; }

        public INumericSeriesCollection<TIndex> Numeric { get; }
        public ICategoricalSeriesCollection<TIndex> Categorical { get; }
        public IStringSeriesCollection<TIndex> Descriptive { get; }
        public ITimeSeriesCollection<TIndex> Temporal { get; }
        public IBoolSeriesCollection<TIndex> Binary { get; }

        public IDataFrame<TIndex> this[int rowNumber] { get; }
        public IDataFrame<TIndex> this[TIndex rowIndex] { get; }
        public IDataFrame<TIndex> this[Range rowNumbers] { get; }
        public IDataFrame<TIndex> this[IEnumerable<TIndex> rowIndices] { get; }
        public IDataFrame<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter] { get; }
        public IDataFrame<TIndex> this[IList<bool> rowNumberedFilter] { get; }
        public IDataFrame<TIndex> this[Func<TIndex, bool> rowIndexFilter] { get; }
        public IDataFrame<TIndex> this[Func<IDataFrame<TIndex>, IBoolSeries<TIndex>> funcFilter] { get; }
        #endregion

        #region Other Accessors
        public IDataFrame<TIndex> AtRow(IEnumerable<int> rowNumbers);
        public void SetByRow(IEnumerable<int> rowNumbers, IDataFrame<TIndex> rows);
        #endregion
    }
}
