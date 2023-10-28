namespace rkis_lws;

public static class PracticalWork4
{
    public static void Task1()
    {
        Console.Write("Enter a natural number: ");
        var number = Helpers.GetIntFromCommandLine(1);

        var sum = 0;
        var product = 1;

        while (number != 0)
        {
            var digit = number % 10;
            sum += digit;
            product *= digit;
            number /= 10;
        }

        Console.WriteLine($"Sum of digits: {sum}");
        Console.WriteLine($"Product of digits: {product}");
    }

    public static void Task2()
    {
        Console.Write("Enter the array size: ");
        var arraySize = Helpers.GetIntFromCommandLine();
        
        Console.Write("Enter the start of the range: ");
        var startRange = Helpers.GetIntFromCommandLine();
        
        Console.Write("Enter the end of the range: ");
        var endRange = Helpers.GetIntFromCommandLine();
        
        var randomArray = GenerateArrayWithRandomNumbers(arraySize, startRange, endRange);
        Console.WriteLine($"Random Array: [{string.Join(", ", randomArray)}]");
        return;
        
        IEnumerable<int> GenerateArrayWithRandomNumbers(int arraySize, int minNumber, int maxNumber)
        {
        var random = new Random();
        var array = new int[arraySize];
        
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minNumber,maxNumber);
        }
        
        return array;
        }
    }

    public static void Task3()
    {
        Console.Write("Enter array size: ");
        var arraySize = Helpers.GetIntFromCommandLine();

        var random = new Random();
        var arrayWithNumbers = new int[arraySize];
        for (var i = 0; i < arrayWithNumbers.Length; i++)
        {
            arrayWithNumbers[i] = random.Next(-100, 101);
        }

        Console.WriteLine($"Array: [{string.Join(", ", arrayWithNumbers)}]");

        ArrayCalculation(arrayWithNumbers);
        return;


        void ArrayCalculation(IReadOnlyList<int> array)
        {
            var positiveCount = 0;
            var negativeCount = 0;
            var zeroCount = 0;

            foreach (var number in array)
            {
                switch (number)
                {
                    case > 0:
                        positiveCount++;
                        break;
                    case < 0:
                        negativeCount++;
                        break;
                    default:
                        zeroCount++;
                        break;
                }
            }

            Console.WriteLine($"Positive Count: {positiveCount}");
            Console.WriteLine($"Negative Count: {negativeCount}");
            Console.WriteLine($"Zero Count: {zeroCount}");
        }
    }

    public static void Task4()
    {
        var originalArray = GetTwoDimensionalArrayWithRandomNumbers();

        Console.WriteLine("Original Array:");
        for (var i = 0; i < originalArray.GetLength(0); i++)
        {
            for (var j = 0; j < originalArray.GetLength(1); j++)
            {
                Console.Write(originalArray[i, j] + " ");
            }

            Console.WriteLine();
        }

        var arrayWithMaxNumbers = new int[originalArray.GetLength(0)];
        for (var i = 0; i < originalArray.GetLength(0); i++)
        {
            arrayWithMaxNumbers[i] = Math.Max(originalArray[i, 0], originalArray[i, 1]);
        }

        Console.WriteLine(Environment.NewLine + "New Array:");
        foreach (var arrayItem in arrayWithMaxNumbers)
        {
            Console.WriteLine(arrayItem);
        }

        return;

        int[,] GetTwoDimensionalArrayWithRandomNumbers()
        {
            var random = new Random();

            const int numCols = 2;
            const int numRows = 10;
            var array = new int[numRows, numCols];

            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numCols; j++)
                {
                    array[i, j] = random.Next(0, 101);
                }
            }

            return array;
        }
    }

    public static void Task5()
    {
        Console.Write("Enter the size (1st dimension) of the 3D array: ");
        var size1 = Helpers.GetIntFromCommandLine();

        Console.Write("Enter the size (2nd dimension) of the 3D array: ");
        var size2 = Helpers.GetIntFromCommandLine();

        Console.Write("Enter the size (3rd dimension) of the 3D array: ");
        var size3 = Helpers.GetIntFromCommandLine();

        var array = new int[size1, size2, size3];
        var random = new Random();

        Console.WriteLine("Array items with indexes:");
        for (var i = 0; i < size1; i++)
        {
            for (var j = 0; j < size2; j++)
            {
                for (var k = 0; k < size3; k++)
                {
                    array[i, j, k] = random.Next(-100, 101);
                    Console.Write($"{array[i, j, k]} [{i}, {j}, {k}]; ");
                }
            }
        }

        Console.WriteLine();

        var min = array[0, 0, 0];

        for (var i = 0; i < size1; i++)
        {
            for (var j = 0; j < size2; j++)
            {
                for (var k = 0; k < size3; k++)
                {
                    if (array[i, j, k] < min)
                    {
                        min = array[i, j, k];
                    }
                }
            }
        }

        Console.WriteLine($"Minimum Element: {min}");
        Console.WriteLine("Indexes of Minimum Elements:");

        for (var i = 0; i < size1; i++)
        {
            for (var j = 0; j < size2; j++)
            {
                for (var k = 0; k < size3; k++)
                {
                    if (array[i, j, k] == min)
                    {
                        Console.WriteLine($"[{i}, {j}, {k}]");
                    }
                }
            }
        }
    }
}