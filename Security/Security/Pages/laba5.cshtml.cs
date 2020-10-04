using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Security.Pages
{
    public class laba5Model : PageModel
    {

        public string correctString { get; set; }
        public string enteredString { get; set; }

        //public int[,] G = new int[,] {
        //    { 0, 0, 0, 1, 1, 0, 0, 0 },
        //    { 0, 0, 1, 0, 0, 1, 0, 0 },
        //    { 0, 1, 0, 0, 0, 0, 1, 0 },
        //    { 1, 0, 0, 0, 0, 0, 0, 1 },
        //};

        //public int[,] H = new int[,] {
        //    { 1, 0, 0, 0, 0, 0, 0, 1 },
        //    { 0, 1, 0, 0, 0, 0, 1, 0 },
        //    { 0, 0, 1, 0, 0, 1, 0, 0 },
        //    { 0, 0, 0, 1, 1, 0, 0, 0 },
        //};


        public string[,] errorArray = new string[9, 16];

        public void OnGet()
        {
        }

        public void OnPost(string? text)
        {
            enteredString = text;
            generateFirst();
            generate();
            int index = searchIndex(text);

            correctString = XOR(text, errorArray[index, 0]);

        }

        private string XOR(string s1, string s2)
        {
            string result = "";

            for (int i = 0; i < s1.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(s1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(s2[i].ToString()));

                if (a ^ b)
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }



        public int searchIndex(string text)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                   
                    if (errorArray[j, i] == text)
                    {
                        return j;
                    }
                 
                }
            }
            return -1;
        }


        public void generateFirst()
        {
            errorArray[0, 0] = "00000000";
            errorArray[0, 1] = "10000001";
            errorArray[0, 2] = "01000010";
            errorArray[0, 3] = "11000011";
            errorArray[0, 4] = "00100100";
            errorArray[0, 5] = "10100101";
            errorArray[0, 6] = "01100110";
            errorArray[0, 7] = "11100111";
            errorArray[0, 8] = "00011000";
            errorArray[0, 9] = "10011001";
            errorArray[0, 10] = "01011010";
            errorArray[0, 11] = "11011011";
            errorArray[0, 12] = "00111100";
            errorArray[0, 13] = "10111101";
            errorArray[0, 14] = "01111110";
            errorArray[0, 15] = "11111111";
        }

        public void generate()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string str = errorArray[0, i];
                    if (str[7 - j] == '1')
                    {
                        str = str.Remove(7 - j, 1).Insert(7 - j, "0");
                    }
                    else
                    {
                        str = str.Remove(7 - j, 1).Insert(7 - j, "1");
                    }
                    errorArray[j + 1, i] = str;
                }
            }
        }


    }
}
