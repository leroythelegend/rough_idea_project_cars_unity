using System;
namespace pcars
{
    public class TelemetryRecorder : ITelemetryProcessor
    {
        int lapNumber;
        readonly Laps laps;
        Lap lap;
        PacketDecoder packet;

        public TelemetryRecorder()
        {
            lapNumber = 99999999;
            laps = new Laps();
            lap = new Lap();
        }

        public void Process()
        {
            if (packet.GetType().Name == "TimingsDataDecoder")
            {
                TimingsDataDecoder timings = (TimingsDataDecoder)packet;

                if (timings.participants.ParticipantInfoArray(timings.localParticipantIndex.Int()).currentLap.Int() != lapNumber)
                {
                    lapNumber = timings.participants.ParticipantInfoArray(timings.localParticipantIndex.Int()).currentLap.Int();
                    if (lap.Size() != 0)
                    {
                        laps.Add(lap);
                        lap = new Lap();
                    }
                }
            }
            lap.Add(packet);
        }

        public void AddPacket(PacketDecoder packet)
        {
            this.packet = packet;
        }

        public Laps GetLaps()
        {
            return laps;
        }
    }
}
