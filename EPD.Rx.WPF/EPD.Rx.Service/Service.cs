using System;
using System.Threading;
using System.Threading.Tasks;

namespace EPD.Rx.Service
{
    internal class Service : IService
    {
        public string[] GetWords(string text)
        {
            var a = new Random();

            Thread.Sleep(100 + a.Next(2000));

            return new[]
            {
                "asd","bsd"
            };
        }

        public async Task<string[]> GetWordsAsync(string text)
        {
            var a = new Random();

            await Task.Wait(100 + a.Next(2000));

            await Task.Wait(100);

            return new[]
            {
                "asd","bsd"
            };
        }
    }
}
