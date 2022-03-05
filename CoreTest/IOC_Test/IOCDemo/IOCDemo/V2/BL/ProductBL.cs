using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOCDemo.V2.DAL;

namespace IOCDemo.V2.BL
{
    public class ProductBL:IProductBL
    {
        private IProductDAL _productDal { get; set; }
        public ProductBL(IProductDAL productDal)
        {
            _productDal = productDal;
        }
        public string GetProducts()
        {
            return _productDal.GetProducts();
        }
    }
}
