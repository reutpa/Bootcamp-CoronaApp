using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Interfaces
{
    public interface ILoginDAL
    {
        Task<User> GetUser(User user);
        Task<bool> AddUser(User user);
    }
}