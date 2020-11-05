using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 127. 单词接龙
    /// https://leetcode-cn.com/problems/word-ladder
    /// </summary>
    public class word_ladder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> wordSet = new HashSet<string>(wordList); //转换为hashset 加快速度
            if (wordSet.Count == 0 || !wordSet.Contains(endWord))
            {  //特殊情况判断
                return 0;
            }
            Queue<string> queue = new Queue<string>(); //bfs 队列
            queue.Enqueue(beginWord);
            Dictionary<string, int> map = new Dictionary<string, int>(); //记录单词对应路径长度
            map.Add(beginWord, 1);

            while (queue.Count>0)
            {
                string word = queue.Dequeue(); //取出队头单词
                int path = map[word]; //获取到该单词的路径长度
                for (int i = 0; i < word.Length; i++)
                { //遍历单词的每个字符
                    char[] chars = word.ToCharArray(); //将单词转换为char array，方便替换
                    for (char k = 'a'; k <= 'z'; k++)
                    { //从'a' 到 'z' 遍历替换
                        chars[i] = k; //替换第i个字符
                        string newWord = string.Join("", chars);//得到新的字符串
                        if (newWord.Equals(endWord))
                        {  //如果新的字符串值与endWord一致，返回当前长度+1
                            return path + 1;
                        }
                        if (wordSet.Contains(newWord) && !map.ContainsKey(newWord))
                        { //如果新单词在set中，但是没有访问过
                            map.Add(newWord, path + 1); //记录单词对应的路径长度
                            queue.Enqueue(newWord);//加入队尾
                        }
                    }
                }
            }
            return 0; //未找到
        }
    }
}
