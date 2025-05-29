namespace leetcodeConsole;

using leetcode;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("hello");

        int[][] matrix = [[1, 2, 4, 8], [10, 11, 12, 13], [14, 20, 30, 40]];
        int target = 10;

        Console.WriteLine(BinarySearch.searchMatrix(matrix, target));
    }
}
