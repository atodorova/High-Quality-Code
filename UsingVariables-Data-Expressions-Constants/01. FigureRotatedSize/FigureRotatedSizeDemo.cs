using System;


class FigureRotatedSizeDemo
{
    public static void Main()
    {
        Figure figure = new Figure(5, 10);
        Console.WriteLine(FigureRotatedSize.GetRotatedSize(figure, 5));
    }
}

