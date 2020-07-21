using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class er_cha_shu_de_jing_xiang_lcof_test
    {
        [Test]
        public void test()
        {
            var tClass = new er_cha_shu_de_jing_xiang_lcof();
            var node = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(7, new TreeNode(6), new TreeNode(9)));

            var before = node.ToInorderString();
            var resultNode = tClass.MirrorTree(node);
            var after = resultNode.ToInorderString();

            var final = string.Join(',', after.Split(',').Reverse().ToList());//反转

            Assert.IsTrue(before == final);
        }
    }
}
