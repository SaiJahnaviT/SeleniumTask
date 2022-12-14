using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoCommonLibrary.Extension_methods
{
    public static class DictionaryExtensions
    {

        public static bool CheckHasKey(this Dictionary<string, string> map, string search)
        {
            foreach (var i in map.Keys)
            {
                if (i == search)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckHasValue(this Dictionary<string, string> map, string price)
        {
            foreach (var item in map.Values)
            {
                if (item == price)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
