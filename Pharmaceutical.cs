using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public  class Pharmaceutical
    {
        public string ProcessGuestDetails(string first, string second)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
            {
                return "";
            }
            foreach (char ch in first)
            {
                if (!char.IsLetter(ch))//checks alphabet
                {
                    return "";
                }

            }
            foreach (char ch in second)
            {
                if (!char.IsLetter(ch))
                {
                    return "";
                }

            }
            first = first.ToUpper();
            second = second.ToUpper();
            if (second.Contains(first))
            {
                second = second.ToUpper();
                string result = second.Replace(first,"");
                char[] arr = result.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }
            else
            {
                string combined = first + second;
                int vowels = 0;
                int consonants = 0;
                combined = combined.ToUpper();
                foreach (char ch in combined)
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
                if (vowels > consonants)
                {
                    return "Premium Guest";
                }
                else if (consonants > vowels)
                {
                    return "Regular Guest";
                }
                else
                {
                    return "Special Guest";
                }
            }
        }
        public static void Main(string[] args)
        {
            Pharmaceutical p = new Pharmaceutical();
            Console.WriteLine("Enter the first name");
            string first = Console.ReadLine();
            Console.WriteLine("Enter the second name");
            string second = Console.ReadLine();
            string res = p.ProcessGuestDetails(first, second);
            if(res == "")
            {
                Console.WriteLine("Invalid guest details");

            }
            else
            {
                Console.WriteLine("The guest category is - " +  res);
            }

            

        }
           
        
    }
}
