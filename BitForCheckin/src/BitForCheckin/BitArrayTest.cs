using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitForCheckin
{
    /// <summary>
    /// 无法统计那些用户签到3天，哪些签到4天...
    /// </summary>
    public class BitArrayTest
    {
        /// <summary>
        /// 从左到右为第一天签到、第二天签到、、第五天签到
        /// </summary>
        public static List<BitArray> _checkinTestList = new List<BitArray>()
        {
            new BitArray(new bool[]{ true, false, true, true,false }),  //用户1签到记录
           new BitArray(new bool[]{ false, true, true, true,false }),   //用户2签到记录
           new BitArray(new bool[]{ false, true, true, true, true}),    //用户3签到记录
           new BitArray(new bool[]{ true, true, true, true, true}),     //用户4签到记录
        };

        public static List<BitArray> _twoDayContinuousCheckinList = new List<BitArray>()
        {
            new BitArray(new bool[]{ true, true, false, false ,false}),
            new BitArray(new bool[]{ false, true, true, false, false}),
            new BitArray(new bool[]{ false, false, true, true ,false}),
            new BitArray(new bool[]{ false, false, false, true ,true}),
        };
        public static List<BitArray> _threeDayContinuousCheckinList = new List<BitArray>()
        {
            new BitArray(new bool[]{ true, true, true, false ,false}),
            new BitArray(new bool[]{ false, true, true, true, false}),
            new BitArray(new bool[]{ false, false, true, true ,true}),
        };
        public static List<BitArray> _fourDayContinuousCheckinList = new List<BitArray>()
        {
            new BitArray(new bool[]{ true, true, true, true, false}),
            new BitArray(new bool[]{ false, true, true, true, true}),
        };
        public static List<BitArray> _fiveDayContinuousCheckinList = new List<BitArray>()
        {
            new BitArray(new bool[]{ true, true, true, true, true}),
        };

        public static void Test()
        {
            Console.WriteLine("测试使用位图检测连续5天签到!");
            foreach (var checkinData in _checkinTestList)
            {
                Console.Write($"签到记录：");
                foreach (bool o in checkinData)
                {
                    if (o) Console.Write(1);
                    else Console.Write(0);
                }

                Console.WriteLine();
                if (FiveDayCheckIn(checkinData))
                {
                    Console.WriteLine("-----连续 5 day");
                }
                else if (FourDayCheckIn(checkinData))
                {
                    Console.WriteLine("-----连续 4 day");
                }
                else if (ThreeDayCheckIn(checkinData))
                {
                    Console.WriteLine("-----连续 3 day");
                }
                else if (TwoDayCheckIn(checkinData))
                {
                    Console.WriteLine("-----连续 2 day");
                }
                else
                {
                    Console.WriteLine("-----没有连续签到");
                }
            }
        }

        private static bool TwoDayCheckIn(BitArray checkinData)
        {
            foreach (var two in _twoDayContinuousCheckinList)
            {
                var result = ((BitArray)two.Clone()).And(checkinData);
                if (IsSame(result, two)) return true;
            }

            return false;
        }

        private static bool ThreeDayCheckIn(BitArray checkinData)
        {
            foreach (var threeData in _threeDayContinuousCheckinList)
            {
                var result = ((BitArray)threeData.Clone()).And(checkinData);
                if (IsSame(result, threeData)) return true;
            }

            return false;
        }

        private static bool FourDayCheckIn(BitArray checkinData)
        {
            foreach (var fourData in _fourDayContinuousCheckinList)
            {
                var result = ((BitArray)fourData.Clone()).And(checkinData);
                if (IsSame(result, fourData)) return true;
            }

            return false;
        }

        private static bool FiveDayCheckIn(BitArray checkinData)
        {
            var five = _fiveDayContinuousCheckinList.First();
            var result = ((BitArray)five.Clone()).And(checkinData);
            return IsSame(result, five);
        }

        private static bool IsSame(BitArray result, BitArray five)
        {
            if (result.Length != five.Length) return false;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != five[i]) return false;
            }

            return true;
        }
    }
}
