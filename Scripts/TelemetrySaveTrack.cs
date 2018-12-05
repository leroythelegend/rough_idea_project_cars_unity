using System;
namespace pcars
{
    public class TelemetrySaveTrack : ITelemetryProcessor
    {
        readonly ITelemetryProcessor recorded;

        public TelemetrySaveTrack(ITelemetryProcessor recorded)
        {
            this.recorded = recorded;
        }

        public void Process()
        {
            // process recorded laps
        }

        public void AddPacket(PacketDecoder packet)
        {
            recorded.AddPacket(packet);
        }

        public Laps GetLaps()
        {
            return recorded.GetLaps();
        }
    }
}
