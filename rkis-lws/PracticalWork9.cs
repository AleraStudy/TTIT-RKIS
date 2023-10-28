using System.Globalization;

namespace rkis_lws;

public static class PracticalWork9
{
    public static void Task1()
    {
        var random = new Random();
        var array = new int[15];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-100, 101);
        }

        foreach (var item in array)
        {
            Console.Write($"{item}, ");
        }
    }

    public static void Task2()
    {
        var array = new int[15];
        for (var i = 0; i < array.Length - 1; i++) // Exclude last element
        {
            Console.WriteLine($"Enter value for element {i + 1}:");
            array[i] = Helpers.GetIntFromCommandLine();
        }

        array[^1] = 0; // Initializing the last element before summing
        foreach (var item in array[..^1]) // Excluding the last element during summation
        {
            array[^1] += item;
        }

        foreach (var item in array)
        {
            Console.Write($"{item}, ");
        }
    }

    private enum MathOperation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    private static (int firstNumber, int secondNumber, MathOperation operation, double result) Task3Function(
        int number1,
        int number2, MathOperation operation)
    {
        var result = operation switch
        {
            MathOperation.Add => number1 + number2,
            MathOperation.Subtract => number1 - number2,
            MathOperation.Multiply => number1 * number2,
            MathOperation.Divide => number1 / (double)number2,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };

        return (number1, number2, operation, result);
    }

    public static void Task3()
    {
        Console.WriteLine("Enter the first number:");
        var firstNumber = Helpers.GetIntFromCommandLine();

        Console.WriteLine("Enter the second number:");
        var secondNumber = Helpers.GetIntFromCommandLine();

        Console.WriteLine("Enter the operation (Add, Subtract, Multiply, Divide):");
        var operationInput = Console.ReadLine();

        if (!Enum.TryParse(typeof(MathOperation), operationInput, true, out var operationObj))
        {
            Console.WriteLine("Invalid operation. Please try again.");
            return;
        }

        var operation = (MathOperation)operationObj;
        var resultTuple = Task3Function(firstNumber, secondNumber, operation);

        Console.WriteLine($"Operation: {resultTuple.operation}");
        Console.WriteLine(
            $"{resultTuple.firstNumber} {GetOperationSymbol(resultTuple.operation)} {resultTuple.secondNumber} = {resultTuple.result}");
        return;

        string GetOperationSymbol(MathOperation op)
        {
            return op switch
            {
                MathOperation.Add => "+",
                MathOperation.Subtract => "-",
                MathOperation.Multiply => "*",
                MathOperation.Divide => "/",
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    }

    private enum DayOfWeekRu
{
    Понедельник,
    Вторник,
    Среда,
    Четверг,
    Пятница,
    Суббота,
    Воскресенье
}

private enum MonthRu
{
    Январь,
    Февраль,
    Март,
    Апрель,
    Май,
    Июнь,
    Июль,
    Август,
    Сентябрь,
    Октябрь,
    Ноябрь,
    Декабрь
}

public static void Task4()
{
    Console.WriteLine("Enter the date (dd.MM.yyyy):");
    var input = Console.ReadLine();
    if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
    {
        var dayOfWeek = GetDayOfWeekRu(date.DayOfWeek);
        var month = GetMonthRu(date.Month);
        Console.WriteLine($"{dayOfWeek}, {date.Day} {month}, {date.Year} год");
    }
    else
    {
        Console.WriteLine("Invalid date format.");
    }
}

private static string GetDayOfWeekRu(DayOfWeek dayOfWeek)
{
    return dayOfWeek switch
    {
        DayOfWeek.Monday => DayOfWeekRu.Понедельник.ToString(),
        DayOfWeek.Tuesday => DayOfWeekRu.Вторник.ToString(),
        DayOfWeek.Wednesday => DayOfWeekRu.Среда.ToString(),
        DayOfWeek.Thursday => DayOfWeekRu.Четверг.ToString(),
        DayOfWeek.Friday => DayOfWeekRu.Пятница.ToString(),
        DayOfWeek.Saturday => DayOfWeekRu.Суббота.ToString(),
        DayOfWeek.Sunday => DayOfWeekRu.Воскресенье.ToString(),
        _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
    };
}

private static string GetMonthRu(int month)
{
    return month switch
    {
        1 => MonthRu.Январь.ToString(),
        2 => MonthRu.Февраль.ToString(),
        3 => MonthRu.Март.ToString(),
        4 => MonthRu.Апрель.ToString(),
        5 => MonthRu.Май.ToString(),
        6 => MonthRu.Июнь.ToString(),
        7 => MonthRu.Июль.ToString(),
        8 => MonthRu.Август.ToString(),
        9 => MonthRu.Сентябрь.ToString(),
        10 => MonthRu.Октябрь.ToString(),
        11 => MonthRu.Ноябрь.ToString(),
        12 => MonthRu.Декабрь.ToString(),
        _ => throw new ArgumentOutOfRangeException(nameof(month), month, "Invalid month")
    };
}

public static void Task5()
{
    try
    {
        Console.WriteLine("Enter the path to a file:");
        var filePath = Console.ReadLine();

        if (filePath == null) return;
        var content = File.ReadAllText(filePath);
        Console.WriteLine($"File content:\n{content}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

}