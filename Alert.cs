using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practiceques
{
    using System;

    interface INotifier
    {
        void SendNotification(string recipient, string message);
    }

    class EmailNotifier : INotifier
    {
        public void SendNotification(string recipient, string message)
        {
            if (string.IsNullOrWhiteSpace(recipient) ||
                string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Invalid recipient or message.");
                return;
            }

            Console.WriteLine("email  : Email");
            Console.WriteLine("Recipient: " + recipient);
            Console.WriteLine("Message  : " + message);
        }
    }

    class SmsNotifier : INotifier
    {
        public void SendNotification(string recipient, string message)
        {
            if (string.IsNullOrWhiteSpace(recipient) ||
                string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Invalid recipient or message.");
                return;
            }

            Console.WriteLine("Channel  : SMS");
            Console.WriteLine("Recipient: " + recipient);
            Console.WriteLine("Message  : " + message);
        }
    }
    public  class Alert
    {

        static void ProcessNotification(
            INotifier notify,
            string recipient,
            string message)
        {
            notify.SendNotification(recipient, message);
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            INotifier e = new EmailNotifier();
            INotifier sms = new SmsNotifier();

            ProcessNotification(
                e,
                "meghana@gmail.com",
                "Ready to receive email"
            );

            ProcessNotification(
                sms,
                "6712635096",
                "Meeting starts sharp at 11 AM."
            );

            
          
        }
    }
}
