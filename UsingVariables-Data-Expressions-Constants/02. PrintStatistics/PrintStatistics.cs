using System;


internal class PrintStatistics
{
    public void GenerateStatistics(double[] numbers)
    {
        CountMaximalValue(numbers);
        CountMinimalValue(numbers);
        CountAverageValue(numbers);
    }

    private void CountMaximalValue(double[] numbers)
    {
        double maxValue = numbers[0];
        for (int index = 0; index < numbers.Length; index++)
        {
            if (numbers[index] > maxValue)
            {
                maxValue = numbers[index];
            }
        }
        PrintMaximalValue(maxValue);
    }

    private void PrintMaximalValue(double maxValue)
    {
        Console.WriteLine("The Maximal Value is {0}", maxValue);
    }

    private void CountMinimalValue(double[] numbers)
    {
        double minValue = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minValue)
            {
                minValue = numbers[i];
            }
        }
        PrintMinimalValue(minValue);
    }

    private void PrintMinimalValue(double minValue)
    {
        Console.WriteLine("The Minimal Value is {0}", minValue);
    }

    private void CountAverageValue(double[] numbers)
    {
        double sumOfElements = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sumOfElements += numbers[i];
        }
        PrintAverageValue(sumOfElements / numbers.Length);
    }

    private void PrintAverageValue(double averageValue)
    {
        Console.WriteLine("The Average Value is {0}", averageValue);
    }
}
