using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Number
{
    internal class Sum
    {
        static int[] strInt;
        /// <summary>
        /// Sum any number in the form of string 
        /// </summary>
        /// <param name="str">Space Seperated number of same size</param>
        /// <param name="size">size of individual numbers</param>
        /// <returns>string </returns>
        public static string SumFunction(string str, int size)
        {
            strInt = new int[size*10];

            var number = string.Empty;
            var flag = true;

            var sumValue = Function(str);
            Array.Reverse(sumValue);
            
            //Concanating sum value
            //start 
            foreach (var z in sumValue)
            {
                if (flag)
                {
                    if (z != 0)
                    {
                        flag = false;
                        number += z;
                    }
                }
                else
                {
                    number += z;
                }
            }
            return number;
        }
        static int[] Function(string str)
        {
            var strArr = str.Split(' ');

            foreach (var i in strArr)
            {
                // converting string to integer array 
                // start
                var y = new int[i.Length];
                var m = i.Length - 1;
                foreach (var sr in i)
                    y[m--] = Convert.ToInt32(sr.ToString());
                // end


                for (var j = 0; j < y.Length; j++)
                {
                    strInt[j] += y[j];
                    if (strInt[j] > 9)
                        AddReminder(j);
                }
            }
            return strInt;
        }
        static void AddReminder(int i)
        {
            // if less than 9 then its fine
            if (strInt[i] <= 9)
                return;
            else if (strInt[i] > 9)
            {
                strInt[i] -= 10;  // setting once place by subtracting 
                strInt[i + 1] += 1; // setting reminder to next position
            }
            AddReminder(i + 1);
        }
    }
}
