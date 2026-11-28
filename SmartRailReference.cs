using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class SmartRailReference
    {
        public string ProcessPassengerDetails(string firstReference, string secondReference)
        {
            if (string.IsNullOrEmpty(firstReference) || string.IsNullOrEmpty(secondReference))
            {
                return "";

            }
            foreach (char ch in firstReference)
            {
                if (!char.IsLetter(ch))
                {
                    return "";
                }

            }
            foreach (char ch in secondReference)
            {
                if (!char.IsLetter(ch))
                {
                    return "";
                }
            }
            firstReference = firstReference.ToUpper();
            secondReference = secondReference.ToUpper();
            bool found = false;//check consecutive identical characters
            for (int i = 1; i < firstReference.Length; i++)
            {
                if (firstReference[i] == firstReference[i - 1])
                {
                    found = true;
                    break;

                }
            }
            //remove consecutive duplicate characters
            if (found)
            {
                string res = "";
                for (int i = 0; i < firstReference.Length; i++)
                {
                    if (i == 0 || firstReference[i] != firstReference[i - 1])
                    {
                        res += firstReference[i];
                    }

                }
                return res + " - " + res.Length;
            }
            string combined = firstReference + secondReference;
            combined = combined.ToUpper();
            int distinct = 0;
            int repeated = 0;
            for (int i = 0; i < combined.Length; i++)
            {
                if (combined.IndexOf(combined[i]) == i)
                {
                    int count = 0;
                    for (int j = 0; j < combined.Length; j++)
                    {
                        if (combined[i] == combined[j])
                        {
                            count++;
                        }
                    }
                    if (count == 1)
                    {
                        distinct++;
                    }
                    else
                    {
                        repeated++;
                    }

                }
            }
            if (distinct > repeated)
                return "Unique Reference";
            else if (repeated > distinct)
                return "Repeated Reference";
            else
                return "Unique Reference";
        }


        public static void Main(string[] args)
        {
                    SmartRailReference p = new SmartRailReference();
                    Console.WriteLine("Enter the booking reference");
                    string first = Console.ReadLine();
                    Console.WriteLine("Enter teh ticket reference");
                    string second = Console.ReadLine();
                    string res = p.ProcessPassengerDetails(first, second);
                    if(res == "")
            {
                Console.WriteLine("Invalid passenger details");
            }
            else
            {
                Console.WriteLine("The passenger reference status is - " + res);
            }

                


            
        }
    }
}
