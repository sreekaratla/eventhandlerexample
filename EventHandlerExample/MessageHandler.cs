using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerExample
{    
    public class MessageHandler
    {
        public static IList<string> messages = new List<string>();

        public void HandleNewMessage(object sender, MessageEventArgs e)
        {
            messages.Add(e.Message);
        }

        public void UploadMessagesToApi()
        {
            foreach (string message in messages)
                Console.WriteLine(message);
        }
    }
}
