namespace OOPDemo;

using System.Collections.Generic;

public class Course
{
    public string CourseName { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();

    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }
}