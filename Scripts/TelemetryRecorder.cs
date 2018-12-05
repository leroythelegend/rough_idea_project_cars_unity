using System;
namespace pcars
{
    public class TelemetryRecorder : ITelemetryProcessor
    {
        readonly Laps laps;
        PacketDecoder packet;

        public TelemetryRecorder()
        {
            laps = new Laps();
        }

        public void Process()
        {
            // process packet into laps
        }

        public void AddPacket(PacketDecoder packet)
        {
            // check it is the right packet
            this.packet = packet;
        }

        public Laps GetLaps()
        {
            return laps;
        }
    }
}
