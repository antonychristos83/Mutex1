using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mutex1
{
    internal class Program
    {
        private static Mutex mutex = new Mutex();
        private const int numhits = 1;
        private const int numThreads = 4;
        private static void ThreadProcess()
        {
            for (int i = 0; i < numhits; i++)
            {
                MutexFunct();
            }
        }
        private static void MutexFunct()
        {
            mutex.WaitOne();
            Console.WriteLine("{0} has entered in MutexFunct", Thread.CurrentThread.Name);
            Thread.Sleep(500);
            Console.WriteLine("{0} is leaving the MutexFunct");
            mutex.ReleaseMutex();
        }
        static void Main(string[] args)
        {
            for(int i = 0; i < numThreads; i++)
            {
                Thread mythread=new Thread(new ThreadStart(ThreadProcess));
                mythread.Name = String.Format("Thread{0}", i + 1);
                mythread.Start();
            }
            Console.ReadLine();
        }
    }
}
