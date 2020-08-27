using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Extend;
using Leetcode.Problems;

namespace LeetcodeTests
{
    class reconstruct_itinerary_test
    {
        reconstruct_itinerary target = new reconstruct_itinerary();
        [Test]
        public void test()
        {
            IList<IList<string>> input = new List<IList<string>>
            {
                new List<string>() {"MUC", "LHR"},
                new List<string>() {"JFK", "MUC"},
                new List<string>() {"SFO", "SJC"},
                new List<string>() {"LHR", "SFO"},
            };
            var res = target.FindItinerary(input);
            Assert.True(ListExtent.ToString<string>(res) == "JFK,MUC,LHR,SFO,SJC");

            input = new List<IList<string>>
            {
                new List<string>() {"JFK","SFO"},
                new List<string>() {"JFK","ATL"},
                new List<string>() {"SFO","ATL"},
                new List<string>() {"ATL","JFK"},
                new List<string>() {"ATL","SFO"},
            };
             res = target.FindItinerary(input);
            Assert.True(ListExtent.ToString<string>(res) == "JFK,ATL,JFK,SFO,ATL,SFO");


            input = new List<IList<string>>
            {
                new List<string>() {"JFK","KUL"},
                new List<string>() {"JFK","NRT"},
                new List<string>() {"NRT","JFK"},
            };
            res = target.FindItinerary(input);
            Assert.True(ListExtent.ToString<string>(res) == "JFK,NRT,JFK,KUL");

            

            input = new List<IList<string>>
            {
                new List<string>() {"EZE","TIA"},new List<string>() {"EZE","HBA"},new List<string>() {"AXA","TIA"},new List<string>() {"JFK","AXA"},new List<string>() {"ANU","JFK"},new List<string>() {"ADL","ANU"},new List<string>() {"TIA","AUA"},new List<string>() {"ANU","AUA"},new List<string>() {"ADL","EZE"},new List<string>() {"ADL","EZE"},new List<string>() {"EZE","ADL"},new List<string>() {"AXA","EZE"},new List<string>() {"AUA","AXA"},new List<string>() {"JFK","AXA"},new List<string>() {"AXA","AUA"},new List<string>() {"AUA","ADL"},new List<string>() {"ANU","EZE"},new List<string>() {"TIA","ADL"},new List<string>() {"EZE","ANU"},new List<string>() {"AUA","ANU"}
            };
            res = target.FindItinerary(input);
            Assert.True(ListExtent.ToString<string>(res) == "JFK,AXA,AUA,ADL,ANU,AUA,ANU,EZE,ADL,EZE,ANU,JFK,AXA,EZE,TIA,AUA,AXA,TIA,ADL,EZE,HBA");
        }
    }
}
