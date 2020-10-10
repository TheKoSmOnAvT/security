using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Security.Pages
{


    class stringSort : IComparer<string>
    {
        public int Compare(string p1, string p2)
        {
            if (p1.Length > p2.Length)
                return -1;
            else if (p1.Length < p2.Length)
                return 1;
            else
                return 0;
        }
    }

    public class laba6Model : PageModel
    {
        public string result { get; set; }
        public string enteredText { get; set; }
        public Dictionary<string, int> LZWArray { get; set; }
        public List<int> lzwNumbers { get; set; }
        private int index;

        public string decodeLWZ { get; set; }


        public string secondCode { get; set; }


        public void OnGet()
        {
        }

        public void OnPost(string? text)
        {
            enteredText = text;
            LZWArray = new Dictionary<string, int>();
            lzwNumbers = new List<int>();
            index = 0;


            //код lwz
            createLZWArray();
            result = string.Join(" ", lzwNumbers);

            //двухступенчатое  кодирование
            createSecondCode();

            //декод lwz
            decodelwz();

        }




        public void createSecondCode()
        {
            addLetter();
            List<string> codes = getSortList();
            secondCode = enteredText;
            foreach (var code in codes)
            {
                var number = LZWArray[code];
                secondCode = secondCode.Replace(code, $" { number } ");
            }

        }

        public void addLetter()
        {
            foreach (var letter in enteredText)
            {
                if (!LZWArray.ContainsKey(letter+""))
                {
                    index++;
                    LZWArray.Add(letter+"",index);
                }
            }
        }

        public List<string> getSortList()
        {
            List<string> list = new List<string>();

            foreach(var obj in LZWArray){

                list.Add(obj.Key);
            }
            list.Sort(new stringSort());
            return list;

        }



        public void decodelwz()
        {
            int[] mas = secondCode.Split(' ').Where(y => y != "" && y != " " ).Select(x => int.Parse(x)).ToArray();


            decodeLWZ = "";
            foreach(var num in mas)
            {
                decodeLWZ += LZWArray.FirstOrDefault(x => x.Value == num).Key;
            }
        }



        public void createLZWArray()
        {
            string str = enteredText[0] + "";
            for (int i = 1; i < enteredText.Length; i++)
            {
                str += enteredText[i];

                if (i + 1 == enteredText.Length)
                {
                    //if (addToArray(str + "#"))
                 //   {
                        addToArray(str + "#");
                        lzwNumbers.Add(index);
                        return;
                    //} else
                    //{
                    //    addToArray(str+"#");
                    //    lzwNumbers.Add(index);
                    //}
                }
                else
                {
                    if (addToArray(str))
                    {
                        lzwNumbers.Add(index);
                        str = enteredText[i] + "";
                    }
                }
            }

        }





        public bool checkInArray(string str)
        {
            if (LZWArray.ContainsKey(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addToArray(string preStr)
        {
            string str = "";
            if (preStr.Length > 1)
            {
                str = preStr.Substring(0, preStr.Length - 1);
            }
            else
            {
                str = preStr;
            }

            if (!checkInArray(str))
            {
                index++;
                LZWArray.Add(str, index);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}