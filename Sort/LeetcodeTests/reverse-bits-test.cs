using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class reverse_bits_test
    {
        reverse_bits target = new reverse_bits();

        [Test]
        [TestCase((uint)43261596, ExpectedResult = (uint)964176192)]
        [TestCase((uint)4294967293, ExpectedResult = (uint)3221225471)]
        public uint test(uint n)
        {
            return target.ReverseBits(n);
        }

        [Test]
        [TestCase((uint)43261596, ExpectedResult = (uint)964176192)]
        [TestCase((uint)4294967293, ExpectedResult = (uint)3221225471)]
        public uint test_V2(uint n)
        {
            return target.ReverseBits_V2(n);
        }
    }
}
