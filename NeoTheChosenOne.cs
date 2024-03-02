using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SweeftStage2Tasks
{
    public class NeoTheChosenOne
    {
        private static int[] ZeroAndOne = [0, 1];
        private static Random Random = new Random();
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private static bool isNeoRunning = false;

        public async Task RunTask9()
        {
            var t1 = Task.Run(PrintZerosAndOnes);
            var t2 = Task.Run(PrintNeo);

            await Task.WhenAll(t1, t2);
        }

        private static async Task PrintZerosAndOnes()
        {
            while (true)
            {
                await semaphore.WaitAsync();

                if (isNeoRunning)
                {
                    semaphore.Release(); // Neo starts running
                }

                Console.ForegroundColor = ConsoleColor.Green;
                var index = Random.Next(0, 2);
                Console.Write(ZeroAndOne[index]);

                semaphore.Release();
            }
        }

        private static async Task PrintNeo()
        {
            while (true)
            {
                await Task.Delay(5000); // wait while printing zeros and ones

                isNeoRunning = true; // stop printing zeros and ones
                await semaphore.WaitAsync();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\nNeo, you are the chosen one\n");
                await Task.Delay(5000);

                isNeoRunning = false;
                semaphore.Release(); // continue printing zeros and ones
            }
        }
    }
}
