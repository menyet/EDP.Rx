using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPD.Rx.Service
{
    public interface IService
    {
        IReadOnlyCollection<string> GetWords(string text);

        Task<IReadOnlyCollection<string>> GetWordsAsync(string text);
    }
}
