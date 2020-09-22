using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity;
using xAPI.Entity.Customers;
using xAPI.Entity.Order;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Order
{
    public class OrderDao
    {
        #region Singleton
        private static OrderDao instance = null;
        public static OrderDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderDao();
                return instance;
            }
        }
        #endregion
        public Boolean Insertar_Pedido(ref BaseEntity objBase, ref OrderHeader objOrder, tBaseDetailOrderList objDetail)
        {
            SqlCommand cmd = null;
            Boolean success;
            try
            {
                cmd = new SqlCommand("Order_Save_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parmIdPedidoOut = cmd.Parameters.Add("@OrderId", SqlDbType.Int);
                parmIdPedidoOut.Direction = ParameterDirection.Output;
                SqlParameter parmLegacyNumberOut = cmd.Parameters.Add("@orderLegacyNumber", SqlDbType.Int);
                parmLegacyNumberOut.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@CustomerId", objOrder.Customer.ID);
                cmd.Parameters.AddWithValue("@AddressId", objOrder.Address.ID);
                cmd.Parameters.AddWithValue("@Total", objOrder.Ordertotal);
                cmd.Parameters.AddWithValue("@DeliveryTotal", objOrder.DeliveryTotal);
                cmd.Parameters.AddWithValue("@SubTotal", objOrder.SubTotal);
                cmd.Parameters.AddWithValue("@PaymentType", objOrder.PaymentType);
                cmd.Parameters.AddWithValue("@PaymentTypeName", objOrder.PaymentTypeName);
                cmd.Parameters.AddWithValue("@PaymentStatus", objOrder.PaymentStatus);
                cmd.Parameters.AddWithValue("@Status", objOrder.Status);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@TY_OrderDetail", Value = objDetail, SqlDbType = SqlDbType.Structured, TypeName = "TY_OrdersDetail" });
                cmd.ExecuteReader();
                success = true;
                if (!cmd.Parameters["@OrderId"].Value.ToString().Equals(String.Empty))
                    objOrder.ID = Convert.ToInt32(cmd.Parameters["@OrderId"].Value);
                if (!cmd.Parameters["@orderLegacyNumber"].Value.ToString().Equals(String.Empty))
                    objOrder.LegacyNumber = Convert.ToInt32(cmd.Parameters["@orderLegacyNumber"].Value);
            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "A ocurrido un error al guardar la Orden."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
        public Boolean Update_Pedido(ref BaseEntity objBase, ref OrderHeader objOrder)
        {
            SqlCommand cmd = null;
            Boolean success;
            try
            {
                cmd = new SqlCommand("Update_Save_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderId", objOrder.ID);
                cmd.ExecuteReader();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "A ocurrido un error al Actualizar la Orden."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
        public OrderHeader Order_GetBy_OrderId(ref BaseEntity objBase, Int32 orderId)
        {
            OrderHeader obj = new OrderHeader();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Order_GetAll_ByOrderId", clsConnection.GetConnection());
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                obj.Customer = new Customer();
                obj.ListOrderDetail = new List<OrderDetail>();
                Products product = new Products();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.Customer = new Customer()
                        {
                            ID = dr.GetColumnValue<Int32>("CustomerId"),
                            FirstName = dr.GetColumnValue<String>("FirstName"),
                            LastNamePaternal = dr.GetColumnValue<String>("LastNamePaternal"),
                            LastNameMaternal = dr.GetColumnValue<String>("LastNameMaternal"),

                        };
                    }
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            product = new Products()
                            {
                                ID = dr.GetColumnValue<Int32>("ID"),
                                Name = dr.GetColumnValue<String>("Name"),
                                UnitPrice = dr.GetColumnValue<Decimal>("UnitPrice"),
                                NameResource = dr.GetColumnValue<String>("NameResource")
                            };
                            product.category.Name = dr.GetColumnValue<String>("Category");
                        }
                    }
                   
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            product.UnitPrice = dr.GetColumnValue<Decimal>("Price");
                            obj.ListOrderDetail.Add(new OrderDetail
                            {
                                ProductId = dr.GetColumnValue<Int32>("ProductId"),
                                Quantity = dr.GetColumnValue<Int32>("Quantity"),
                                Totalprice = dr.GetColumnValue<Int32>("Quantity") * dr.GetColumnValue<Decimal>("Price"),
                                Product = product
                            });
                        }
                    }
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            obj.Ordertotal = dr.GetColumnValue<Decimal>("Total");
                            obj.SubTotal = dr.GetColumnValue<Decimal>("SubTotal");
                            obj.DeliveryTotal = dr.GetColumnValue<Decimal>("DeliveryTotal");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                obj = null;
                objBase.Errors.Add(new BaseEntity.ListError(exception, "No se encontro orden."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return obj;
        }

        public DataTable Order_GetHistory_ByCustomer(ref BaseEntity objEntity, Int32 customerId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Order_GetHistory_ByCustomer_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@customerId", customerId);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));

            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }
    }
}
