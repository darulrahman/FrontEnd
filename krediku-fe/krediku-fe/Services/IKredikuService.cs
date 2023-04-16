using krediku_fe.Models;
using krediku_fe.Models.Backend;

namespace krediku_fe.Services
{
    public interface IKredikuService
    {
        Task<ApiMessage<List<Location>>> GetLocations();
        Task<ApiMessage<List<Transaction>>> GetTransactions();
        Task<ApiMessage<Transaction>> AddTransaction(Transaction transaction);
    }
}
