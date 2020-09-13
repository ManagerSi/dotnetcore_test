using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class word_search_test
    {
        word_search target = new word_search();

        [Test]
        public void test()
        {
            var nums = new Char[][]
            {
                new Char[] {'A', 'B', 'C', 'E'},
                new Char[] {'S', 'F', 'C', 'S'},
                new Char[] {'A', 'D', 'E', 'E'}
            };
            var word = "ABCCED";
            var res = target.Exist(nums, word);
            Assert.True(res);

            word = "SEE";
            res = target.Exist(nums, word);
            Assert.True(res);

            word = "ABCB";
            res = target.Exist(nums, word);
            Assert.False(res);

            Console.WriteLine(res);
        }

        [Test]
        public void test_V2()
        {
            var nums = new Char[][]
            {
                new Char[] {'A', 'B', 'C', 'E'},
                new Char[] {'S', 'F', 'C', 'S'},
                new Char[] {'A', 'D', 'E', 'E'}
            };
            var word = "ABCCED";
            var res = target.Exist_V2(nums, word);
            Assert.True(res);

            word = "SEE";
            res = target.Exist_V2(nums, word);
            Assert.True(res);

            word = "ABCB";
            res = target.Exist_V2(nums, word);
            Assert.False(res);

        }

        [Test]
        public void test_compare()
        {
            var nums = new Char[][]
            {
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'
                },
                new Char[]
                {
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a',
                    'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b'
                }

            };
            var word =
                "baaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            Stopwatch sp = Stopwatch.StartNew();
            var res = target.Exist_V2(nums, word);
            Console.WriteLine($"Exist_V2 spand time: {sp.ElapsedMilliseconds}");
            Assert.True(res);

            sp.Restart();
            res = target.Exist(nums, word);
            Console.WriteLine($"Exist spand time: {sp.ElapsedMilliseconds }");
            Assert.True(res);
        }
    }
}
