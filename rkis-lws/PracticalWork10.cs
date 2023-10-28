namespace rkis_lws;

public static class PracticalWork10
{
    public static void Task1()
    {
        Console.WriteLine("Enter a number N:");
        var n = Helpers.GetIntFromCommandLine(1);

        var sum = CalculateSum(n);
        Console.WriteLine($"The sum of integers between 1 and {n} is: {sum}");
        return;

        int CalculateSum(int end)
        {
            return (end * (end + 1)) / 2;
        }
    }


    public static void Task2()
    {
        var array = Helpers.GetArrayFromCommandLine();

        var result = AnalyzeSequence(array);
        Console.WriteLine($"Sum of positive elements: {result.Sum}, Product of elements between min and max: {result.Product}");
    
        (int Sum, int Product) AnalyzeSequence(int[] arr)
        {
            var sumPositive = arr.Where(x => x > 0).Sum();
            var min = arr.Min();
            var max = arr.Max();
            var indexMin = Array.IndexOf(arr, min);
            var indexMax = Array.IndexOf(arr, max);
            if (indexMin > indexMax) (indexMin, indexMax) = (indexMax, indexMin);
            var product = arr.Skip(indexMin + 1).Take(indexMax - indexMin - 1).Aggregate(1, (prod, next) => prod * next);
        
            return (sumPositive, product);
        }
    }


    public static void Task3()
    {
        Console.WriteLine("Enter the length of the array:");
        var length = Helpers.GetIntFromCommandLine(1);

        var array = GenerateArray(length);
        Console.WriteLine(string.Join(", ", array));
        return;

        IEnumerable<int> GenerateArray(int len)
        {
            var arr = new int[len];
            var random = new Random();
            for (var i = 0; i < len; i++)
            {
                arr[i] = random.Next(1, 51) * 2;  // Generates even numbers
            }
            Array.Sort(arr);
            return arr;
        }
    }


    public static void Task4()
    {
        Console.WriteLine("Enter a string:");
        var input = Console.ReadLine();

        if (input == null) return;
        var result = ModifyString(input);
        Console.WriteLine(result);

        return;

        string ModifyString(string str)
        {
            return str.StartsWith("abc") ? str.Replace("abc", "www") : $"{str}zzz";
        }
    }


    public static void Task5()
    {
        Console.WriteLine("Enter value for a:");
        var a = Helpers.GetDoubleFromCommandLine();

        Console.WriteLine("Enter value for b:");
        var b = Helpers.GetDoubleFromCommandLine();

        var result = EvaluateExpression(a, b);
        Console.WriteLine($"The result of the expression is: {result}");
        return;

        double EvaluateExpression(double val1, double val2)
        {
            return (val1 + 4 * val2) * (val1 - 3 * val2) + val1 * val1;
        }
    }


    public static void Task6()
    {
        var array = Helpers.GetArrayFromCommandLine();

        var result = InvertSigns(array);
        Console.WriteLine(string.Join(", ", result));
        return;

        IEnumerable<int> InvertSigns(IEnumerable<int> arr)
        {
            return arr.Select(x => -x).ToArray();
        }
    }


    public static void Task7()
    {
        Console.WriteLine("Enter the X coordinate of the point:");
        var x = Helpers.GetDoubleFromCommandLine();

        Console.WriteLine("Enter the Y coordinate of the point:");
        var y = Helpers.GetDoubleFromCommandLine();

        Console.WriteLine("Enter the radius of the circle:");
        var radius = Helpers.GetDoubleFromCommandLine(0);

        var isInside = CheckPoint(x, y, radius);
        Console.WriteLine(isInside ? "The point is inside the circle." : "The point is outside the circle.");
        return;

        bool CheckPoint(double xCoord, double yCoord, double rad)
        {
            return xCoord * xCoord + yCoord * yCoord <= rad * rad;
        }
    }
}