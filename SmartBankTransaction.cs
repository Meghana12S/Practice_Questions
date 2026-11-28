using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class SmartBankTransaction
    {
        public string ProcessTransactionCodes(string firstCode, string secondCode)
        {
            if (string.IsNullOrEmpty(firstCode) || string.IsNullOrEmpty(secondCode))
            {
                return "";
            }
            if (firstCode.Length < 5 || firstCode.Length > 15 || secondCode.Length < 5 || secondCode.Length > 15)
            {
                return "";
            }
            foreach(char ch in firstCode)
            {
                if(!char.IsLetterOrDigit(ch))
                {
                    return "";
                }
            }
            foreach(char ch in secondCode)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return "";
                }
            }
            bool found = false;
            for(int i =1;i<firstCode.Length;i++)
            {
                if (firstCode[i] == firstCode[i-1])
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                string result = firstCode.ToUpper();
                string modified = "";
                foreach(char ch in result)
                {
                    if (char.IsDigit(ch))
                    {
                        modified += "#";

                    }
                    else
                    {
                        modified += ch;
                    }
                }
                string finalresult = "";
                for(int i = 0;i<modified.Length;i++)
                {
                    if (i == 0 || modified[i] != modified[i-1])
                    {
                        finalresult += modified[i];
                    }
                }
                return finalresult;
            }
            else
            {
                int combined = firstCode.Length + secondCode.Length;
                int asciiSum = (int)secondCode[0] + (int)secondCode[secondCode.Length - 1];
                if (combined >= 20 && asciiSum <= 150)
                    return "High Risk Transaction";
                else if (combined <= 20 && asciiSum >= 150)
                    return "Verified Transaction";
                else
                    return "Normal Transaction";
            }
        }
            
        public static void Main(string[] args)
        {
            SmartBankTransaction p = new SmartBankTransaction();
            Console.WriteLine("Enter the first transaction code");
            string first = Console.ReadLine();
            Console.WriteLine("Enter the second transaction code");
            string second = Console.ReadLine();
            string res = p.ProcessTransactionCodes(first, second);
            if(res == "")
            {
                Console.WriteLine("Invalid transaction detail");
            }
            else
            {
                Console.WriteLine("The transaction status is - " + res);
            }
        }

    }
}
