using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Order
{
    public class OrderDAO
    {
        #region Singleton
        private static OrderDAO instance = null;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderDAO();
                return instance;
            }
        }
        #endregion

        //public int Insertar_Pedido(ref BaseEntity objBase, OrderHeader p, List<tBaseProductMarket> detail)
        //{
        //    SqlCommand cmd = null;
        //    int i = 0;
        //    try
        //    {
        //        cmd = new SqlCommand("SP_INSERTAR_PEDIDO", clsConnection.GetConnection());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter parmIdPedidoOut = cmd.Parameters.Add("@PedidoId", SqlDbType.Int);
        //        parmIdPedidoOut.Direction = ParameterDirection.Output;
        //        cmd.Parameters.AddWithValue("@CliId", p.CliId);
        //        cmd.Parameters.AddWithValue("@Total", p.Total);
        //        cmd.Parameters.Add(new SqlParameter { ParameterName = "@TY_DetallePedido", Value = detail, SqlDbType = SqlDbType.Structured, TypeName = "TY_DetallePedido" });
        //        i = cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        i = 0;
        //        objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
        //    }
        //    finally
        //    {
        //        clsConnection.DisposeCommand(cmd);
        //    }
        //    return i;
        //}
    }
}
