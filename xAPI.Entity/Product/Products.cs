using System;
using xAPI.Entity.Category;
using xAPI.Library.Base;

namespace xAPI.Entity.Product
{
    [Serializable]
    public class Products : BaseEntity
    {
        public String SKU { get; set; }
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String FilePublicName { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 Stock { get; set; }
        public Decimal PriceOffer { get; set; }
        public String UniMed { get; set; }
        public String NameResource { get; set; }
        public String DocType { get; set; }
        public Int16 IsUpload { get; set; }
        
        Categorys objCategory;
        public Categorys category
        {
            get
            {
                objCategory = objCategory ?? new Categorys();
                return objCategory;
            }
            set
            {
                objCategory = value;
            }
        }
        Brand objBrand;
        public Brand brand
        {
            get
            {
                objBrand = objBrand ?? new Brand();
                return objBrand;
            }
            set
            {
                objBrand = value;
            }
        }
    }
}
