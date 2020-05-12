using InteligenciaNegocio.AdminProducto;
using Libreria.Base;
using Libreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using SystemGlobal_Ecommerce.src.app_code;

namespace SystemGlobal_Ecommerce
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Categoria();

        }
        private void Cargar_Categoria()
        {
            MetodoRespuesta objRespuesta = new MetodoRespuesta();
            List<srCategoria> lst = new List<srCategoria>();

            DataTable dt = CategoriaBL.Instance.Categoria_Lista(ref objRespuesta);
            if (objRespuesta.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new srCategoria()
                        {
                            IdCategoria = HttpUtility.UrlEncode(Encryption.Encrypt(item["IdCategoria"].ToString())),
                            CategoriaNombre = item["CategoriaNombre"].ToString(),
                        });
                    }
                }

            }
            if (objRespuesta.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfDataCategoria.Value = sJSON.ToString();
                }
            }
        }

    }
}