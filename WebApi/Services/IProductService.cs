using DataModel;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> FindAll(string filter, int pIdx, int pAmt);
        Task<List<Product>> GetAll();
        Task<Product> Get(long Id);
        Task<Product> Save(Product data);
        Task<Product> Delete(long Id);
        Task<int> Count();
    }
}
