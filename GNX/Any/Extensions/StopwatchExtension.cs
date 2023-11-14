﻿using System;
using System.Diagnostics;

namespace GNX
{
    public static class StopwatchExtension
    {
        public static float ElapsedSeconds(this Stopwatch sw)
        {
            return Convert.ToSingle(((float)sw.ElapsedMilliseconds / 1000).ToString("N2"));
        }
    }
}