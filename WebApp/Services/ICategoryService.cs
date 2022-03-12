using DataModel;

namespace WebApp.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> FindAll(string filter, int pIdx, int pAmt);
        Task<List<Category>> GetAll();
        Task<Category> Get(long Id);
        Task<Category> Save(Category data);
        Task<Category> Delete(long Id);
        Task<int> Count();
    }
}
