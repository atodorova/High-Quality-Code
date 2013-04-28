using System;
using System.Collections.Generic;


class Bowl
{
    public IList<Vegetable> Content { get; set; }

    public IList<Vegetable> Add(Vegetable vegetable)
    {
        this.Content.Add(vegetable);
        return this.Content;
    }
}

