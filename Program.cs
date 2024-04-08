using System.Text;

namespace Assignment2_Sasank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,,,,,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the input array is empty or null
                if (nums == null || nums.Length == 0)
                    return 0; // If so, return 0 as there are no elements to process

                int k = 1; // Initialize the count of unique elements to 1 (first element is always unique)
                for (int i = 1; i < nums.Length; i++)
                {
                    // Check if the current element is different from the previous one
                    if (nums[i] != nums[i - 1])
                    {
                        // If the current element is unique, move it to the next position
                        nums[k] = nums[i]; // Update the array to keep track of unique elements
                        k++; // Increment the count of unique elements
                    }
                }
                // Return the count of unique elements after removing duplicates
                return k;
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions that occur during the process
            }
        }


        /*
         * Self Reflection
         * In tackling this problem, I engaged with the fundamental concepts of array manipulation, particularly focusing on in-place modifications to remove duplicates efficiently.

As I implemented the solution, I revisited the concept of traversing arrays, understanding the importance of iterating through each element to identify and handle duplicates effectively.

Encountering edge cases such as empty arrays or arrays with just one element prompted me to pay closer attention to handling such scenarios. I realized the significance of incorporating conditional checks to ensure the function behaves correctly under all conditions, thereby enhancing its robustness.

Through this exercise, I gained insight into the importance of optimizing both time and memory complexities. By ensuring that the solution operates efficiently in linear time, I acknowledged the performance implications, especially when dealing with large datasets or real-time applications where speed and memory usage are critical factors.

Overall, this experience deepened my understanding of array manipulation techniques and reinforced the significance of considering efficiency in algorithm design.
        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if the input array is null or has only one element
                if (nums == null || nums.Length <= 1)
                    return nums.ToList(); // Return the list as it is if it's null or has only one element

                int nonZeroIndex = 0; // Initialize the index for non-zero elements
                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the current element is non-zero
                    if (nums[i] != 0)
                    {
                        // Move the non-zero element to the current non-zero index
                        nums[nonZeroIndex] = nums[i];
                        nonZeroIndex++; // Increment the non-zero index
                    }
                }

                // Fill the remaining positions with zeroes from the last non-zero index
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0; // Set remaining positions to zero
                }

                // Convert the modified array to a list and return
                return nums.ToList();
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions that occur during the process
            }
        }


        /*
         * Self-Reflection :
         
         * 
               This problem presented an opportunity to practice rearranging elements within an array without using additional space, which is fundamental in array manipulation. 
        Initially, the approach involved iterating through the array to move non-zero elements to the beginning while preserving their relative order, reinforcing efficient array traversal techniques. 
        Attention was given to handling edge cases, such as arrays with fewer than two elements or those consisting entirely of zeros, ensuring the function behaved correctly across various scenarios. 
        By optimizing array manipulation without making copies or using extra space, the solution effectively achieved the desired outcome while maintaining the relative order of elements, demonstrating a methodical approach to problem-solving in array manipulation techniques.
         */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>(); // Initialize the result list
                Array.Sort(nums); // Sort the array in ascending order

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int left = i + 1; // Initialize the left pointer
                    int right = nums.Length - 1; // Initialize the right pointer

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right]; // Calculate the sum of the triplet

                        if (sum == 0)
                        {
                            // Found a triplet with sum equal to zero
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++; // Move the left pointer to the right
                            right--; // Move the right pointer to the left
                        }
                        else if (sum < 0)
                        {
                            left++; // Move left pointer to increase sum
                        }
                        else
                        {
                            right--; // Move right pointer to decrease sum
                        }
                    }
                }
                return result; // Return the list of triplets
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }


        /*
         * Self-Reflection :
         
          To address this problem, sophisticated array manipulation techniques were employed, including sorting the array and employing multiple pointers to identify triplets summing up to zero.
          It was crucial to meticulously handle edge cases to minimize unnecessary computations and optimize performance. 
          The solution was implemented using conditional statements to manage duplicate pointer adjustments and determine actions based on the sum of elements, refining my proficiency in applying conditional logic to algorithmic solutions. 
          Leveraging data structures like lists to store and return the result set underscored the significance of selecting appropriate data structures for efficient problem-solving, emphasizing principles learned regarding data structures. 
          Continuous refinement of the implementation aimed at minimizing redundant computations and enhancing overall solution efficiency, highlighting a dedicated focus on algorithm optimization for improved performance.
         */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxConsecutiveCount = 0; // Initialize the maximum consecutive count of 1's
                int currentConsecutiveCount = 0; // Initialize the current consecutive count of 1's

                // Iterate through the array
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        // Increment the current count for consecutive 1's
                        currentConsecutiveCount++;
                    }
                    else
                    {
                        // Update the maximum count and reset the current count when encountering 0
                        maxConsecutiveCount = Math.Max(maxConsecutiveCount, currentConsecutiveCount);
                        currentConsecutiveCount = 0;
                    }
                }

                // Update maxConsecutiveCount for the last sequence of consecutive 1's
                maxConsecutiveCount = Math.Max(maxConsecutiveCount, currentConsecutiveCount);

                return maxConsecutiveCount; // Return the maximum consecutive count of 1's
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }


        /*
         * Self-Reflection :
         
          The solution necessitated a strategic traversal of the array to accurately update the count of encountered elements.
          This process provided valuable insights into effective array traversal techniques. Essentially, the solution meticulously tracked the occurrence positions of ones within the binary array, enabling precise counting of consecutive elements.
          The simplicity and clarity of the approach underscored the importance of maintaining clarity in algorithmic solutions. Special consideration was given to handling edge cases, such as arrays with only one element or consisting entirely of zeros, ensuring robustness across various scenarios.
          Emphasizing efficient count updates during array traversal highlighted the significance of designing algorithms with optimal time complexity.
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the Math.Pow function. You will implement a function called BinaryToDecimal which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the BinaryToDecimal function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (<<, >>, &, |, ^) and the Math.Pow function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalValue = 0; // Initialize the decimal value to 0
                int powerOfTwo = 1; // Initialize the power of two to 1

                // Iterate until the binary number becomes 0
                while (binary != 0)
                {
                    int lastDigit = binary % 10; // Extract the last digit of the binary number
                    binary /= 10; // Remove the last digit from the binary number

                    decimalValue += lastDigit * powerOfTwo; // Update the decimal value by adding the last digit multiplied by the power of two
                    powerOfTwo *= 2; // Update the power of two for the next iteration
                }

                return decimalValue; // Return the decimal value
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }


        /*
         * Self-Reflection :
         
           The process of converting binary numbers to decimal ones through basic arithmetic operations significantly deepened my understanding of number systems. 
           The solution is straightforward and relies solely on simple arithmetic, showcasing the efficiency of algorithms in problem-solving.
           This approach highlights the significance of numerical operations in algorithmic solutions and emphasizes creativity in problem-solving. 
           It underscores the importance of considering alternative approaches and avoiding reliance on complex functions or operators, demonstrating the simplicity and effectiveness of using basic arithmetic operations.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 2)
                    return 0; // Return 0 if the array is null or has less than two elements

                // Find the minimum and maximum elements in the array
                int minVal = int.MaxValue;
                int maxVal = int.MinValue;
                foreach (int num in nums)
                {
                    minVal = Math.Min(minVal, num); // Update the minimum value
                    maxVal = Math.Max(maxVal, num); // Update the maximum value
                }

                // Calculate the minimum possible gap
                int minGap = (int)Math.Ceiling((double)(maxVal - minVal) / (nums.Length - 1));

                // Create buckets to store elements
                int numBuckets = (maxVal - minVal) / minGap + 1;
                int[] minBucket = new int[numBuckets];
                int[] maxBucket = new int[numBuckets];
                Array.Fill(minBucket, int.MaxValue);
                Array.Fill(maxBucket, int.MinValue);

                // Distribute numbers into buckets
                foreach (int num in nums)
                {
                    int index = (num - minVal) / minGap;
                    minBucket[index] = Math.Min(minBucket[index], num); // Update the minimum value in the bucket
                    maxBucket[index] = Math.Max(maxBucket[index], num); // Update the maximum value in the bucket
                }

                // Find the maximum gap between successive non-empty buckets
                int maxGap = 0;
                int prevMax = maxBucket[0];
                for (int i = 1; i < numBuckets; i++)
                {
                    if (minBucket[i] != int.MaxValue)
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - prevMax); // Update the maximum gap
                        prevMax = maxBucket[i]; // Update the previous maximum value
                    }
                }

                return maxGap; // Return the maximum gap
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }




        /*
         * Self-Reflection :
         
           This problem required applying mathematical concepts to calculate the gap between elements and distribute numbers into buckets.
           It emphasized using these concepts effectively in algorithmic solutions.
           The method ensured linear time complexity and linear extra space usage, highlighting the importance of efficiency in algorithms.
           Handling edge cases, like arrays with fewer than two elements, ensured the function works flawlessly under any condition. 
           Manipulating the array to distribute elements into buckets and compute the gap highlighted the significance of careful algorithm design while adhering to constraints.
           Overall, the reflection emphasized the importance of being aware of constraints and designing algorithms accordingly for efficient problem-solving.
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array in ascending order
                for (int i = nums.Length - 1; i >= 2; i--) // Iterate from right to left to find the largest perimeter
                {
                    int a = nums[i - 2]; // Length of side 'a'
                    int b = nums[i - 1]; // Length of side 'b'
                    int c = nums[i]; // Length of side 'c'
                    if (a + b > c) // Check if a valid triangle can be formed
                    {
                        return a + b + c; // Return the perimeter of the triangle
                    }
                }
                return 0; // No valid triangle can be formed
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }

        /*
         * Self-Reflection :
         
           While working on this problem, I focused on applying the triangle inequality theorem to determine if given side lengths could form a valid triangle with a non-zero area.
           This process helped me connect geometric concepts with algorithmic solutions. The straightforward approach of iterating through the sorted array to check for valid triangles demonstrated an efficient algorithm design.
           Through this, I realized that effective algorithm design often requires interdisciplinary thinking, where mathematical concepts are seamlessly integrated into the solution.
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string originalString, string substring)
        {
            try
            {
                int index;
                while ((index = originalString.IndexOf(substring)) != -1)
                {
                    // Remove the leftmost occurrence of the substring
                    originalString = originalString.Remove(index, substring.Length);
                }
                return originalString;
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }


        /*
         * Self-Reflection :
         
         * 
           While working on this solution, I refreshed my skills in handling strings, particularly with methods like IndexOf and Remove, which helped identify and remove substrings efficiently.
           The implementation employs a while loop to search for and remove the substring from the original string, ensuring accuracy and effectiveness in repetitive tasks. Robust error handling is incorporated to handle exceptions, such as 'index out of range' errors, which could occur during string manipulation.
           By utilizing built-in string manipulation methods, the solution showcases the optimization features of the language for efficient algorithm design. 
           Overall, the solution provides a clear and readable approach for replacing occurrences of substrings, demonstrating the effectiveness of algorithmic problem-solving.
         */


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}