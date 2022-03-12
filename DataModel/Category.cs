using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Category : SystemId
    {
        public Category()
        {
            LProducts = new List<Product>();
        }

        string name;
        [StringLength(100)]
        [Required(ErrorMessage = "required field")]
        public string Name { get => name; set => SetProperty(ref name, value); }

        string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

        List<Product> lProducts;
        public virtual List<Product> LProducts { get => lProducts; set => SetProperty(ref lProducts, value); }


    }
}
