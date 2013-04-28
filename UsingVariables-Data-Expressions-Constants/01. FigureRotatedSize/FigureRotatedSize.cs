using System;


class FigureRotatedSize
{
    public static Figure GetRotatedSize(Figure figure, double angleOfTheFigureThatWillBeRotaed)
    {
        double absSinusOfAngel = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed));
        double absCosinusOfAngel = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed));
        double rotatedFigureWidth = absCosinusOfAngel * figure.Width + absSinusOfAngel * figure.Height;
        double rotatedFigureHeight = absSinusOfAngel * figure.Width + absCosinusOfAngel * figure.Height;
        Figure rotatedFigure = new Figure(rotatedFigureWidth, rotatedFigureHeight);
 
        return rotatedFigure;
    }
}

