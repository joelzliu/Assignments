namespace OOPDemo;

using System;

public class Instructor : Person, IInstructorService
{
    public DateTime JoinDate { get; set; }

    public override decimal CalculateSalary()
    {
        return base.CalculateSalary() + CalculateBonusSalary();
    }

    public decimal CalculateBonusSalary()
    {
        int experience = DateTime.Now.Year - JoinDate.Year;
        return experience * 1000; // 每年经验增加 1000 作为奖金
    }
}