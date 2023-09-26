namespace rkis_lws;

public static class PracticalWork3
{
    public static void Task1()
    {
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();

        Console.WriteLine($"Hello, {name}");
    }

    public static void Task2()
    {
        Console.Write("Enter number a: ");
        var a = Helpers.GetDoubleFromCommandLine();

        Console.Write("Enter number b: ");
        var b = Helpers.GetDoubleFromCommandLine();

        Console.Write("Enter number c: ");
        var c = Helpers.GetDoubleFromCommandLine();

        var m = Math.Max(a, Math.Max(b, c));

        Console.WriteLine($"The maximum value is: {m}");
    }

    public static void Task3()
    {
        Console.Write("Enter number x: ");
        var x = Helpers.GetDoubleFromCommandLine();

        Console.Write("Enter number y: ");
        var y = Helpers.GetDoubleFromCommandLine();

        (x, y) = (y, x);
        Console.WriteLine($"After swapping: x = {x}, y = {y}");
    }

    public static void Task4()
    {
        Console.Write("Enter array of int numbers, separated by ';': ");
        var input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("Input error");
            return;
        }

        var arrayElements = input.Split(';');
        
        var array = Array.ConvertAll(arrayElements, int.Parse);

        var minIndex = Array.IndexOf(array, array.Min())+1;

        Console.WriteLine($"The index of the min element is: {minIndex}");
    }

    public static void Task5()
    {
        Console.WriteLine("1.Convert Kilobytes to Bytes" + Environment.NewLine + "2.Convert Bytes to Kilobytes");
        Console.Write("Make a choice: ");
        var choice = Helpers.GetIntFromCommandLine(1,2);

        Console.Write("Enter a number: ");
        var number = Helpers.GetIntFromCommandLine();

        switch (choice)
        {
            case 1:
                Console.WriteLine($"{number} Kilobytes is equal to {number * 1024} Bytes");
                break;
            case 2:
                Console.WriteLine($"{number} Bytes is equal to {number / 1024.0} Kilobytes");
                break;
        }
    }
}