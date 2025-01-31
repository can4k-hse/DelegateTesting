namespace Code;

class Program {
    static void Main(string[] args)
    {
        // Тестируем сортировку
        Watchers watchers = new Watchers();
        var test = new Test(Algo.BubbleSort);
        test.TestSort(1);
    }
}
