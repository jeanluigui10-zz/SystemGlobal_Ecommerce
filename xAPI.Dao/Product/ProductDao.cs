using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Product
{
    public class ProductDao
    {
        #region Singleton
        private static ProductDao instance = null;
        public static ProductDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDao();
                return instance;
            }
        }
        #endregion
        public DataTable Products_GetList_ById(ref BaseEntity objEntity, Int32 ProductId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_GetList_ById_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@productId", ProductId);
                cmd.CommandTimeout = 0;
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

        public DataTable Products_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Resources_GetResource_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }

        public DataTable Products_ByCategory(ref BaseEntity objEntity, Int32 CategoryId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_ByCategory_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@categoryId", CategoryId);
                cmd.CommandTimeout = 0;
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

        public DataTable Products_Search_ByName(ref BaseEntity objEntity, String name)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_Search_ByName_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", name);
                cmd.CommandTimeout = 0;
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
        
        public DataTable Product_GetList(ref BaseEntity Base)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_GetList_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  while loading data"));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return dt;
        }

        public Products Products_GetList_ById_Ecommerce(ref BaseEntity Base, Int32 ID)
        {
            Products objProducts = new Products();
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Products_GetList_ById_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@productId", ID);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objProducts = GetEntity_v3(dr);
                }
            }
            catch (Exception ex)
            {
                objProducts = null;
                Base.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objProducts;
        }
        private Products GetEntity_v3(SqlDataReader ObjDr)
        {
            Products obj = new Products
            {
                ID = ObjDr.GetColumnValue<Int32>("ID"),
                FileName = ObjDr.GetColumnValue<String>("FileName"),
                Description = ObjDr.GetColumnValue<String>("Description"),
                FileExtension = ObjDr.GetColumnValue<String>("FileExtension"),
                FilePublicName = ObjDr.GetColumnValue<String>("FilePublicName"),
                DocType = ObjDr.GetColumnValue<String>("DocType"),
                NameResource = ObjDr.GetColumnValue<String>("NameResource"),
                Status = ObjDr.GetColumnValue<Int16>("Status"),
                IsUpload = ObjDr.GetColumnValue<Int16>("IsUpload"),
                UnitPrice = ObjDr.GetColumnValue<Decimal>("UnitPrice"),
                Name = ObjDr.GetColumnValue<String>("Name"),
                Stock = ObjDr.GetColumnValue<Int32>("Stock"),
                UniMed = ObjDr.GetColumnValue<String>("UniMed"),
                PriceOffer = ObjDr.GetColumnValue<Decimal>("PriceOffer")
            };
            obj.brand.Name = ObjDr.GetColumnValue<String>("BrandName");
            obj.brand.ID = ObjDr.GetColumnValue<Int32>("BrandId");
            obj.category.Name = ObjDr.GetColumnValue<String>("Resource_Category_Name");
            obj.category.ID = ObjDr.GetColumnValue<Int32>("CategoryId");
            return obj;
        }

    }
}
