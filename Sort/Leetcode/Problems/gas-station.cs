using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 134. 加油站
    /// https://leetcode-cn.com/problems/gas-station/
    /// </summary>
    public class gas_station
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //gas  = [1, 2, 3, 4, 5]
            //cost = [3, 4, 5, 1, 2]
            for (int i = 0; i < gas.Length; i++)
            {
                if (CheckGasStation(i, gas, cost))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool CheckGasStation(int i, int[] gas, int[] cost)
        {
            int totalGas = gas[i] - cost[i];
            if (totalGas < 0)
                return false;

            var cycleIndex = i;
            i = GetNextIndex(i, gas);
            while (i!= cycleIndex)
            {
                totalGas += gas[i] - cost[i];
                if (totalGas < 0)
                    return false;
                
                i = GetNextIndex(i, gas);
            }

            return true;
        }

        private int GetNextIndex(int i, int[] gas)
        {
            //if (i < gas.Length - 1)
            //    return ++i;

            //return 0;

            return (i+1) % gas.Length;
        }
        private int GetPreIndex(int i, int[] gas)
        {
            if (i > 0)
                return --i;

            return gas.Length - 1;
        }

        /// <summary>
        /// 换一个思路，首先如果总油量减去总消耗大于零那么一定可以跑完一圈，说明 各个站点的加油站 剩油量remain[i]相加一定是大于零的。
        /// 每个加油站的剩余量remain[i] 为gas[i] - cost[i]。
        /// 
        /// i从0开始累加remain[i]，和记为curSum，如果curSum小于零，说明[0, i] 区间都不能作为起始位置，起始位置从i+1算起。
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit_V2(int[] gas, int[] cost)
        {
            //gas  = [1, 2, 3, 4, 5]
            //cost = [3, 4, 5, 1, 2]

            int currentSum = 0;
            int totalSum = 0;
            int start = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                currentSum += gas[i] - cost[i];
                totalSum += gas[i] - cost[i];
                if (currentSum < 0)
                {
                    start = i + 1;
                    currentSum = 0;
                }
            }

            if (totalSum < 0)
                return -1;

            return start;
        }

    }
}
