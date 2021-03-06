﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Data
{
    public static class Tables
    {
        public static readonly Dictionary<uint, string> ModifierTable = new Dictionary<uint, string>
        {
            { 3, "-3" },
            { 4, "-2" },
            { 5, "-2" },
            { 6, "-1" },
            { 7, "-1" },
            { 8, "-1" },
            { 9, "" },
            { 10, "" },
            { 11, "" },
            { 12, "" },
            { 13, "+1" },
            { 14, "+1" },
            { 15, "+1" },
            { 16, "+2" },
            { 17, "+2" },
            { 18, "+3" }
        };

        public static readonly Dictionary<uint, string> CharismaTable = new Dictionary<uint, string>
        {
            { 3, "+2/1/4" },
            { 4, "+1/2/5" },
            { 5, "+1/2/5" },
            { 6, "+1/3/6" },
            { 7, "+1/3/6" },
            { 8, "+1/3/6" },
            { 9, "0/4/7" },
            { 10, "0/4/7" },
            { 11, "0/4/7" },
            { 12, "0/4/7" },
            { 13, "-1/5/8" },
            { 14, "-1/5/8" },
            { 15, "-1/5/8" },
            { 16, "-1/6/9" },
            { 17, "-1/6/9" },
            { 18, "-2/7/10" }
        };

        public static readonly int[][] ToHitTable =
        {
           new [] {20, 20, 20, 20, 20, 20, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11},
           new [] {20, 20, 20, 20, 20, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10},
           new [] {20, 20, 20, 20, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9},
           new [] {20, 20, 20, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8},
           new [] {20, 20, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7},
           new [] {20, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6},
           new [] {20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5},
           new [] {19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4},
           new [] {18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3},
           new [] {17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2},
           new [] {16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 2},
           new [] {15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2},
           new [] {14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2, 2},
           new [] {13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2, 2, 2},
           new [] {12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2, 2, 2, 2},
           new [] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2, 2, 2, 2, 2},
           new [] {10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2, 2, 2, 2, 2, 2}
        };
    }
}
