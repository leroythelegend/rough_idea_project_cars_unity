using System;
using System.Collections.Generic;

namespace pcars
{
    public class Laps
    {
        readonly List<Lap> laps;

        public Laps()
        {
            laps = new List<Lap>();
        }

        public void Add(Lap lap)
        {
            laps.Add(lap);
        }

        public void EraseLaps()
        {
            laps.Clear();
        }

        public List<Lap> GetLaps()
        {
            return laps;
        }

        public int Size()
        {
            return laps.Count;
        }

        public string GetTrackName()
        {
            string trackName = System.String.Empty;
            for (int i = 0; i < Size(); ++i)
            {
                for (int j = 0; j < laps[i].Size(); ++j)
                {
                    if (laps[i].GetPackets()[j].GetType().Name == "RaceDataDecoder")
                    {
                        var raceData = (RaceDataDecoder)laps[i].GetPackets()[j];
                        var trackLocation = raceData.trackLocation.String(0);
                        var trackVariation = raceData.trackVariation.String(0);
                        trackName = trackLocation + "_" + trackVariation;
                        break;
                    }
                }
                if (trackName.Length != 0)
                {
                    break;
                }
            }
            return trackName;
        }
    }
}
