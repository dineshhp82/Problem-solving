using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    /*MS Excel columns has a pattern like A, B, C, … ,Z, AA, AB, AC,…. ,AZ, BA, BB, … ZZ, AAA, AAB ….. etc. 
     *In other words, column 1 is named as “A”, column 2 as “B”, column 27 as “AA”.
     * e.g
     * Input          Output
         26             Z
         51             AY
         52             AZ
         80             CB
         ------------------------------------------------
         A-Z (0-25)
         If remainder with 26 comes out to be 0 (meaning 26, 52 and so on) 
         then we put ‘Z’ in the output string and new n becomes n/26 -1 because 
         here we are considering 26 to be ‘Z’ while in actual it’s 25th with respect to ‘A’.

        Similarly if the remainder comes out to be non zero. (like 1, 2, 3 and so on) 
        then we need to just insert the char accordingly in the string and do n = n/26.    
     */
    public class ExcelColumnNameFind
    {
        public void SolveProblem(int columnNumber)
        {
            string columnName = string.Empty;
            int totalAlphabat = 26;

            while (columnNumber > 0)
            {
                int rem = columnNumber % totalAlphabat;

                //if rem =0 then 'Z'  in output 
                if (rem == 0)
                {
                    columnName += "Z";
                    columnNumber = (columnNumber / totalAlphabat) - 1; //-1 because column index start from 0
                }
                else
                {
                    columnName += (char)(rem - 1 + 'A');
                    //Add 'A' here because capital letter start from 65 
                    //-1 because column index start from 0
                    columnNumber /= totalAlphabat;
                }
            }
            char[] str = columnName.ToCharArray();
            Array.Reverse(str);
            Console.WriteLine(new string(str));
        }
    }
}
