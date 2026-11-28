using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class SmartBank
    {
        public string ProcessSecurityCodes(string accountCode, string transactionCode)
        {
            if(string.IsNullOrEmpty(accountCode) || string.IsNullOrEmpty(transactionCode))
            {
                return "";
            }
            foreach(char ch in accountCode)
            {
                if (!char.IsLetter(ch))
                {
                    return "";
                }
            }
            foreach(char ch in transactionCode)
            {
                if (!char.IsLetter(ch))
                {
                    return "";
                }
            }
            //count vowels and consonants
            int vowels = 0;
            int consonants = 0;
            foreach(char ch in accountCode)
            {
                if ("AEIOU".Contains(ch))
                {
                    vowels++;

                }
                else
                {
                    consonants++;
                }
            }
            //if vowels > consonants
            if (vowels > consonants)
            {
                string res = "";
                int count = 0;
                foreach (char ch in accountCode)
                {
                    if ("AEIOUaeiou".Contains(ch))
                    {
                        res += "*";
                        count++;
                    }
                    else
                    {
                        res += ch;
                    }
                }
                return res.ToUpper() + "-" + count;

            }
            else
            {
                string combined = accountCode + transactionCode;
                combined = combined.ToUpper();
                int max = 0;
                int mostFrequent = 0;
                foreach (char ch in combined)
                {
                    int count = 0;
                    foreach (char c in combined)
                    {
                        if (ch == c)
                        {
                            count++;
                        }
                    }
                    if (count > max || (count == max && ch < mostFrequent))
                    {
                        max = count;
                        mostFrequent = ch;

                    }
                }
                return $"{mostFrequent}-{max}";

            }
        }
        public static void Main(string[] args)
        {
            SmartBank s = new SmartBank();
            Console.WriteLine("Enter the account security code");
            string accountCode = Console.ReadLine();
            Console.WriteLine("Enter the transaction verification code");
            string transactionCode = Console.ReadLine();
            string res = s.ProcessSecurityCodes(accountCode, transactionCode);
            if(res == "")
            {
                Console.WriteLine("Invalid security codes");
            }
            else
            {
                Console.WriteLine("The security code analysis result is -" + res);
            }
        }
    }
}
