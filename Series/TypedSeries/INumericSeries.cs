﻿using Index;
using Index.IndexLabels;
using Series.Utilities.Parallelization;

namespace Series.TypedSeries
{
    public interface INumericSeries<T> : ISeries<T> where T : IIndexLabel
    {
        #region Indexers
        //Note - where applicable, indexers preserve order from the argument list, not necessarily the object being indexed. Additionally, ranges are max exclusive.
        public double this[int rowNumber] { get; set; }
        public double this[T rowIndex] { get; set; }
        public INumericSeries<T> this[Range rowNumbers] { get; }
        public INumericSeries<T> this[IEnumerable<int> rowNumbers] { get; }
        public INumericSeries<T> this[IEnumerable<T> rowIndices] { get; }
        public INumericSeries<T> this[IBoolSeries<T> rowIndexedFilter] { get; }
        public INumericSeries<T> this[IList<bool> rowNumberedFilter] { get; }
        public INumericSeries<T> this[Func<double, bool> rowContentFilter] { get; }
        public INumericSeries<T> this[Func<T, bool> rowIndexFilter] { get; }
        #endregion

        #region Elementwise Operations
        public static INumericSeries<T> ElementwiseAdd(INumericSeries<T> series, double scalar)
        {
            double add(double element) => element + scalar;
            return Map(series, add, $"{series.Name} + {scalar}");
        }

        public static INumericSeries<T> ElementwiseAdd(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static double plus(double n1, double n2) => n1 + n2;
            return Map2(series1, series2, plus, $"{series1.Name} + {series2.Name}");
        }

        public static INumericSeries<T> ElementwiseNegate(INumericSeries<T> series)
        {
            static double negate(double element) => -element;
            return Map(series, negate, $"-{series.Name}");
        }

        public static INumericSeries<T> ElementwiseSubtract(INumericSeries<T> series, double scalar)
        {
            double reduce(double element) => element - scalar;
            return Map(series, reduce, $"{series.Name} - {scalar}");
        }

        public static INumericSeries<T> ElementwiseSubtract(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static double subtract(double n1, double n2) => n1 - n2;
            return Map2(series1, series2, subtract, $"{series1.Name} - {series2.Name}");
        }

        public static INumericSeries<T> ElementwiseMultiply(INumericSeries<T> series, double scalar)
        {
            double scale(double element) => element * scalar;
            return Map(series, scale, $"{series.Name} * {scalar}");
        }

        public static INumericSeries<T> ElementwiseMultiply(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static double multiply(double n1, double n2) => n1 * n2;
            return Map2(series1, series2, multiply, $"{series1.Name} * {series2.Name}");
        }

        public static INumericSeries<T> ElementwiseDivide(INumericSeries<T> series, double divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();
            double divide(double n) => n / divisor;
            return Map(series, divide, $"{series.Name} / {divisor}");
        }

        public static INumericSeries<T> ElementwiseDivide(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static double divide(double n1, double n2)
            {
                if (n2 == 0)
                    throw new DivideByZeroException();
                return n1 / n2;
            }
            return Map2(series1, series2, divide, $"{series1.Name} / {series2.Name}");
        }

        public static IBoolSeries<T> ElementwiseLessThan(INumericSeries<T> series, double scalar)
        {
            bool lt(double n) => n < scalar;
            return Map(series, lt, $"{series.Name} < {scalar}");
        }

        public static IBoolSeries<T> ElementwiseLessThan(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static bool lt(double n1, double n2) => n1 < n2;
            return Map2(series1, series2, lt, $"{series1.Name} < {series2.Name}");
        }

        public static IBoolSeries<T> ElementwiseLessThanOrEqual(INumericSeries<T> series, double scalar)
        {
            bool lte(double n) => n <= scalar;
            return Map(series, lte, $"{series.Name} <= {scalar}");
        }

        public static IBoolSeries<T> ElementwiseLessThanOrEqual(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static bool lte(double n1, double n2) => n1 <= n2;
            return Map2(series1, series2, lte, $"{series1.Name} <=  {series2.Name}");
        }

        public static IBoolSeries<T> ElementwiseGreaterThan(INumericSeries<T> series, double scalar)
        {
            bool gt(double n) => n > scalar;
            return Map(series, gt, $"{series.Name} < {scalar}");
        }

        public static IBoolSeries<T> ElementwiseGreaterThan(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static bool gt(double n1, double n2) => n1 > n2;
            return Map2(series1, series2, gt, $"{series1.Name} < {series2.Name}");
        }

        public static IBoolSeries<T> ElementwiseGreaterThanOrEqual(INumericSeries<T> series, double scalar)
        {
            bool gte(double n) => n >= scalar;
            return Map(series, gte, $"{series.Name} <= {scalar}");
        }

        public static IBoolSeries<T> ElementwiseGreaterThanOrEqual(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static bool gte(double n1, double n2) => n1 >= n2;
            return Map2(series1, series2, gte, $"{series1.Name} <= {series2.Name}");
        }

        public static IBoolSeries<T> ElementwiseEquals(INumericSeries<T> series1, double value)
        {
            bool eq(double n) => n == value;
            return Map(series1, eq, $"{series1.Name} == {value}");
        }

        public static IBoolSeries<T> ElementwiseEquals(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static bool eq(double n1, double n2) => n1 == n2;
            return Map2(series1, series2, eq, $"{series1.Name} == {series2.Name}");
        }

        public static IBoolSeries<T> ElementwiseNotEquals(INumericSeries<T> series1, double value)
        {
            bool eq(double n) => n != value;
            return Map(series1, eq, $"{series1.Name} != {value}");
        }

        public static IBoolSeries<T> ElementwiseNotEquals(INumericSeries<T> series1, INumericSeries<T> series2)
        {
            static bool neq(double n1, double n2) => n1 != n2;
            return Map2(series1, series2, neq, $"{series1.Name} != {series2.Name}");
        }
        #endregion

        #region Operator Overloads for Elementwise Operations

        public static INumericSeries<T> operator +(INumericSeries<T> series, double scalar) => ElementwiseAdd(series, scalar);

        public static INumericSeries<T> operator +(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseAdd(series1, series2);

        public static INumericSeries<T> operator -(INumericSeries<T> series) => ElementwiseNegate(series);

        public static INumericSeries<T> operator -(INumericSeries<T> series, double scalar) => ElementwiseSubtract(series, scalar);

        public static INumericSeries<T> operator -(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseSubtract(series1, series2);

        public static INumericSeries<T> operator *(INumericSeries<T> series, double scalar) => ElementwiseMultiply(series, scalar);

        public static INumericSeries<T> operator *(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseMultiply(series1, series2);

        public static INumericSeries<T> operator /(INumericSeries<T> series, double divisor) => ElementwiseDivide(series, divisor);

        public static INumericSeries<T> operator /(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseDivide(series1, series2);

        public static IBoolSeries<T> operator <(INumericSeries<T> series, double scalar) => ElementwiseLessThan(series, scalar);

        public static IBoolSeries<T> operator <(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseLessThan(series1, series2);

        public static IBoolSeries<T> operator <=(INumericSeries<T> series, double scalar) => ElementwiseLessThanOrEqual(series, scalar);

        public static IBoolSeries<T> operator <=(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseLessThanOrEqual(series1, series2);

        public static IBoolSeries<T> operator >(INumericSeries<T> series, double scalar) => ElementwiseGreaterThan(series, scalar);

        public static IBoolSeries<T> operator >(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseGreaterThan(series1, series2);

        public static IBoolSeries<T> operator >=(INumericSeries<T> series, double scalar) => ElementwiseGreaterThanOrEqual(series, scalar);

        public static IBoolSeries<T> operator >=(INumericSeries<T> series1, INumericSeries<T> series2) => ElementwiseGreaterThanOrEqual(series1, series2);

        //due to language constraints we cannot overload equality operators == and != to perform element-wise operation.

        #endregion

        #region Function Mappings
        public static IBoolSeries<T> Map(INumericSeries<T> source, Func<double, bool> operation, string resultName)
        {
            List<bool> resultData = Map(source, operation);
            return source.MakeSeriesPreservingIndex(source.Index, resultData, resultName);
        }

        public static ICategoricalSeries<T> Map(INumericSeries<T> source, Func<double, int> operation, string resultName)
        {
            List<int> resultData = Map(source, operation);
            return source.MakeSeriesPreservingIndex(source.Index, resultData, resultName);
        }

        public static INumericSeries<T> Map(INumericSeries<T> source, Func<double, double> operation, string resultName)
        {
            List<double> resultData = Map(source, operation);
            return source.MakeSeriesPreservingIndex(source.Index, resultData, resultName);
        }

        public static IStringSeries<T> Map(INumericSeries<T> source, Func<double, string> operation, string resultName)
        {
            List<string> resultData = Map(source, operation);
            return source.MakeSeriesPreservingIndex(source.Index, resultData, resultName);
        }

        public static ITimeSeries<T> Map(INumericSeries<T> source, Func<double, DateTime> operation, string resultName)
        {
            List<DateTime> resultData = Map(source, operation);
            return source.MakeSeriesPreservingIndex(source.Index, resultData, resultName);
        }

        public static INumericSeries<T> Map2(INumericSeries<T> source1, INumericSeries<T> source2, Func<double, double, double> operation, string resultName)
        {
            List<double> resultData = Map2(source1, source2, operation);
            return source1.MakeSeriesPreservingIndex(source1.Index, resultData, resultName);
        }

        public static IBoolSeries<T> Map2(INumericSeries<T> source1, INumericSeries<T> source2, Func<double, double, bool> operation, string resultName)
        {
            List<bool> resultData = Map2(source1, source2, operation);
            return source1.MakeSeriesPreservingIndex(source1.Index, resultData, resultName);
        }

        private static List<R> Map<R>(INumericSeries<T> source, Func<double, R> operation)
        {
            int dataLength = source.Count;
            List<R> resultData = new(dataLength);
            void apply(int i) => resultData[i] = operation(source[i]);
            ParallelizationUtilities.ParallelizeIfEfficient(apply, dataLength);
            return resultData;
        }

        private static List<R> Map2<R>(INumericSeries<T> source1, INumericSeries<T> source2, Func<double, double, R> operation)
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
