using DataAccess;
using DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IDalService DalService;
        public PurchaseOrderService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<PurchaseOrder>> FindAll(string filter, int pIdx, int pAmt)
        {
            try
            {
                string _QR = @"select * from PurchaseOrders where PurchaseOrder.Deleted = 0";

                List<SqlParameter> Parameters = new List<SqlParameter>();

                //if (!string.IsNullOrEmpty(filter))
                //{
                //    _QR += " and (PurchaseOrders.Name like @Filter)";
                //    Parameters.Add(new SqlParameter("@Filter", string.Format("%{0}%", filter)));
                //}

                _QR += " order by PurchaseOrders.CreatedDate asc";

                _QR += " OFFSET @pagSkip ROWS FETCH NEXT @pagAmt ROWS ONLY";
                Parameters.Add(new SqlParameter("@pagSkip", pIdx * pAmt));
                Parameters.Add(new SqlParameter("@pagAmt", pAmt));

                return DalService.DBContext.PurchaseOrders.FromSqlRaw(_QR, Parameters.ToArray()).ToList();
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<List<PurchaseOrder>> GetAll()
        {
            return DalService.GetAll<PurchaseOrder>();
        }

        public async Task<PurchaseOrder> Get(long Id)
        {
            var result = DalService.Get<PurchaseOrder>(Id);

            return result;
        }

        public async Task<PurchaseOrder> Save(PurchaseOrder data)
        {
            return DalService.Save(data);
        }

        public async Task<PurchaseOrder> Delete(long Id)
        {
            return DalService.Delete<PurchaseOrder>(Id);
        }

        public async Task<int> Count()
        {
            return DalService.Count<PurchaseOrder>();
        }
    }
}
