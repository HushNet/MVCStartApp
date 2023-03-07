// AlexeyQwake Qwake

using System.Threading.Tasks;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Models
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}