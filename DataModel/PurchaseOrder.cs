using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class PurchaseOrder : SystemId
    {
        public PurchaseOrder()
        {
            LProducts = new List<PurchaseOrderProduct>();
        }
                
        List<PurchaseOrderProduct> lProducts;
        public virtual List<PurchaseOrderProduct> LProducts { get => lProducts; set => SetProperty(ref lProducts, value); }


        decimal totalSalePrice;
        public decimal TotalSalePrice { get => totalSalePrice; set => SetProperty(ref totalSalePrice, value); }


        decimal paymentAmt;
        public decimal PaymentAmt { get => paymentAmt; set => SetProperty(ref paymentAmt, value); }


        decimal changeAmt;
        public decimal ChangeAmt { get => changeAmt; set => SetProperty(ref changeAmt, value); }

        
        public void Update()
        {
            TotalSalePrice = LProducts.Sum(x=>x.Qty * x.SalePrice);
            ChangeAmt = PaymentAmt - TotalSalePrice;
            ChangeAmt = ChangeAmt > 0 ? ChangeAmt : 0;
        }

    }
}
