namespace OOPDemo;

using System;

public abstract class Person : IPersonService
{
    private string name;
    private DateTime dateOfBirth;
    private decimal salary;

    public string Name { get => name; set => name = value; }
    public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    public decimal Salary 
    { 
        get => salary; 
        set 
        {
            if (value >= 0) salary = value;
            else throw new Exception("Salary cannot be negative.");
        }
    }

    public int CalculateAge()
    {
        return DateTime.Now.Year - DateOfBirth.Year;
    }

    public virtual decimal CalculateSalary()
    {
        return Salary;
    }
}