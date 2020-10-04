using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Security.Pages
{
    public class laba4Model : PageModel
    {


        private const int sizeOfBlock = 32; //поскольку в unicode символ в два раза длинее, то увеличим блок тоже в два раза
        private const int sizeOfChar = 16; //размер одного символа (Unicode 16 bit)

        private const int shiftKey = 2; //сдвиг ключа 

        private const int quantityOfRounds = 16; //количество раундов

        string[] blocks; //сами блоки в двоичном формате
        public string code;
        public string deCode;



        public string decodeKey;

        public void OnGet()
        {
        }


        public void OnPost(string? text, string? keyS)
        {
            if (text == null || text.Length == 0 || keyS == null || keyS.Length == 0)
            {
                return;
            }

            // шифр

            string str = text;
            string key = keyS;

            //дополнение длины елси кол блоков не равное 
            str = fullStringLenght(str);

            //перевод в бинарный и создание блоков 
            createBlocks(str);

            //довести длину ключа до длины половины блока
            key = сorrectKeyWord(key, str.Length / (2 * blocks.Length));


            //ключ в двоичный код
            key = stringToBinary(key);

            for (int j = 0; j < quantityOfRounds; j++)
            {
                for (int i = 0; i < blocks.Length; i++)
                {
                    //раунд DES с XOR
                    blocks[i] = roundDES(blocks[i], key);
                }
                if (j != quantityOfRounds - 1) 
                {
                    //сдвиг ключа
                    key = keyToNextRound(key);
                }
            }

            //перевод ключа в string
            decodeKey = binaryToString(key);

            string result = "";

            for (int i = 0; i < blocks.Length; i++)
            {
                result += blocks[i];
            }
            //перевод шифра в string
            code = binaryToString(result);

            //Дешифр

            //перевод ключа в двоичную систему
            key = stringToBinary(decodeKey);

            //перевод шифра в двоичную систему
            str = stringToBinary(code);

            //разбитие двоич системы на блоки 
            createBinaryBlocks(str);

            for (int j = 0; j < quantityOfRounds; j++)
            {
                for (int i = 0; i < blocks.Length; i++)
                {
                    //раунд дес дешифровки
                    blocks[i] = roundDecodeDES(blocks[i], key);
                }
                if (j != quantityOfRounds - 1)
                {
                    key = KeyToPrevRound(key);
                }
            }

            result = "";

            for (int i = 0; i < blocks.Length; i++)
            {
                result += blocks[i];
            }


            deCode = binaryToString(result);



            deCode.Replace('#',' ');

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


        private void createBinaryBlocks(string input)
        {
            blocks = new string[input.Length / sizeOfBlock];

            int lengthOfBlock = input.Length / blocks.Length;

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
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

        private string сorrectKeyWord(string input, int lengthKey)
        {
            if (input.Length > lengthKey)
            {
                input = input.Substring(0, lengthKey);
            }
            else
            {
                while (input.Length < lengthKey)
                {
                    input = "0" + input;
                }
            }
            return input;
        }

        private string roundDES(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (R + XOR(L, f(R, key)));
        }


        private string roundDecodeDES(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (XOR(f(L, key), R) + L);
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


        private string keyToNextRound(string key)
        {
            for (int i = 0; i < shiftKey; i++)
            {
                key = key[key.Length - 1] + key;
                key = key.Remove(key.Length - 1);
            }

            return key;
        }


        private string KeyToPrevRound(string key)
        {
            for (int i = 0; i < shiftKey; i++)
            {
                key = key + key[0];
                key = key.Remove(0, 1);
            }

            return key;
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
