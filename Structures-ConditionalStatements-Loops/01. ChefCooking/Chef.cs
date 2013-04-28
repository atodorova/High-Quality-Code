using System;

    
public class Chef
{
    private Bowl GetBowl()
    {
        Bowl bowl = new Bowl();
        return bowl;
    }

    private Carrot GetCarrot()
    {
        Carrot carrot = new Carrot();
        return carrot;
    }

    private Potato GetPotato()
    {
        Potato potato = new Potato();
        return potato;
    }

    private void Cut(Vegetable potato)
    {
        //...
    }

    private void Peel(Vegetable potato)
    {
        //...
    }

    public void Cook()
    {
        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);

        Bowl bowl = GetBowl();
        bowl.Add(carrot);               
        bowl.Add(potato);
    }
}
