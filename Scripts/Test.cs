using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pcars;
using System.Threading;

public class Test : MonoBehaviour
{
    Thread udpThread;
    Thread consoleThread;

    void Awake()
    {
        var packetQueue = new PacketQueue();
        var udpProcess = new UDPProcess(ref packetQueue);
        var consoleProcess = new ConsoleProcess(ref packetQueue);

        udpThread = new Thread(new ThreadStart(udpProcess.Process));
        consoleThread = new Thread(new ThreadStart(consoleProcess.Process));

        udpThread.Start();
        consoleThread.Start();
    }

    void OnDisable()
    {
        udpThread.Abort();
        consoleThread.Abort();
    }
}
