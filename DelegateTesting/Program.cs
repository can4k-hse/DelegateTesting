// Author: Alexander Yakovlev
// CreatedAt: 31 января 2025 г. 11:44:02
// Filename: Program.cs
// Summary: Точка входа в программу


namespace Code;

class Program {
    static void Main(string[] args)
    {
        // Тестируем сортировку
        _ = new Watchers();
        var test = new Test(Algo.BubbleSort);
        test.TestSort(1);
    }
}
