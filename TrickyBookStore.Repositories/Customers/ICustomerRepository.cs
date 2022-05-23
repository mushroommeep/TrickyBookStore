using TrickyBookStore.Models;

// KeepIt
namespace TrickyBookStore.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(long id);
    }
}
