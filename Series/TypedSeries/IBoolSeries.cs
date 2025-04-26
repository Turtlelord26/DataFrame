using Series.Utilities.Parallelization;

namespace Series.TypedSeries
{
    public interface IBoolSeries<TIndex> : ISeries<TIndex, bool>
    {
        #region Indexers
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public IBoolSeries<TIndex> this[Range rowNumbers] { get; set; }
        public IBoolSeries<TIndex> this[IEnumerable<TIndex> rowIndices] { get; }
        public IBoolSeries<TIndex> this[IBoolSeries<TIndex> rowIndexedFilter] { get; }
        public IBoolSeries<TIndex> this[IList<bool> rowNumberedFilter] { get; }
        public IBoolSeries<T> this[Func<TIndex, bool> rowIndexFilter] { get; }
        #endregion

        #region Other Accessors
        public IBoolSeries<TIndex> AtRow(IEnumerable<int> rowNumbers);
        #endregion

        #region Elementwise Operations
        public static IBoolSeries<TIndex> ElementwiseAnd(IBoolSeries<TIndex> series, bool boolean)
        {
            bool and(bool b) => b & boolean;
            return Map(series, and, $"{series.Name} AND {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseAnd(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool and(bool b1, bool b2) => b1 & b2;
            return Map2(series1, series2, and, $"{series1.Name} AND {series2.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseOr(IBoolSeries<TIndex> series, bool boolean)
        {
            bool or(bool b) => b | boolean;
            return Map(series, or, $"{series.Name} OR {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseOr(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool or(bool b1, bool b2) => b1 | b2;
            return Map2(series1, series2, or, $"{series1.Name} OR {series2.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseXOR(IBoolSeries<TIndex> series, bool boolean)
        {
            bool xor(bool b) => b ^ boolean;
            return Map(series, xor, $"{series.Name} XOR {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseXOR(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool xor(bool b1, bool b2) => b1 ^ b2;
            return Map2(series1, series2, xor, $"{series1.Name} XOR {series2.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseNot(IBoolSeries<TIndex> series)
        {
            static bool not(bool b) => !b;
            return Map(series, not, $"NOT {series.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseNand(IBoolSeries<TIndex> series1, bool boolean)
        {
            bool nand(bool b) => !(b & boolean);
            return Map(series1, nand, $"{series1.Name} NAND {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseNand(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool nand(bool b1, bool b2) => !(b1 & b2);
            return Map2(series1, series2, nand, "{series1.Name} NAND {series2.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseNor(IBoolSeries<TIndex> series1, bool boolean)
        {
            bool nor(bool b) => !(b & boolean);
            return Map(series1, nor, $"{series1.Name} NOR {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseNor(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool nor(bool b1, bool b2) => !(b1 & b2);
            return Map2(series1, series2, nor, $"{series1.Name} NOR {series2.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseEquals(IBoolSeries<TIndex> series, bool boolean)
        {
            bool eq(bool b) => b == boolean;
            return Map(series, eq, $"{series.Name} == {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseEquals(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool eq(bool n1, bool n2) => n1 == n2;
            return Map2(series1, series2, eq, $"{series1.Name} == {series2.Name}");
        }

        public static IBoolSeries<TIndex> ElementwiseNotEquals(IBoolSeries<TIndex> series, bool boolean)
        {
            bool eq(bool b) => b != boolean;
            return Map(series, eq, $"{series.Name} != {boolean}");
        }

        public static IBoolSeries<TIndex> ElementwiseNotEquals(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2)
        {
            static bool neq(bool n1, bool n2) => n1 != n2;
            return Map2(series1, series2, neq, $"{series1.Name} != {series2.Name}");
        }
        #endregion

        #region Operator Overloads for Elementwise Operations

        public static IBoolSeries<TIndex> operator &(IBoolSeries<TIndex> series1, bool boolean) => ElementwiseAnd(series1, boolean);

        public static IBoolSeries<TIndex> operator &(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2) => ElementwiseAnd(series1, series2);

        public static IBoolSeries<TIndex> operator |(IBoolSeries<TIndex> series1, bool boolean) => ElementwiseOr(series1, boolean);

        public static IBoolSeries<TIndex> operator |(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2) => ElementwiseOr(series1, series2);

        public static IBoolSeries<TIndex> operator ^(IBoolSeries<TIndex> series1, bool boolean) => ElementwiseXOR(series1, boolean);

        public static IBoolSeries<TIndex> operator ^(IBoolSeries<TIndex> series1, IBoolSeries<TIndex> series2) => ElementwiseXOR(series1, series2);

        public static IBoolSeries<TIndex> operator !(IBoolSeries<TIndex> series) => ElementwiseNot(series);

        //due to language constraints we cannot define custom operators for nand and nor

        //due to language constraints we cannot overload equality operators == and != to perform element-wise operation.
        #endregion

        #region Function Mappings
        public IBoolSeries<TIndex> Map(Func<bool, bool> operation, string resultName) => Map(this, operation, resultName);
        public ICategoricalSeries<TIndex> Map(Func<bool, int> operation, string resultName) => Map(this, operation, resultName);
        public INumericSeries<TIndex> Map(Func<bool, double> operation, string resultName) => Map(this, operation, resultName);
        public IStringSeries<TIndex> Map(Func<bool, string> operation, string resultName) => Map(this, operation, resultName);
        public ITimeSeries<TIndex> Map(Func<bool, DateTime> operation, string resultName) => Map(this, operation, resultName);

        public static IBoolSeries<TIndex> Map(IBoolSeries<TIndex> source, Func<bool, bool> operation, string resultName)
        {
            List<bool> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static ICategoricalSeries<TIndex> Map(IBoolSeries<TIndex> source, Func<bool, int> operation, string resultName)
        {
            List<int> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static INumericSeries<TIndex> Map(IBoolSeries<TIndex> source, Func<bool, double> operation, string resultName)
        {
            List<double> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static IStringSeries<TIndex> Map(IBoolSeries<TIndex> source, Func<bool, string> operation, string resultName)
        {
            List<string> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static ITimeSeries<TIndex> Map(IBoolSeries<TIndex> source, Func<bool, DateTime> operation, string resultName)
        {
            List<DateTime> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static IBoolSeries<TIndex> Map2(IBoolSeries<TIndex> source1, IBoolSeries<TIndex> source2, Func<bool, bool, bool> operation, string resultName)
        {
            List<bool> resultData = Map2(source1, source2, operation);
            return SeriesFactory.MakeSeries(source1.Index, resultData, resultName);
        }

        private static List<R> Map<R>(IBoolSeries<TIndex> source, Func<bool, R> operation)
        {
            int dataLength = source.Count;
            List<R> resultData = new(dataLength);
            void apply(int i) => resultData[i] = operation(source[i]);
            ParallelizationUtilities.ParallelizeIfEfficient(apply, dataLength);
            return resultData;
        }

        private static List<R> Map2<R>(IBoolSeries<TIndex> source1, IBoolSeries<TIndex> source2, Func<bool, bool, R> operation)
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
            void apply(int i) => resultData[i] = operation(source1[i], source2[i]);
            ParallelizationUtilities.ParallelizeIfEfficient(apply, dataLength);
            return resultData;
        }
        #endregion
    }
}
