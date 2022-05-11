using System;

namespace demo.Models
{
    public class Products
    {
        public int ProID { get; set; }
        public string PorName { get; set; }
        public decimal ProPrice { get; set; }
        public int PTID { get; set; }
        //外键导航属性=每个商品都有一个类型
        virtual public ProductType ProductType { get; set; }
    }
}
