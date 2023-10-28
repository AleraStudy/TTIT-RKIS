namespace rkis_lws;

public static class PracticalWork7
{
    public static void Task1()
    {
        var numbers = Helpers.GetArrayFromCommandLine();

        var sum = SumOfEvenIndices(numbers);
        Console.WriteLine($"The sum of numbers at even indices is: {sum}");
        return;

        int SumOfEvenIndices(IReadOnlyList<int> array)
        {
            var result = 0;
            for (var i = 0; i < array.Count; i += 2)
            {
                result += array[i];
            }

            return result;
        }
    }

    public static void Task2()
    {
        Console.WriteLine("Enter the day:");
        var day = Helpers.GetIntFromCommandLine(1, 31);
        Console.WriteLine("Enter the month:");
        var month = Helpers.GetIntFromCommandLine(1, 12);

        var isDateValid = ValidateDate(day, month);
        Console.WriteLine(isDateValid ? "Yes" : "No");
        return;

        bool ValidateDate(int day, int month)
        {
            try
            {
                var dateTime = new DateTime(DateTime.Now.Year, month, day);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }

    public static void Task3()
    {
        Console.WriteLine("Enter a number:");
        var number = Helpers.GetDoubleFromCommandLine();

        var result = ProcessNumber(number);
        Console.WriteLine($"The processed number is: {result}");
        return;

        double ProcessNumber(double num)
        {
            switch (num)
            {
                case >= 2 and <= 5:
                    return num + 10;
                case >= 7 and <= 40:
                    return num - 100;
                case <= 0:
                case > 3000:
                    return num * 3;
                default:
                    return 0;
            }
        }
    }

    public static void Task4()
    {
        Console.WriteLine("Enter the exchange rate (USD to RUB):");
        var rate = Helpers.GetDoubleFromCommandLine();

        PrintConversionTable(rate);
        return;

        void PrintConversionTable(double exchangeRate)
        {
            Console.WriteLine("USD - RUB - KG of Candy");
            for (var i = 1; i <= 100; i++)
            {
                var rub = i * exchangeRate;
                var kgCandy = rub / 20;
                Console.WriteLine($"{i}$ - {rub} р - {kgCandy} kg");
            }
        }
    }

    public static void Task5()
    {
        var count = 0;
        int number;
        do
        {
            Console.WriteLine("Enter a non-zero integer (0 to stop):");
            number = Helpers.GetIntFromCommandLine();
            if (number % 2 == 0 && number != 0) count++;
        } while (number != 0);

        Console.WriteLine($"Count of even numbers entered: {count}");
    }

    public static void Task6()
    {
        var numbers = Helpers.GetArrayFromCommandLine();

        var result = FindMinAndCount(numbers);
        Console.WriteLine($"Minimum number: {result.Item1}, Count: {result.Item2}");
        return;

        (int, int) FindMinAndCount(int[] array)
        {
            var min = array.Min();
            var count = array.Count(n => n == min);
            return (min, count);
        }
    }

    public static void Task7()
    {
        var numbers = Helpers.GetArrayFromCommandLine();

        var reversedArray = ReverseArray(numbers);
        Console.WriteLine($"Reversed array: [{string.Join(", ", reversedArray)}]");
        return;

        IEnumerable<int> ReverseArray(IEnumerable<int> array)
        {
            return array.Reverse().ToArray();
        }
    }

    public static void Task8()
    {
        // Assuming a fixed size matrix for simplicity
        var matrix = new int[5, 5]
        {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { 16, 17, 18, 19, 20 },
            { 21, 22, 23, 24, 25 }
        };

        PrintFirstAndLastRowsAndColumns(matrix);
        return;

        void PrintFirstAndLastRowsAndColumns(int[,] mat)
        {
            Console.WriteLine("First and Last Rows and Columns:");
            for (var i = 0; i < mat.GetLength(0); i++)
            {
                for (var j = 0; j < mat.GetLength(1); j++)
                {
                    if (i == 0 || i == mat.GetLength(0) - 1 || j == 0 || j == mat.GetLength(1) - 1)
                    {
                        Console.Write(mat[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
            }
        }
    }

    public static void Task9()
    {
        // Assuming a fixed size matrix for simplicity
        var matrix = new int[5, 5]
        {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { 16, 17, 18, 19, 20 },
            { 21, 22, 23, 24, 25 }
        };
        Console.WriteLine("Initial:");
        Helpers.PrintMatrix(matrix);
        
        SwapRows(matrix, 3, 4);
        Console.WriteLine();
        Console.WriteLine("Result:");
        Helpers.PrintMatrix(matrix);
        return;

        void SwapRows(int[,] mat, int row1, int row2)
        {
            for (var j = 0; j < mat.GetLength(1); j++)
            {
                (mat[row1, j], mat[row2, j]) = (mat[row2, j], mat[row1, j]);
            }
        }

        
    }

    public static void Task10()
    {
        Console.WriteLine("Enter the number of rows:");
        var rows = Helpers.GetIntFromCommandLine(1);
        Console.WriteLine("Enter the number of columns:");
        var columns = Helpers.GetIntFromCommandLine(1);

        // Creating the source matrix
        var matrix = new int[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                matrix[i, j] = i * columns + j + 1; // Simply filling the matrix with numbers for example
            }
        }

        Console.WriteLine("Original Matrix:");
        Helpers.PrintMatrix(matrix);

        var shuffledMatrix = ShuffleRows(matrix);
        Console.WriteLine("Shuffled Matrix:");
        Helpers.PrintMatrix(shuffledMatrix);
        return;

        int[,] ShuffleRows(int[,] originalMatrix)
        {
            var rand = new Random();
            var rowCount = originalMatrix.GetLength(0);
            var columnCount = originalMatrix.GetLength(1);
            var resultMatrix = (int[,])originalMatrix.Clone(); // Cloning the source matrix

            for (var i = 0; i < rowCount; i++)
            {
                var randomIndex = rand.Next(rowCount); // Getting a random row index

                // Swapping rows
                for (var j = 0; j < columnCount; j++)
                {
                    (resultMatrix[i, j], resultMatrix[randomIndex, j]) = (resultMatrix[randomIndex, j], resultMatrix[i, j]);
                }
            }

            return resultMatrix;
        }
    }
}