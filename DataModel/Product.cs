using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Product : SystemId
    {        
        long categoryId;
        [Required(ErrorMessage = "required field")]
        [Range(1, long.MaxValue, ErrorMessage = "required field")]
        public long CategoryId { get => categoryId; set => SetProperty(ref categoryId, value); }
        Category category;
        public virtual Category Category { get => category; set => SetProperty(ref category, value); }


        string name;
        [StringLength(100)]
        [Required(ErrorMessage = "required field")]
        public string Name { get => name; set => SetProperty(ref name, value); }

        string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

        decimal price;
        public decimal Price { get => price; set => SetProperty(ref price, value); }

        int inStock;
        public int InStock { get => inStock; set => SetProperty(ref inStock, value); }

        string base64; //Picture
        public string Base64 { get => base64; set => SetProperty(ref base64, value); }

        
    }
}
