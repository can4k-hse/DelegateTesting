// Author: Alexander Yakovlev
// CreatedAt: 31 января 2025 г. 11:29:39
// Filename: Watchers.cs
// Summary: Класс наблюдателей, отслеживающих прогресс сортировки


namespace Code;

public class Watchers
{
    public Watchers()
    {
        Algo.onHandler += DisplayProgress;
    }
    
    /// <summary>
    /// Выводил прогресс
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="size">Величина прогрессбара</param>
    private void DisplayProgress(int[] arr)
    {
        // Размер поля
        int size = 40;
        
        var sorted_copy = (int[])arr.Clone();
        Array.Sort(sorted_copy);
        
        // Количество элементов на своих позициях
        int count = 0;
        
        for (int i = 0; i < arr.Length; i++)
        {
            count += (arr[i] == sorted_copy[i] ? 1 : 0);
        }

        // Считаем количество заполненных полей
        int fillNumber = (int) double.Floor((double)count / arr.Length * size);
        
        for (int i = 0; i < size; i++)
        {
            Console.Write(i < fillNumber ? "*" : "_");
        }
        
        Console.Write(Environment.NewLine);
    }
}