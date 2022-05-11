using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Models
{
    //using System.ComponentModel.DataAnnotations;

    public class ProductType
    {
        public int PTID { get; set; }
        public string PTName { get; set; }
        //每个产品类型有许多商品
       virtual public ICollection<Products> Products { get; set; }

    }
}
