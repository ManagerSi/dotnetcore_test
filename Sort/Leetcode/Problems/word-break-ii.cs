using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 140. 单词拆分 II
    /// https://leetcode-cn.com/problems/word-break-ii/
    /// </summary>
    public class word_break_ii
    {       
        /// <summary>
        /// 树形递归
        /// 
        /// 字符串为根节点
        /// 对字符串截前1字符、前2字符...前n字符，为此字符串的子节点（若截取的不在字典，则此分支剪断）
        /// ...
        /// 直到一个字符不剩，此为叶子节点，此分支即为一个结果，根节点到此节点截取的所有字符串即为一个分割方案
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            _cache = new Dictionary<int, IList<string>>();
            return Partition(s, 0, wordDict);
        }
        private IDictionary<int, IList<string>> _cache = new Dictionary<int, IList<string>>();

        /// <summary>
        /// 切分子字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start">子字符串起始位置</param>
        private IList<string> Partition(string s, int start, IList<string> wordDict)
        {
            if (_cache.ContainsKey(start)) return _cache[start];

            var results = new List<string>();
            //字符串末尾是唯一出口，祖先节点已经切分好的前缀即为此分支的唯一结果
            if (start == s.Length) results.Add(null);

            string sub;
            //对字符串截前1字符、前2字符...前n字符，为此字符串的子节点
            for (int i = start; i < s.Length; i++)
            {
                sub = s.Substring(start, i - start + 1);
                if (wordDict.Contains(sub))
                {
                    foreach (var x in Partition(s, i + 1, wordDict))
                    {
                        results.Add(sub + (x == null ? "" : " " + x));
                    }
                }
                //若截取的不在字典，则此分支剪断
            }
            _cache.Add(start, results);
            return results;
        }

    }
}
