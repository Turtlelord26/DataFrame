namespace Index
{
    public interface IIndex<TIndex1>
    {
        #region Indexers
        public int this[TIndex1 indexValue] { get; }
        public IEnumerable<TIndex1> this[Range rowNumbers] { get; set; }
        public IEnumerable<TIndex1> this[IEnumerable<int> rowNumbers] { get; set; }
        public IEnumerable<int> this[IEnumerable<TIndex1> indexValues] { get; set; }
        #endregion

        #region Other Accessors
        public TIndex1 AtRow(int rowNumber);
        public void SetByRow(int rowNumber, TIndex1 value);
        #endregion

        #region List Functions
        public void Add(TIndex1 value);
        public void Insert(int index, TIndex1 item);
        public void Remove(TIndex1 value);
        public void RemoveElementAt(int rowNumber);
        #endregion

        //Members below are organized as in the pandas API reference (2.2 at time of comment)


        //Properties


        //Index.values (and recommended alternatives Index.array and Index.to_numpy) are ignored. If this functionality is needed, will implement conversions to List and Dictionary.

        public bool IsMonotonicNondecreasing { get; }

        public bool IsMonotonicNonincreasing { get; }

        public bool IsUnique { get; }

        public bool HasDuplicates { get; }

        //Index.hasNaNs is ignored. The implementation on a general index would be unwieldy, and its function can be performed on a numeric index with Contains

        //Index.dtype and Index.inferred_type are ignored. We have static types.

        //Index.shape is ignored, it's the same as Count.

        string Name { get; }

        //Index.nbytes and Index.memory_usage are ignored for now. Microsoft has tools for inspecting memory usage of .NET objects. See .NET Object Allocation tool

        //Index.ndim is ignored. It's 1.

        //Index.size is implemented as Count

        int Count { get; }

        //Index.T is ignored.

        //Index.memory_usage is ignored. .NET has tools for gauging memory usage of objects.


        // Modifying and computations


        //Index.all and .any are ignored

        //Index.argmix, .argmax, min, max are ignored as LINQ provides this functionality with user-supplied comparators, and reimplementing that would be redundant.

        public IIndex<TIndex1> Copy(bool deepCopy = true);

        public IIndex<TIndex1> Drop(int rowNumber);

        public IIndex<TIndex1> Drop(IEnumerable<int> rowNumbers);

        public IIndex<TIndex1> DropDuplicates();

        public IList<TIndex1> Duplicated();

        public bool Equals(IIndex<TIndex1> other);

        public (IIndex<TIndex1>, IList<TIndex1>) Factorize(bool sort = false, bool useNANSentinel = true);

        //Index.identical is ignored as a duplicate of equals in a C# context.

        //Index.insert is implemented above

        ////////Index.Reindex requires more understanding

        ////////Index.Rename requires more context from MultiIndex implementation

        public IIndex<TIndex1> Repeat(int n);

        //Index.Where undesirably overloads with LINQ, and moreover is pretty redundant with LINQ.Select and our own Map method using a simple user-defined conditional replacement function.

        //Index.Take also overloads with LINQ and is implemented as Distribute (being the opposite of factorize)

        public IIndex<TIndex1> Distribute(IList<TIndex1> indices);
        public IIndex<TIndex1> Distribute(IList<TIndex1> indices, TIndex1 fillValue);

        //Index.putmask is ignored.

        public IIndex<TIndex1> Unique(); //Note to come back here to examine the pandas parameter for this method after figuring out multiindex

        //Index.nunique is implemented as UniqueCount

        public int UniqueCount();

        public Dictionary<TIndex1, double> ValueCounts(bool normalize = false, bool sort = true, bool ascending = true, bool dropNaN = true); //ignoring the bins parameter for now, it is noted as a convenience with general function Cut
    }
}
