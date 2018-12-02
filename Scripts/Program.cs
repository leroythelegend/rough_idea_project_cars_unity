using System;
using System.Collections.Generic;
using System.Threading;

namespace pcars
{
    class MainClass
    {
        public static void Main()
        {
            //Test test = new Test();

            //var packetQueue = new PacketQueue();
            //var udpProcess = new UDPProcess(ref packetQueue);
            //var consoleProcess = new ConsoleProcess(ref packetQueue);

            //var udpThread = new Thread(new ThreadStart(udpProcess.Process));
            //var consoleThread = new Thread(new ThreadStart(consoleProcess.Process));

            //udpThread.Start();
            //consoleThread.Start();

            //Console.Read();

            //udpThread.Abort();
            //consoleThread.Abort();

            FileStream stream = new FileStream("test.bin");

            List<TrackPosData> laps = new List<TrackPosData>();

            TrackPosData data = new TrackPosData();
            TrackData trackdata = new TrackData();

            trackdata.worldposx = 1;
            trackdata.worldposy = 2;
            trackdata.worldposz = 3;
            trackdata.currentLap = 4;

            data.trackData.Add(trackdata);
            laps.Add(data);

            stream.Write(laps);

            return;
        }
    }
}
