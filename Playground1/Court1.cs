using System;
using System.Collections.Generic;
using System.Text;

namespace Playground1
{

    public class Court1
    {
        public void play()
        {
            var numList = new int[] { 2, 4, 6, 7, 9 };
            // var index = Search(numList, 4);
            // var firstBadVersion = FirstBadVersion(3);

            //var searchInsertResult = SearchInsert(numList, 10);

            //Rotate(numList, 1);
            ReverseString(new char[]{'h','e','l','l','0'});
            var reversedWords = ReverseWords("Let's Go Outside");

        }

         public string ReverseWords(string s) {
             var list = s.Split(" ");
             var strBuilder = new StringBuilder();
             foreach(var str in list)
             {
                 var chArray = str.ToCharArray();
                 ReverseString(chArray);
                 strBuilder.Append(new string(chArray));
                 strBuilder.Append(" ");
             }
             var retString = strBuilder.ToString().Trim();
             return retString;
        }

        public void ReverseString(char[] s)
        {
            var i = 0;
            var j = s.Length - 1;
            while (j > i)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
        }

        public void Rotate(int[] nums, int k)
        {
            // var prev = nums[nums.Length - 1];
            // while(k >= 0) {
            //     for(int i = 0; i < nums.Length; i++)
            //     {
            //         var temp = nums[i];
            //         nums[i] = prev;
            //         prev = temp;
            //     }
            //     --k;
            // }

            var list = new List<int>(nums);
            for (int i = k; i < nums.Length; i++)
            {
                nums[i] = list[i - k];
            }
            for (int i = 0; i < k; i++)
            {
                nums[i] = list[nums.Length - 1 - i];
            }

        }

        public int[] SortedSquares(int[] nums)
        {
            var numsToReturn = new int[nums.Length];

            for (int u = 0; u < nums.Length; u++)
            {
                nums[u] = nums[u] * nums[u];
            }

            int i = 0;
            int j = nums.Length - 1;
            var index = nums.Length - 1;
            while (j >= i)
            {
                if (nums[i] > nums[j])
                {
                    numsToReturn[index] = nums[i];
                    i++;
                }
                else
                {
                    numsToReturn[index] = nums[j];
                    j--;
                }
                index--;
            }
            return numsToReturn;
        }

        public int SearchInsert(int[] nums, int target)
        {
            int i = 0;
            int j = nums.Length;
            while (j >= i)
            {
                var mid = (i + j) / 2;
                if (i == j)
                {
                    if (i == nums.Length - 1 && nums[i] < target) return i + 1;
                    return i;
                }
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    j = mid;
                }
                else
                {
                    i = mid + 1;
                }
            }
            return 0;
        }

        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            var leftInd = 0;
            var rightInd = nums.Length;
            while (rightInd >= leftInd)
            {
                var curIndex = (rightInd + leftInd) / 2;
                if (curIndex >= nums.Length) return -1;

                if (nums[curIndex] == target) return curIndex;
                if (target < nums[curIndex])
                {
                    rightInd = curIndex - 1;
                    continue;
                }
                if (target > nums[curIndex])
                {
                    leftInd = curIndex + 1;
                }
            }
            return -1;
        }

        public int FirstBadVersion(int n)
        {
            int i = 1;
            int j = n;

            while (j >= i)
            {
                var mid = (i + j) / 2;
                if (isBadVersion(mid))
                {
                    j = mid - 1;
                }
                else
                {
                    i = mid + 1;
                }
            }

            return i;
        }

        public static bool isBadVersion(int n)
        {
            return n >= 2;
        }


    }
}