namespace rkis_lws;

public static class Helpers
{
    private static int? GetIntOrNullFromCommandLine(int min = int.MinValue, int max = int.MaxValue)
    {
        var input = Console.ReadLine();

        if (!int.TryParse(input, out var intNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return null;
        }

        // ReSharper disable once InvertIf
        if (intNumber < min || intNumber > max)
        {
            Console.WriteLine("Incorrect range. Please enter a valid number.");
            return null;
        }

        return intNumber;
    }

    public static int GetIntFromCommandLine(int min = int.MinValue, int max = int.MaxValue)
    {
        int? result = null;
        do
        {
            result = Helpers.GetIntOrNullFromCommandLine(min, max);
        } while (result == null);

        return result.Value;
    }

    private static double? GetDoubleOrNullFromCommandLine(double min = double.MinValue, double max = double.MaxValue)
    {
        var input = Console.ReadLine();

        if (!double.TryParse(input, out var doubleNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return null;
        }

        // ReSharper disable once InvertIf
        if (doubleNumber < min || doubleNumber > max)
        {
            Console.WriteLine("Incorrect range. Please enter a valid number.");
            return null;
        }

        return doubleNumber;
    }

    public static double GetDoubleFromCommandLine(double min = double.MinValue, double max = double.MaxValue)
    {
        double? result = null;
        do
        {
            result = Helpers.GetDoubleOrNullFromCommandLine(min, max);
        } while (result == null);

        return result.Value;
    }
}