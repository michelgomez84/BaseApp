using DataAccess;
using DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IDalService DalService;
        public ProductService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<Product>> FindAll(string filter, int pIdx, int pAmt)
        {
            try
            {
                string _QR = @"select * from Products where Product.Deleted = 0";

                List<SqlParameter> Parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(filter))
                {
                    _QR += " and (Products.Name like @Filter)";
                    Parameters.Add(new SqlParameter("@Filter", string.Format("%{0}%", filter)));
                }

                _QR += " order by Products.Name asc";

                _QR += " OFFSET @pagSkip ROWS FETCH NEXT @pagAmt ROWS ONLY";
                Parameters.Add(new SqlParameter("@pagSkip", pIdx * pAmt));
                Parameters.Add(new SqlParameter("@pagAmt", pAmt));

                return DalService.DBContext.Products.FromSqlRaw(_QR, Parameters.ToArray()).ToList();
            }
            catch (Exception ex)
            { }

            return null;
        }

        public async Task<List<Product>> GetAll()
        {
            return DalService.GetAll<Product>();
        }

        public async Task<Product> Get(long Id)
        {
            var result = DalService.Get<Product>(Id);

            return result;
        }

        public async Task<Product> Save(Product data)
        {
            return DalService.Save(data);
        }

        public async Task<Product> Delete(long Id)
        {
            return DalService.Delete<Product>(Id);
        }

        public async Task<int> Count()
        {
            return DalService.Count<Product>();
        }
    }
}

