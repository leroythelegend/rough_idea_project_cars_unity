using System;
using System.Collections.Generic;

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
            var laps = GetLaps();
            string fileName = "./Tracks/" + laps.GetTrackName() + ".bin";

            // temp get laps x y z;
            TrackData trackData = new TrackData();
            List<TrackData> tracks = new List<TrackData>();

            for (int i = 1; i < laps.Size(); i = (i + 2))
            {
                // skip out lap and them get every second lap
                // 1 = outside
                // 3 = raceline
                // 5 = inside
                for (int j = 0; j < laps.GetLaps()[i].Size(); ++j)
                {
                    if (laps.GetLaps()[i].GetPackets()[j].GetType().Name == "TimingsDataDecoder")
                    {
                        TimingsDataDecoder timings = (TimingsDataDecoder)laps.GetLaps()[i].GetPackets()[j];;

                        trackData = new TrackData
                        {
                            worldposx = timings.participants.ParticipantInfoArray(timings.localParticipantIndex.Int()).worldPosition.Int(0),
                            worldposy = timings.participants.ParticipantInfoArray(timings.localParticipantIndex.Int()).worldPosition.Int(1),
                            worldposz = timings.participants.ParticipantInfoArray(timings.localParticipantIndex.Int()).worldPosition.Int(2),
                            currentLap = i
                        };
                        tracks.Add(trackData);
                    }
                }
            }

            if (tracks.Count != 0)
            {
                FileStream stream = new FileStream(fileName);
                stream.Save(tracks);
            }

            laps.EraseLaps();
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
