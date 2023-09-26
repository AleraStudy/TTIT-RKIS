namespace rkis_lws;

public static class PracticalWork1
{
    public static void Task1()
    {
        Console.Write("Enter the distance in meters: ");
        var distanceInMeters = Helpers.GetIntFromCommandLine();

        var distanceInCentimeters = distanceInMeters * 100;
        Console.WriteLine($"Distance in centimeters: {distanceInCentimeters}");
    }

    public static void Task2()
    {
        Console.WriteLine("Enter distance in kilometers:");
        var distanceInKilometers = Helpers.GetIntFromCommandLine();

        Console.WriteLine("Enter another distance in meters:");
        var distanceInMeters = Helpers.GetIntFromCommandLine();

        double minDistance;

        if (distanceInKilometers * 1000 < distanceInMeters)
        {
            minDistance = distanceInKilometers * 1000;
        }
        else
        {
            minDistance = distanceInMeters;
        }
        
        Console.WriteLine("Smallest distance: " + minDistance + " m");
    }

    public static void Task3()
    {
        Console.WriteLine("Enter a number: ");
        var number = Helpers.GetIntFromCommandLine();

        for (var i = 1; i <= 10; i++)
        {
            var product = number * i;
            Console.WriteLine($"{number} * {i} = {product}");
        }
    }
}