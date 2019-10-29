using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao;
using xAPI.Dao.Cotizations;
using xAPI.Entity;
using xAPI.Library.Base;

namespace xAPI.BL.Cotizations
{
    public class CotizationBl
    {
        #region Singleton
        private static CotizationBl instance = null;
        public static CotizationBl Instance
        {
            get
            {
                if (instance == null)
                    instance = new CotizationBl();
                return instance;
            }
        }
        #endregion

        #region ResourcesCategories

        public DataTable ResourceCategories_GetAll(ref BaseEntity Entity, Int16 status)
        {
            return ResourceCategoriesDAO.Instance.GetaAll(ref Entity, status);
        }

        public Boolean ResourceCategories_Delete(ref BaseEntity Entity, tBaseIdList idList)
        {
            Boolean success = false;
            if (idList.Count > 0)
                success = ResourceCategoriesDAO.Instance.Delete(ref Entity, idList);
            else
                Entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred while sending data"));

            return success;
        }

        public Boolean ResourceCategories_Save(ref BaseEntity Entity, ResourceCategories ResourceCategory)
        {
            Boolean success = false;
            Entity = new BaseEntity();
            if (!String.IsNullOrEmpty(ResourceCategory.Name) && !String.IsNullOrEmpty(ResourceCategory.Description))
                success = ResourceCategoriesDAO.Instance.Save(ref Entity, ResourceCategory);
            else
                Entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred while sending data"));

            return success;
        }

        public ResourceCategories ResourceCategories_GetById(ref BaseEntity Entity, Int32 Id)
        {
            Entity = new BaseEntity();
            ResourceCategories dt = null;

            if (Id > 0)
                dt = ResourceCategoriesDAO.Instance.GetById(ref Entity, Id);

            return dt;

        }
        public DataTable Get_ResourcesApplication_Actives(ref BaseEntity entity)
        {
            return CotizationDAO.Instance.Get_ResourcesApplication_Actives(ref entity);
        }

        #endregion
        public DataTable ResourceType_GetAll(ref BaseEntity entity)
        {
            return ResourcesDAO.Instance.ResourceType_GetAll(entity);
        }
        public Cotization AppResource_GetByID(ref BaseEntity entity, Int32 ID)
        {
            entity = new BaseEntity();
            Cotization dt = null;
            if (ID > 0)
            {
                dt = CotizationDAO.Instance.GetAllByID(ref entity, ID);
            }
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));
            return dt;

        }
        public Int32 Get_QuantityLegalDocuments(ref BaseEntity Base, Cotization resource/*, tBaseLanguagueIdList ListLanguage*/)
        {
            return CotizationDAO.Instance.Get_QuantityLegalDocuments(ref Base, resource/*, ListLanguage*/);
        }
        public Boolean AppResource_Save(ref BaseEntity Entity, /*tBaseLanguagueIdList listLanguages,*/ Cotization Resource, Boolean RegisterTBL = false, String Username = "")
        {
            Boolean success = false;
            Entity = new BaseEntity();

            success = CotizationDAO.Instance.Save(ref Entity, /*listLanguages,*/ Resource, RegisterTBL, Username);

            return success;
        }
        public DataTable AppResource_GetByAplicationID(ref BaseEntity entity)
        {
            entity = new BaseEntity();
            DataTable dt = null;
            dt = CotizationDAO.Instance.GetAllByAplicationID(ref entity);

            return dt;
        }
        public Boolean AppResource_Delete(ref BaseEntity entity, tBaseIdList idList)
        {
            Boolean success = false;
            if (idList.Count > 0)
                success = CotizationDAO.Instance.Delete(ref entity, idList);
            else
                entity.Errors.Add(new BaseEntity.ListError(new Exception { }, "An error occurred sending data"));

            return success;
        }
    }
}
