using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace Security.Pages
{
    public class laba2Model : PageModel
    {
        public string text { get; set; }

        public string codable { get; set; }

        public string decode { get; set; }

        public List<BigInteger> codeList { get; set; }


        public List<string> letterList { get; set; }
        public List<BigInteger> open { get; set; }
        public List<BigInteger> closed { get; set; }

        public void OnGet()
        { }

        public void OnPost(string? text)
        {
            this.text = text;
            string letters = "q w e r t y u i o p a s d f g h j k l z x c v b n m 1 2 3 4 5 6 7 8 9 0 - = é ö ó ê å í ã ø ù ç õ ú ô û â à ï ð î ë ä æ ý ÿ ÷ ñ ì è ò ü á þ É Ö Ó Ê Å Í Ã Ø Ù Ç Õ Ú Ô Û Â À Ï Ð Î Ë Ä Æ Ý ß × Ñ Ì È Ò Ü Á Þ Q W E R T Y U I O P A S D F G H J K L Z X C V B N M , / ! ; ' [ ] .  ";
            letterList = letters.Split(' ').ToList();
            generateKey();
            code();
            deCode();
        }

        public void code()
        {
            if (text == null) return;
            codeList = new List<BigInteger>();
            foreach (char letter in text)
            {
                int numLetter = letterList.IndexOf(letter.ToString());
                BigInteger code = toPow(numLetter, open[0]) % open[1]; //(numLetter ^ (int)open[0]) % open[1];
                codeList.Add(code);
            }
            codable = string.Join(" ", codeList);
        }

        public void deCode()
        {
            decode = "";
            foreach (BigInteger code in codeList)
            {

                BigInteger letter = toPow(code, closed[0]) % closed[1];
                string numLetter = letterList[(int)letter];
                decode += numLetter;
            }
        }

        public void generateKey()
        {
            BigInteger q = 17;//generatePQ(); //59
            BigInteger p = 23;//generatePQ(); // 67

            BigInteger n = p * q;

            BigInteger phi = (p - 1) * (q - 1);
            BigInteger e = 3;// calculateE(phi);
            BigInteger d = 1;
            while ((d * e) % phi != 1)
            {
                d++;
            }

            open = new List<BigInteger>();
            open.Add(e);
            open.Add(n);
            closed = new List<BigInteger>();
            closed.Add(d);
            closed.Add(n);
        }

        public BigInteger toPow(BigInteger num, BigInteger x)
        {
            BigInteger r = 1;
            while (x>0)
            {
                if (x%2 ==1)
                {
                    r = r * num;
                }
                x = x / 2;
                num = num * num;
            }
            return r;
        }
        public BigInteger calculateE(BigInteger phi)
        {
            BigInteger e = 3;
            while (!isSimple(e) || NOD(phi, e) != 1)
            {
                e++;
            }
            return e;

        }
        public bool isSimple(BigInteger num)
        {
            if (num % 2 == 0) { return false; }
            BigInteger q = 3;
            while (q * q <= num)
            {
                if (num % q == 0) { return false; }
                q += 2;
            }
            return true;
        }
        public BigInteger NOD(BigInteger x, BigInteger y)
        {
            BigInteger a = x;
            BigInteger b = y;
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        public BigInteger generatePQ()
        {
            Random rnd = new Random();
            BigInteger num = rnd.Next(11, 15);// * 1000000000000;
            while (!isSimple(num))
            {
                num++;
            }
            return num;
        }


    }
}
