using Catalog;
using System.Runtime.CompilerServices;

internal static class ClassbookHelper
{
    public static List<Student> getStartupStudentsList()
    {

        List<Student> students = new List<Student>()
        {

            new Student("firstName1", "lastName1", 1, new Address("City1", "Street1", 1), new List<Mark>() { new Mark(1, DateTime.Now, Course.Math), 
                                                                                                             new Mark(2, DateTime.Now, Course.Biology),
                                                                                                             new Mark(5, DateTime.Now, Course.Biology)}),
            new Student("firstName2", "lastName2", 2, new Address("City2", "Street2", 2), new List<Mark>() { new Mark(1, DateTime.Now, Course.Physics) }),
            new Student("firstName3", "lastName3", 3, new Address("City3", "Street3", 3), new List<Mark>() { new Mark(3, DateTime.Now, Course.Biology) }),
            new Student("firstName4", "lastName4", 4, new Address("City4", "Street4", 4), new List<Mark>() { new Mark(4, DateTime.Now, Course.Physics) }),
            new Student("firstName5", "lastName5", 5, new Address("City5", "Street5", 5), new List<Mark>() { new Mark(5, DateTime.Now, Course.Math) })

        };

        return students;
    }

    public static Address readAddress()
    {
        Console.Write("Oras=");
        string city = Console.ReadLine();

        Console.Write("Strada=");
        string street = Console.ReadLine();

        Console.Write("Numar=");
        int number = int.Parse(Console.ReadLine());

        return new Address(city, street, number);
    }

    public static Mark readMark()
    {
        Console.Write("Valoare=");
        int value = int.Parse(Console.ReadLine());

        Console.Write("Data si ora acordarii(MM/DD/YYYY HH:MM:SS)=");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());

        Console.Write("Curs=");
        Course course = (Course)Enum.Parse(typeof(Course), Console.ReadLine(), true);

        return new Mark(value, dateTime, course);
    }

    public static List<Mark> readMarks()
    {
        Console.Write("Introduceti numarul de note pe care doriti sa-l introduceti in catalog=");
        UInt16 marksNo = UInt16.Parse(Console.ReadLine());
        List<Mark> marks    = new List<Mark>();
        while (marksNo>0)
        {
            marks.Add(readMark());
            marksNo--;
        }

        return marks;
    }

    public static Student readStudent()
    {
        Console.Write("Prenume=");
        string firstName = Console.ReadLine();

        Console.Write("Nume=");
        string lastName = Console.ReadLine();

        Console.Write("Varsta=");
        UInt16 age = UInt16.Parse(Console.ReadLine());

        Address address = readAddress();
        List<Mark> marks = readMarks();

        return new Student(firstName, lastName, age, address, marks);
    }
}