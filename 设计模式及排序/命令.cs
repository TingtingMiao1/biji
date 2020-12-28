using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minglingmoshi
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoker i = new Invoker();
            i.SetCommand(c);
            i.ExectueCommand();
            Console.ReadKey();

        }
        public abstract class Command
        {
            private Receiver receiver;

            internal Receiver Receiver
            {
                get { return receiver; }
                set { receiver = value; }
            }
            public Command(Receiver receiver)
            {
                this.receiver = receiver;
            }
            public abstract void Execute();

        }
        public class Receiver
        {
            public void Action()
            {
                Console.WriteLine("取得receiver的action方法！");
            }
        }
        public class ConcreteCommand : Command
        {
            public ConcreteCommand(Receiver receiver) : base(receiver) { }
            public override void Execute()
            {
                Receiver.Action();
            }
        }
        public class Invoker
        {
            private Command command;

            internal Command Command
            {
                get { return command; }
                set { command = value; }
            }
            public void SetCommand(Command command)
            {
                this.command = command;
            }
            public void ExectueCommand()
            {
                command.Execute();
            }
        }
    }
}
