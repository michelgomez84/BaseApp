using DataAccess;
using DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services
{
    public class GenericService<T> : IGenericService<T> where T : class, DataModel.Identity
    {
        private readonly IDalService DalService;
        public GenericService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<T>> FindAll(string filter, int pIdx, int pAmt)
        {
            try
            {
                //string _QR = @"select * from PurchaseOrder where PurchaseOrder.Deleted = 0";

                //List<SqlParameter> Parameters = new List<SqlParameter>();

                ////if (!string.IsNullOrEmpty(filter))
                ////{
                ////    _QR += " and (PurchaseOrder.Name like @Filter)";
                ////    Parameters.Add(new SqlParameter("@Filter", string.Format("%{0}%", filter)));
                ////}

                //_QR += " order by PurchaseOrder.CreatedDate asc";

                //_QR += " OFFSET @pagSkip ROWS FETCH NEXT @pagAmt ROWS ONLY";
                //Parameters.Add(new SqlParameter("@pagSkip", pIdx * pAmt));
                //Parameters.Add(new SqlParameter("@pagAmt", pAmt));

                //return DalService.DBContext.PurchaseOrders.FromSqlRaw(_QR, Parameters.ToArray()).ToList();
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<List<T>> GetAll()
        {
            return DalService.GetAll<T>();
        }

        public async Task<T> Get(long Id)
        {
            var result = DalService.Get<T>(Id);

            return result;
        }

        public async Task<T> Save(T data)
        {
            return DalService.Save(data);
        }

        public async Task<T> Delete(long Id)
        {
            return DalService.Delete<T>(Id);
        }
        public async Task<int> Count()
        {
            return DalService.Count<T>();
        }

    }
}
