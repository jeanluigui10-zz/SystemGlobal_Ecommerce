using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Base
{
    public static class Validar
    {

        public static Boolean EsValido(Int64 valor)
        {
            try
            {
                return valor <= 0 ? false : true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public static Boolean EsValido(Int32 valor)
        {
            try
            {
                return valor <= 0 ? false : true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public static Boolean EsValido(Int16 valor)
        {
            try
            {
                return valor <= 0 ? false : true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public static Boolean EsValido(String valor)
        {
            try
            {
                return !String.IsNullOrEmpty(valor);
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public static Boolean EsValido(Object objecto)
        {
            try
            {
                return objecto == null ? false : true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
