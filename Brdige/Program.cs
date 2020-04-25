using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brdige
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();

            customerManager.MessageSenderBase = new EMailSender();

            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);        
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EMail Sender", body.Title);
        }
    }   
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SMS Sender", body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title= "Bridge Design Pattern"});
            Console.WriteLine("Customer Updated!");
        }
    }    

}
