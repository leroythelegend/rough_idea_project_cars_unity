﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace pcars
{
    public class FileStream
    {
        private readonly string fileName;

        public FileStream(string fileName)
        {
            this.fileName = fileName;
        }

        public void Save(List<TrackPosData> laps)
        {
            if (laps.Count > 0)
            {
                Stream SaveFileStream = File.Create(fileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, laps);
                SaveFileStream.Close();
            }
        }

        public List<TrackPosData> LoadTrackPosData()
        {
            Stream openFileStream = File.OpenRead(fileName);
            BinaryFormatter deserializer = new BinaryFormatter();
            List<TrackPosData> laps = (List<TrackPosData>)deserializer.Deserialize(openFileStream);
            openFileStream.Close();
            return laps;
        }

        public void Save(List<TrackData> laps)
        {
            if (laps.Count > 0)
            {
                Stream SaveFileStream = File.Create(fileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, laps);
                SaveFileStream.Close();
            }
        }

        public List<TrackData> LoadTrackData()
        {
            Stream openFileStream = File.OpenRead(fileName);
            BinaryFormatter deserializer = new BinaryFormatter();
            List<TrackData> laps = (List<TrackData>)deserializer.Deserialize(openFileStream);
            openFileStream.Close();
            return laps;
        }
    }
}
