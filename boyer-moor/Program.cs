
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{

    public class Boyer
    {


        public int max(int a, int b) { return (a > b) ? a : b; }

        // The preprocessing function for Boyer Moore's
        // bad character heuristic
        public void badCharHeuristic(String str, int size, int[] badchar)
        {
            int i;

            // Initialize all occurrences as -1
            for (i = 0; i < 256; i++)
                badchar[i] = -1;

            // Fill the actual value of last occurrence 
            // of a character
            for (i = 0; i < size; i++)
                badchar[(int)str[i]] = i;
        }

        /* A pattern searching function that uses Bad
           Character Heuristic of Boyer Moore Algorithm */
        public void search(String txt, String pat)
        {
            int pattern_length = pat.Length;
            int txt_length = txt.Length;

            int[] badchar = new int[256];

            /* Fill the bad character array by calling 
               the preprocessing function badCharHeuristic() 
               for given pattern */
            badCharHeuristic(pat, pattern_length, badchar);

            int shift_pattern_withrespect_text = 0;  // s is shift of the pattern with 
                                                     // respect to text
            while (shift_pattern_withrespect_text <= (txt_length - pattern_length))
            {
                int j = pattern_length - 1;

                /* Keep reducing index j of pattern while 
                   characters of pattern and text are 
                   matching at this shift s */
                while (j >= 0 && pat[j] == txt[shift_pattern_withrespect_text + j])
                {

                    Console.Write("\n pat[j] =" + pat[j] + " j= " + j);
                    j--;
                }
                /* If the pattern is present at current
                   shift, then index j will become -1 after
                   the above loop */
                if (j < 0)
                {
                    Console.Write("\n pattern occurs at shift =" + shift_pattern_withrespect_text);

                    /* Shift the pattern so that the next 
                       character in text aligns with the last 
                       occurrence of it in pattern.
                       The condition s+m < n is necessary for 
                       the case when pattern occurs at the end 
                       of text */
                    // shift_pattern_withrespect_text += (shift_pattern_withrespect_text+pattern_length < txt_length)? pattern_length-badchar[txt[shift_pattern_withrespect_text+pattern_length]] : 1;

                    shift_pattern_withrespect_text += (shift_pattern_withrespect_text + pattern_length < txt_length) ? pattern_length + 1 : 1;






                }

                else
                    /* Shift the pattern so that the bad character
                       in text aligns with the last occurrence of
                       it in pattern. The max function is used to
                       make sure that we get a positive shift. 
                       We may get a negative shift if the last 
                       occurrence  of bad character in pattern
                       is on the right side of the current 
                       character. */
                    shift_pattern_withrespect_text += max(1, j - badchar[txt[shift_pattern_withrespect_text + j]]);

                Console.Write("\nS----" + shift_pattern_withrespect_text);
            }
        }


    }




    public class Program
    {



        public static void Main(string[] args)
        {


            Boyer b = new Boyer();
            int[] bad = new int[4];
            int i = 0;

            b.search("TESTING", "ST");


        }
    }
}