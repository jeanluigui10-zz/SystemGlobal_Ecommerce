using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Customers;

namespace xAPI.Entity.Order
{
    public class OrderHeader
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public Decimal Ordertotal { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        Customer objCustomer;
        public Customer Customer
        {
            get
            {
                objCustomer = objCustomer ?? new Customer();
                return objCustomer;
            }
            set
            {
                objCustomer = value;
            }
        }

        List<OrderDetail> objListOrderDetail;
        public List<OrderDetail> ListOrderDetail
        {
            get
            {
                objListOrderDetail = objListOrderDetail ?? new List<OrderDetail>();
                return objListOrderDetail;
            }
            set
            {
                objListOrderDetail = value;
            }
        }
        public int GetQuantityProducts()
        {
            int count = 0;
            for (int i = 0; i < this.ListOrderDetail.Count; i++)
            {
                count = count + ListOrderDetail[i].Quantity;
            }
            return count;
        }
        public void CalculateTotals()
        {
            Decimal TotalOrder = 0;

            foreach (OrderDetail item in this.ListOrderDetail)
            {
                TotalOrder += item.Totalprice;              
            }

            this.Ordertotal = TotalOrder;
        }
    }
}
