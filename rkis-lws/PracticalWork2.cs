namespace rkis_lws;

public static class PracticalWork2
{
    public static void Task1()
    {
        Console.Write("Enter the number a: ");
        var a = Helpers.GetIntFromCommandLine();
        
        Console.Write("Enter the number b: ");
        var b = Helpers.GetIntFromCommandLine();
        
        var isDivisible = b % a == 0;
        Console.WriteLine($"Number a {(isDivisible ? "is" : "is not")} a divisor of number b");
    }

    public static void Task2()
    {
        Console.Write("Enter a number: ");
        var number = Helpers.GetIntFromCommandLine();

        Console.WriteLine($"That's the number you entered: {number}");
    }

    public static void Task3()
    {
        Console.Write("Enter the number m: ");
        var m = Helpers.GetIntFromCommandLine();
        
        Console.Write("Enter the number n: ");
        var n = Helpers.GetIntFromCommandLine();
        
        if (m > n)
        {
            Console.WriteLine("Number m > n");
        }
        else if (m < n)
        {
            Console.WriteLine("Number m < n");
        }
        else
        {
            Console.WriteLine("The numbers are equal");
        }
    }
    
    public static void Task4()
    {
        Console.Write("Enter a radius: ");
        var radius = Helpers.GetDoubleFromCommandLine();
        
        double diameter = radius * 2;
        Console.WriteLine($"The diameter of the circle with radius {radius} is {diameter}");
    }
        
    public static void Task5()
    {
        var sumAll = 0;
        for (var i = 100; i <= 500; i++)
        {
            sumAll += i;
        }

        Console.WriteLine($"Sum of all integers from 100 to 500: {sumAll}");
    }
    
    public static void Task6()
    {
        Console.Write("Enter a: ");
        var a = Helpers.GetIntFromCommandLine(max: 500);
        
        var sumAll = 0;
        for (int i = a; i <= 500; i++)
        {
            sumAll += i;
        }
        
        Console.WriteLine($"Sum of all integers from {a} to 500: {sumAll}");
    }
}