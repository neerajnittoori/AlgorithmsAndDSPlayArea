using System;
using System.Collections.Generic;
using Court5.DataStructures;

namespace Court5.DataStructures
{
    public class MyQueue {
        
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public MyQueue() {
            
        }
        
        public void Push(int x) {
            stack1.Push(x);
        }
        
        public int Pop() {
            if(stack1.Count == 0) return -1;
            while(stack1.Count > 1) {
                var poppedEle = stack1.Pop();
                stack2.Push(poppedEle);
            }
            var eleToReturn = stack1.Pop();
            while(stack2.Count > 0) {
                var poppedEle = stack2.Pop();
                stack1.Push(poppedEle);
            }
            
            return eleToReturn;
        }
        
        public int Peek() {
            if(stack1.Count == 0) return -1;
            while(stack1.Count > 1) {
                var poppedEle = stack1.Pop();
                stack2.Push(poppedEle);
            }
            var eleToReturn = stack1.Peek();
            while(stack2.Count > 0) {
                var poppedEle = stack2.Pop();
                stack1.Push(poppedEle);
            }
            
            return eleToReturn;
        }
        
        public bool Empty() {
            return stack1.Count == 0;
        }
    }
    
    
    
}

namespace Playground1
{
    public class Court5
    {
        public void Play()
        {
            // var matrix = new int[3][];
            // matrix[0] = new int[]{1, 3, 5 ,7};
            // matrix[1] = new int[]{10, 11, 16, 20};
            // matrix[2] = new int[]{23, 30, 34, 60};
            // var isFound = SearchMatrix(matrix, 3);
            // FirstUniqChar("leetcode");
            // var isValidBrackets = IsValid("{[]()}");
            
            var myQueue = new MyQueue();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);
            var ele = myQueue.Pop();
        }
        
        public bool IsValid(string s) {
            var stack = new Stack<char>();
            foreach(var ch in s) {
                var rightBracket = GetRightBracket(ch);
                if(rightBracket == ' '){ //Which means this is a right bracket and we gotta pop left bracket
                    if(stack.Count == 0) return false;
                    var poppedBracket = stack.Pop();
                    var bracket = GetRightBracket(poppedBracket);
                    if(bracket != ch) return false;
                } else {
                    stack.Push(ch);
                }
            }
            return stack.Count == 0;
        }
        
        public char GetRightBracket(char ch) {
            if(ch == '(') return ')';
            if(ch == '{') return '}';
            if(ch == '[') return ']';
            
            return ' ';
        }
        
        public bool IsAnagram(string s, string t) {
            int[] arr = new int[26];
            foreach(var ch in s) {
                arr[ch - 97] = arr[ch - 97] + 1;
            }
            
            foreach(var ch in t) {
                arr[ch - 97] = arr[ch - 97] - 1;
            }
            
            foreach(var num in arr) {
                if (num != 0) return false;
            }
            
            return true;
        }
        
        public bool CanConstruct(string ransomNote, string magazine) {
            int[] mag = new int[26];
            foreach(var ch in magazine) {
                mag[ch - 97] = mag[ch - 97] + 1;
            }
            
            foreach(var ch in ransomNote) {
                var index = ch - 97;
                mag[index] = mag[index] - 1;
            }
            
            foreach(var num in mag) {
                if (num < 0) return false;
            }
            return true;
        }
        
         public int FirstUniqChar(string s) {
            int[] myCount = new int[26];
            foreach(var ch in s) {
                myCount[ch - 97] = myCount[ch - 97] + 1;
            }
            for(int i = 0; i < s.Length; i++) {
                var index = s[i] - 97;
                if(myCount[index] == 1) {
                    return i;
                }
            }
            
            return -1;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            var rowToSearch = WhereShouldIInsertElement(matrix, target);
            var isEleFound = IsEleFound(matrix, target, rowToSearch);
            return isEleFound;
        }
        
        private bool IsEleFound(int[][] matrix, int target, int rowToSearch) {
            var arr = matrix[rowToSearch];
            int i = 0;
            int j = arr.Length - 1;
            while(i <= j) {
                var mid = (i + j)/2;
                if (arr[mid] == target) return true;
                if(target < arr[mid]) {
                    j = mid - 1;
                } else {
                    i = mid + 1;
                }
            }
            return false;
        }

        private int WhereShouldIInsertElement(int[][] nums, int target)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (i <= j)
            {
                var mid = (i + j) / 2;
                if (nums[mid][0] == target) return mid;
                if (target < nums[mid][0])
                {
                    j = mid - 1;
                }
                else
                {
                    i = mid + 1;
                }

            }

            return i - 1 < 0 ? 0 : i - 1;
        }

        public bool IsValidSudoku(char[][] board)
        {
            var hashSetArray = new HashSet<char>[9];
            var reusableDictionary = new HashSet<char>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    //Checking Duplicate Rows
                    var cur = board[i][j];
                    if (cur == '.') continue;
                    if (reusableDictionary.Contains(cur)) return false;
                    reusableDictionary.Add(cur);
                }

                reusableDictionary.Clear();
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    //Checking Duplicate Cols
                    var cur = board[j][i];
                    if (cur == '.') continue;
                    if (reusableDictionary.Contains(cur)) return false;
                    reusableDictionary.Add(cur);
                }

                reusableDictionary.Clear();
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    for (int k = i * 3; k < (i * 3) + 3; k++)
                    {
                        for (int l = j * 3; l < (j * 3) + 3; l++)
                        {
                            var cur = board[k][l];
                            if (cur == '.') continue;
                            if (reusableDictionary.Contains(cur)) return false;
                            reusableDictionary.Add(cur);
                        }
                    }
                    reusableDictionary.Clear();
                }
            }


            return true;
        }




    }

}