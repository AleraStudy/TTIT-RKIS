using System.Text.RegularExpressions;

namespace rkis_lws;

public static partial class PracticalWork8
{
    public static void Task1()
    {
        var matrix = new [,]
        {
            { 0.5, 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 8.5, 9.5 },
            { 10.5, 11.5, 12.5, 13.5, 14.5, 15.5, 16.5, 17.5, 18.5, 19.5 },
            { 20.5, 21.5, 22.5, 23.5, 24.5, 25.5, 26.5, 27.5, 28.5, 29.5 },
            { 30.5, 31.5, 32.5, 33.5, 34.5, 35.5, 36.5, 37.5, 38.5, 39.5 },
            { 40.5, 41.5, 42.5, 43.5, 44.5, 45.5, 46.5, 47.5, 48.5, 49.5 }
        };

        var evenFractionsList = FindEvenFractions(matrix);
        Console.WriteLine($"Even fractions: {string.Join(", ", evenFractionsList)}");
        return;

        IEnumerable<double> FindEvenFractions(double[,] mat)
        {
            return mat.Cast<double>().Where(value => Math.Abs(value % 1 - 0.5) < 0.01 && (int)value % 2 == 0).ToList();
        }
    }

    public static void Task2()
    {
        Console.WriteLine("Enter phone number:");
        var phoneNumber = Console.ReadLine();

        const string pattern = @"\+\d \(\d{3}\) \d{3}-\d{2}-";
        var isMatch = phoneNumber != null && MyRegex().IsMatch(phoneNumber);
        Console.WriteLine(isMatch ? "Everything all right" : "Oh my god");
    }

    public static void Task3()
    {
        Console.WriteLine("Enter a number:");
        var number = Helpers.GetIntFromCommandLine();

        var isPerfect = CheckIfPerfect(number);
        Console.WriteLine($"Is perfect: {isPerfect}");
        return;

        bool CheckIfPerfect(int num)
        {
            var sum = 0;
            for (var i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                }
            }

            return sum == num;
        }
    }

    public static void Task4()
    {
        Console.WriteLine("Enter the path to the text file:");
        var filePath = Console.ReadLine();
        Console.WriteLine(filePath);


        if (filePath == null) return;
        try
        {
            var maxNumber = FindMaxNumberInFile(filePath);
            Console.WriteLine($"Max number in file: {maxNumber}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return;

        int FindMaxNumberInFile(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines.SelectMany(line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => int.TryParse(str, out var number) ? number : (int?)null))
                .Where(number => number.HasValue)
                .Max(number => number ?? 0);
        }
    }

    public static void Task5()
    {
        Console.WriteLine("First array:");
        var array1 = Helpers.GetArrayFromCommandLine();
        Console.WriteLine("Second array:");
        var array2 = Helpers.GetArrayFromCommandLine();

        var sumArray = SumArrays(array1, array2);
        Console.WriteLine($"Sum array: [{string.Join(", ", sumArray)}]");
        return;

        IEnumerable<int> SumArrays(IReadOnlyList<int> arr1, IReadOnlyList<int> arr2)
        {
            var sumList = new List<int>();
            var carry = 0;
            for (var i = 0; i < Math.Max(arr1.Count, arr2.Count); i++)
            {
                var sum = (i < arr1.Count ? arr1[i] : 0) + (i < arr2.Count ? arr2[i] : 0) + carry;
                sumList.Add(sum % 10);
                carry = sum / 10;
            }

            if (carry > 0)
            {
                sumList.Add(carry);
            }

            return sumList.ToArray();
        }
    }

    [GeneratedRegex(@"\+\d \(\d{3}\) \d{3}-\d{2}-")]
    private static partial Regex MyRegex();
}