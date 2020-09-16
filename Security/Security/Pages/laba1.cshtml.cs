using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Security.Pages
{
    public class laba1Model : PageModel
    {
        private int rndEnd = 10000;
        private int rndStart = 0;
        public string Message { get; set; }

        public string code { get; set; }

        public Dictionary<int, char> table { get; set; }
        public void OnGet()
        {
            Message = "";
        }
        public void OnPost(string? text)
        {
            table = new Dictionary<int, char>();
            Message = text;
            CodeMessage();
        }



        public void CodeMessage()
        {
            foreach (char letter in Message)
            {
                int key;
                do
                {
                    Random rnd = new Random();
                    key = rnd.Next(rndStart, rndEnd);
                    if (table.Count > rndEnd - 100)
                    {
                        rndStart += 10000;
                        rndEnd += 10000;
                    }
                } while (table.ContainsKey(key));
                code += $"{key} ";
                table.Add(key, letter);
            }
        }
    }
}
