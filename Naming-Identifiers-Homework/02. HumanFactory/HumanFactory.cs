using System;


class HumanFactory
{
    public static void GetHumanGender(int EGN)
    {
        Human human = new Human();
        human.Age = EGN;
        if (EGN % 2 == 0)
        {
            human.Name = "Mr";
            human.Gender = Gender.Male;
        }
        else
        {
            human.Name = "Miss";
            human.Gender = Gender.Female;
        }

        Console.WriteLine(human);
    }
}

