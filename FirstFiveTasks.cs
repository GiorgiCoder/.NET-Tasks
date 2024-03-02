using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks
{
    public class FirstFiveTasks
    {
        // Task 1 - Check if given string is a palindrome
        public bool IsPalindrome(string text)
        {
            var left = 0;
            var right = text.Length - 1;

            while (right > left)
            {
                if (text[left] != text[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }


        // Task 2 - Minimal number of coins needed
        public int MinSplit(int amount)
        {
            int[] coins = [50, 20, 10, 5, 2, 1];
            int count = 0;

            foreach (int coin in coins)
            {
                int numOfCoins = amount / coin;
                count += numOfCoins;

                amount = amount % coin;
            }

            return count;
        }


        // Task 3 - Find the minimal positive integer that the array doesn't contain
        public int NotContains(int[] nums)
        {
            HashSet<int> numbers = new HashSet<int>(nums);

            for (int i = 1; i <= nums.Length + 1; i++) // O(n)
            {
                if (!numbers.Contains(i))
                {
                    return i;
                }
            }

            return -1;
        }


        // Task 4 - Check if parenthesis in a sequence are correctly placed
        public bool IsProperly(string sequence)
        {
            if (sequence[0] == ')') return false;

            Stack<char> chars = new Stack<char>();

            foreach (char c in sequence)
            {
                if (c == '(')
                {
                    chars.Push(c);
                }
                else
                {
                    if (chars.Pop() != '(') // popping at the same time, so if c = '(', we remove it and '(' and ')' cancel out
                        return false;
                }
            }

            return chars.Count == 0;
        }


        // Task 5 - Count total of how many combinations of 1 or 2 steps get you to the top of the stairs
        public int CountVariants(int stairCount)
        {
            // I used memoization since otherwise there will be many redundant operations calculating variants for the same stairCount
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return CountVariants(stairCount, memo);
        }

        private static int CountVariants(int stairCount, Dictionary<int, int> memo)
        {
            if (stairCount <= 2) return stairCount; // for stairCount = 1, only one option
                                                    // for stairCount = 2, two ways: one 2-step, or two 1-steps.
            if (memo.ContainsKey(stairCount))
                return memo[stairCount];

            int count = CountVariants(stairCount - 1, memo) + CountVariants(stairCount - 2, memo);

            memo.Add(stairCount, count);

            return count;
        }
    }
}
