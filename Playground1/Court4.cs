
using System;
using System.Collections.Generic;

namespace Playground1
{
    public class Court4
    {
        public void Play()
        {
            var minTotalList = new List<IList<int>>();
            minTotalList.Add(new List<int> { -1 });
            minTotalList.Add(new List<int> { 2, 3 });
            minTotalList.Add(new List<int> { 1, -1, -3 });

            var minTot = MinimumTotal(minTotalList);
            var twoSum = TwoSum(new int[] { 1, 3, 1, 4 }, 6);
            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var nums2 = new int[] { 2, 5, 6 };
           //Merge(nums1, 3, nums2, 3);
           // var intersectedArray = Intersect(new int[]{4,9,5}, new int[]{9,4,9,8,4});
            var doesContainNearByDuplicate = ContainsNearbyAlmostDuplicate(new int[]{-2147483648, 2147483647}, 1, 1);
        }

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
            for(int i = 0; i < nums.Length; i++) {
                var maxIndex = Math.Min(nums.Length - 1, i + k);
                while(maxIndex > i) {
                    long result = Math.Abs(Convert.ToInt64(nums[i]) - Convert.ToInt64(nums[maxIndex]));
                    //abs(nums[i] - nums[j]) <= t
                    if(result <= t) return true;
                    maxIndex--;
                }
            }

            return false;
        }      

         public int[][] MatrixReshape(int[][] mat, int r, int c) {
               if(r * c != mat.Length * mat[0].Length) return mat;
             var list = new List<int>();
             for(int i =0;i < mat.Length; i++) {
                 for(int j = 0; j < mat[0].Length; j++) {
                     list.Add(mat[i][j]);
                 }
             }

             var newMat = new int[r][];
             var count = 0;
             for(int i = 0; i < r; i++) {
                 newMat[i] = new int[c];
                 for(int j =0; j < c; j++) {
                     newMat[i][j] = list[count];
                     count++;
                 }
             }
             return newMat;
         }

        public int MaxProfit(int[] prices) {
            if(prices.Length == 0) return 0;
            int currentMaxProfit = 0;
            int buyingPrice = prices[0];
            foreach(var price in prices) {
                if(price < buyingPrice) {
                    buyingPrice = price;
                    currentMaxProfit = 0;
                } else {
                    currentMaxProfit = Math.Max(price - buyingPrice, currentMaxProfit);
                }
            }

            return currentMaxProfit;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var dictionary = new Dictionary<int, int>();
            int[] arrToAssign;
            int[] arrToLoop;
            if (nums1.Length < nums2.Length)
            {
                arrToAssign = nums2;
                arrToLoop = nums1;
            }
            else
            {
                arrToAssign = nums1;
                arrToLoop = nums2;
            }
            foreach (var num in arrToAssign)
            {
                if(dictionary.ContainsKey(num))
                    dictionary[num] = dictionary[num] + 1;
                else 
                    dictionary[num] = 1;
            }
            var listToReturn = new List<int>();
            foreach(var num in arrToLoop) {
                if(dictionary.ContainsKey(num) && dictionary[num] > 0) {
                    listToReturn.Add(num);
                    dictionary[num] = dictionary[num] - 1;
                }
            }

            return listToReturn.ToArray();
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var index = m + n - 1;
            var i = m - 1;
            var j = n - 1;
            while (index >= 0 && (i >= 0 || j >= 0))
            {
                if (i < 0)
                {
                    nums1[index] = nums2[j];
                    j--;
                }
                else if (j < 0)
                {
                    nums1[index] = nums1[i];
                    i--;
                }
                else if (nums1[i] > nums2[j])
                {
                    nums1[index] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[index] = nums2[j];
                    j--;
                }

                index--;
            }
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var numDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                numDict[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var requiredSum = target - nums[i];
                if (numDict.ContainsKey(requiredSum) && numDict[requiredSum] != i)
                {
                    return new int[] { i, numDict[requiredSum] };
                }
            }
            return null;
        }

        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int currentMaxVal = nums[0];
            int maxVal = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentMaxVal = Math.Max(nums[i], currentMaxVal + nums[i]);
                maxVal = Math.Max(maxVal, currentMaxVal);
            }

            return maxVal;
        }

        Dictionary<int, List<int>> pascalTriangleDictionary = new Dictionary<int, List<int>>();

        public IList<IList<int>> Generate(int numRows)
        {
            var list = new List<IList<int>>();
            GenerateHelper(numRows);
            for (int i = 1; i <= numRows; i++)
            {
                list.Add(pascalTriangleDictionary[i]);
            }

            return list;
        }
        public List<int> GenerateHelper(int numRows)
        {
            var list = new List<int>();
            if (numRows == 0) return list;
            list.Add(1);
            if (pascalTriangleDictionary.ContainsKey(numRows)) return pascalTriangleDictionary[numRows];
            if (numRows == 1)
            {
                pascalTriangleDictionary.TryAdd(1, list);
                return list;
            }

            var pascalForUpperLevel = GenerateHelper(numRows - 1);
            for (int i = 0; i + 1 < pascalForUpperLevel.Count; i++)
            {
                list.Add(pascalForUpperLevel[i] + pascalForUpperLevel[i + 1]);
            }

            list.Add(1);
            pascalTriangleDictionary.Add(numRows, list);
            return list;
        }

        Dictionary<int, int> dict = new Dictionary<int, int>();
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var list = new List<int>();
            var lenList = new List<int>();
            foreach (var t in triangle)
            {
                var c = t.Count;
                foreach (var num in t)
                {
                    lenList.Add(c);
                    list.Add(num);
                }
            }

            var minPath = MiniumumTotalHelper(list, lenList, 0);

            return minPath;
        }



        public int MiniumumTotalHelper(List<int> triangle, List<int> lenList, int index)
        {
            if (index >= triangle.Count) return 0;
            if (dict.ContainsKey(index)) return dict[index];
            var path1 = triangle[index] + MiniumumTotalHelper(triangle, lenList, index + lenList[index]);
            var path2 = triangle[index] + MiniumumTotalHelper(triangle, lenList, index + lenList[index] + 1);
            var min = Math.Min(path1, path2);
            dict.Add(index, min);

            return min;
        }

        Dictionary<int, int> robAmountDictionary = new Dictionary<int, int>();
        public int Rob(int[] nums)
        {
            //var amount = new int[nums.Length];
            var amount1 = RobHelper(nums, 0);
            var amount2 = RobHelper(nums, 1);

            var max = Math.Max(amount1, amount2);
            return max;
        }

        public int RobHelper(int[] nums, int index)
        {
            if (index >= nums.Length) return 0;
            if (robAmountDictionary.ContainsKey(index)) return robAmountDictionary[index];
            var amount1 = nums[index] + RobHelper(nums, index + 2);
            var amount2 = nums[index] + RobHelper(nums, index + 3);

            var max = Math.Max(amount1, amount2);
            robAmountDictionary.Add(index, max);
            return max;
        }
    }
}