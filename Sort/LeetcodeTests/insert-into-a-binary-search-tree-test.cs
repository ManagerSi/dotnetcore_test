using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class insert_into_a_binary_search_tree_test
    {
        insert_into_a_binary_search_tree target = new insert_into_a_binary_search_tree();

        [Test]
        public void test()
        {
            var root = new TreeNode(4, 
                    new TreeNode(2, new TreeNode(1), new TreeNode(3)), 
                    new TreeNode(7));
            var res = target.InsertIntoBST(root, 5);
            Assert.True(res.ToInorderString() == "1,2,3,4,5,7");

            root = null;
            res = target.InsertIntoBST(root, 5);
            Assert.True(res.ToInorderString() == "5");
        }

        [Test]
        public void test_V2()
        {
            var root = new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(7));
            var res = target.InsertIntoBST_V2(root, 5);
            Assert.True(res.ToInorderString() == "1,2,3,4,5,7");

            root = null;
            res = target.InsertIntoBST_V2(root, 5);
            Assert.True(res.ToInorderString() == "5");
        }



        [Test]
        public void test_V3()
        {
            var root = new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(7));
            var res = target.InsertIntoBST_V3(root, 5);
            Assert.True(res.ToInorderString() == "1,2,3,4,5,7");

            root = null;
            res = target.InsertIntoBST_V3(root, 5);
            Assert.True(res.ToInorderString() == "5");
        }
    }
}
