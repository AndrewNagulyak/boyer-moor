
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace boyer_moor
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Input main string");
            string str1 = Console.ReadLine();
            Console.WriteLine("Input searched string");
            string str2 = Console.ReadLine();


            int position = FindSubstring(str1, str2);
            Console.WriteLine(position);

        }

        private static int FindSubstring(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;
            int count = 0;
            int[] d = GetIndexFunction(str2);

            int i = 0, j = 0;
            while (j < m && i - j < n - m + 1)
            {
                if (str1[i] == str2[j])
                {
                    Console.WriteLine(str2[j] + " " + str1[i]);

                    j++;
                    i++;
                    count++;
                }

                else if (j == 0)
                {
                    Console.WriteLine(str2[j] + " " + str1[i]);


                    i++;

                    count++;
                }
                else
                {
                    Console.WriteLine(str2[j] + " " + str1[i]);


                    count++;
                    i = i - d[j - 1];
                    j = 0;
                }

            }

            if (j == m)
            {
                Console.WriteLine("Operation count : " + count);
                Console.WriteLine("UnderIndex : ");
                return i - j + 1;
            }
            else
            {
                Console.WriteLine("Operation count : " + count);

                return -1;
            }
        }

        private static int[] GetIndexFunction(string str2)
        {
            int length = str2.Length;
            int[] result = new int[length];
            int j = 1;
            int i = length-2;
            while (i>=0)
            {
                result[i] = j;
                for (int o = i; o < length - 2; o++)
                {
                    if(str2[i]==str2[o])
                    result[i] = result[o];
                }

                j++;
                i--;
            }
            result[length - 1] = length;

            for (int o = 0; o < length-1; o++)
            {
                if(str2[length-1] == str2[o])
                    result[length-1] = result[o];
            }

            for (int p = 0; p < length ; p++)
            {
                Console.Write(result[p]+" ");
            }
            Console.WriteLine();
            return result;
        }
    }
}