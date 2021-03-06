﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Untity
{
    public static class ExtendTool
    {
        public static int ToInt32(this string value, int defaultValue)
        {
            int result = 0;
            bool isSuccess = int.TryParse(value, out result);
            if (!isSuccess)
            {
                return defaultValue;
            }
            return result;
        }

        public static bool ToBool(this string value, bool defaultValue)
        {
            bool result = false;
            bool isSuccess = bool.TryParse(value, out result);
            if (!isSuccess)
            {
                return defaultValue;
            }
            return result;
        }

        public static int ToInt32(this bool value)
        {
            if (value)
            {
                return 1;
            }
            return 0;
        }
    }
}
