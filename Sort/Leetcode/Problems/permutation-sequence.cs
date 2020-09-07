using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Extend;

namespace Leetcode.Problems
{
    /// <summary>
    /// 60. 第k个排列
    /// https://leetcode-cn.com/problems/permutation-sequence/
    /// </summary>
    public class permutation_sequence
    {
        /// <summary>
        /// https://zh.wikipedia.org/wiki/%E5%BA%B7%E6%89%98%E5%B1%95%E5%BC%80
        /// 既然康托展开是一个双射，那么一定可以通过康托展开值求出原排列，即可以求出n的全排列中第x大排列。
        /// 
        /// 如n=5,x=96时：
        /// 
        /// 首先用96-1得到95，说明x之前有95个排列.(将此数本身减去1)
        /// 用95去除4! 得到3余23，说明有3个数比第1位小，所以第一位是4.
        /// 用23去除3! 得到3余5，说明有3个数比第2位小，所以是4，但是4已出现过，因此是5.
        /// 用5去除2!得到2余1，类似地，这一位是3.
        /// 用1去除1!得到1余0，这一位是2.
        /// 最后一位只能是1.
        /// 所以这个数是45321.
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetPermutation(int n, int k)
        {
                /**
                直接用回溯法做的话需要在回溯到第k个排列时终止就不会超时了, 但是效率依旧感人
                可以用数学的方法来解, 因为数字都是从1开始的连续自然数, 排列出现的次序可以推
                算出来, 对于n=4, k=15 找到k=15排列的过程:
                
                1 + 对2,3,4的全排列 (3!个)         
                2 + 对1,3,4的全排列 (3!个)         3, 1 + 对2,4的全排列(2!个)
                3 + 对1,2,4的全排列 (3!个)-------> 3, 2 + 对1,4的全排列(2!个)-------> 3, 2, 1 + 对4的全排列(1!个)-------> 3214
                4 + 对1,2,3的全排列 (3!个)         3, 4 + 对1,2的全排列(2!个)         3, 2, 4 + 对1的全排列(1!个)
                
                确定第一位:
                    k = 14(从0开始计数)
                    index = k / (n-1)! = 2, 说明第15个数的第一位是3 
                    更新k
                    k = k - index*(n-1)! = 2
                确定第二位:
                    k = 2
                    index = k / (n-2)! = 1, 说明第15个数的第二位是2
                    更新k
                    k = k - index*(n-2)! = 0
                确定第三位:
                    k = 0
                    index = k / (n-3)! = 0, 说明第15个数的第三位是1
                    更新k
                    k = k - index*(n-3)! = 0
                确定第四位:
                    k = 0
                    index = k / (n-4)! = 0, 说明第15个数的第四位是4
                最终确定n=4时第15个数为3214 
                **/

                StringBuilder sb = new StringBuilder();
                // 候选数字
                List<int> candidates = new List<int>();
                // 分母的阶乘数
                int[] factorials = new int[n + 1];
                factorials[0] = 1;
                int fact = 1;
                for (int i = 1; i <= n; ++i)
                {
                    candidates.Add(i);
                    fact *= i;
                    factorials[i] = fact;
                }
                k -= 1;
                for (int i = n - 1; i >= 0; --i)
                {
                    // 计算候选数字的index
                    int index = k / factorials[i];
                    
                    sb.Append(candidates[index]);
                    candidates.RemoveAt(index);
                    k -= index * factorials[i];
                }
                return sb.ToString();
            
        }

        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetPermutation_v2(int n, int k)
        {
            res = new List<string>();
            depth = 0;

            //init nums //生成nums数组
            List<string> nums = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                nums.Add(i.ToString());
            }

            //记录当前的索引的数是否被使用过
            bool[] used = new bool[n];

            var index = k / n;
            return dfs(nums,used, k);
        }

        private List<string> res = new List<string>();
        private int depth;


        /// <summary>
        ///def dfs(n){                         //可以描述阶段的状态
        ///     if(valid) {收集结果，返回}	        //出口条件
        ///     if(pruning) return;             //剪枝，这一步是为了加快回溯过程，降低程序执行时间
        ///     for(i:1~p)
        ///     {                               //选择该阶段的所有决策
        ///         选择可行决策;                   //剪枝的一种 
        ///         add;                          //标记已访问该点
        ///         DFS(n + 1);                     //进入下一阶段
        ///         if(valid) {返回}
        ///         recover;                      //还原
        ///     }
        /// }
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="used"></param>
        /// <param name="depth"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private string dfs(List<string> nums, bool[] used, int target)
        {
            //出口条件
            if (res.Count == nums.Count)
            {
                depth++;

                //出口条件
                if (depth == target)
                {
                    return string.Join("",res);
                }

                //剪枝
                return null;
            }
            
            for (int i = 0; i < nums.Count; i++)
            {
                //剪枝
                if (res.Contains(nums[i]))
                    continue;

                //标记使用
                used[i] = true;
                res.Add(nums[i]);
                //递归循环
                var result = dfs(nums, used, target);
                //出口条件
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }

                //还原
                used[i] = false;
                res.Remove(nums[i]);

            }

            return null;
        }
    }
}
