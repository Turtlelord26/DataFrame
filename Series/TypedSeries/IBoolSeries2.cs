using Series.Utilities.Parallelization;

namespace Series.TypedSeries
{
    public interface IBoolSeries<TIndex1, TIndex2> : ISeries<TIndex1, TIndex2, bool>
    {
        #region Indexers
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public IBoolSeries<TIndex1, TIndex2> this[Range rowNumbers] { get; set; }
        public IBoolSeries<TIndex1, TIndex2> this[IEnumerable<TIndex1> rowIndices1, IEnumerable<TIndex2> rowIndices2] { get; }
        public IBoolSeries<TIndex1, TIndex2> this[IBoolSeries<TIndex1, TIndex2> rowIndexedFilter] { get; }
        public IBoolSeries<TIndex1, TIndex2> this[IList<bool> rowNumberedFilter] { get; }
        public IBoolSeries<TIndex1, TIndex2> this[Func<TIndex1, TIndex2, bool> rowIndexFilter] { get; }
        #endregion

        #region Other Accessors
        public IBoolSeries<TIndex1, TIndex2> AtRow(IEnumerable<int> rowNumbers);
        #endregion

        #region Elementwise Operations
        public static IBoolSeries<TIndex1, TIndex2> ElementwiseAnd(IBoolSeries<TIndex1, TIndex2> series, bool boolean)
        {
            bool and(bool b) => b & boolean;
            return Map(series, and, $"{series.Name} AND {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseAnd(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool and(bool b1, bool b2) => b1 & b2;
            return Map2(series1, series2, and, $"{series1.Name} AND {series2.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseOr(IBoolSeries<TIndex1, TIndex2> series, bool boolean)
        {
            bool or(bool b) => b | boolean;
            return Map(series, or, $"{series.Name} OR {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseOr(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool or(bool b1, bool b2) => b1 | b2;
            return Map2(series1, series2, or, $"{series1.Name} OR {series2.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseXOR(IBoolSeries<TIndex1, TIndex2> series, bool boolean)
        {
            bool xor(bool b) => b ^ boolean;
            return Map(series, xor, $"{series.Name} XOR {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseXOR(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool xor(bool b1, bool b2) => b1 ^ b2;
            return Map2(series1, series2, xor, $"{series1.Name} XOR {series2.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNot(IBoolSeries<TIndex1, TIndex2> series)
        {
            static bool not(bool b) => !b;
            return Map(series, not, $"NOT {series.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNand(IBoolSeries<TIndex1, TIndex2> series1, bool boolean)
        {
            bool nand(bool b) => !(b & boolean);
            return Map(series1, nand, $"{series1.Name} NAND {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNand(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool nand(bool b1, bool b2) => !(b1 & b2);
            return Map2(series1, series2, nand, "{series1.Name} NAND {series2.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNor(IBoolSeries<TIndex1, TIndex2> series1, bool boolean)
        {
            bool nor(bool b) => !(b & boolean);
            return Map(series1, nor, $"{series1.Name} NOR {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNor(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool nor(bool b1, bool b2) => !(b1 & b2);
            return Map2(series1, series2, nor, $"{series1.Name} NOR {series2.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseEquals(IBoolSeries<TIndex1, TIndex2> series, bool boolean)
        {
            bool eq(bool b) => b == boolean;
            return Map(series, eq, $"{series.Name} == {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseEquals(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool eq(bool n1, bool n2) => n1 == n2;
            return Map2(series1, series2, eq, $"{series1.Name} == {series2.Name}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNotEquals(IBoolSeries<TIndex1, TIndex2> series, bool boolean)
        {
            bool eq(bool b) => b != boolean;
            return Map(series, eq, $"{series.Name} != {boolean}");
        }

        public static IBoolSeries<TIndex1, TIndex2> ElementwiseNotEquals(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2)
        {
            static bool neq(bool n1, bool n2) => n1 != n2;
            return Map2(series1, series2, neq, $"{series1.Name} != {series2.Name}");
        }
        #endregion

        #region Operator Overloads for Elementwise Operations

        public static IBoolSeries<TIndex1, TIndex2> operator &(IBoolSeries<TIndex1, TIndex2> series1, bool boolean) => ElementwiseAnd(series1, boolean);

        public static IBoolSeries<TIndex1, TIndex2> operator &(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2) => ElementwiseAnd(series1, series2);

        public static IBoolSeries<TIndex1, TIndex2> operator |(IBoolSeries<TIndex1, TIndex2> series1, bool boolean) => ElementwiseOr(series1, boolean);

        public static IBoolSeries<TIndex1, TIndex2> operator |(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2) => ElementwiseOr(series1, series2);

        public static IBoolSeries<TIndex1, TIndex2> operator ^(IBoolSeries<TIndex1, TIndex2> series1, bool boolean) => ElementwiseXOR(series1, boolean);

        public static IBoolSeries<TIndex1, TIndex2> operator ^(IBoolSeries<TIndex1, TIndex2> series1, IBoolSeries<TIndex1, TIndex2> series2) => ElementwiseXOR(series1, series2);

        public static IBoolSeries<TIndex1, TIndex2> operator !(IBoolSeries<TIndex1, TIndex2> series) => ElementwiseNot(series);

        //due to language constraints we cannot define custom operators for nand and nor

        //due to language constraints we cannot overload equality operators == and != to perform element-wise operation.
        #endregion

        #region Function Mappings
        public IBoolSeries<TIndex1, TIndex2> Map(Func<bool, bool> operation, string resultName) => Map(this, operation, resultName);
        public ICategoricalSeries<TIndex1, TIndex2> Map(Func<bool, int> operation, string resultName) => Map(this, operation, resultName);
        public INumericSeries<TIndex1, TIndex2> Map(Func<bool, double> operation, string resultName) => Map(this, operation, resultName);
        public IStringSeries<TIndex1, TIndex2> Map(Func<bool, string> operation, string resultName) => Map(this, operation, resultName);
        public ITimeSeries<TIndex1, TIndex2> Map(Func<bool, DateTime> operation, string resultName) => Map(this, operation, resultName);

        public static IBoolSeries<TIndex1, TIndex2> Map(IBoolSeries<TIndex1, TIndex2> source, Func<bool, bool> operation, string resultName)
        {
            List<bool> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName); //TODO All MakeSeries calls need a parameter for each level of index
        }

        public static ICategoricalSeries<TIndex1, TIndex2> Map(IBoolSeries<TIndex1, TIndex2> source, Func<bool, int> operation, string resultName)
        {
            List<int> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static INumericSeries<TIndex1, TIndex2> Map(IBoolSeries<TIndex1, TIndex2> source, Func<bool, double> operation, string resultName)
        {
            List<double> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static IStringSeries<TIndex1, TIndex2> Map(IBoolSeries<TIndex1, TIndex2> source, Func<bool, string> operation, string resultName)
        {
            List<string> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static ITimeSeries<TIndex1, TIndex2> Map(IBoolSeries<TIndex1, TIndex2> source, Func<bool, DateTime> operation, string resultName)
        {
            List<DateTime> resultData = Map(source, operation);
            return SeriesFactory.MakeSeries(source.Index, resultData, resultName);
        }

        public static IBoolSeries<TIndex1, TIndex2> Map2(IBoolSeries<TIndex1, TIndex2> source1, IBoolSeries<TIndex1, TIndex2> source2, Func<bool, bool, bool> operation, string resultName)
        {
            List<bool> resultData = Map2(source1, source2, operation);
            return SeriesFactory.MakeSeries(source1.Index, resultData, resultName);
        }

        private static List<R> Map<R>(IBoolSeries<TIndex1, TIndex2> source, Func<bool, R> operation)
        {
            int dataLength = source.Count;
            List<R> resultData = new(dataLength);
            void apply(int i) => resultData[i] = operation(source[i]);
            ParallelizationUtilities.ParallelizeIfEfficient(apply, dataLength);
            return resultData;
        }

        private static List<R> Map2<R>(IBoolSeries<TIndex1, TIndex2> source1, IBoolSeries<TIndex1, TIndex2> source2, Func<bool, bool, R> operation)
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
