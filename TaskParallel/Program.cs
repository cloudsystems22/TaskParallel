using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.Invoke(
                () => ExecutThreadZero(), 
                () => ExecutThreadUm(), 
                () => ExecutThreadDot()
                );
            
            stopwatch.Stop();
            Console.WriteLine("Tarefa finalizada! {0}s", stopwatch.ElapsedMilliseconds / 1000.0);
        }

        private static void ExecutThreadDot()
        {
            for (int i = 0; i < 300; i++)
            {
                TaskSleep();
                Console.Write(".");
            }
        }

        private static void ExecutThreadUm()
        {
            for (int i = 0; i < 300; i++)
            {
                TaskSleep();
                Console.Write("1");
            }
        }

        private static void ExecutThreadZero()
        {
            for (int i = 0; i < 300; i++)
            {
                TaskSleep();
                Console.Write("0");
            }
        }

        private static void TaskSleep()
        {
            Thread.Sleep(10);
        }
    }
}
