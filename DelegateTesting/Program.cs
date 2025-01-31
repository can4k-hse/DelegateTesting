namespace Code;

class Program {
    static void Main(string[] args)
    {
        // Тестируем сортировку
        Watchers watchers = new Watchers();
        var test = new Test(Algo.MergeSort);
        test.TestSort(1);
    }
}
