using System.Xml.Linq;

Name n1 = new Name("Anders", "Hejlsberg");
Name n2 = new Name("Kevin", "Arnold");
Name n3 = new Name("Frank", "Arnold");
Name[] names = new Name[] { n1, n2, n3 };

foreach (Name name in names)
{
    if (name is { LastName: "Arnold" } arnold)
    {
        Console.WriteLine($"{nameof(arnold)} == {name.FirstName}");
    }
}

Person p1 = new(n1, 60);
Person p2 = new(n2, 15);
Person p3 = new(n3, 15);

Person[] people = new Person[] { p1, p2, p3 };

foreach (Person p in people)
{
    if (p is { Name: { LastName: "Arnold" } } arnold)
    {
        Console.WriteLine(arnold);
    }
}

foreach (Person p in people)
{
    if (p is { Name.LastName: "Arnold" } arnold)
    {
        Console.WriteLine(arnold);
    }
}

foreach (Person p in people)
{
    if (p == null) continue;
    if (p.Name == null) continue;

    if (p.Name.LastName == "Arnold")
    {
        Console.WriteLine(p.Name.LastName);
    }
}

record class Name(string FirstName, string LastName);

record class Person(Name Name, int Age);
