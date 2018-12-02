using System;
// using System.Collections.Concurrent;
using System.Threading;
// using System.Threading.Tasks;

namespace pcars
{

    public class PacketQueue
    {
        readonly ConcurrentQueue<PacketDecoder> packetQueue;

        public PacketQueue()
        {
            packetQueue = new ConcurrentQueue<PacketDecoder>();
        }

        public PacketDecoder Pop()
        {
            PacketDecoder packet = new PacketDecoder();
            packetQueue.TryDequeue(ref packet);
            return packet;
        }

        public PacketDecoder Peek()
        {
            PacketDecoder packet = new PacketDecoder();
            packetQueue.TryPeek(ref packet);
            return packet;
        }

        public void Push(PacketDecoder packet)
        {
            packetQueue.Enqueue(packet);
        }

        public bool IsEmpty()
        {
            return packetQueue.IsEmpty();
        }

        public int Size()
        {
            return packetQueue.Count();
        }
    }
}
