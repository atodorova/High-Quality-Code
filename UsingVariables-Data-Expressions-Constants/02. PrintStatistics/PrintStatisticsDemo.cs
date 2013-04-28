using System;


public class PrintStatisticsDemo
{
    public static void Main()
    {
        Console.WriteLine("Print Statistics:\n");
        double[] numbers = { 1,2,3,4,5,6,7,8,9 };
        PrintStatistics printStatistic = new PrintStatistics();
        printStatistic.GenerateStatistics(numbers);
    }
}

