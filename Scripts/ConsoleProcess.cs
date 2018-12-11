using System;
namespace pcars
{
    public class ConsoleProcess : IProcess
    {
        readonly PacketQueue packets;
        readonly IAction action;

        public ConsoleProcess(ref PacketQueue packets, IAction action)
        {
            this.action = action;
            this.packets = packets;
        }

        public void Process()
        {
            while (true)
            {
                //Console.WriteLine("Number of elements " + packets.Size());
                if (!packets.IsEmpty())
                {
                    action.Start(packets.Pop());
                }
            }
        }
    }
}
