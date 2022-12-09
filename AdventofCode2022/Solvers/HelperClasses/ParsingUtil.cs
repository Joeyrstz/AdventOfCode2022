namespace AdventofCode2022.Solvers.HelperClasses;

public static class ParsingUtil
{
    /// <summary>
    /// Splits array into parameter number of new arrays.
    /// </summary>
    /// <param name="arr">Array or list to split</param>
    /// <param name="splitsNumber">amount of new arrays</param>
    /// <typeparam name="T">Stored type in array</typeparam>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<T>> SplitArray<T>(IEnumerable<T> arr, int splitsNumber)
    {
        var list = arr.ToList();
        int size = list.Count / splitsNumber;
        int pos = 0;
        for (int i = 0; i + 1 < splitsNumber; ++i, pos += size)
        {
            yield return list.GetRange(pos, size);
        }

        yield return list.GetRange(pos, list.Count - pos);
    }
}