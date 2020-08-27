using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 332. 重新安排行程
    /// https://leetcode-cn.com/problems/reconstruct-itinerary/
    /// </summary>
    public class reconstruct_itinerary
    {
        public Dictionary<String, List<String>> dict = new Dictionary<string, List<string>>();

        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            dict = tickets.GroupBy(i => i.First(), (s, enumerable) =>
                new
                {
                    key = s,
                    val = enumerable.SelectMany(i => i.Where(k => k != s)).OrderBy(i => i).ToList()
                }).ToDictionary(i => i.key, i => i.val);

            var res = new List<string>();
            res.Add("JFK");
            DFS(tickets.Count + 1, 1, res);
            
            return res;
        }

        private bool DFS(int ticketNum, int index, List<string> result)
        {
            if (ticketNum == result.Count)
                return true;

            var last = result.Last();
            if (!dict.ContainsKey(last) || dict[last].Count==0)
            {
                return false;
            }

            for (int i = 0; i < dict[last].Count; i++)
            {
                var city = dict[last][i];
                result.Add(city);
                //删除城市
                dict[last].RemoveAt(i);
                //if (dict[last].Count == 0)
                //    dict.Remove(last);

                if (DFS(ticketNum, index + 1, result))
                    return true;

                //加回来
                if (dict.ContainsKey(last))
                    dict[last].Insert(i, city);
                //else
                //    dict.Add(last, new List<string>() { city });

                //删除城市
                result.RemoveAt(result.Count-1);
            }

            return false;
        }
    }
}
