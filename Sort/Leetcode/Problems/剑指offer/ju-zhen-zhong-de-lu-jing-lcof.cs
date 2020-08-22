using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 12. 矩阵中的路径
    /// https://leetcode-cn.com/problems/ju-zhen-zhong-de-lu-jing-lcof/
    /// </summary>
    public class ju_zhen_zhong_de_lu_jing_lcof
    {
        #region v1

        /// <summary>
        /// 超时了，需要做剪枝动作
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            target = string.Empty;
            path = new List<string>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    DFS(board, i, j, word);
                    if (target == word)
                    {
                        return true;
                    }
                    else
                    {
                        target = string.Empty;
                        //reset path
                        path.Clear();
                    }
                }
            }

            return false;
        }

        private string target;
        private List<string> path;
        private bool DFS(char[][] board, int i, int j, string word)
        {
            //判断i的边界条件
            if (i >= board.Length || i < 0) return false;

            //判断j的边界条件
            if (j >= board[0].Length || j < 0) return false;

            if (target.Length < word.Length && board[i][j] == word[target.Length] && !path.Contains(i.ToString() + j))
                target += board[i][j];
            else
                return false;

            if (target == word) return true;

            //add path
            path.Add(i.ToString() + j);

            //上
            var res = DFS(board, i - 1, j, word);
            if (res == true) return true;
            //下
            res = DFS(board, i + 1, j, word);
            if (res == true) return true;
            //左
            res = DFS(board, i, j - 1, word);
            if (res == true) return true;
            //右
            res = DFS(board, i, j + 1, word);
            if (res == true) return true;

            path.Remove(i.ToString() + j);
            target = target.Substring(0, target.Length - 1);

            return false;
        }
        #endregion


        #region v2
        public bool exist(char[][] board, String word)
        {
            char[] words = word.ToCharArray();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (dfs(board, words, i, j, 0)) return true;
                }
            }
            return false;
        }
        bool dfs(char[][] board, char[] word, int i, int j, int k)
        {
            if (i >= board.Length || i < 0 || j >= board[0].Length || j < 0 || board[i][j] != word[k]) return false;
            if (k == word.Length - 1) return true;
            char tmp = board[i][j];
            board[i][j] = '/';
            bool res = dfs(board, word, i + 1, j, k + 1) || dfs(board, word, i - 1, j, k + 1) ||
                          dfs(board, word, i, j + 1, k + 1) || dfs(board, word, i, j - 1, k + 1);
            board[i][j] = tmp;
            return res;
        }

        #endregion
    }
}
