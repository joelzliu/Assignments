namespace OOPDemo;

using System.Collections.Generic;

public class Student : Person, IStudentService
{
    private List<double> grades = new List<double>();

    public void AddGrade(double grade) => grades.Add(grade);

    public double CalculateGPA()
    {
        if (grades.Count == 0) return 0;
        double sum = 0;
        foreach (var grade in grades)
            sum += grade;
        return sum / grades.Count;
    }
}