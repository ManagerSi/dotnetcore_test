using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.V2.DAL
{
    public class ProductDAL:IProductDAL
    {
        public string GetProducts()
        {
            return "all products";
        }
    }
}
