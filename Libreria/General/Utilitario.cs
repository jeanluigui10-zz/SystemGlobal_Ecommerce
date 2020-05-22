using System;
using System.Text.RegularExpressions;

namespace Libreria.General
{
    public class Utilitario
    {
        public static Boolean esNumerico(String numero) {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(numero))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static Boolean esEmailValido(String email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,6})+$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
