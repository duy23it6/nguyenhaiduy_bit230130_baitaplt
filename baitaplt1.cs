using System;

public class AgeOutOfRangeException : Exception
{
    public AgeOutOfRangeException(string message) : base(message)
    {
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter the student's age: ");
            int age = int.Parse(Console.ReadLine());
            CheckEligibility(age);
            Console.WriteLine("The student is eligible for university admission.");
        }
        catch (AgeOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    public static void CheckEligibility(int age)
    {
        if (age < 18 || age > 25)
        {
            throw new AgeOutOfRangeException($"The student's age ({age}) is not within the eligible range of 18 to 25.");
        }
    }
}