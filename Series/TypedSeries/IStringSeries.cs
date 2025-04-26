using Series.Utilities.Parallelization;

namespace Series.TypedSeries
{
    public interface IStringSeries<TIndex> : ISeries<TIndex, string>
    {
        #region Indexers
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public IStringSeries<TIndex> this[Range rowNumbers] { get; set; }
        public IStringSeries<TIndex> this[IEnumerable<TIndex> rowIndices] { get; }
        public IStringSeries<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter] { get; }
        public IStringSeries<TIndex> this[IList<bool> rowNumberedFilter] { get; }
        public IStringSeries<TIndex> this[Func<TIndex, bool> rowIndexFilter] { get; }
        #endregion

        #region Other Accessors
        public IStringSeries<TIndex> AtRow(IEnumerable<int> rowNumbers);
        #endregion

        #region Elementwise String operations
        public IBoolSeries<TIndex> Contains(string substring)
        {
            return Map(this, (string elem) => elem.Contains(substring), $"{Name} contains {substring}");
        }
        #endregion

        #region Function Mappings
        public IBoolSeries<TIndex> Map(Func<string, bool> operation, string resultName) => Map(this, operation, resultName);
        public ICategoricalSeries<TIndex> Map(Func<string, int> operation, string resultName) => Map(this, operation, resultName);
        public INumericSeries<TIndex> Map(Func<string, double> operation, string resultName) => Map(this, operation, resultName);
        public IStringSeries<TIndex> Map(Func<string, string> operation, string resultName) => Map(this, operation, resultName);
        public ITimeSeries<TIndex> Map(Func<string, DateTime> operation, string resultName) => Map(this, operation, resultName);

        public static IBoolSeries<TIndex> Map(IStringSeries<TIndex> source, Func<string, bool> operation, string resultName)
        {
            List<bool> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static ICategoricalSeries<TIndex> Map(IStringSeries<TIndex> source, Func<string, int> operation, string resultName)
        {
            List<int> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static INumericSeries<TIndex> Map(IStringSeries<TIndex> source, Func<string, double> operation, string resultName)
        {
            List<double> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static IStringSeries<TIndex> Map(IStringSeries<TIndex> source, Func<string, string> operation, string resultName)
        {
            List<string> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static ITimeSeries<TIndex> Map(IStringSeries<TIndex> source, Func<string, DateTime> operation, string resultName)
        {
            List<DateTime> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static IBoolSeries<TIndex> Map2(IStringSeries<TIndex> source1, IStringSeries<TIndex> source2, Func<string, string, bool> operation, string resultName)
        {
            List<bool> resultData = Map2(source1, source2, operation);
            return SeriesFactory.MakeSeries(source1.Index, resultData, resultName);
        }

        public static IStringSeries<TIndex> Map2(IStringSeries<TIndex> source1, IStringSeries<TIndex> source2, Func<string, string, string> operation, string resultName)
        {
            List<string> resultData = Map2(source1, source2, operation);
            return SeriesFactory.MakeSeries(source1.Index, resultData, resultName);
        }

        private static List<R> Map<R>(IStringSeries<TIndex> source, Func<string, R> operation)
        {
            int dataLength = source.Count;
            List<R> resultData = new(dataLength);
            void apply(int i) => resultData[i] = operation(source.AtRow(i));
            ParallelizationUtilities.ParallelizeIfEfficient(apply, dataLength);
            return resultData;
        }

        private static List<R> Map2<R>(IStringSeries<TIndex> source1, IStringSeries<TIndex> source2, Func<string, string, R> operation)
        {
            int dataLength = source1.Count;
            if (dataLength != source2.Count)
            {
                throw new ArgumentException("Series length mismatch for binary operation");
            }
            if (!source1.Index.Equals(source2.Index))
            {
                throw new ArgumentException("Series index mismatch for binary operation");
            }

            List<R> resultData = new(dataLength);
            void apply(int i) => resultData[i] = operation(source1.AtRow(i), source2.AtRow(i));
            ParallelizationUtilities.ParallelizeIfEfficient(apply, dataLength);
            return resultData;
        }
        #endregion
    }
}
