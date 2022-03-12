namespace WebApp.Services
{
    public interface IGenericService<T> where T : class,DataModel.Identity
    {
        Task<List<T>> FindAll(string filter, int pIdx, int pAmt);
        Task<List<T>> GetAll();
        Task<T> Get(long Id);
        Task<T> Save(T data);
        Task<T> Delete(long Id);
        Task<int> Count();
    }

    
}
