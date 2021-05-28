using System;
using System.Collections.Generic;

namespace CountTriplets
{
    class Program
    {
        static long CountTheTriplets(List<long> arr, long r)
        {
            var pairs = new Dictionary<long, long[]>();
            long triplets = 0;

            foreach (var n in arr)
            {
                if (!pairs.ContainsKey(n))
                {
                    pairs.Add(n, new long[] { 0, 0 });
                }

                if (n % r == 0 && pairs.ContainsKey(n / r))
                {
                    var prevPair = pairs[n / r];
                    triplets += prevPair[1];
                    pairs[n][1] += prevPair[0];
                }

                pairs[n][0]++;
            }

            return triplets;
        }

        static void Main(string[] args)
        {
            List<long> list = new List<long>() { 1, 3, 9, 9, 27, 81 };
            long ratio = 3;
            Console.WriteLine("Triplets count is: " + CountTheTriplets(list, ratio));
        }
    }
}
