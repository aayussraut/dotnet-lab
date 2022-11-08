using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter any two numbers: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        int num2 = Convert.ToInt32(Console.ReadLine());

        System.Console.WriteLine("The Sum of "+num1+ " and "+num2+" is: "+$"{num1+num2}");

    }
}