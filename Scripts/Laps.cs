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
    }
}
