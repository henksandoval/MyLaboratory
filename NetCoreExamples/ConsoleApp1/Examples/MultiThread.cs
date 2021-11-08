namespace NetCoreExamples.Examples
{
    using System;
    using System.Threading;

    public class MultiThread : IRunnable
    {
        private static int count = 0;
        private static bool execute = true;

        public void Run()
        {
            Thread thread01 = new Thread(Increase);
            Thread thread02 = new Thread(Increase);

            thread01.Start();
            thread02.Start();


            while (execute)
            {
                if (count > 100) execute = false;
            }


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finish run on Multithread");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void Increase()
        {
            while (execute)
            {
                count++;
                Console.WriteLine("-------");
                Console.WriteLine("Thread id --> {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Count --> {0}", count);

                Thread.Sleep(300);
            }
        }
    }
}
