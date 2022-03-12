using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface Identity
    {
        long Id { get; }
        bool Deleted { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
