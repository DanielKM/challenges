class Solution 
{
    public int solution(int[] array)
    {
        // Sort
        // Increment until you find the smallest
        // Return that number
        int[] sortedArray = array.OrderBy((x) => (x));

        Console.WriteLine(sortedArray);

        // foreach(int element in array)
        // {
        //     if()
        // }
    }

    // Array = A 
    // N integers
    // Return smallest positive integer that is not in A

    int[] A = [1, 3, 6, 4, 1, 2];

    solution(A);
}