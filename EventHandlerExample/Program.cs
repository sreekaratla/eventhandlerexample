using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageHandler messageHandler = new MessageHandler();
            SalesForceListener salesForceListener = new SalesForceListener();
            salesForceListener.newMessageArrived += messageHandler.HandleNewMessage;

            salesForceListener.OnMessage("first sample message from salesforce");

            messageHandler.UploadMessagesToApi();
        }
    }
}
