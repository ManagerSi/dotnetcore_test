using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class keys_and_rooms_test
    {
        private keys_and_rooms target = new keys_and_rooms();

        [Test]
        public void test()
        {
            var rooms = new List<IList<int>>()
            {
                new List<int>(){1},
                new List<int>(){2},
                new List<int>(){3},
                new List<int>(){},
            };
            var res = target.CanVisitAllRooms(rooms);
            Assert.True(res);

            //false
            rooms = new List<IList<int>>()
            {
                new List<int>(){1,3},
                new List<int>(){3,0,1},
                new List<int>(){2},
                new List<int>(){0},
            };
            res = target.CanVisitAllRooms(rooms);
            Assert.False(res);
        }

        [Test]
        public void test_V2()
        {
            var rooms = new List<IList<int>>()
            {
                new List<int>(){1},
                new List<int>(){2},
                new List<int>(){3},
                new List<int>(){},
            };
            var res = target.CanVisitAllRooms_V2(rooms);
            Assert.True(res);

            //false
            rooms = new List<IList<int>>()
            {
                new List<int>(){1,3},
                new List<int>(){3,0,1},
                new List<int>(){2},
                new List<int>(){0},
            };
            res = target.CanVisitAllRooms_V2(rooms);
            Assert.False(res);
        }
    }
}
