// AlexeyQwake Qwake

using System.Threading.Tasks;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Models
{
    public interface IRequestRepository
    {
        Task LogRequest(Request request);
        Task<Request[]> GetRequests();
    }
}