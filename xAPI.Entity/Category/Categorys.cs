using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Category
{
    public class Categorys
    {
        #region Singleton
        private static Categorys instance = null;
        public static Categorys Instance
        {
            get
            {
                if (instance == null)
                    instance = new Categorys();
                return instance;
            }
        }
        #endregion
    }
}
