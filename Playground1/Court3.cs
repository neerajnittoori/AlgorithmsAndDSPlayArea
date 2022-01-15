using System;
using System.Collections.Generic;
using Court3.DataStructures;

namespace Court3.DataStructures
{
}

namespace Playground1
{
    public class Court3
    {
        public void Play()
        {
            var oranges = new int[3][];
            oranges[0] = new int[] { 2, 1, 1 };
            oranges[1] = new int[] { 1, 1, 0 };
            oranges[2] = new int[] { 0, 1, 2 };
            // var minutesToRotOranges = OrangesRotting(oranges);
            var combine = Combine(4, 2);

            var permute = Permute(new int[] { 1, 2, 3 });
            var letterCasePermute = LetterCasePermutation("a1b2");
        }
         Dictionary<int, int> dict = new Dictionary<int, int>();
        public int ClimbStairs(int n) {
            if(n == 0) return 0;
            if(n == 1) return 1;
            if( n == 2) return 2;
            if(dict.ContainsKey(n)) return dict[n];
            var take1StepWays = ClimbStairs(n - 1);
            var take2StepsWays = ClimbStairs(n - 2);
            var numberofWays = take1StepWays + take2StepsWays;
            dict.Add(n, numberofWays);

            return numberofWays;
        }

        public IList<string> LetterCasePermutation(string s)
        {
            var list = LetterCasePermuteHelper(s, 0);
            return list;
        }

        public IList<string> LetterCasePermuteHelper(string s, int start)
        {
            IList<string> list = new List<string>();
            if (start >= s.Length) return list;
                var listToAdd = LetterCasePermuteHelper(s, start + 1);
                    if(listToAdd.Count > 0) {
                    foreach (var str in listToAdd)
                    {
                        if (Char.IsNumber(s[start]))
                        {
                            var strToAdd = s[start].ToString();
                            strToAdd += str;
                            list.Add(strToAdd);
                        }
                        else
                        {
                            var lowerStr = s[start].ToString().ToLowerInvariant();
                            var upperStr = s[start].ToString().ToUpper();
                            lowerStr += str;
                            upperStr += str;
                            list.Add(lowerStr);
                            list.Add(upperStr);
                        }
                    }
                } else {
                    if (Char.IsNumber(s[start]))
                        {
                            var strToAdd = s[start].ToString();
                            list.Add(strToAdd);
                        }
                        else
                        {
                            var lowerStr = s[start].ToString().ToLowerInvariant();
                            var upperStr = s[start].ToString().ToUpper();
                            list.Add(lowerStr);
                            list.Add(upperStr);
                        }
                }
            return list;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var list = PermuteHelper(nums, 0);

            return list;
        }

        IList<IList<int>> PermuteHelper(int[] nums, int startIndex)
        {
            var listToReturn = new List<IList<int>>();
            if (nums.Length == 0) return listToReturn;
            if (startIndex == nums.Length - 1)
            {
                listToReturn.Add(new List<int> { nums[startIndex] });
                return listToReturn;
            }
            //Swap currentIndex with 
            for (int i = startIndex; i < nums.Length; i++)
            {
                var temp = nums[startIndex];
                nums[startIndex] = nums[i];
                nums[i] = temp;

                var nextPermuteList = PermuteHelper(nums, startIndex + 1);
                foreach (var permuteList in nextPermuteList)
                {
                    var tempList = new List<int>();
                    tempList.Add(nums[startIndex]);
                    tempList.AddRange(permuteList);
                    listToReturn.Add(tempList);
                }
                var temp2 = nums[startIndex];
                nums[startIndex] = temp;
                nums[i] = temp2;
            }

            return listToReturn;
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> listToReturn = CombineHelper(1, n, k);

            return listToReturn;
        }

        public IList<IList<int>> CombineHelper(int start, int n, int k)
        {
            IList<IList<int>> listToReturn = new List<IList<int>>();
            if (k == 0) return listToReturn;
            for (int i = start; i <= n; i++)
            {
                if (k == 1)
                {
                    listToReturn.Add(new List<int> { i });
                    continue;
                }
                var listToAdd = CombineHelper(i + 1, n, k - 1);
                foreach (var temp in listToAdd)
                {
                    var tempList = new List<int>();
                    tempList.Add(i);
                    tempList.AddRange(temp);
                    listToReturn.Add(tempList);
                }
            }
            return listToReturn;
        }



        public int OrangesRotting(int[][] grid)
        {
            //Add all bad oranges to queue
            var queue = new Queue<int[]>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0) continue;
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue(new int[] { i, j });
                        grid[i][j] = 0;
                    }
                    else
                    {
                        grid[i][j] = int.MaxValue;
                    }
                }
            }

            var dirs = new int[4][];
            dirs[0] = new int[] { 0, -1 };
            dirs[1] = new int[] { 0, 1 };
            dirs[2] = new int[] { -1, 0 };
            dirs[3] = new int[] { 1, 0 };


            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                var r = cur[0];
                var c = cur[1];
                foreach (var dir in dirs)
                {
                    var xx = r + dir[0];
                    var yy = c + dir[1];
                    if (xx < 0 || yy < 0 || xx >= grid.Length || yy >= grid[0].Length || grid[xx][yy] == 0) continue;

                    if (grid[xx][yy] > grid[r][c] + 1)
                    {
                        grid[xx][yy] = grid[r][c] + 1;
                        queue.Enqueue(new int[] { xx, yy });
                    }
                }
            }

            int minTime = int.MinValue;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] > minTime)
                    {
                        minTime = grid[i][j];
                    }
                }
            }

            return minTime == int.MaxValue ? -1 : minTime;
        }

        public int[][] UpdateMatrix(int[][] mat)
        {
            var queue = new Queue<int[]>();
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue(new int[2] { i, j });
                    }
                    else
                    {
                        mat[i][j] = int.MaxValue;
                    }
                }
            }
            var dirs = new int[4][];
            //left
            dirs[0] = new int[] { 0, -1 };
            //right
            dirs[1] = new int[] { 0, 1 };
            //top
            dirs[2] = new int[] { -1, 0 };
            //bottom
            dirs[3] = new int[] { 1, 0 };

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                var r = cur[0];
                var c = cur[1];
                foreach (var dir in dirs)
                {
                    var xx = r + dir[0];
                    var yy = c + dir[1];
                    if (xx < 0 || yy < 0 || xx >= mat.Length || yy >= mat[0].Length) continue;
                    if (mat[xx][yy] > mat[r][c] + 1)
                    {
                        //If the result matrix distance at the neighbour node is greater than the currenNode + 1
                        queue.Enqueue(new int[2] { xx, yy });
                        mat[xx][yy] = mat[r][c] + 1;
                    }
                }
            }

            return mat;
        }


    }
}