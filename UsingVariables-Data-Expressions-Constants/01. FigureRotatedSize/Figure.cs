using System;
using System.Text;


public class Figure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Figure(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("Rotated Figure Size:\n");
        result.AppendFormat("Width is {0},\nHeight is {1}\n", this.Width, this.Height);
        return result.ToString();
    }
}

