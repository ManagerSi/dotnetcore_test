using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void subtree_of_another_tree_test()
        {
            var t = new TreeNode(4,new TreeNode(1),new TreeNode(2));
            var s = new TreeNode(3, t, new TreeNode(5));

            var res = new subtree_of_another_tree().IsSubtree(s, t);

            Assert.IsTrue(res);
        }
        [Test]
        public void subtree_of_another_tree_test2()
        {
            var t = new TreeNode(1);
            var s = new TreeNode(0);

            var res = new subtree_of_another_tree().IsSubtree(s, t);

            Assert.False(res);
        }
        [Test]
        public void subtree_of_another_tree_test3()
        {
            var t = new TreeNode(1);
            var s = new TreeNode(1, new TreeNode(1));

            var res = new subtree_of_another_tree().IsSubtree(s, t);

            Assert.True(res);
        }
    }
}