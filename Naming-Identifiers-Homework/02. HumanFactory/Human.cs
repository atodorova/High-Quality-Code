using System;
using System.Text;


enum Gender { Male, Female };

class Human
{
    public Gender Gender { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Human():this(null, 0, Gender.Male)
    {
    }

    public Human(string name, int age, Gender gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("Hello, {0}", this.Name);
        return result.ToString();
    }
}
