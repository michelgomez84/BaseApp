using DataModel;

namespace WebApp.Services
{
    public interface IPurchaseOrderService
    {
        Task<List<PurchaseOrder>> FindAll(string filter, int pIdx, int pAmt);
        Task<List<PurchaseOrder>> GetAll();
        Task<PurchaseOrder> Get(long Id);
        Task<PurchaseOrder> Save(PurchaseOrder data);
        Task<PurchaseOrder> Delete(long Id);
        Task<int> Count();
    }
}
