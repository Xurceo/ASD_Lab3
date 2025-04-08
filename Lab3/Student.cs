
namespace Lab3
{
    public class Student : IComparable<Student>
    {
        public string Surname { get; set; }

        public int Course { get; set; }

        public uint StudentID { get; set; }

        public decimal AverageGrade { get; set; }

        public string Citizenship { get; set; }

        public Student(string surname, int course, uint studentID, decimal averageGrade, string citizenship)
        {
            Surname = surname;
            Course = course;
            StudentID = studentID;
            AverageGrade = averageGrade;
            Citizenship = citizenship;
        }

        public override string ToString()
        {
            return $"{Surname, -10}|{Course, -6}|{StudentID, -10}|{AverageGrade, -10}|{Citizenship, -12}";
        }

        public int CompareTo(Student? other)
        {
            return other is null ? 1 : StudentID.CompareTo(other.StudentID);
        }
    }
}
