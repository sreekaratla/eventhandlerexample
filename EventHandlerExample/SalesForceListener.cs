using EventHandlerExample;
using System;
namespace EventHandlerExample
{
    public class SalesForceListener
    {
        public event EventHandler<MessageEventArgs> newMessageArrived;

        public void OnMessage(string message)
        {
            var convertedJsonMessage = message;
            MessageEventArgs messageEventArgs = new MessageEventArgs();
            messageEventArgs.Message = message;
            newMessageArrived?.Invoke(this, messageEventArgs);
        }
    }
}