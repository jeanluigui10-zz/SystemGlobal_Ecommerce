using System;
using System.Collections.Generic;
using xAPI.Entity.Addresses;
using xAPI.Entity.Customers;
using xAPI.Library.Base;

namespace xAPI.Entity.Order
{
    public class OrderHeader : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Decimal Ordertotal { get; set; }
        public Decimal SubTotal { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public Int32 PaymentType { get; set; }
        public Int32 PaymentStatus { get; set; }
        public String PaymentTypeName { get; set; }

        public Decimal DeliveryTotal { get; set; }

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
            Decimal TotalOrder = 0.00M;
            Decimal Subtotal = 0.00M;
            Decimal DeliveryTotal = 0.00M;
            foreach (OrderDetail item in this.ListOrderDetail)
            {
                Subtotal += item.Totalprice;               
            }

            DeliveryTotal = Subtotal * 0.18M;
            TotalOrder = Subtotal + Convert.ToDecimal(DeliveryTotal.ToString("N2"));

            this.SubTotal = Subtotal;
            this.Ordertotal = TotalOrder;
            this.DeliveryTotal = Convert.ToDecimal(DeliveryTotal.ToString("N2"));

        }
        public void CalculateTotalPricexProduct(OrderDetail OrderDetail)
        {
            Decimal totalPrice = 0;
            totalPrice += OrderDetail.Quantity * OrderDetail.Product.UnitPrice;
            OrderDetail.Totalprice = Convert.ToDecimal(totalPrice.ToString("N2"));
            //return TotalPrice;
        }
    }
}
