using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Security.Pages
{
    public class laba8Model : PageModel
    {

        private const int sizeOfBlock = 32; //поскольку в unicode символ в два раза длинее, то увеличим блок тоже в два раза
        private const int sizeOfChar = 16; //размер одного символа (Unicode 16 bit)


        private const int quantityOfRounds = 16; //количество раундов

        string[] blocks; //сами блоки в двоичном формате
        public string key { get; set; }
        public string decodeText { get; set; }
        public string codeText { get; set; }
        public string enteredText { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(string? text)
        {

            if (text == null || text.Length == 0)
            {
                return;
            }

            //генерация случайного числа
            generateKey();

            //дополнение длины елси кол блоков не равное 
            enteredText = fullStringLenght(text);

            //перевод в бинарный и создание блоков 
            createBlocks(enteredText);

            codeText = "";
            decodeText = "";
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = XOR(blocks[i], key);
                codeText += blocks[i];
            }
            codeText = binaryToString(codeText);

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = XOR(blocks[i], key);
                decodeText += blocks[i];
            }
            decodeText = binaryToString(decodeText);

        }

        public void generateKey()
        {
            key = "";

            for (int i = 0; i < 32; i++)
            {
                Random rnd = new Random();
                key += rnd.Next(2).ToString();
            }
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