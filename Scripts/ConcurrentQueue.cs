using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace pcars
{
    public class ConcurrentQueue<T>
    {
        readonly Mutex mutex;
        Queue<T> queue;

        public ConcurrentQueue()
        {
            mutex = new Mutex();
            queue = new Queue<T>();
        }

        public bool TryDequeue(ref T packet)
        {
            bool result = mutex.WaitOne();
            if (result)
            {
                packet = queue.Dequeue();
                mutex.ReleaseMutex();
            }
            else 
            {
                packet = default(T);
            }
            return result;
        }

        public bool TryPeek(ref T packet)
        {
            bool result = mutex.WaitOne();
            if (result)
            {
                packet = queue.Peek();
                mutex.ReleaseMutex();
            }
            else
            {
                packet = default(T);
            }
            return result;
        }

        public void Enqueue(T packet)
        {
            mutex.WaitOne();
            queue.Enqueue(packet);
            mutex.ReleaseMutex();
        }

        public bool IsEmpty()
        {
            mutex.WaitOne();
            bool result = (queue.Count == 0);
            mutex.ReleaseMutex();
            return result;
        }

        public int Count()
        {
            mutex.WaitOne();
            int result = queue.Count;
            mutex.ReleaseMutex();
            return result;
        }
    }
}
