﻿using System;
using System.Reflection;

namespace Libreria.General
{
    public static class GeneralEnum
    {
        public static String ObtenerString(this Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].StringValue;
            }
            return output;
        }

    }

    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }

    public enum EnumTipoMensaje
    {
        [StringValue("Éxito")]
        Exito = 1,
        [StringValue("Error")]
        Error = 2,
        [StringValue("Información")]
        Informacion = 3,
        [StringValue("Advertencia")]
        Advertencia = 4,
    }


    public enum EnumGlobalEstado
    {
        [StringValue("Activo")]
        Activo = 1,
        [StringValue("Inactivo/Eliminado")]
        Inactivo = 0,
    }
}
