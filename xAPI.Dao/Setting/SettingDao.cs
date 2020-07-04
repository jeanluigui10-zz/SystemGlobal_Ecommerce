using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Store;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Setting
{
    public class SettingDao
    {
        #region Singleton
        private static SettingDao instance = null;
        public static SettingDao Instance 
        {
            get {
                if (instance == null)
                    instance = new SettingDao();
                return instance;
            }
        }
        #endregion

        #region Methods
        public Store Store_GetInformation(ref BaseEntity objEntity) {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Store objStore = new Store();
            try
            {
                cmd = new SqlCommand("Store_GetInformation_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    objStore = Store_GetInfo(dr);
                }
            }
            catch (Exception ex)
            {
                objStore = null;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  getting a AppResource by it's Id."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return objStore;
        }

        private Store Store_GetInfo(SqlDataReader ObjDr)
        {
            Store obj = new Store
            {
                ID = ObjDr.GetColumnValue<Int32>("ID"),
                Name = ObjDr.GetColumnValue<String>("Name"),
                Address = ObjDr.GetColumnValue<String>("Address"),
                Email = ObjDr.GetColumnValue<String>("Email"),
                Phone1 = ObjDr.GetColumnValue<String>("Phone1"),
                Phone2 = ObjDr.GetColumnValue<String>("Phone2"),
                AttentionHours = ObjDr.GetColumnValue<String>("AttentionHours"),
                NoteDelivery = ObjDr.GetColumnValue<String>("NoteDelivery"),
                NoteSupport = ObjDr.GetColumnValue<String>("NoteSupport"),
                NotePromotions = ObjDr.GetColumnValue<String>("NotePromotions"),
                NotePayment = ObjDr.GetColumnValue<String>("NotePayment"),
                Year = ObjDr.GetColumnValue<Int32>("Year"),
                Banner = ObjDr.GetColumnValue<String>("Banner"),
                Logo = ObjDr.GetColumnValue<String>("Logo"),
                Facebook = ObjDr.GetColumnValue<String>("Facebook"),
                Instagram = ObjDr.GetColumnValue<String>("Instagram"),
                Youtube = ObjDr.GetColumnValue<String>("Youtube"),
                Twitter = ObjDr.GetColumnValue<String>("Twitter"),
                Status = ObjDr.GetColumnValue<Byte>("Status")
            };
            return obj;
        }
        #endregion
    }
}
