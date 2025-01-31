namespace Code;

public class Test
{
    public delegate void Sort(int[] arr);

    private Sort _sort;
    
    public Test(Sort sort)
    {
        _sort = sort;
    }
    
    /// <summary>
    /// Тестирует сортировку по неубыванию на случайном наборе тестов
    /// </summary>
    /// <param name="sort"></param>
    /// <param name="iterations"></param>
    public void TestSort(int iterations=1000)
    {
        while (iterations-- != 0)
        {
            var arr = GenerateArray();
            _sort(arr);
            if (!IsSorted(arr))
            {
                Console.WriteLine("Test failed :(");
                throw new Exception(string.Join(' ', arr));
            }
        }
        
        Console.WriteLine("Test completed :)");
    }

    /// <summary>
    /// Проверяет, что данный массив отсортирован по неубывванию
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    private bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Генерирует массив случайной длины из случайных значений
    /// </summary>
    /// <param name="minEl">Минимальный элемент</param>
    /// <param name="maxEl">Максимальный элемент</param>
    /// <param name="minRange">Минимальная длина массива</param>
    /// <param name="maxRange">Максимальная длина массива</param>
    /// <returns></returns>
    private int[] GenerateArray(int minEl = -100, int maxEl = 100, int minRange=1, int maxRange = 100)
    {
        // Создаем генератор случайных чисел
        var generator = new Random();
        
        // Задаем длину
        var range = generator.Next(minRange, maxRange);
        var arr = new int[range];
        
        // Заполняем массив
        for (int i = 0; i < range; i++)
        {
            arr[i] = generator.Next(minEl, maxEl);
        }

        return arr;
    }
}