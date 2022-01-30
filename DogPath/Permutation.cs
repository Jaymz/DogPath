// https://stackoverflow.com/a/1952336
public class Permutation
{

    public static IEnumerable<T[]> GetPermutations<T>(T[] items)
    {
        if (items.Length == 0) 
        { 
            yield return Array.Empty<T>(); 
        } 
        else 
        {
            int[] work = new int[items.Length];
            for (int i = 0; i < work.Length; i++)
            {
                work[i] = i;
            }
            foreach (int[] index in GetIntPermutations(work, 0, work.Length))
            {
                T[] result = new T[index.Length];
                for (int i = 0; i < index.Length; i++) result[i] = items[index[i]];
                yield return result;
            }
        }
    }

    public static IEnumerable<int[]> GetIntPermutations(int[] index, int offset, int len)
    {
        if (len == 1)
        {
            yield return index;
        }
        else if (len == 2)
        {
            yield return index;
            Swap(index, offset, offset + 1);
            yield return index;
            Swap(index, offset, offset + 1);
        }
        else
        {
            foreach (int[] result in GetIntPermutations(index, offset + 1, len - 1))
            {
                yield return result;
            }
            for (int i = 1; i < len; i++)
            {
                Swap(index, offset, offset + i);
                foreach (int[] result in GetIntPermutations(index, offset + 1, len - 1))
                {
                    yield return result;
                }
                Swap(index, offset, offset + i);
            }
        }
    }

    private static void Swap(int[] index, int offset1, int offset2)
    {
        int temp = index[offset1];
        index[offset1] = index[offset2];
        index[offset2] = temp;
    }

}