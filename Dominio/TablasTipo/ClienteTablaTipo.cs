using Dominio.Entidades;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dominio.TablasTipo
{
    public class ClienteTablaTipo : List<Cliente>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("IdDocumentoTipo", SqlDbType.TinyInt),
                new SqlMetaData("IdComercio", SqlDbType.SmallInt),
                new SqlMetaData("Nombre", SqlDbType.NVarChar,100),
                new SqlMetaData("ApellidoPaterno", SqlDbType.NVarChar,100),
                new SqlMetaData("ApellidoMaterno", SqlDbType.NVarChar,100),
                new SqlMetaData("NumeroDocumento", SqlDbType.NVarChar,20),
                new SqlMetaData("Celular", SqlDbType.NVarChar,20),
                new SqlMetaData("Telefono", SqlDbType.NVarChar,20),
                new SqlMetaData("Email", SqlDbType.NVarChar,50),
                new SqlMetaData("Contrasenha", SqlDbType.NVarChar,50),
                new SqlMetaData("Estado", SqlDbType.Bit),
                new SqlMetaData("CreadoPor", SqlDbType.Int),
                new SqlMetaData("ActualizadoPor", SqlDbType.Int)
                );
            foreach (Cliente data in this)
            {
                ret.SetByte(0, data.IdDocumentoTipo.HasValue ? data.IdDocumentoTipo.Value : Convert.ToByte(0));
                ret.SetInt16(1, data.IdComercio);
                ret.SetString(2, data.Nombre);
                ret.SetString(3, data.ApellidoPaterno);
                ret.SetString(4, data.ApellidoMaterno);
                ret.SetString(5, data.NumeroDocumento);
                ret.SetString(6, data.Celular);
                ret.SetString(7, data.Telefono);
                ret.SetString(8, data.Email);
                ret.SetString(9, data.Contrasenha);
                ret.SetBoolean(10, data.Estado);
                ret.SetInt32(11, data.CreadoPor);
                ret.SetInt32(12, data.ActualizadoPor.HasValue ? data.ActualizadoPor.Value : 0);
                yield return ret;
            }
        }
    }

}
