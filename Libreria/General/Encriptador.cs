using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Libreria.General
{
    public static class Encriptador
    {


        public static String Encriptar(String ValorEncriptar)
        {
            try
            {
                String cadenaPassword = "@1B2c3D4e5F6g7H8x1cr3t22";
                String valorSalt = "@1B2c3D4e5F6g7H8";
                String algoritmoHash = "SHA1";

                Int32 iteracionPassword = 2;
                String vectorInicial = "@1B2c3D4e5F6g7H8";
                Int32 longitudClave = 256;

                Byte[] IniciarVectoresBytes = Encoding.ASCII.GetBytes(vectorInicial);
                Byte[] valorSaltBytes = Encoding.ASCII.GetBytes(valorSalt);

                Byte[] ValorEncriptarBytes = Encoding.UTF8.GetBytes(ValorEncriptar);


                PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(cadenaPassword, valorSaltBytes, algoritmoHash, iteracionPassword);

                Byte[] llaveBytes = passwordDeriveBytes.GetBytes(longitudClave / 8);
                RijndaelManaged rijndaelManaged = new RijndaelManaged();

                rijndaelManaged.Mode = CipherMode.CBC;

                ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(llaveBytes, IniciarVectoresBytes);

                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);

                cryptoStream.Write(ValorEncriptarBytes, 0, ValorEncriptarBytes.Length);
                cryptoStream.FlushFinalBlock();
                Byte[] cifrarTextoBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                String textoCifrado = Convert.ToBase64String(cifrarTextoBytes);
                return textoCifrado;
            }
            catch (Exception exception)
            {
                return String.Empty;
            }
        }

        public static String Desencriptar(String ValorEncriptado)
        {
            try
            {
                String cadenaPassword = "@1B2c3D4e5F6g7H8x1cr3t22";
                String valorSalt = "@1B2c3D4e5F6g7H8";
                String algoritmoHash = "SHA1";

                Int32 iteracionPassword = 2;
                String vectorInicial = "@1B2c3D4e5F6g7H8";
                Int32 longitudClave = 256;

                Byte[] IniciarVectoresBytes = Encoding.ASCII.GetBytes(vectorInicial);
                Byte[] valorSaltBytes = Encoding.ASCII.GetBytes(valorSalt);

                Byte[] ValorEncriptarBytes = Convert.FromBase64String(ValorEncriptado);

                PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(cadenaPassword, valorSaltBytes, algoritmoHash, iteracionPassword);

                Byte[] llaveBytes = passwordDeriveBytes.GetBytes(longitudClave / 8);

                RijndaelManaged rijndaelManaged = new RijndaelManaged();

                rijndaelManaged.Mode = CipherMode.CBC;
                ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(llaveBytes, IniciarVectoresBytes);
                MemoryStream memoryStream = new MemoryStream(ValorEncriptarBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
                Byte[] textoBytes = new Byte[ValorEncriptarBytes.Length];


                Int32 totalBytesCifrados = cryptoStream.Read(textoBytes, 0, textoBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                String textoFinal = Encoding.UTF8.GetString(textoBytes, 0, totalBytesCifrados);

                return textoFinal;
            }
            catch (Exception exception)
            {
                return "";
            }
        }


    }
}
