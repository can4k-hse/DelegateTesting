namespace Code;

public class Algo
{
    public delegate void Handler(int[] arr);
    public static event Handler onHandler;
    
    /// <summary>
    /// Сортирует arr в порядке не убывания
    /// </summary>
    /// <param name="arr"></param>
    public static void MergeSort(int[] arr)
    {
        SortRange(arr, 0, arr.Length - 1);
    }

    /// <summary>
    /// Метод упорядочивает подотрезок [l, r] данного массива
    /// </summary>
    /// <param name="arr">данный массив</param>
    /// <param name="l">Левая граница отрезка</param>
    /// <param name="r">Правая граница отрезка</param>
    /// <exception cref="ArgumentException"></exception>
    private static void SortRange(int[] arr, int l, int r)
    {
        if (l > r)
        {
            throw new ArgumentException("invalid range");
        }

        if (l == r)
        {
            return;
        }

        // Делим отрезок пополам
        int m = (l + r) / 2;
        
        // Рекурсивно сортируем подмассивы
        SortRange(arr, l, m);
        SortRange(arr, m + 1, r);

        // Выделяем отсортированные подмассивы
        var rangeL = arr[l..(m + 1)];
        var rangeR = arr[(m + 1)..(r + 1)];

        // Выделяем общую отсортированную последовательность
        var merged = Merge(rangeL, rangeR);
        
        // Обновляем исходный массив
        for (int i = l; i <= r; i++)
        {
            arr[i] = merged[i - l];
        }
        
        onHandler.Invoke(arr);
    }

    /// <summary>
    /// Объединяет две упорядоченные по не_убыванию последовательности в одну, такжже упорядоченную
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    private static int[] Merge(int[] a, int[] b)
    {
        var res = new int[a.Length + b.Length];
        for (int aI = 0, bI = 0, i = 0; i < res.Length; i++)
        {
            if (aI == a.Length)
            {
                res[i] = b[bI++];
            } else if (bI == b.Length)
            {
                res[i] = a[aI++];
            }
            else
            {
                if (a[aI] < b[bI])
                {
                    res[i] = a[aI++];
                }
                else
                {
                    res[i] = b[bI++];
                }
            }
        }

        return res;
    }
}