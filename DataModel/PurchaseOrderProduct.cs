using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class PurchaseOrderProduct : SystemId
    {
        //Order Relation
        long purchaseOrderId;
        public long PurchaseOrderId { get => purchaseOrderId; set => SetProperty(ref purchaseOrderId, value); }
        PurchaseOrder purchaseOrder;
        public virtual PurchaseOrder PurchaseOrder { get => purchaseOrder; set => SetProperty(ref purchaseOrder, value); }

        //Product Relation 
        long productId;
        public long ProductId { get => productId; set => SetProperty(ref productId, value); }
        Product product;
        public virtual Product Product { get => product; set => SetProperty(ref product, value); }
                
        decimal salePrice;
        public decimal SalePrice { get => salePrice; set => SetProperty(ref salePrice, value); }

        int qty;
        public int Qty { get => qty; set => SetProperty(ref qty, value); }                

    }
}
