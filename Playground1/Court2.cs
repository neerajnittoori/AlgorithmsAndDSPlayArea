using System;
using System.Collections.Generic;

namespace Playground1 {
    public class Court2 {
        public void Play() {
            //var longestSubStr = LengthOfLongestSubstring("abba");
            var checkInclusion = CheckInclusion("adc", "dcda");
            var floodFillMatrix = new int[3][];
            floodFillMatrix[0] = new int[3] {1,1,1};
            floodFillMatrix[1] = new int[3] {1,2,0};
            floodFillMatrix[2] = new int[3] {1,0,1};
            var floodFill = FloodFill(floodFillMatrix, 1, 1, 2);
        }

         public int MaxAreaOfIsland(int[][] grid) {
             int maxArea = 0;
             for(int i = 0; i < grid.Length; i++)
             {
                 for(int j = 0; j < grid[0].Length; j++)
                 {
                     var curArea = ExploreIslandAndCalculateArea(grid, i, j);
                     maxArea = Math.Max(maxArea, curArea);
                 }
             }
             return maxArea;
        }

        private int ExploreIslandAndCalculateArea(int[][] grid, int i, int j) {
            if (i < 0 || j < 0 || i >=  grid.Length || j >= grid[0].Length || grid[i][j] != 1) return 0;

            grid[i][j] = 2;
            var left = j - 1;
            var right = j + 1;
            var top = i - 1;
            var bottom = i + 1;
            
            return 1 + ExploreIslandAndCalculateArea(grid, i, left) +
            ExploreIslandAndCalculateArea(grid, i, right) +
            ExploreIslandAndCalculateArea(grid, top, j) +
            ExploreIslandAndCalculateArea(grid, bottom, j);
        }

         public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
             var originalColor = image[sr][sc];
             if (newColor == originalColor) return image;
             Fill(image, sr, sc, newColor, originalColor);

             return image;
        }

        void Fill(int[][] image, int i, int j, int newColor, int originalColor) {
            
            if (i < 0 || j < 0 || i >= image.Length || j >= image[0].Length || image[i][j] != originalColor) return;
            var left = j - 1;
            var right = j + 1;
            var top = i - 1;
            var bottom = i + 1;
            image[i][j] = newColor;
            Fill(image, i, left, newColor, originalColor);
            Fill(image, i, right, newColor, originalColor);
            Fill(image, top, j, newColor, originalColor);
            Fill(image, bottom, j, newColor, originalColor);
        }

        public bool CheckInclusion(string s1, string s2) {
            int curIndex = 0;
            var dictionary = new Dictionary<char, int>();
            fillDictionary(s1, dictionary, 0 , s1.Length - 1);
            for(int i = 0; i < s2.Length; i++) {
                if(dictionary.ContainsKey(s2[i]) && dictionary[s2[i]] > 0) {
                    if(i - curIndex + 1 == s1.Length) {
                        return true;
                    }
                    dictionary[s2[i]] = dictionary[s2[i]] - 1;
                } else {
                    fillDictionary(s2, dictionary, curIndex, i - 1);
                    curIndex = curIndex + 1;
                    i = curIndex;
                }
            }
            return false;
        }

        private void fillDictionary(string s, Dictionary<char,int> dict, int l, int r) {
            if ( r < l) return;
            for(int i = l; i <= r; i++) {
                var currentChar = s[i];
                if(dict.ContainsKey(currentChar)) {
                    dict[currentChar] = dict[currentChar] + 1;
                } else {
                    dict[currentChar] = 1;
                }
            }
        }

        public int LengthOfLongestSubstring(string s) {
            //using 2 pointers
            int left = 0;
            int length = 0;
            var dict = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i])) {
                    if (dict[s[i]] >= left) {
                        left = dict[s[i]] + 1;
                    }
                    
                }
                length = Math.Max(length, i - left + 1);
                dict[s[i]] = i;
            }   

            return length;
        }
    }
}