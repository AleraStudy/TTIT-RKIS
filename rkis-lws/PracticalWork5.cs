namespace rkis_lws;

public static class PracticalWork5
{
    public static void Task1()
    {
        Console.WriteLine("Enter the array elements separated by commas:");
        var numbersArray = Helpers.GetArrayFromCommandLine();
        Console.WriteLine("Enter the target sum:");
        var target = Helpers.GetIntFromCommandLine();

        var indices = FindTwoSum(numbersArray, target);

        Console.WriteLine(indices != null
            ? $"Indexes: [{indices.Value.Item1}, {indices.Value.Item2}]"
            : "No two sum solution found!");
        return;

        (int, int)? FindTwoSum(IReadOnlyList<int> nums, int targetNumber)
        {
            for (var i = 0; i < nums.Count; i++)
            {
                for (var j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] + nums[j] == targetNumber)
                        return (i, j);
                }
            }
            return null;
        }
    }

    public static void Task2()
    {
        Console.WriteLine("Enter a number to be reversed:");
        var x = Helpers.GetIntFromCommandLine();
        var reversedNumber = ReverseNumber(x);
        Console.WriteLine($"Reversed number: {reversedNumber}");
        return;

        int ReverseNumber(int num)
        {
            var str = num.ToString();
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            var reversedStr = new string(charArray);
            return int.Parse(reversedStr);
        }
    }

    public static void Task3()
    {
        Console.WriteLine("Enter a number to check for palindrome:");
        var num = Helpers.GetIntFromCommandLine();
        var isPalindrome = IsPalindrome(num);
        Console.WriteLine($"Is palindrome: {isPalindrome}");
        return;

        bool IsPalindrome(int x)
        {
            if (x < 0) return false;  // Negative numbers are not palindromes

            var original = x.ToString();
            var reversed = new string(original.Reverse().ToArray());

            return original == reversed;
        }
    }

    public static void Task4()
    {
        Console.WriteLine("Enter the elements of the first array:");
        var listFirst = Helpers.GetArrayFromCommandLine();
        Console.WriteLine("Enter the elements of the second array:");
        var listSecond = Helpers.GetArrayFromCommandLine();

        var sortedMergedArray = MergeAndSort(listFirst, listSecond);
        Console.WriteLine($"Merged and sorted array: [{string.Join(", ", sortedMergedArray)}]");
        return;
        
        IEnumerable<int> MergeAndSort(IReadOnlyList<int> l1, IReadOnlyList<int> l2)
        {
            var merged = new List<int>(l1.Count + l2.Count);
            int i = 0, j = 0;

            // Merge the two arrays while they have elements
            while (i < l1.Count && j < l2.Count)
            {
                if (l1[i] <= l2[j])
                {
                    merged.Add(l1[i]);
                    i++;
                }
                else
                {
                    merged.Add(l2[j]);
                    j++;
                }
            }

            // If there are remaining elements in l1 or l2, add them to the merged list
            while (i < l1.Count)
            {
                merged.Add(l1[i]);
                i++;
            }
            while (j < l2.Count)
            {
                merged.Add(l2[j]);
                j++;
            }

            return merged.ToArray();
        }
    }

    public static void Task5()
    {
        var numbers = Helpers.GetArrayFromCommandLine();
        Console.WriteLine("Enter the target value:");
        var targetNumber = Helpers.GetIntFromCommandLine();

        var insertPosition = SearchTargetPosition(numbers, targetNumber);
        Console.WriteLine(insertPosition);
        return;


        int SearchTargetPosition(IReadOnlyList<int> nums, int target)
        {
            var low = 0;
            var high = nums.Count - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;  // If target is not found, low is the index where it could be inserted
        }
    }
}