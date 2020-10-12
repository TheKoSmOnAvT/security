using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Security.Pages
{
    public class laba7Model : PageModel
    {
        private const int sizeOfBlock = 32; //поскольку в unicode символ в два раза длинее, то увеличим блок тоже в два раза
        private const int sizeOfChar = 16; //размер одного символа (Unicode 16 bit)


        private const int quantityOfRounds = 16; //количество раундов

        string[] blocks; //сами блоки в двоичном формате
        string[] keys;

        public string code;
        public string deCode;

        public string enteredCode;
        public string hash { get; set; }
        public void OnGet()
        {
        }
        public void OnPost(string? pass)
        {
            enteredCode = pass;
            if (pass == null || pass.Length == 0)
            {
                return;
            }


            //дополнение длины елси кол блоков не равное 
            enteredCode = fullStringLenght(enteredCode);

            //перевод в бинарный и создание блоков 
            createBlocks(enteredCode);
            keys = blocks;

            for (int j = 0; j < quantityOfRounds; j++)
            {
                for (int i = 0; i < blocks.Length; i++)
                {
                    blocks[i] = roundDES(blocks[i], stringToBinary(keys[i]));
                }
            }

            string result = "";

            for (int i = 0; i < blocks.Length; i++)
            {
                result += blocks[i];
            }
            //перевод хэш в string
            hash = binaryToString(result);
        }



        //дополнение длины для равного значения внутри всех блоков 
        private string fullStringLenght(string input)
        {
            while (((input.Length * sizeOfChar) % sizeOfBlock) != 0)
            {
                input += "#";
            }
            return input;
        }

        //создание блоков
        private void createBlocks(string input)
        {
            blocks = new string[(input.Length * sizeOfChar) / sizeOfBlock];

            int lengthOfBlock = input.Length / blocks.Length;

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
                blocks[i] = stringToBinary(blocks[i]);
            }
        }

        //строка в двоичный код
        private string stringToBinary(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                string charB = Convert.ToString(input[i], 2);

                while (charB.Length < sizeOfChar)
                {
                    charB = "0" + charB;
                }

                result += charB;
            }
            return result;
        }
        private string roundDES(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (R + XOR(L, f(R, key)));
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

        private string f(string s1, string s2)
        {
            return XOR(s1, s2);
        }


        private string binaryToString(string input)
        {
            string result = "";

            while (input.Length > 0)
            {
                string cahrB = input.Substring(0, sizeOfChar);
                input = input.Remove(0, sizeOfChar);

                int a = 0;
                int degree = cahrB.Length - 1;

                foreach (char c in cahrB)
                {
                    a += Convert.ToInt32(c.ToString()) * (int)Math.Pow(2, degree--);
                }

                result += ((char)a).ToString();
            }

            return result;
        }

    }
}
