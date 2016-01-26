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
    }
}
