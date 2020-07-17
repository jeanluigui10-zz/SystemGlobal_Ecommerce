using System;
using System.Data;
using xAPI.Dao.Order;
using xAPI.Entity;
using xAPI.Entity.Order;
using xAPI.Library.Base;

namespace xAPI.BL.Order
{
    public class OrderBL
    {
        #region Singleton
        private static OrderBL instance = null;
        public static OrderBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderBL();
                return instance;
            }
        }
        #endregion

        public Boolean Insertar_Pedido(ref BaseEntity objEntity, ref OrderHeader objOrder, tBaseDetailOrderList objDetail) 
        {
            Boolean success;
            try
            {
                objEntity = new BaseEntity();
                success = OrderDao.Instance.Insertar_Pedido(ref objEntity, ref objOrder, objDetail);
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }
        public Boolean Update_Pedido(ref BaseEntity objEntity, ref OrderHeader objOrder)
        {
            Boolean success;
            try
            {
                objEntity = new BaseEntity();
                success = OrderDao.Instance.Update_Pedido(ref objEntity, ref objOrder);
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }
        
        public OrderHeader Order_GetBy_OrderId(ref BaseEntity objEntity, Int32 orderId)
        {
            OrderHeader objOrder = null;
            try
            {
                objEntity = new BaseEntity();
                objOrder = OrderDao.Instance.Order_GetBy_OrderId(ref objEntity, orderId);
            }
            catch (Exception ex)
            {
                objOrder = null;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return objOrder;
        }
        public DataTable Order_GetHistory_ByCustomer(ref BaseEntity objEntity, Int32 customerId)
        {
            objEntity = new BaseEntity();
            DataTable dt = null;
            dt = OrderDao.Instance.Order_GetHistory_ByCustomer(ref objEntity, customerId);

            return dt;
        }
    }
}
