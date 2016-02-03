using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EPD.Rx.Service
{
    public interface IService
    {
        IReadOnlyCollection<string> GetWords(string text);

        Task<IReadOnlyCollection<string>> GetWordsAsync(string text);

        string GetData(string firstName, string lastName, int duration);

        Task<string> GetDataAsync(string firstName, string lastName, int duration, CancellationToken cancellationToken);
    }
}
