using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class GenericModel<T> where T : class
    {
        public GenericModel()
        {
            Ldata = null;
            Total = 0;
            PagAmt = 20;
            PagIdx = 0;
            Filter = "";
        }

        public int PagAmt { get; set; }
        public int PagIdx { get; set; }
        public string Filter { get; set; }
        public string ErrorMsg { get; set; }  

        public long ParentId { get; set; }

        public List<T> Ldata { get; set; }

        public int Total { get; set; }
        public int PagesCount
        {
            get
            {
                try
                {
                    return ((int)Math.Ceiling((decimal)Total / (decimal)PagAmt));
                }
                catch { }
                return 0;
            }
            set { }
        }

        //public long Id { get; set; }

        public T Data { get; set; }


    }

}
