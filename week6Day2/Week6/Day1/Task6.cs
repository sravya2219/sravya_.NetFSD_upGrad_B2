using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.Week6.Day1
{
    public interface INotification 
    {
        public void Send(string message);
    }
    public class EmailNotification: INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }
    public class SMSNotification : INotification
    {

        public void Send(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push sent: " + message);
        }
    }

    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();

                case "sms":
                    return new SMSNotification();

                case "push":
                    return new PushNotification();

                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }
    class Program3
    {
        static void Main()
        {
            NotificationFactory factory = new NotificationFactory();

            INotification notification1 = factory.CreateNotification("email");
            notification1.Send("Welcome to our service!");

            INotification notification2 = factory.CreateNotification("sms");
            notification2.Send("Your OTP is 1234");

            INotification notification3 = factory.CreateNotification("push");
            notification3.Send("You have a new message");
        }
    }
}
