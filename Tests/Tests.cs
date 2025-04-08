using Lab3;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void InsertTest()
        {
            // Arrange
            var tree = new Tree();

            var student1 = new Student("Alice", 1, 12345676, 85, "Ukraine");
            var student2 = new Student("Bob", 2, 32142332, 70, "USA");
            var student3 = new Student("Charlie", 3, 67589312, 90, "Ukraine");

            // Act
            tree.Insert(student1);
            tree.Insert(student2);
            tree.Insert(student3);

            // Assert
            // Check if all students were inserted by iterating through the tree
            var students = tree.ToArray();
            Assert.Contains(students, s => s.Surname == "Alice");
            Assert.Contains(students, s => s.Surname == "Bob");
            Assert.Contains(students, s => s.Surname == "Charlie");
        }
        [Fact]
        public void InOrderTraversalTest()
        {
            //Arrange
            Tree tree = new();

            //Act
            tree.Insert(new Student("Colton", 1, 12346123, 96, "USA"));
            tree.Insert(new Student("Doe", 3, 6123412, 68, "Canada"));
            tree.Insert(new Student("Kent", 1, 1244661, 89, "Mexico"));
            tree.Insert(new Student("Tokarev", 1, 12347543, 98, "Ukraine"));
            tree.Insert(new Student("Castillo", 1, 12347544, 100, "Venezuela"));

            //Assert
            //Check if all students in the tree are sorted by default
            Assert.Equal(tree.ToList().OrderBy(x => x.StudentID), tree.ToList());
        }

        [Fact]
        public void CustomSearchTest()
        {
            // Arrange
            var tree = new Tree();
            var student1 = new Student("Alice", 1, 12345676, 85, "Ukraine");
            var student2 = new Student("Bob", 2, 32142332, 70, "USA");
            var student3 = new Student("Charlie", 1, 67589312, 90, "Canada");
            var student4 = new Student("David", 4, 12345865, 88, "Ukraine");

            tree.Insert(student1);
            tree.Insert(student2);
            tree.Insert(student3);
            tree.Insert(student4);

            // Act
            var result = tree.CustomSearch(); // Custom search for non-Ukrainian students with grade >= 90 and course == 1

            // Assert
            Assert.Contains(result, s => s.Surname == "Charlie");
            Assert.DoesNotContain(result, s => s.Surname == "Alice");
            Assert.DoesNotContain(result, s => s.Surname == "David");
        }

        [Fact]
        public void RemoveTest()
        {
            // Arrange
            var tree = new Tree();
            var student1 = new Student("Alice", 1, 12345676, 85, "Ukraine");
            var student2 = new Student("Bob", 2, 32142332, 70, "USA");
            var student3 = new Student("Charlie", 3, 67589312, 90, "Ukraine");

            tree.Insert(student1);
            tree.Insert(student2);
            tree.Insert(student3);

            // Act
            tree.Remove(s => s.Surname == "Alice");

            // Assert
            var students = tree.ToArray();
            Assert.DoesNotContain(students, s => s.Surname == "Alice");
            Assert.Contains(students, s => s.Surname == "Bob");
            Assert.Contains(students, s => s.Surname == "Charlie");
        }

        [Fact]
        public void EmptyTreeTest()
        {
            // Arrange
            var tree = new Tree();

            // Act
            var students = tree.ToArray();

            // Assert
            Assert.Empty(students); // Tree should be empty initially
        }

        [Fact]
        public void CustomRemoveTest()
        {
            // Arrange
            var tree = new Tree();
            var student1 = new Student("Alice", 1, 12345678, 96, "Canada");
            var student2 = new Student("Bob", 2, 87654321, 92, "USA");
            var student3 = new Student("Charlie", 1, 12344321, 90, "USA");
            var student4 = new Student("David", 2, 43211234, 88, "Ukraine");

            tree.Insert(student1);
            tree.Insert(student2);
            tree.Insert(student3);
            tree.Insert(student4);

            // Act
            tree.CustomRemove(); // Remove students who are not from Ukraine, have grade >= 90, and are in course 1

            // Assert
            var students = tree.ToArray();
            Assert.DoesNotContain(students, s => s.Surname == "Charlie"); // Charlie should be removed
            Assert.DoesNotContain(students, s => s.Surname == "Alice"); // Alice should be removed
            Assert.Contains(students, s => s.Surname == "Bob"); // Bob should remain
            Assert.Contains(students, s => s.Surname == "David"); // David should remain
        }
    }
}