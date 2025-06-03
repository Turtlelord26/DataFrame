using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFrame.SeriesCollection;
using Index;
using Series.TypedSeries;

namespace DataFrame.Generic
{
    public interface IDataFrame<TIndex1, TIndex2>
    {
        #region Indexers
        public IIndex<TIndex1, TIndex2> RowIndex { get; set; }

        public INumericSeriesCollection<TIndex1, TIndex2> Numeric { get; }
        public ICategoricalSeriesCollection<TIndex1, TIndex2> Categorical { get; }
        public IStringSeriesCollection<TIndex1, TIndex2> Descriptive { get; }
        public ITimeSeriesCollection<TIndex1, TIndex2> Temporal { get; }
        public IBoolSeriesCollection<TIndex1, TIndex2> Binary { get; }

        public IDataFrame<TIndex1, TIndex2> this[int rowNumber] { get; }
        public IDataFrame<TIndex1, TIndex2> this[TIndex1 rowIndex1] { get; }
        public IDataFrame<TIndex1, TIndex2> this[TIndex1 rowIndex1, TIndex2 rowIndex2] { get; }
        public IDataFrame<TIndex1, TIndex2> this[Range rowNumbers] { get; }
        public IDataFrame<TIndex1, TIndex2> this[IEnumerable<TIndex1> rowIndices] { get; }
        public IDataFrame<TIndex1, TIndex2> this[IEnumerable<TIndex1> rowIndices1, IEnumerable<TIndex2> rowIndices2] { get; }
        public IDataFrame<TIndex1, TIndex2> this[IBoolSeries<TIndex1, TIndex2> rowIndexedFilter] { get; }
        public IDataFrame<TIndex1, TIndex2> this[IList<bool> rowNumberedFilter] { get; }
        public IDataFrame<TIndex1, TIndex2> this[Func<TIndex1, bool> rowIndexFilter] { get; }
        public IDataFrame<TIndex1, TIndex2> this[Func<TIndex1, TIndex2, bool> rowIndexFilter] { get; }
        public IDataFrame<TIndex1, TIndex2> this[Func<IDataFrame<TIndex1, TIndex2>, IBoolSeries<TIndex1, TIndex2>> funcFilter] { get; }
        #endregion

        #region Other Accessors
        public IDataFrame<TIndex1, TIndex2> AtRow(IEnumerable<int> rowNumbers);
        public void SetByRow(IEnumerable<int> rowNumbers, IDataFrame<TIndex1, TIndex2> rows);
        #endregion
    }
}
