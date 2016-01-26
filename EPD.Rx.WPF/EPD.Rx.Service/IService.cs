using System.Threading.Tasks;

namespace EPD.Rx.Service
{
    public interface IService
    {
        string[] GetWords(string text);

        Task<string[]> GetWordsAsync(string text);
    }
}
