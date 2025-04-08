using Lab3;

Tree tree = new();

tree.Insert(new Student("Colton", 1, 12346123, 96, "USA"));
tree.Insert(new Student("Doe", 3, 6123412, 68, "Canada"));
tree.Insert(new Student("Kent", 1, 1244661, 89, "Mexico"));
tree.Insert(new Student("Tokarev", 1, 12347543, 98, "Ukraine"));
tree.Insert(new Student("Castillo", 1, 12347544, 100, "Venezuela"));

Console.WriteLine("Surname   |Course|StudentID |AverageGrade|Citizenship");
foreach (var student in tree)
{
    Console.WriteLine(student);
}

Console.WriteLine("\nFound Students:");
Console.WriteLine("Surname   |Course|StudentID|AverageGrade|Citizenship");
foreach (var student in tree.CustomSearch())
{
    Console.WriteLine(student);
}

tree.CustomRemove();

Console.WriteLine("\nUpdated Students:");
Console.WriteLine("Surname   |Course|StudentID|AverageGrade|Citizenship");
foreach (var student in tree)
{
    Console.WriteLine(student);
}
