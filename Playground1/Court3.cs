using System;
using System.Collections.Generic;
using Court3.DataStructures;

namespace Court3.DataStructures
{
}

namespace Plaground1
{
    public class Court3
    {
        public void Play()
        {

        }

        public int[][] UpdateMatrix(int[][] mat) {
            var queue = new Queue<int[]>();
            for(int i = 0; i < mat.Length; i++)
            {
                for(int j = 0; j < mat[0].Length; j++) {
                    if(mat[i][j] == 0) {
                        queue.Enqueue(new int[2]{i,j});
                    } else {
                        mat[i][j] = int.MaxValue;
                    }
                }
            }
             var dirs = new int[4][];
            //left
            dirs[0] = new int[]{0, -1};
            //right
            dirs[1] = new int[]{0, 1};
            //top
            dirs[2] = new int[]{-1, 0};
            //bottom
            dirs[3] = new int[]{1, 0};

            while(queue.Count > 0) {
                var cur = queue.Dequeue();
                var r = cur[0];
                var c = cur[1];
                foreach(var dir in dirs) {
                    var xx = r + dir[0];
                    var yy = c + dir[1];
                    if (xx < 0 || yy < 0 || xx >= mat.Length || yy >= mat[0].Length) continue;
                    if (mat[xx][yy] > mat[r][c] + 1) {
                        //If the result matrix distance at the neighbour node is greater than the currenNode + 1
                        queue.Enqueue(new int[2]{xx, yy});
                        mat[xx][yy] = mat[r][c] + 1;
                    }
                }
            }

            return mat;
        }


    }
}