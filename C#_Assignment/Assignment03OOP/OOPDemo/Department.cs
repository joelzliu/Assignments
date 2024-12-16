namespace OOPDemo;

using System.Collections.Generic;

public class Department
{
    public string DepartmentName { get; set; }
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public void AddCourse(Course course)
    {
        Courses.Add(course);
    }
}