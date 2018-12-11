using System;
namespace pcars
{
    public interface ITelemetryProcessor
    {
        void Process();
        void AddPacket(PacketDecoder packet);
        Laps GetLaps();
    }
}
