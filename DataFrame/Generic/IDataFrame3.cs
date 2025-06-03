using DataFrame.SeriesCollection;
using Index;
using Series.TypedSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataFrame.Generic
{
    public interface IDataFrame<TIndex1, TIndex2, TIndex3>
    {
        #region Indexers
        public IIndex<TIndex1, TIndex2, TIndex3> RowIndex { get; set; }

        public INumericSeriesCollection<TIndex1, TIndex2, TIndex3> Numeric { get; }
        public ICategoricalSeriesCollection<TIndex1, TIndex2, TIndex3> Categorical { get; }
        public IStringSeriesCollection<TIndex1, TIndex2, TIndex3> Descriptive { get; }
        public ITimeSeriesCollection<TIndex1, TIndex2, TIndex3> Temporal { get; }
        public IBoolSeriesCollection<TIndex1, TIndex2, TIndex3> Binary { get; }

        public IDataFrame<TIndex1, TIndex2, TIndex3> this[int rowNumber] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[TIndex1 rowIndex] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[TIndex1 rowIndex1, TIndex2 rowIndex2] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[TIndex1 rowIndex1, TIndex2 rowIndex2, TIndex3 rowIndex3] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[Range rowNumbers] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[IEnumerable<TIndex1> rowIndices] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[IEnumerable<TIndex1> rowIndices1, IEnumerable<TIndex2> rowIndices2] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[IEnumerable<TIndex1> rowIndices, IEnumerable<TIndex2> rowIndices2, IEnumerable<TIndex3> rowIndices3] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[IBoolSeries<TIndex1, TIndex2, TIndex3> rowIndexedFilter] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[IList<bool> rowNumberedFilter] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[Func<TIndex1, bool> rowIndexFilter] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[Func<TIndex1, TIndex2, bool> rowIndexFilter] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[Func<TIndex1, TIndex2, TIndex3, bool> rowIndexFilter] { get; }
        public IDataFrame<TIndex1, TIndex2, TIndex3> this[Func<IDataFrame<TIndex1, TIndex2, TIndex3>, IBoolSeries<TIndex1, TIndex2, TIndex3>> funcFilter] { get; }
        #endregion

        #region Other Accessors
        public IDataFrame<TIndex1, TIndex2, TIndex3> AtRow(IEnumerable<int> rowNumbers);
        public void SetByRow(IEnumerable<int> rowNumbers, IDataFrame<TIndex1, TIndex2, TIndex3> rows);
        #endregion
    }
}
