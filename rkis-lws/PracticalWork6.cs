using System.Globalization;

namespace rkis_lws;

public static class PracticalWork6
{
    public static void Task1()
    {
        var currentDate = DateTime.Now;
        var currentDayOfWeek = currentDate.ToString("dddd", new CultureInfo("en-EN"));
        var currentMonth = currentDate.ToString("MMMM", new CultureInfo("en-EN"));
        const string name = "Alexey";

        Console.WriteLine(currentDayOfWeek);
        Console.WriteLine(currentMonth);
        Console.WriteLine(name);
    }

    public static void Task2()
    {
        Console.WriteLine("Enter the first number:");
        var num1 = Helpers.GetIntFromCommandLine();
        Console.WriteLine("Enter the second number:");
        var num2 = Helpers.GetIntFromCommandLine();
        Console.WriteLine("Enter the third number:");
        var num3 = Helpers.GetIntFromCommandLine();

        var resultSum = CalculateSum(num1, num2, num3);
        Console.WriteLine($"The sum of the new values is: {resultSum}");
        return;

        int CalculateSum(int number1, int number2, int number3)
        {
            var newNumber1 = number1 * 2;
            var newNumber2 = number2 - 3;
            var newNumber3 = number3 * number3;

            return newNumber1 + newNumber2 + newNumber3;
        }
    }

    public static void Task3()
    {
        Console.WriteLine("Enter the width of the rectangle:");
        var width = Helpers.GetDoubleFromCommandLine();
        Console.WriteLine("Enter the height of the rectangle:");
        var height = Helpers.GetDoubleFromCommandLine();
        Console.WriteLine("Enter the side length of the square:");
        var sideLength = Helpers.GetDoubleFromCommandLine();

        var squaresCount = CalculateSquaresCount(width, height, sideLength);
        Console.WriteLine($"The number of squares that can be cut out is: {squaresCount}");
        return;

        int CalculateSquaresCount(double rectangleWidth, double rectangleHeight, double squareSideLength)
        {
            var squaresAlongWidth = (int)(rectangleWidth / squareSideLength);
            var squaresAlongHeight = (int)(rectangleHeight / squareSideLength);

            return squaresAlongWidth * squaresAlongHeight;
        }
    }

    public static void Task4()
    {
        Console.WriteLine("Enter the first number:");
        var num1 = Helpers.GetDoubleFromCommandLine();
        Console.WriteLine("Enter the second number:");
        var num2 = Helpers.GetDoubleFromCommandLine();

        var maxNumber = FindMax(num1, num2);
        Console.WriteLine($"The maximum number is: {maxNumber}");
        return;

        double FindMax(double number1, double number2)
        {
            return number1 > number2 ? number1 : number2;
        }
    }

    public static void Task5()
    {
        Console.WriteLine("Enter the elements of the array, separated by commas:");
        var numbers = Helpers.GetArrayFromCommandLine();

        var positiveCount = CountPositiveNumbers(numbers);
        Console.WriteLine($"The count of positive numbers is: {positiveCount}");
        return;

        int CountPositiveNumbers(IEnumerable<int> array)
        {
            return array.Count(number => number > 0);
        }
    }


    public static void Task6()
    {
        var numbers = Helpers.GetArrayFromCommandLine();

        var product = CalculateProductOfOddIndices(numbers);
        Console.WriteLine($"The product of numbers at odd indices is: {product}");
        return;

        int CalculateProductOfOddIndices(IReadOnlyList<int> array)
        {
            var result = 1;
            for (var i = 1; i < array.Count; i += 2)
            {
                result *= array[i];
            }

            return result;
        }
    }

    public static void Task7()
    {
        Console.WriteLine("Enter a number:");
        var number = Helpers.GetIntFromCommandLine();

        var isDescending = CheckIfDigitsAreDescending(number);
        Console.WriteLine($"Are digits in descending order: {isDescending}");
        return;

        bool CheckIfDigitsAreDescending(int num)
        {
            var digits = num.ToString().ToCharArray();
            for (var i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] < digits[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static void Task8()
    {
        var random = new Random();
        var arrayLength = random.Next(1, 26);
        var array = GenerateDescendingArrayDivisibleByThree(arrayLength);
        Console.WriteLine($"Generated array: [{string.Join(", ", array)}]");
        return;

        IEnumerable<int> GenerateDescendingArrayDivisibleByThree(int length)
        {
            var list = new List<int>();
            for (var i = length * 3; i >= 3; i -= 3)
            {
                list.Add(i);
            }

            return list.ToArray();
        }
    }

    public static void Task9()
    {
        var numbers = Helpers.GetArrayFromCommandLine();
        Console.WriteLine("Enter the number to search for:");
        var target = Helpers.GetIntFromCommandLine();

        var contains = ArrayContainsNumber(numbers, target);
        Console.WriteLine($"Array contains {target}: {contains}");
        return;

        bool ArrayContainsNumber(IEnumerable<int> array, int num)
        {
            return array.Contains(num);
        }
    }

    public static void Task10()
    {
        Console.WriteLine("Enter the dimensions of the array:");
        var dimensions = Helpers.GetIntFromCommandLine(1);

        var array = GenerateArrayWithSquaredIndices(dimensions);
        Console.WriteLine($"Generated array: [{string.Join(", ", array)}]");
        return;

        IEnumerable<int> GenerateArrayWithSquaredIndices(int dimensions)
        {
            var arr = new int[dimensions];
            for (var i = 0; i < dimensions; i++)
            {
                arr[i] = i * i;
            }

            return arr;
        }
    }
}