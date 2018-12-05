using System;
using System.Collections.Generic;

namespace pcars
{
    public class Lap
    {
        readonly List<PacketDecoder> packets;

        public Lap()
        {
            packets = new List<PacketDecoder>();
        }

        public void Add(PacketDecoder packet)
        {
            packets.Add(packet);
        }

        public void ErasePackets()
        {
            packets.Clear();    
        }

        public List<PacketDecoder> GetPackets()
        {
            return packets;
        }
    }
}
