using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07._03._33
{
    class Program
    {
        //public static int  Mytimer()
        //{
        //    int count = 0;
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        count++;
        //        Thread.Sleep(1000);
        //    }
        //    return count;
        //}
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Timer starts:");
        //    //Thread.Sleep(1000);
        //    Task timer_task = Task.Run(() =>
        //    {
        //       int total =  Mytimer();
        //    }
        //    );
        //    Console.ReadLine();
        //    Console.WriteLine(timer_task);
        //}

        static CancellationTokenSource source = new CancellationTokenSource();
        static int counter = 0;
        static void MyTimer()
        {
            while ( !source.IsCancellationRequested)
            {
                Console.WriteLine(counter);
                Thread.Sleep(1000);
                counter++;
            }

            if (source.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Timer starts:");
            Task t1 = Task.Run(MyTimer);
            Console.WriteLine("Press [Enter] to stop ...");
            Console.ReadLine();

            source.Cancel(); 

            Console.WriteLine($"Timer has stopped:{counter} ");
        }

    }
}
