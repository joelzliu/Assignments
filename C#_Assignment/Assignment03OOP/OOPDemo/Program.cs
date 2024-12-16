using System;
using OOPDemo;

class Program
{
    static void Main(string[] args)
    {
        Instructor instructor = new Instructor
        {
            Name = "Dr. Smith",
            DateOfBirth = new DateTime(1980, 5, 20),
            Salary = 50000,
            JoinDate = new DateTime(2010, 6, 15)
        };

        Console.WriteLine($"Instructor: {instructor.Name}");
        Console.WriteLine($"Age: {instructor.CalculateAge()}");
        Console.WriteLine($"Salary with Bonus: {instructor.CalculateSalary()}");

        Student student = new Student
        {
            Name = "Alice",
            DateOfBirth = new DateTime(2000, 3, 10)
        };
        student.AddGrade(3.7);
        student.AddGrade(3.9);

        Console.WriteLine($"\nStudent: {student.Name}");
        Console.WriteLine($"Age: {student.CalculateAge()}");
        Console.WriteLine($"GPA: {student.CalculateGPA()}");

        Course course = new Course { CourseName = "Object-Oriented Programming" };
        course.EnrollStudent(student);

        Department department = new Department
        {
            DepartmentName = "Computer Science",
            Head = instructor,
            Budget = 100000
        };
        department.AddCourse(course);

        Console.WriteLine($"\nDepartment: {department.DepartmentName}");
        Console.WriteLine($"Head: {department.Head.Name}");
        Console.WriteLine($"Budget: {department.Budget}");
        Console.WriteLine($"Courses Offered: {department.Courses[0].CourseName}");
        Console.WriteLine($"Enrolled Students: {department.Courses[0].EnrolledStudents[0].Name}");
    }
}