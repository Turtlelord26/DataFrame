using Index;
using Index.IndexLabels;
using Series.TypedSeries;

namespace Series
{
    public static class SeriesFactory
    {
        public static IBoolSeries<T> MakeBoolSeries<T>(IIndex<T> index, List<bool> data, string name) where T : IIndexLabel
        {
            throw new NotImplementedException();
        }

        public static ICategoricalSeries<T> MakeCategoricalSeries<T>(IIndex<T> index, List<int> data, string name) where T : IIndexLabel
        {
            throw new NotImplementedException();
        }

        public static INumericSeries<T> MakeNumericSeries<T>(IIndex<T> index, List<double> data, string name) where T : IIndexLabel
        {
            throw new NotImplementedException();
        }
    }
}
