using System;


class StateWriter
{
    public void Write(bool value)
    {
        string state = value.ToString();
        Console.WriteLine(state);
    }
}
