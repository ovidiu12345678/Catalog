using Catalog;
using System.Data;
using System.Runtime.CompilerServices;

class Classbook
{
    List<Student> students = ClassbookHelper.getStartupStudentsList();

    public void addStudent(Student student) { students.Add(student); }

    public void removeStudent(UInt16 studentId) { students.Remove(getStudentById(studentId)); }

    public Student getStudentById(UInt16 studentId)
    {
        return students.Find(student => student.Id == studentId);
    }

    public void modifyStudentInfo(UInt16 studentId)
    {
        Console.Write("Alegeti ce doriti sa modificati:\n" +
                  "1.Nume\n" +
                  "2.Prenume\n" +
                  "3.Varsta\n" +
                  "Optiune=");
        string studentInfoToModify = Console.ReadLine();
        switch (studentInfoToModify)
        {
            case "1":
                Console.Write("Intoroduceti noul nume al studentului=");
                string newLastName = Console.ReadLine();
                getStudentById(studentId).LastName = newLastName;
                break;
            case "2":
                Console.Write("Intoroduceti noul prenume al studentului=");
                string newFirstName = Console.ReadLine();
                getStudentById(studentId).FirstName = newFirstName;
                break;
            case "3":
                Console.Write("Intoroduceti noul nume al studentului=");
                UInt16 newAge = UInt16.Parse(Console.ReadLine());
                getStudentById(studentId).Age = newAge;
                break;
            default:
                Console.WriteLine("Optiunea aleasa nu este valida\n");
                break;
        }
    }

    public void modifyStudentAddress(UInt16 studentId)
    {
        Console.WriteLine("Introduceti noua adresa");
        Address address = ClassbookHelper.readAddress();
        getStudentById(studentId).Address = address;
    }

    public void addMark(UInt16 studentId)
    {
        Console.WriteLine("Introduceti nota:");
        Mark mark = ClassbookHelper.readMark();
        getStudentById(studentId).Marks.Add(mark);
    }

    public float getStudentAverage(UInt16 studentId)
    {
        Student student=students.Find(student => student.Id == studentId);
        int marksSum = 0;
        student.Marks.ForEach(mark => marksSum+=mark.MarkValue);
        return (float)marksSum/student.Marks.Count;
    }

    public Dictionary<Course,float> getStudentAverageOnEachSubject(UInt16 studentId)
    {
        Dictionary<Course, float> averages = new Dictionary<Course, float>{
            {
                Course.Math, 0
            },
            {
                Course.Physics, 0
            },
            {
                Course.Biology, 0
            }
        };
        Dictionary<Course, int> marksNr = new Dictionary<Course, int>
        {
            {
                Course.Math, 0
            },
            {
                Course.Physics, 0 
            },
            {
                Course.Biology, 0
            }
        };

        Student student = students.Find(student => student.Id == studentId);

        student.Marks.ForEach(mark =>
        {
            if (mark.Course == Course.Math)
            {
                averages[Course.Math] += mark.MarkValue;
                marksNr[Course.Math]++;
            }
            if (mark.Course == Course.Biology)
            {
                averages[Course.Biology] += mark.MarkValue;
                marksNr[Course.Biology]++;
            }
            if (mark.Course == Course.Physics)
            {
                averages[Course.Physics] += mark.MarkValue;
                marksNr[Course.Physics]++;
            }
        });

        if (marksNr[Course.Math]!=0)
            averages[Course.Math] = (float)averages[Course.Math] / marksNr[Course.Math];
        if (marksNr[Course.Biology] != 0)
            averages[Course.Biology] = (float)averages[Course.Biology] / marksNr[Course.Biology];
        if (marksNr[Course.Physics] != 0)
            averages[Course.Physics] = (float)averages[Course.Physics] / marksNr[Course.Physics];

        return averages;

    }

   public List<Student> getStudentsOrderedByAverageDesc()
    {
        return students.OrderByDescending(student => getStudentAverage(student.Id)).ToList();
    }

    public List<Student> Students { get => students; set => students = value; }
}