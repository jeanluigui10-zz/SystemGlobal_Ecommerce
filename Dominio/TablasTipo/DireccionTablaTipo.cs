using Dominio.Entidades;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.TablasTipo
{
    [Serializable]
    public class DireccionTablaTipo : List<Direccion>,IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("IdCliente", SqlDbType.Int),
                new SqlMetaData("IdDireccionTipo", SqlDbType.TinyInt),
                new SqlMetaData("IdDistrito", SqlDbType.Int),
                new SqlMetaData("IdProvincia", SqlDbType.Int),
                new SqlMetaData("IdRegion", SqlDbType.Int),
                new SqlMetaData("DireccionPrimaria", SqlDbType.NVarChar,500),
                new SqlMetaData("DireccionSecundaria", SqlDbType.NVarChar,500),
                new SqlMetaData("Zip", SqlDbType.NVarChar,100),
                new SqlMetaData("Estado", SqlDbType.Bit),
                new SqlMetaData("CreadoPor", SqlDbType.Int),
                new SqlMetaData("ActualizadoPor", SqlDbType.Int)
                );
            foreach (Direccion data in this)
            {
                ret.SetInt32(0, data.IdCliente);
                ret.SetByte(1, data.IdDireccionTipo);
                ret.SetInt32(2, data.IdDistrito);
                ret.SetInt32(3, data.IdProvincia);
                ret.SetInt32(4, data.IdRegion);
                ret.SetString(5, data.DireccionPrincipal);
                ret.SetString(6, data.DireccionSecundaria);
                ret.SetString(7, data.Zip);
                ret.SetBoolean(8, data.Estado);
                ret.SetInt32(9, data.CreadoPor);
                ret.SetInt32(10, data.ActualizadoPor.HasValue? data.ActualizadoPor.Value: 0);
                yield return ret;
            }
        }
    }














}
