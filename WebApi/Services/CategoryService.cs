using DataAccess;
using DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IDalService DalService;
        public CategoryService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<List<Category>> FindAll(string filter, int pIdx, int pAmt)
        {            
            try
            {
                string _QR = @"select * from Categories where Categories.Deleted = 0";

                List<SqlParameter> Parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(filter))
                {
                    _QR += " and (Categories.Name like @Filter)";
                    Parameters.Add(new SqlParameter("@Filter", string.Format("%{0}%", filter)));
                }

                _QR += " order by Categories.Name asc";

                _QR += " OFFSET @pagSkip ROWS FETCH NEXT @pagAmt ROWS ONLY";
                Parameters.Add(new SqlParameter("@pagSkip", pIdx * pAmt));
                Parameters.Add(new SqlParameter("@pagAmt", pAmt));

                return DalService.DBContext.Categories.FromSqlRaw(_QR, Parameters.ToArray()).ToList();
            }
            catch (Exception ex)
            { }
            
            return null;
        }

        public async Task<List<Category>> GetAll()
        {
            return DalService.GetAll<Category>();
        }

        public async Task<Category> Get(long Id)
        {
            var result = DalService.Get<Category>(Id);

            return result;
        }

        public async Task<Category> Save(Category data)
        {
            return DalService.Save(data);
        }

        public async Task<Category> Delete(long Id)
        {
            return DalService.Delete<Category>(Id);
        }
        public async Task<int> Count()
        {
            return DalService.Count<Category>();
        }
    }
}
