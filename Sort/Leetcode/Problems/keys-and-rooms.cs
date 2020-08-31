using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 841. 钥匙和房间
    /// https://leetcode-cn.com/problems/keys-and-rooms/
    /// </summary>
    public class keys_and_rooms
    {
        /// <summary>
        /// 深度优先遍历
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var res = Enumerable.Range(0, rooms.Count).ToDictionary(i => i, i => false);

            dfs(rooms, 0, res);

            return !(res.Any(i => i.Value == false));
        }

        private void dfs(IList<IList<int>> rooms, int v, Dictionary<int, bool> res)
        {
            if (res[v])//房间已进入则无需再次进入
                return;

            //设置房间已进入
            res[v] = true;

            var keysInRoom = rooms[v];

            foreach (var roomIndex in keysInRoom)
            {
                dfs(rooms, roomIndex, res);

            }

        }

        /// <summary>
        /// 深度优先遍历,采用bool数组
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public bool CanVisitAllRooms_V2(IList<IList<int>> rooms)
        {
            var res = new bool[rooms.Count];

            dfs(rooms, 0, res);

            return !(res.Any(i => i == false));
        }

        private void dfs(IList<IList<int>> rooms, int v, bool[] res)
        {
            if (res[v])//房间已进入则无需再次进入
                return;

            //设置房间已进入
            res[v] = true;

            var keysInRoom = rooms[v];

            foreach (var roomIndex in keysInRoom)
            {
                dfs(rooms, roomIndex, res);

            }

        }
    }
}
