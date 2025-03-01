namespace Series.Utilities.Parallelization
{
    public static class ParallelizationUtilities
    {
        public const int PARALLELISM_THRESHOLD = 128;

        public static bool ParallelCondition(int dataLength) => dataLength >= PARALLELISM_THRESHOLD;

        internal static void ParallelizeIfEfficient(Action<int> action, int dataEndpoint, int startPoint = 0)
        {
            if (ParallelCondition(dataEndpoint))
            {
                Parallel.For(startPoint, dataEndpoint,
                    (i) => action(i)
                    );
            }
            else
            {
                for (int i = startPoint; i < dataEndpoint; i++)
                {
                    action(i);
                }
            }
        }
    }
}
