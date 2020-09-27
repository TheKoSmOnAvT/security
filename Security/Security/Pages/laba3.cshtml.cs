using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace Security.Pages
{
    public class laba3Model : PageModel
    {





        public BigInteger number { get; set; }
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }

        public BigInteger A { get; set; }
        public BigInteger B { get; set; }

        public BigInteger Kx { get; set; }
        public BigInteger Ky { get; set; }


        public void OnGet()
        {
            BigInteger q = generatePQ(); //17
            BigInteger p = generatePQ(); // 23

            BigInteger n = p * q;
            
            X = generateXY();
            //A = qx mod n
            A = toPow(q,X) % n; // посылаетс€ второму участнику
            Y = generateXY();
            //B = qy mod n 
            B = toPow(q, Y) % n; // посылаетс€ первому участнику

            //Kx = Bx mod n 
            //ѕартнер P1, получив ¬, вычисл€ет Kx
            Kx = toPow(B, X) % n;


            //Ky = Ay mod n
            //P2 вычисл€ет Ky
            Ky = toPow(A, Y) % n;

        }


        public BigInteger generateXY()
        {
            Random rnd = new Random();
            BigInteger num = rnd.Next(10, 35);// * 1000000000000;
            while (!isSimple(num))
            {
                num++;
            }
            return num;
        }

        public BigInteger toPow(BigInteger num, BigInteger x)
        {
            BigInteger r = 1;
            while (x > 0)
            {
                if (x % 2 == 1)
                {
                    r = r * num;
                }
                x = x / 2;
                num = num * num;
            }
            return r;
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
            BigInteger num = rnd.Next(10, 35);// * 1000000000000;
            while (!isSimple(num))
            {
                num++;
            }
            return num;
        }
    }
}
