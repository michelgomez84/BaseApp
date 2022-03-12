using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class DataList<T>
    {
        public List<T> LData { get; set; }
        public int Count { get; set; }
    }

}
