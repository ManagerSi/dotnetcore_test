using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 79. 单词搜索
    /// https://leetcode-cn.com/problems/word-search/
    /// </summary>
    /// <param name="board"></param>
    /// <param name="word"></param>
    /// <returns></returns>
    public class word_search
    {
        /// <summary>
        /// DFS -- 超时了
        /// https://leetcode-cn.com/problems/word-search/
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length == 0)
                return false;
            if (string.IsNullOrEmpty(word))
                return false;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var res = dfs(board, word, i, j, new List<string>());
                    if (res)
                        return res;

                }
            }

            return false;
        }

        private bool dfs(char[][] board, string word, int iIndex, int jIndex, List<string> path)
        {
            //退出条件
            if (path.Count == word.Length)
            {
                return true;
            }
            //剪枝
            if (path.Contains($"{iIndex}{jIndex}"))
                return false;

            //判断当前值
            if (path.Count<word.Length && board[iIndex][jIndex] == word[path.Count])
            {
                //加入
                path.Add($"{iIndex}{jIndex}");

                //退出条件
                if (path.Count == word.Length)
                {
                    return true;
                }

                //上
                if (iIndex - 1 >= 0 && dfs(board, word, iIndex - 1, jIndex, path))
                    return true;
                //下
                if (iIndex + 1 < board.Length && dfs(board, word, iIndex + 1, jIndex, path))
                    return true;
                //左
                if (jIndex - 1 >= 0 && dfs(board, word, iIndex, jIndex - 1, path))
                    return true;
                //右
                if (jIndex + 1 < board[iIndex].Length && dfs(board, word, iIndex, jIndex + 1, path))
                    return true;

                //撤销
                path.Remove($"{iIndex}{jIndex}");
            }

            return false;
        }


        /// <summary>
        /// DFS -- 使用bool[][] path 改良
        /// https://leetcode-cn.com/problems/word-search/
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist_V2(char[][] board, string word)
        {
            if (board == null || board.Length == 0)
                return false;
            if (string.IsNullOrEmpty(word))
                return false;

            bool[][] path = new bool[board.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                path[i] = new bool[board[i].Length];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var res = dfs_V2(board, word, i, j, path, 0);
                    if (res)
                        return res;

                }
            }

            return false;
        }

        private bool dfs_V2(char[][] board, string word, int iIndex, int jIndex, bool[][] path, int matched)
        {
            //退出条件
            if (matched == word.Length)
            {
                return true;
            }
            //剪枝
            if (path[iIndex][jIndex])
                return false;

            //判断当前值
            if (matched < word.Length && board[iIndex][jIndex] == word[matched])
            {
                //加入
                matched++;
                path[iIndex][jIndex] = true;

                //退出条件
                if (matched == word.Length)
                {
                    return true;
                }

                //上
                if (iIndex - 1 >= 0 && dfs_V2(board, word, iIndex - 1, jIndex, path, matched))
                    return true;
                //下
                if (iIndex + 1 < board.Length && dfs_V2(board, word, iIndex + 1, jIndex, path, matched))
                    return true;
                //左
                if (jIndex - 1 >= 0 && dfs_V2(board, word, iIndex, jIndex - 1, path, matched))
                    return true;
                //右
                if (jIndex + 1 < board[iIndex].Length && dfs_V2(board, word, iIndex, jIndex + 1, path, matched))
                    return true;

                //撤销
                path[iIndex][jIndex] = false;
            }

            return false;
        }
    }
}
