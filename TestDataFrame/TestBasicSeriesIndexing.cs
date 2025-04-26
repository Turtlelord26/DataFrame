using Index;
using Series;
using Series.TypedSeries;

namespace TestDataFrame
{
    public class TestBasicSeriesIndexing
    {
        public const double VALUE_1 = 4.5, VALUE_2 = 7.8, VALUE_3 = 3.2, VALUE_4 = 9.9, VALUE_5 = 0.0, VALUE_6 = 14.1, VALUE_7 = 7.3, VALUE_8 = 5.5, VALUE_9 = -4.44, VALUE_10 = -6.6;

        private INumericSeries<string> _series1;
        private INumericSeries<int> _series2;
        private INumericSeries<string> _series3;
        private INumericSeries<string> _series4;

        [SetUp]
        public void Setup()
        {
            _series1 = SeriesFactory.MakeSeries(IndexFactory.MakeIndex<string>([], "_index1"), new List<double>(), "_series1");
            _series1["first"] = VALUE_1;
            _series1["second"] = VALUE_2;
            _series1["third"] = VALUE_3;

            _series2 = SeriesFactory.MakeSeries(IndexFactory.MakeIndex<int>([], "_index1"), new List<double>(), "_series1");
            _series2[0] = VALUE_4;
            _series2[1] = VALUE_5;
            _series2[3] = VALUE_6;
            _series2[2] = VALUE_7;

            _series3 = SeriesFactory.MakeSeries(IndexFactory.MakeIndex(["1", "2", "3", "4"], "_index3"), [VALUE_7, VALUE_4, VALUE_10, VALUE_2], "_series3");

            _series4 = SeriesFactory.MakeSeries(IndexFactory.MakeIndex(["a", "b", "c", "d"], "_index3"), [VALUE_1, VALUE_2, VALUE_4, VALUE_8], "_series4");
        }

        [Test]
        public void TestBasicElementAccess()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_series1["first"], Is.EqualTo(VALUE_1));
                Assert.That(_series1.AtRow(0), Is.EqualTo(_series1["first"]));

                Assert.That(_series1["second"], Is.EqualTo(VALUE_2));
                Assert.That(_series1.AtRow(1), Is.EqualTo(_series1["second"]));

                Assert.That(_series1["third"], Is.EqualTo(VALUE_3));
                Assert.That(_series1.AtRow(2), Is.EqualTo(_series1["third"]));

                Assert.That(_series2[0], Is.EqualTo(VALUE_4));
                Assert.That(_series2.AtRow(0), Is.EqualTo(_series2[0]));

                Assert.That(_series2[1], Is.EqualTo(VALUE_5));
                Assert.That(_series2.AtRow(1), Is.EqualTo(_series2[1]));

                Assert.That(_series2[3], Is.EqualTo(VALUE_6));
                Assert.That(_series2.AtRow(2), Is.EqualTo(_series2[3]));

                Assert.That(_series2[2], Is.EqualTo(VALUE_7));
                Assert.That(_series2.AtRow(3), Is.EqualTo(_series2[2]));
            });
        }

        [Test]
        public void TestBasicElementSet()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_series1["third"], Is.EqualTo(VALUE_3));
                _series1["third"] = VALUE_8;
                Assert.That(_series1["third"], Is.Not.EqualTo(VALUE_3));
                Assert.That(_series1["third"], Is.EqualTo(VALUE_8));

                Assert.That(_series2[1], Is.EqualTo(VALUE_5));
                _series1["third"] = VALUE_9;
                Assert.That(_series2[1], Is.Not.EqualTo(VALUE_5));
                Assert.That(_series2[1], Is.EqualTo(VALUE_9));
            });
        }

        [Test]
        public void TestBasicElementSetByRow()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_series4["d"], Is.EqualTo(VALUE_8));
                Assert.That(_series4.AtRow(3), Is.EqualTo(VALUE_8));
                _series1.SetByRow(3, VALUE_10);
                Assert.That(_series4["d"], Is.Not.EqualTo(VALUE_8));
                Assert.That(_series4["d"], Is.EqualTo(VALUE_10));
                Assert.That(_series4.AtRow(3), Is.Not.EqualTo(VALUE_8));
                Assert.That(_series4.AtRow(3), Is.EqualTo(VALUE_10));
            });
        }

        [Test]
        public void TestBasicEnumerableMultirowAccess()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_series3.Count, Is.EqualTo(4));
                INumericSeries<string> positiveSeries3 = _series3[["1", "2", "3"]];
                Assert.That(_series3.Count, Is.EqualTo(4));
                Assert.That(positiveSeries3.Count, Is.EqualTo(3));
                Assert.That(positiveSeries3["1"], Is.EqualTo(VALUE_7));
                Assert.That(positiveSeries3["2"], Is.EqualTo(VALUE_4));
                Assert.That(positiveSeries3["3"], Is.EqualTo(VALUE_10));
                Assert.Throws<KeyNotFoundException>(() => { var toss = positiveSeries3["4"]; });

            });
        }

        [Test]
        public void TestBasicConditionalMultirowAccess()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_series3.Count, Is.EqualTo(4));
                INumericSeries<string> positiveSeries3 = _series3[_series3 > 0];
                Assert.That(_series3.Count, Is.EqualTo(4));
                Assert.That(positiveSeries3.Count, Is.EqualTo(3));
                Assert.That(positiveSeries3["1"], Is.EqualTo(VALUE_7));
                Assert.That(positiveSeries3["2"], Is.EqualTo(VALUE_4));
                Assert.That(positiveSeries3["4"], Is.EqualTo(VALUE_2));
                Assert.Throws<KeyNotFoundException>(() => { var toss = positiveSeries3["3"]; });
            });
        }
    }
}
