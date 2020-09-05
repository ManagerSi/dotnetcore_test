using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
