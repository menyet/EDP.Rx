using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EPD.Rx.Service
{
    internal class Service : IService
    {
        public IReadOnlyCollection<string> GetWords(string text)
        {
            var a = new Random();

            Thread.Sleep(100 + a.Next(2000));

            return DataProvider.CarsList.Where(x => x.StartsWith(text)).ToList();
        }

        public async Task<IReadOnlyCollection<string>> GetWordsAsync(string text)
        {
            var a = new Random();

            await Task.Delay(100 + a.Next(2000));

            return DataProvider.CarsList.Where(x => x.StartsWith(text)).ToList();
        }


        public string GetData(string firstName, string lastName, int duration)
        {
            Console.WriteLine("Starting to load data on thread {0}", Thread.CurrentThread.ManagedThreadId);
            var a = new Random();

            Thread.Sleep(duration * 1000);

            Console.WriteLine("Finished loading data on thread {0}", Thread.CurrentThread.ManagedThreadId);
            return firstName + " " + lastName;
        }

        public async Task<string> GetDataAsync(string firstName, string lastName, int duration, CancellationToken cancellationToken)
        {
            var a = new Random();

            try
            {
                await Task.Delay(duration*1000, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled");
            }

            return firstName + " " + lastName;
        }
    }
}
