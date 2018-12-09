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
            string fileName = System.String.Empty;

            // find track location and variation for file name
            for (int i = 0; i < laps.Size(); ++i)
            {
                for (int j = 0; j < laps.GetLaps()[i].Size(); ++j)
                {
                    if (laps.GetLaps()[i].GetPackets()[j].GetType().Name == "RaceDataDecoder")
                    {
                        var raceData = (RaceDataDecoder)laps.GetLaps()[i].GetPackets()[j];
                        var trackLocation = raceData.trackLocation.String(0);
                        var trackVariation = raceData.trackVariation.String(0);
                        fileName = trackLocation + "_" + trackVariation + ".bin";
                        break;
                    }
                }
                if (fileName.Length != 0) 
                {
                    break;
                }
            }

            // temp get laps x y z;
            TrackData trackData = new TrackData();
            List<TrackData> tracks = new List<TrackData>();

            for (int i = 0; i < laps.Size(); ++i)
            {
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

            FileStream stream = new FileStream(fileName);
            stream.Save(tracks);

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
