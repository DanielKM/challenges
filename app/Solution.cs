using System;

namespace app
{
    class Solution
    {

        static void Main(string[] args)
        {	
          	int[] A = {1, 4, 3, 1, 12}; 

            Console.WriteLine("Question 1 Answer: " + QuestionOne(A));

            int X = 5;
          	int[] B = {1, 3, 1, 4, 2, 3, 5, 4}; 

            Console.WriteLine("Question 2 Answer: " + QuestionTwo(X, B));

          	int[] C = {0, 1, 0, 1, 1, 0, 1}; 

            Console.WriteLine("Question 3 Answer: " + QuestionThree(C));

            
        }

        // QUESTION 1
        // array A
        // N integers
        // Return smallest positive integer that is not in A

        // ASSUMPTIONS
        // N is an integer within the range [1..100,000]
        // each element of array A is an integer within the range [−1,000,000..1,000,000]

        // This is solved in O(n), meaning it takes n operations because it loops through the list a constant number of times 
        //  (once for sorting, once for finding the missing number) 
        static int QuestionOne(int[] array)
        {
            // Sort the array in ascending order
            Array.Sort(array);

            // Declare lowest allowed value
            int lowestInt = 1;

            // Iterate through each integer in the sorted array
            foreach(int element in array)
            {
                // Check if the current integer in the array is larger than the lowest integer value 
                if(element > lowestInt) 
                { 
                    // Increment the lowest integer value and check again
                    lowestInt += 1;

                    // Check if the current integer in the array is larger than the lowest integer value and if so, return it
                    if(element > lowestInt) 
                    { 
                        return lowestInt; 
                    }
                }
                // Check if the current integer in the array is larger than zero, if it is, set the lowest integer to that value
                else if(element >= 0) { lowestInt = element; }
            }

            // Return the lowest integer
            return lowestInt; 
        }

        // QUESTION 2
    
        // Position 0 - Frog start position
        // Position X + 1 - Frog destination

        // Leaves fall onto the surface of the river
        // array A of N integers
        // A[K] represents the position where one leaf falls at time K, measured in seconds.

        // Goal - Find earliest time the frog can jump to the other side of the river
        // Constraints - The frog can only cross when all positions are covered in leaves (1 to x)

        // Assumptions 
        // - Non-empty array consisting of N integers 
        // - N and X are integers within the range [1..100,000];
        // - each element of array A is an integer within the range [1..X]

        // Return K (Earliest ime that the leaves are all down)
        // If the frog can never cross, return -1 

        // This is solved in O(n^2), meaning it is using quadratic time complexity:
        // * once for cloning the array, once for sorting, once for finding the missing number, then iterating through the template array
        // I could probably have made this more efficient, by not using question 1 as a method called, and by refactoring the template array loop
        static int QuestionTwo(int X, int[] array)
        {

            // clone the array to use the indices later
            int[] clonedArray = (int[]) array.Clone();

            // Check if there is a missed step, and if it is below the desired final leaf position
            int smallestMissedStep = QuestionOne(array);

            if(smallestMissedStep < X) { return -1; }

            // create a new array of length X
            int[] templateArray = new int[X];

            int highestInteger = 0;

            // if there is no missing step, iterate through the array, checking the cloned array for indices 
            // this operation is using quadratic time complexity (O(n^2))
            for(int i = 0; i < templateArray.Length; i++)
            {
                int currentInteger = Array.IndexOf(clonedArray, i + 1);

                if( currentInteger > highestInteger) { highestInteger = currentInteger; }
            }

            return highestInteger;
        }

        // QUESTION 3

        // Leaves fall onto the surface of the river
        // Cars on the road - array A of N integers

        // 0 = East 
        // 1 = West

        // (P, Q) = Pair of Cars
        // 0 <= P < Q < N
        // P is traveling Eastward
        // Q is traveling Westward

        // This is solved in O(n), meaning it is using linear time complexity:
        // It iterates through the array once
        static int QuestionThree(int[] array)
        {
            int totalPassed = 0;
            int eastwardCount = 0;

            // Starting at the end of the array, iterate through to determine how many cars go to the east 
            for(int i = array.Length - 1; i >= 0; i--) 
            {
                if( array[i] == 1 ) 
                {
                    eastwardCount +=1;
                } else {
                    totalPassed += eastwardCount;
                }
            }

            return totalPassed;
        }
    }
}
