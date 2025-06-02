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
    public interface IDataFrame
    {
        #region Indexers
        public IIndex RowIndex { get; set; }

        public INumericSeriesCollection Numeric { get; }
        public ICategoricalSeriesCollection Categorical { get; }
        public IStringSeriesCollection Descriptive { get; }
        public ITimeSeriesCollection Temporal { get; }
        public IBoolSeriesCollection Binary { get; }

        public IDataFrame this[int rowNumber] { get; }
        public IDataFrame this[Range rowNumbers] { get; }
        public IDataFrame this[IEnumerable<int> rowIndices] { get; }
        public IDataFrame this[IBoolSeries rowIndexedFilter] { get; }
        public IDataFrame this[IList<bool> rowNumberedFilter] { get; }
        public IDataFrame this[Func<int, bool> rowIndexFilter] { get; }
        public IDataFrame this[Func<IDataFrame, IBoolSeries> funcFilter] { get; }
        #endregion

        #region Other Accessors
        public IDataFrame AtRow(IEnumerable<int> rowNumbers);
        public void SetByRow(IEnumerable<int> rowNumbers, IDataFrame rows);
        #endregion
    }
}
